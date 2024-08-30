using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.CommonContracts.Models;
using TaskManagement.CommonContracts.ViewModels;

namespace TaskManagement.CommonContracts.DataAccess
{
    public interface ITaskDataAccess
    {
        public Task<IReadOnlyList<TaskModel>> GetAllTasksAsync();

        public Task<bool> SaveTaskDetailsAsync(AssignTasksViewModel model);
    }
}
