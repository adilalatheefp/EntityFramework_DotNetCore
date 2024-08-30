using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.CommonContracts.DataAccess;
using TaskManagement.CommonContracts.Models;
using TaskManagement.CommonContracts.Services;
using TaskManagement.CommonContracts.ViewModels;

namespace TaskManagement.Services
{
    public class ViewTasksService : IViewTasksService
    {
        private readonly IProjectDataAccess _projectDataAccess;
        private readonly ITaskDataAccess _taskDataAccess;

        public ViewTasksService(IProjectDataAccess projectDataAccess, ITaskDataAccess taskDataAccess)
        {
            _projectDataAccess = projectDataAccess;
            _taskDataAccess = taskDataAccess;
        }

        public async Task<DisplayTasksViewModel> GetDetailsForViewTasksAsync()
        {
            DisplayTasksViewModel model = new DisplayTasksViewModel
            {
                Projects = await _projectDataAccess.GetAllProjectsAsync(),
                Tasks = await _taskDataAccess.GetAllTasksAsync()
            };

            return model;
        }

        public async Task<DisplayTasksViewModel> GetDetailsForViewTasksByProjectAsync(int projectId)
        {
            IReadOnlyList<TaskModel> tasks = await _taskDataAccess.GetAllTasksAsync();

            DisplayTasksViewModel model = new DisplayTasksViewModel
            {
                ProjectId = projectId,
                Projects = await _projectDataAccess.GetAllProjectsAsync(),
                Tasks = tasks.Where(x => x.ProjectId == projectId).ToList()
            };

            return model;
        }
    }
}
