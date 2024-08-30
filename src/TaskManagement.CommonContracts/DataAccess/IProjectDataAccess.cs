using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.CommonContracts.Models;

namespace TaskManagement.CommonContracts.DataAccess
{
    public interface IProjectDataAccess
    {
        public Task<IReadOnlyList<ProjectModel>> GetAllProjectsAsync();
    }
}
