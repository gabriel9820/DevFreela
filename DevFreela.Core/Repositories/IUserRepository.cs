using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(int id);
        Task<int> CreateAsync(User user);
        Task<User?> Authenticate(string email, string passwordHash);
    }
}
