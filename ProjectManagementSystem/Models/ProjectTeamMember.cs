using System;
using System.Collections.Generic;

namespace ProjectManagementSystem.Models;

public partial class ProjectTeamMember
{
    public int Id { get; set; }

    public int ProjectId { get; set; }

    public int UserId { get; set; }

    public string? RoleInProject { get; set; }

    public DateTime AssignedAt { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
