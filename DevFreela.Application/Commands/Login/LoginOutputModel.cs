namespace DevFreela.Application.Commands.Login
{
    public class LoginOutputModel
    {
        public string Email { get; private set; }
        public string Token { get; private set; }

        public LoginOutputModel(string email, string token)
        {
            Email = email;
            Token = token;
        }
    }
}
