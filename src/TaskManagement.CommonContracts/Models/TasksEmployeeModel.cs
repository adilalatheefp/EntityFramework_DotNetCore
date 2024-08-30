using System.Diagnostics.CodeAnalysis;

namespace TaskManagement.CommonContracts.Models
{
    [ExcludeFromCodeCoverage]
    public class TasksEmployeeModel
    {
        public int Id { get; set; }

        public string EmployeeId { get; set; }

        public int TaskId { get; set; }

        public EmployeeModel Employee { get; set; }

        public TaskModel Task { get; set; }
    }
}
