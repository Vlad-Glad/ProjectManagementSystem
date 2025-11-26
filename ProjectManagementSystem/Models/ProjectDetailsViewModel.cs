using System.Collections.Generic;
using ProjectManagementSystem.Models;

public class ProjectDetailsViewModel
{
    public VProject Project { get; set; }
    public IEnumerable<VTask> Tasks { get; set; }
}
