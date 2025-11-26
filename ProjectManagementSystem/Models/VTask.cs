using System;
using System.Collections.Generic;

namespace ProjectManagementSystem.Models;

public partial class VTask
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int ProjectId { get; set; }

    public bool IsDeleted { get; set; }

    public string? StatusName { get; set; }

    public string? PriorityName { get; set; }
}
