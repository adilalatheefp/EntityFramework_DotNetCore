using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManagement.CommonContracts.DataAccess;
using TaskManagement.CommonContracts.Models;

namespace TaskManagement.DataAccess
{
    public class ProjectDataAccess : IProjectDataAccess
    {
        private readonly TaskDbContext _dbContext;

        public ProjectDataAccess(TaskDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<ProjectModel>> GetAllProjectsAsync()
        {
            return await _dbContext.Projects.Include(x => x.Tasks).ToListAsync();
        }
    }
}
