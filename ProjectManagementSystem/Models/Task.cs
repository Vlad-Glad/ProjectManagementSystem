using System;
using System.Collections.Generic;

namespace ProjectManagementSystem.Models;

public partial class Task
{
    public int Id { get; set; }

    public int ProjectId { get; set; }

    public int? ProjectStageId { get; set; }

    public int? ParentTaskId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public int? AssigneeUserId { get; set; }

    public int ReporterUserId { get; set; }

    public int TaskStatusId { get; set; }

    public int TaskPriorityId { get; set; }

    public int? TaskTypeId { get; set; }

    public DateOnly? DueDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedByUserId { get; set; }

    public DateTime? LastModifiedAt { get; set; }

    public int? LastModifiedByUserId { get; set; }

    public bool IsDeleted { get; set; }

    public virtual User? AssigneeUser { get; set; }

    public virtual User CreatedByUser { get; set; } = null!;

    public virtual ICollection<Task> InverseParentTask { get; set; } = new List<Task>();

    public virtual User? LastModifiedByUser { get; set; }

    public virtual Task? ParentTask { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual ProjectStage? ProjectStage { get; set; }

    public virtual User ReporterUser { get; set; } = null!;

    public virtual ICollection<TaskComment> TaskComments { get; set; } = new List<TaskComment>();

    public virtual TaskPriority TaskPriority { get; set; } = null!;

    public virtual TaskStatus TaskStatus { get; set; } = null!;

    public virtual TaskType? TaskType { get; set; }

    public virtual ICollection<WorkLog> WorkLogs { get; set; } = new List<WorkLog>();
}
