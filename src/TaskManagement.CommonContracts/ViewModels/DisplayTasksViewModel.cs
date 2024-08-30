using System.Collections.Generic;
using TaskManagement.CommonContracts.Models;

namespace TaskManagement.CommonContracts.ViewModels
{
    public class DisplayTasksViewModel
    {
        public int ProjectId { get; set; }

        public IReadOnlyList<ProjectModel> Projects { get; set; }

        public IReadOnlyList<TaskModel> Tasks { get; set; }
    }
}
