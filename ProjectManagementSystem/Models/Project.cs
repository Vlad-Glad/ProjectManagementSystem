using System;
using System.Collections.Generic;

namespace ProjectManagementSystem.Models;

public partial class Project
{
    public int Id { get; set; }

    public int? ClientId { get; set; }

    public int? DepartmentId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int ProjectStatusId { get; set; }

    public int OwnerUserId { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDatePlanned { get; set; }

    public DateOnly? EndDateActual { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedByUserId { get; set; }

    public DateTime? LastModifiedAt { get; set; }

    public int? LastModifiedByUserId { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Client? Client { get; set; }

    public virtual User CreatedByUser { get; set; } = null!;

    public virtual Department? Department { get; set; }

    public virtual User? LastModifiedByUser { get; set; }

    public virtual User OwnerUser { get; set; } = null!;

    public virtual ICollection<ProjectStage> ProjectStages { get; set; } = new List<ProjectStage>();

    public virtual ProjectStatus ProjectStatus { get; set; } = null!;

    public virtual ICollection<ProjectTeamMember> ProjectTeamMembers { get; set; } = new List<ProjectTeamMember>();

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
