using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.CommonContracts.Models;
using TaskManagement.CommonContracts.Services;
using TaskManagement.CommonContracts.ViewModels;

namespace TaskManagement.Web.Controllers
{
    public class AssignTaskController : Controller
    {
        private readonly IAssignTaskService _service;

        public AssignTaskController(IAssignTaskService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            AssignTasksViewModel model = await _service.GetDetailsForAssignTasksAsync();

            return View(model);
        }

        [HttpGet("[controller]/[action]/{projectId}")]
        public async Task<IActionResult> GetEmployeesByProject(int projectId)
        {
            IReadOnlyList<EmployeeModel> employees = await _service.GetEmployeesByProjectAsync(projectId);

            return Json(employees);
        }

        [HttpPost]
        public async Task<IActionResult> SaveTask(AssignTasksViewModel postData)
        {
            bool isSuccess = false;

            if (!ModelState.IsValid)
            {
                return Json(isSuccess);
            }

            isSuccess = await _service.SaveTaskDetailsAsync(postData);

            return Json(isSuccess);
        }
    }
}
