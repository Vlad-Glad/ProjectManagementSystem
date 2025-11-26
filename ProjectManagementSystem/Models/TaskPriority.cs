using System;
using System.Collections.Generic;

namespace ProjectManagementSystem.Models;

public partial class TaskPriority
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
