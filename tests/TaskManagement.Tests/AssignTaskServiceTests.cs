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
    public class AssignTaskServiceTests
    {
        private readonly AssignTaskService _assignTaskService;
        private readonly Mock<IEmployeeDataAccess> _mockEmployeeDataAccess = new Mock<IEmployeeDataAccess>();
        private readonly Mock<IProjectDataAccess> _mockProjectDataAccess = new Mock<IProjectDataAccess>();
        private readonly Mock<ITaskDataAccess> _mockTaskDataAccess = new Mock<ITaskDataAccess>();

        public AssignTaskServiceTests()
        {
            _assignTaskService = new AssignTaskService(_mockEmployeeDataAccess.Object, _mockProjectDataAccess.Object, _mockTaskDataAccess.Object);
        }

        [TestMethod]
        public async Task TestGetDetailsForAssignTasksAsync()
        {
            //Arrange
            AssignTasksViewModel viewModel = new AssignTasksViewModel();
            List<ProjectModel> projectModel = new List<ProjectModel>();
            _mockProjectDataAccess.Setup(x => x.GetAllProjectsAsync()).ReturnsAsync(projectModel);

            //Act
            AssignTasksViewModel result = await _assignTaskService.GetDetailsForAssignTasksAsync();

            //Assert
            Assert.AreEqual(viewModel.ProjectId, result.ProjectId);
        }

        [TestMethod]
        public async Task TestGetEmployeesByProjectAsync()
        {
            //Arrange
            int projectId = 2;
            List<EmployeeModel> employeeModel = new List<EmployeeModel>();
            _mockEmployeeDataAccess.Setup(x => x.GetAllEmployeesAsync()).ReturnsAsync(employeeModel);

            //Act
            IReadOnlyList<EmployeeModel> result = await _assignTaskService.GetEmployeesByProjectAsync(projectId);

            //Assert
            Assert.AreEqual(employeeModel.Count , result.Count);
        }

        [TestMethod]
        public async Task TestSaveTaskDetailsAsync()
        {
            //Arrange
            AssignTasksViewModel viewModel = new AssignTasksViewModel();

            //Act
            await _assignTaskService.SaveTaskDetailsAsync(viewModel);

            //Assert
            _mockTaskDataAccess.Verify(x => x.SaveTaskDetailsAsync(viewModel), Times.AtLeastOnce());
        }
    }
}
