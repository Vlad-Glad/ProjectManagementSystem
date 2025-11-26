using System;
using System.Collections.Generic;

namespace ProjectManagementSystem.Models;

public partial class WorkLog
{
    public int Id { get; set; }

    public int TaskId { get; set; }

    public int UserId { get; set; }

    public DateOnly WorkDate { get; set; }

    public int DurationMinutes { get; set; }

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Task Task { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
