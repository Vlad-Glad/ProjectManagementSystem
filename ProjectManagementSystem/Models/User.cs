using System;
using System.Collections.Generic;

namespace ProjectManagementSystem.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? DepartmentId { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Department? Department { get; set; }

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    public virtual ICollection<Project> ProjectCreatedByUsers { get; set; } = new List<Project>();

    public virtual ICollection<Project> ProjectLastModifiedByUsers { get; set; } = new List<Project>();

    public virtual ICollection<Project> ProjectOwnerUsers { get; set; } = new List<Project>();

    public virtual ICollection<ProjectTeamMember> ProjectTeamMembers { get; set; } = new List<ProjectTeamMember>();

    public virtual ICollection<Task> TaskAssigneeUsers { get; set; } = new List<Task>();

    public virtual ICollection<TaskComment> TaskComments { get; set; } = new List<TaskComment>();

    public virtual ICollection<Task> TaskCreatedByUsers { get; set; } = new List<Task>();

    public virtual ICollection<Task> TaskLastModifiedByUsers { get; set; } = new List<Task>();

    public virtual ICollection<Task> TaskReporterUsers { get; set; } = new List<Task>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    public virtual ICollection<WorkLog> WorkLogs { get; set; } = new List<WorkLog>();
}
