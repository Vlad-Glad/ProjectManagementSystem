using System;
using System.Collections.Generic;

namespace ProjectManagementSystem.Models;

public partial class ProjectStage
{
    public int Id { get; set; }

    public int ProjectId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDatePlanned { get; set; }

    public DateOnly? EndDateActual { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
