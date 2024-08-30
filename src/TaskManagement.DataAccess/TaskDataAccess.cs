using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManagement.CommonContracts.DataAccess;
using TaskManagement.CommonContracts.Models;
using TaskManagement.CommonContracts.ViewModels;

namespace TaskManagement.DataAccess
{
    public class TaskDataAccess : ITaskDataAccess
    {
        private readonly TaskDbContext _dbContext;

        public TaskDataAccess(TaskDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<TaskModel>> GetAllTasksAsync()
        {
            return await _dbContext.Tasks.Include(x => x.TasksEmployees).ThenInclude(x => x.Employee).ToListAsync();
        }

        [ExcludeFromCodeCoverage]
        public async Task<bool> SaveTaskDetailsAsync(AssignTasksViewModel model)
        {
            try
            {
                await _dbContext.Database.ExecuteSqlInterpolatedAsync($"exec [usp_AssignTask] {string.Join(',', model.EmployeeIds)}, {model.TaskDescription}, {model.TaskStartDate}, {model.TaskDueDate}, {model.ProjectId}");
                
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
