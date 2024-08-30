using System;
using System.Collections.Generic;

namespace TaskManagement.CommonContracts.Models
{
    public class TaskModel
    {
        public string Description { get; set; }

        public DateTime DueDate { get; set; }
        
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public DateTime StartDate { get; set; }

        public ProjectModel Project { get; set; }

        public IReadOnlyList<TasksEmployeeModel> TasksEmployees { get; set; }
    }
}
