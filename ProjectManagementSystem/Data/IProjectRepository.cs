using System.Collections.Generic;
using ProjectManagementSystem.Models;

public interface IProjectRepository
{
    IEnumerable<VProject> GetAll();
    VProject? GetById(int id);
    void SoftDelete(int id, int userId);
}
