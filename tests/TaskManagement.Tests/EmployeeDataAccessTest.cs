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
    public class EmployeeDataAccessTest
    {
        private readonly EmployeeDataAccess _employeeDataAccess;
        private readonly TaskDbContext _dbContext;

        public EmployeeDataAccessTest()
        {
            var options = new DbContextOptionsBuilder<TaskDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _dbContext = new TaskDbContext(options);

            var employees = new[]
            {
                new EmployeeModel { Id = "M1001072", Name = "Rohit Reddy", ProjectId = 1 },
                new EmployeeModel { Id = "M1001075", Name = "Rahul Dev", ProjectId = 2 },
                new EmployeeModel { Id = "M1001090", Name = "Anjan G", ProjectId = 1 },
                new EmployeeModel { Id = "M1001099", Name = "Bhushan S", ProjectId = 2 }
            };

            _dbContext.Employees.AddRange(employees);
            _dbContext.SaveChanges();

            _employeeDataAccess = new EmployeeDataAccess(_dbContext);
        }

        [TestMethod]
        public async Task TestGetAllEmployeesAsync()
        {
            //Act
            IReadOnlyList<EmployeeModel> result = await _employeeDataAccess.GetAllEmployeesAsync();

            //Assert
            Assert.AreEqual(4, result.Count);
        }
    }
}
