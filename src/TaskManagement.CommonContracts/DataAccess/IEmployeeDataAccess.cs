using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.CommonContracts.Models;

namespace TaskManagement.CommonContracts.DataAccess
{
    public interface IEmployeeDataAccess
    {
        public Task<IReadOnlyList<EmployeeModel>> GetAllEmployeesAsync();
    }
}
