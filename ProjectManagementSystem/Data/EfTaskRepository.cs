using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;

public class EfTaskRepository : ITaskRepository
{
    private readonly AppDbContext _context;

    public EfTaskRepository(AppDbContext context)
    {
        _context = context;
    }
    public IEnumerable<VTask> GetByProject(int projectId)
    {
        var p = new SqlParameter("@ProjectId", projectId);

        return _context.VTasks
            .FromSqlRaw("EXEC dbo.GetTasksByProject @ProjectId", p)
            .ToList();
    }

    public VTask? GetById(int id)
    {
        var p = new SqlParameter("@TaskId", id);

        return _context.VTasks
            .FromSqlRaw("EXEC dbo.GetTaskById @TaskId", p)
            .FirstOrDefault();
    }

    // Soft delete через процедуру
    public void SoftDelete(int taskId, int userId)
    {
        var p1 = new SqlParameter("@TaskId", taskId);
        var p2 = new SqlParameter("@UserId", userId);

        _context.Database.ExecuteSqlRaw("EXEC dbo.SoftDeleteTask @TaskId, @UserId", p1, p2);
    }
}
