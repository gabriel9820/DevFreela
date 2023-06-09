using MediatR;

namespace DevFreela.Application.Commands.Login
{
    public class LoginCommand : IRequest<LoginOutputModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
