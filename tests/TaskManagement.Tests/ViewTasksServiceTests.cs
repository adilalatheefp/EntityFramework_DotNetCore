using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TaskManagement.CommonContracts.DataAccess;
using TaskManagement.CommonContracts.Models;
using TaskManagement.CommonContracts.ViewModels;
using TaskManagement.Services;

namespace TaskManagement.Tests
{
    [TestClass]
    public class ViewTasksServiceTests
    {
        private readonly ViewTasksService _viewTasksService;
        private readonly Mock<IProjectDataAccess> _mockProjectDataAccess = new Mock<IProjectDataAccess>();
        private readonly Mock<ITaskDataAccess> _mockTaskDataAccess = new Mock<ITaskDataAccess>();

        public ViewTasksServiceTests()
        {
            _viewTasksService = new ViewTasksService(_mockProjectDataAccess.Object, _mockTaskDataAccess.Object);
        }

        [TestMethod]
        public async Task TestGetDetailsForViewTasksAsync()
        {
            //Arrange
            DisplayTasksViewModel viewModel = new DisplayTasksViewModel();
            List<ProjectModel> projectModel = new List<ProjectModel>();
            List<TaskModel> taskModel = new List<TaskModel>();
            _mockProjectDataAccess.Setup(x => x.GetAllProjectsAsync()).ReturnsAsync(projectModel);
            _mockTaskDataAccess.Setup(x => x.GetAllTasksAsync()).ReturnsAsync(taskModel);

            //Act
            DisplayTasksViewModel result = await _viewTasksService.GetDetailsForViewTasksAsync();

            //Assert
            Assert.AreEqual(viewModel.ProjectId, result.ProjectId);
        }

        [TestMethod]
        public async Task TestGetDetailsForViewTasksByProjectAsync()
        {
            //Arrange
            int projectId = 2;
            DisplayTasksViewModel viewModel = new DisplayTasksViewModel
            {
                ProjectId = 2
            };
            List<ProjectModel> projectModel = new List<ProjectModel>();
            List<TaskModel> taskModel = new List<TaskModel>();
            _mockProjectDataAccess.Setup(x => x.GetAllProjectsAsync()).ReturnsAsync(projectModel);
            _mockTaskDataAccess.Setup(x => x.GetAllTasksAsync()).ReturnsAsync(taskModel);

            //Act
            DisplayTasksViewModel result = await _viewTasksService.GetDetailsForViewTasksByProjectAsync(projectId);

            //Assert
            Assert.AreEqual(viewModel.ProjectId, result.ProjectId);
        }
    }
}
