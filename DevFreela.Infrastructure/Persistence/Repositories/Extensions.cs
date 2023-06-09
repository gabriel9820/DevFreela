using DevFreela.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public static class Extensions
    {
        public static async Task<PaginationResult<T>> ToPagedListAsync<T>(this IQueryable<T> query, int currentPage, int pageSize) where T : class
        {
            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            var data = await query.Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PaginationResult<T>(currentPage, totalPages, pageSize, totalCount, data);
        }
    }
}
