using System;
using System.Collections.Generic;

namespace ProjectManagementSystem.Models;

public partial class Client
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? ContactName { get; set; }

    public string? ContactEmail { get; set; }

    public string? ContactPhone { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
