using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using TaskManagement.CommonContracts.Models;

namespace TaskManagement.CommonContracts.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class AssignTasksViewModel
    {
        public IReadOnlyList<string> EmployeeIds { get; set; }

        [Required()]
        public int ProjectId { get; set; }

        public IReadOnlyList<ProjectModel> Projects { get; set; }

        [Required()]
        [MaxLength(100, ErrorMessage = "TaskDescription should not exceed 100 characters")]
        public string TaskDescription { get; set; }

        [Required()]
        public DateTime TaskDueDate { get; set; }

        [Required()]
        public DateTime TaskStartDate { get; set; }

    }
}
