using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Data.SqlAnalogue
{
    public class SqlTaskTimelineRepository : ITaskTimelineSqlRepository
    {
        private readonly AppDbContext _context;

        public SqlTaskTimelineRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TaskEvent> GetTimeline(int taskId)
        {
            var param = new SqlParameter("@TaskId", taskId);

            var rows = _context.TaskTimelineRows
                .FromSqlRaw("EXEC dbo.GetTaskTimeline @TaskId", param)
                .AsEnumerable();

            return rows.Select(r => new TaskEvent
            {
                Type = r.EventType,
                UserId = r.UserId,
                Text = r.Text,
                CreatedAt = r.CreatedAt
            });
        }

        public void AddComment(int taskId, int userId, string text)
        {
            var p1 = new SqlParameter("@TaskId", taskId);
            var p2 = new SqlParameter("@UserId", userId);
            var p3 = new SqlParameter("@Text", text);

            _context.Database.ExecuteSqlRaw(
                "EXEC dbo.AddTaskComment @TaskId, @UserId, @Text",
                p1, p2, p3);
        }
    }
}
