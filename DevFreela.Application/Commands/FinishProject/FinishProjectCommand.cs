using MediatR;

namespace DevFreela.Application.Commands.FinishProject
{
    public class FinishProjectCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string CreditCardNumber { get; set; }
        public string CVV { get; set; }
        public string ExpiresAt { get; set; }
        public string FullName { get; set; }
    }
}
