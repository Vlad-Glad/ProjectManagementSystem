using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;

public class EfProjectRepository : IProjectRepository
{
    private readonly AppDbContext _context;

    public EfProjectRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<VProject> GetAll()
    {
        return _context.VProjects
            .FromSqlRaw("EXEC dbo.GetAllProjects")
            .ToList();
    }

    public VProject? GetById(int id)
    {
        var p = new SqlParameter("@ProjectId", id);

        return _context.VProjects
            .FromSqlRaw("EXEC dbo.GetProjectById @ProjectId", p)
            .FirstOrDefault();
    }

    // Soft delete через процедуру
    public void SoftDelete(int id, int userId)
    {
        var p1 = new SqlParameter("@ProjectId", id);
        var p2 = new SqlParameter("@UserId", userId);

        _context.Database.ExecuteSqlRaw("EXEC dbo.SoftDeleteProject @ProjectId, @UserId", p1, p2);
    }
}
