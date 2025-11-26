using System;
using System.Collections.Generic;

namespace ProjectManagementSystem.Models;

public partial class VProject
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDatePlanned { get; set; }

    public bool IsDeleted { get; set; }

    public string? StatusName { get; set; }
}
