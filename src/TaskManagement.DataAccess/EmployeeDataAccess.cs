using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManagement.CommonContracts.DataAccess;
using TaskManagement.CommonContracts.Models;

namespace TaskManagement.DataAccess
{
    public class EmployeeDataAccess : IEmployeeDataAccess
    {
        private readonly TaskDbContext _dbContext;

        public EmployeeDataAccess(TaskDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<EmployeeModel>> GetAllEmployeesAsync()
        {
            return await _dbContext.Employees.ToListAsync();
        }
    }
}
