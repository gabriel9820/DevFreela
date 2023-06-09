using DevFreela.Application.IntegrationEvents;
using DevFreela.Core.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace DevFreela.Application.Consumers
{
    public class ApprovedPaymentConsumer : BackgroundService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IServiceProvider _serviceProvider;

        private const string APPROVED_PAYMENTS_QUEUE = "ApprovedPayments";

        public ApprovedPaymentConsumer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            var factory = new ConnectionFactory
            {
                HostName = "localhost",
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(
                queue: APPROVED_PAYMENTS_QUEUE,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += async (sender, eventArgs) =>
            {
                var payloadBytes = eventArgs.Body.ToArray();
                var payloadString = Encoding.UTF8.GetString(payloadBytes);
                var paymentApproved = JsonSerializer.Deserialize<ApprovedPaymentIntegrationEvent>(payloadString);

                await FinishProject(paymentApproved.ProjectId);

                _channel.BasicAck(eventArgs.DeliveryTag, false);
            };

            _channel.BasicConsume(APPROVED_PAYMENTS_QUEUE, false, consumer);

            return Task.CompletedTask;
        }

        private async Task FinishProject(int id)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var projectRepository = scope.ServiceProvider.GetRequiredService<IProjectRepository>();
                var project = await projectRepository.GetByIdAsync(id);

                project.Finish();

                await projectRepository.UpdateAsync(project);
            }
        }
    }
}
