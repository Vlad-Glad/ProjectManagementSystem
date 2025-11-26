using System;
using System.Collections.Generic;

namespace ProjectManagementSystem.Models;

public partial class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int? ManagerUserId { get; set; }

    public virtual User? ManagerUser { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
