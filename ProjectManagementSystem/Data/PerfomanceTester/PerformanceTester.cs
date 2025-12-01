using ProjectManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

public class PerformanceTester
{
    private readonly AppDbContext _context;
    private readonly ITaskActivityRepository _mongoRepo;

    public PerformanceTester(AppDbContext context, ITaskActivityRepository mongoRepo)
    {
        _context = context;
        _mongoRepo = mongoRepo;
    }

    public async System.Threading.Tasks.Task<TimelineBenchmarkResult> BenchmarkTimelineAsync(int taskId, int iterations)
    {
        var result = new TimelineBenchmarkResult
        {
            TaskId = taskId,
            Iterations = iterations
        };

        var sw = new Stopwatch();

        // SQL
        var sqlParam = new Microsoft.Data.SqlClient.SqlParameter("@TaskId", taskId);

        sw.Start();
        for (int i = 0; i < iterations; i++)
        {
            var rows = _context.TaskTimelineRows
                .FromSqlRaw("EXEC dbo.GetTaskTimeline @TaskId", sqlParam)
                .AsEnumerable()
                .ToList();
        }
        sw.Stop();
        result.SqlTotalMilliseconds = sw.ElapsedMilliseconds;

        // Mongo
        sw.Restart();
        for (int i = 0; i < iterations; i++)
        {
            var doc = await _mongoRepo.GetTimelineAsync(taskId);
            var _ = doc?.Events?.Count;
        }
        sw.Stop();
        result.MongoTotalMilliseconds = sw.ElapsedMilliseconds;

        return result;
    }
}
