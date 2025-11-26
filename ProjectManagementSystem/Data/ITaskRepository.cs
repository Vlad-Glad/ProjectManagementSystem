using ProjectManagementSystem.Models;
using System.Collections.Generic;

public interface ITaskRepository
{
    IEnumerable<VTask> GetByProject(int projectId);
    void SoftDelete(int taskId, int userId);
}
