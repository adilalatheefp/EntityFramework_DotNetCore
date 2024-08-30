using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.CommonContracts.Models;
using TaskManagement.CommonContracts.ViewModels;

namespace TaskManagement.CommonContracts.Services
{
    public interface IAssignTaskService
    {
        public Task<AssignTasksViewModel> GetDetailsForAssignTasksAsync();

        public Task<bool> SaveTaskDetailsAsync(AssignTasksViewModel model);

        public Task<IReadOnlyList<EmployeeModel>> GetEmployeesByProjectAsync(int projectId);
    }
}
