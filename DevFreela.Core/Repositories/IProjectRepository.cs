using DevFreela.Core.Entities;
using DevFreela.Core.Models;
using System.Linq.Expressions;

namespace DevFreela.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<PaginationResult<Project>> GetAllAsync(Expression<Func<Project, bool>>? where, int currentPage, int pageSize);
        Task<Project?> GetByIdAsync(int id);
        Task<int> CreateAsync(Project project);
        Task CreateCommentAsync(ProjectComment projectComment);
        Task UpdateAsync(Project project);
        Task StartAsync(Project project);
    }
}
