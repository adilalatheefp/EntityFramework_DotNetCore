using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskManagement.CommonContracts.Models;
using TaskManagement.DataAccess;

namespace TaskManagement.Tests
{
    [TestClass]
    public class ProjectDataAccessTest
    {
        private readonly ProjectDataAccess _projectDataAccess;
        private readonly TaskDbContext _dbContext;

        public ProjectDataAccessTest()
        {
            var options = new DbContextOptionsBuilder<TaskDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _dbContext = new TaskDbContext(options);

            var projects = new[]
            {
                new ProjectModel { Id = 1 , Name = "iPhone UI" },
                new ProjectModel { Id = 2 , Name = "iPad Bugs" }
            };

            _dbContext.Projects.AddRange(projects);
            _dbContext.SaveChanges();

            _projectDataAccess = new ProjectDataAccess(_dbContext);
        }

        [TestMethod]
        public async Task TestGetAllProjectsAsync()
        {
            //Act
            IReadOnlyList<ProjectModel> result = await _projectDataAccess.GetAllProjectsAsync();

            //Assert
            Assert.AreEqual(2, result.Count);
        }
    }
}
