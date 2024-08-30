using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.CommonContracts.DataAccess;
using TaskManagement.CommonContracts.Models;
using TaskManagement.CommonContracts.Services;
using TaskManagement.CommonContracts.ViewModels;

namespace TaskManagement.Services
{
    public class AssignTaskService : IAssignTaskService
    {
        private readonly IEmployeeDataAccess _employeeDataAccess;
        private readonly IProjectDataAccess _projectDataAccess;
        private readonly ITaskDataAccess _taskDataAccess;

        public AssignTaskService(IEmployeeDataAccess employeeDataAccess,
                                 IProjectDataAccess projectDataAccess,
                                 ITaskDataAccess taskDataAccess)
        {
            _employeeDataAccess = employeeDataAccess;
            _projectDataAccess = projectDataAccess;
            _taskDataAccess = taskDataAccess;
        }

        public async Task<AssignTasksViewModel> GetDetailsForAssignTasksAsync()
        {
            AssignTasksViewModel model = new AssignTasksViewModel
            {
                Projects = await _projectDataAccess.GetAllProjectsAsync()
            };

            return model;
        }

        public async Task<IReadOnlyList<EmployeeModel>> GetEmployeesByProjectAsync(int projectId)
        {
            IReadOnlyList<EmployeeModel> employees = await _employeeDataAccess.GetAllEmployeesAsync();

            return employees.Where(x => x.ProjectId == projectId).ToList();
        }

        public async Task<bool> SaveTaskDetailsAsync(AssignTasksViewModel model)
        {
            return await _taskDataAccess.SaveTaskDetailsAsync(model);
        }
    }
}
