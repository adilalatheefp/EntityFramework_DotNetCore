using System.Collections.Generic;

namespace TaskManagement.CommonContracts.Models
{
    public class EmployeeModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int ProjectId { get; set; }

        public ProjectModel Project { get; set; }

        public IReadOnlyList<TasksEmployeeModel> TasksEmployees { get; set; }
    }
}
