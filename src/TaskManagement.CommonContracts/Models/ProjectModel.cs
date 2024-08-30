using System.Collections.Generic;

namespace TaskManagement.CommonContracts.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IReadOnlyList<EmployeeModel> Employees { get; set; }

        public IReadOnlyList<TaskModel> Tasks { get; set; }
    }
}
