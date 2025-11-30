using ProjectManagementSystem.Models;
using System.Collections.Generic;

public interface ITaskRepository
{
    IEnumerable<VTask> GetByProject(int projectId);
    VTask? GetById(int id);
    void SoftDelete(int taskId, int userId);
}
