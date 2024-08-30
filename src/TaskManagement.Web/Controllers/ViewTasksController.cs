using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.CommonContracts.Services;
using TaskManagement.CommonContracts.ViewModels;

namespace TaskManagement.Web.Controllers
{
    public class ViewTasksController : Controller
    {
        private readonly IViewTasksService _service;

        public ViewTasksController(IViewTasksService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            DisplayTasksViewModel model = await _service.GetDetailsForViewTasksAsync();

            return View(model);
        }

        [HttpGet("[controller]/[action]/{projectId}")]
        public async Task<IActionResult> ViewTasksByProject(int projectId)
        {
            DisplayTasksViewModel model = await _service.GetDetailsForViewTasksByProjectAsync(projectId);

            return View(model);
        }
    }
}
