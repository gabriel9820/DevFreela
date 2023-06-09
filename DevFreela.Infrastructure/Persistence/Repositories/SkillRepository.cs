using Dapper;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly string _connectionString;

        public SkillRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DevFreela");
        }

        public async Task<List<Skill>> GetAllAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var script = "SELECT Id, Description FROM Skills";

                await connection.OpenAsync();
                var skills = await connection.QueryAsync<Skill>(script);

                return skills.ToList();
            }
        }
    }
}
