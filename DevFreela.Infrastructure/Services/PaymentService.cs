using DevFreela.Infrastructure.MessageBus;
using System.Text;
using System.Text.Json;

namespace DevFreela.Infrastructure.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IMessageBusService _messageBusService;
        private const string PAYMENTS_QUEUE = "Payments";

        public PaymentService(IMessageBusService messageBusService)
        {
            _messageBusService = messageBusService;
        }

        public void ProcessPayment(PaymentInfoDTO paymentInfoDto)
        {
            var payloadString = JsonSerializer.Serialize(paymentInfoDto);
            var payloadBytes = Encoding.UTF8.GetBytes(payloadString);

            _messageBusService.Publish(PAYMENTS_QUEUE, payloadBytes);
        }
    }

    public class PaymentInfoDTO
    {
        public int ProjectId { get; private set; }
        public string CreditCardNumber { get; private set; }
        public string CVV { get; private set; }
        public string ExpiresAt { get; private set; }
        public string FullName { get; private set; }
        public decimal Amount { get; private set; }

        public PaymentInfoDTO(int projectId, string creditCardNumber, string cvv, string expiresAt, string fullName, decimal amount)
        {
            ProjectId = projectId;
            CreditCardNumber = creditCardNumber;
            CVV = cvv;
            ExpiresAt = expiresAt;
            FullName = fullName;
            Amount = amount;
        }
    }
}
