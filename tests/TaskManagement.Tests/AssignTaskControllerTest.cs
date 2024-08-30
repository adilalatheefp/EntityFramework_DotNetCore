using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TaskManagement.CommonContracts.Models;
using TaskManagement.CommonContracts.Services;
using TaskManagement.CommonContracts.ViewModels;
using TaskManagement.Web.Controllers;

namespace TaskManagement.Tests
{
    [TestClass]
    public class AssignTaskControllerTest
    {
        private readonly AssignTaskController _assignTaskController;
        private readonly Mock<IAssignTaskService> _mockAssignTaskService = new Mock<IAssignTaskService>();

        public AssignTaskControllerTest()
        {
            _assignTaskController = new AssignTaskController(_mockAssignTaskService.Object);
        }

        [TestMethod]
        public async Task TestAssignTask()
        {
            //Arrange
            AssignTasksViewModel viewModel = new AssignTasksViewModel();
            _mockAssignTaskService.Setup(x => x.GetDetailsForAssignTasksAsync()).ReturnsAsync(viewModel);

            //Act
            ViewResult result = await _assignTaskController.Index() as ViewResult;

            //Assert
            Assert.AreEqual(viewModel, result.Model);
        }

        [TestMethod]
        public async Task TestGetEmployeesByProject()
        {
            //Arrange
            int projectId = 2;
            List<EmployeeModel> employeeModel = new List<EmployeeModel>();
            _mockAssignTaskService.Setup(x => x.GetEmployeesByProjectAsync(projectId)).ReturnsAsync(employeeModel);

            //Act
            JsonResult result = await _assignTaskController.GetEmployeesByProject(projectId) as JsonResult;

            //Assert
            Assert.AreEqual(employeeModel, result.Value);
        }

        [TestMethod]
        public async Task TestSaveTask()
        {
            //Arrange
            AssignTasksViewModel viewModel = new AssignTasksViewModel();
            _mockAssignTaskService.Setup(x => x.SaveTaskDetailsAsync(viewModel)).ReturnsAsync(true);

            //Act
            JsonResult result = await _assignTaskController.SaveTask(viewModel) as JsonResult;

            //Assert
            Assert.AreEqual(true, result.Value);
        }
    }
}
