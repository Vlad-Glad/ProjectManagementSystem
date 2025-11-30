using MongoDB.Driver;
using ProjectManagementSystem.Models;

public class TaskActivitySeeder
{
    private readonly AppDbContext _sql;
    private readonly IMongoCollection<TaskActivity> _collection;

    public TaskActivitySeeder(AppDbContext sql, IMongoDatabase mongoDb)
    {
        _sql = sql;
        _collection = mongoDb.GetCollection<TaskActivity>("taskActivity");
    }

    public async System.Threading.Tasks.Task SeedAsync()
    {
        await _collection.DeleteManyAsync(FilterDefinition<TaskActivity>.Empty);


        var taskIds = _sql.Tasks
            .Select(t => t.Id)
            .Take(10)
            .ToList();

        foreach (var taskId in taskIds)
        {
            var comments = _sql.TaskComments
                .Where(c => c.TaskId == taskId)
                .ToList();

            var logs = _sql.WorkLogs
                .Where(w => w.TaskId == taskId)
                .ToList();

            var events = new List<TaskEvent>();

            foreach (var c in comments)
            {
                events.Add(new TaskEvent
                {
                    Type = "comment",
                    UserId = c.UserId,
                    Text = c.CommentText,
                    CreatedAt = c.CreatedAt
                });
            }

            foreach (var w in logs)
            {
                events.Add(new TaskEvent
                {
                    Type = "worklog",
                    UserId = w.UserId,
                    Text = w.Description,
                    CreatedAt = w.CreatedAt
                });
            }

            if (!events.Any())
                continue; 

            events = events
                .OrderBy(e => e.CreatedAt)
                .ToList();

            var doc = new TaskActivity
            {
                TaskId = taskId,
                Events = events
            };

            await _collection.InsertOneAsync(doc);
        }
    }
}
