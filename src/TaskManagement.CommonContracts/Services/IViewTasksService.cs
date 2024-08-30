using System.Threading.Tasks;
using TaskManagement.CommonContracts.ViewModels;

namespace TaskManagement.CommonContracts.Services
{
    public interface IViewTasksService
    {
        public Task<DisplayTasksViewModel> GetDetailsForViewTasksAsync();

        public Task<DisplayTasksViewModel> GetDetailsForViewTasksByProjectAsync(int projectId);
    }
}
