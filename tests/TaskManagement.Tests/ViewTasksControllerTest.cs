using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TaskManagement.CommonContracts.Services;
using TaskManagement.CommonContracts.ViewModels;
using TaskManagement.Web.Controllers;

namespace TaskManagement.Tests
{
    [TestClass]
    public class ViewTasksControllerTest
    {
        private readonly ViewTasksController _viewTasksController;
        private readonly Mock<IViewTasksService> _mockViewTasksService = new Mock<IViewTasksService>();

        public ViewTasksControllerTest()
        {
            _viewTasksController = new ViewTasksController(_mockViewTasksService.Object);
        }

        [TestMethod]
        public async Task TestViewTasks()
        {
            //Arrange
            DisplayTasksViewModel viewModel = new DisplayTasksViewModel();
            _mockViewTasksService.Setup(x => x.GetDetailsForViewTasksAsync()).ReturnsAsync(viewModel);

            //Act
            ViewResult result = await _viewTasksController.Index() as ViewResult;

            //Assert
            Assert.AreEqual(viewModel, result.Model);
        }

        [TestMethod]
        public async Task TestViewTasksByProject()
        {
            //Arrange
            int projectId = 2;
            DisplayTasksViewModel viewModel = new DisplayTasksViewModel();
            _mockViewTasksService.Setup(x => x.GetDetailsForViewTasksByProjectAsync(projectId)).ReturnsAsync(viewModel);

            //Act
            ViewResult result = await _viewTasksController.ViewTasksByProject(projectId) as ViewResult;

            //Assert
            Assert.AreEqual(viewModel, result.Model);
        }
    }
}
