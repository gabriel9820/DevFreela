namespace DevFreela.Core.Services
{
    public interface IAuthService
    {
        string GenerateJwt(string email, string role);
        string ComputeSha256Hash(string password);
    }
}
