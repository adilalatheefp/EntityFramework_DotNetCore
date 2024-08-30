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
    public class TaskDataAccessTest
    {
        private readonly TaskDataAccess _taskDataAccess;
        private readonly TaskDbContext _dbContext;

        public TaskDataAccessTest()
        {
            var options = new DbContextOptionsBuilder<TaskDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _dbContext = new TaskDbContext(options);

            var tasks = new[]
            {
                new TaskModel { Id = 1, Description = "Push Notifications", StartDate = new DateTime(2019, 01, 10), DueDate = new DateTime(2019, 02, 22), ProjectId = 1 },
                new TaskModel { Id = 2, Description = "Help Screen", StartDate = new DateTime(2020, 01, 10), DueDate = new DateTime(2020, 02, 22), ProjectId = 1 },
                new TaskModel { Id = 3, Description = "Graphics Slicing", StartDate = new DateTime(2021, 01, 10), DueDate = new DateTime(2021, 02, 22), ProjectId = 2 }
            };

            _dbContext.Tasks.AddRange(tasks);
            _dbContext.SaveChanges();

            _taskDataAccess = new TaskDataAccess(_dbContext);
        }

        [TestMethod]
        public async Task TestGetAllTasksAsync()
        {
            //Act
            IReadOnlyList<TaskModel> result = await _taskDataAccess.GetAllTasksAsync();

            //Assert
            Assert.AreEqual(3, result.Count);
        }
    }
}
