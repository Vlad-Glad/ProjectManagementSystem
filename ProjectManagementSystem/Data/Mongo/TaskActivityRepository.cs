using MongoDB.Driver;

public class TaskActivityRepository : ITaskActivityRepository
{
    private readonly IMongoCollection<TaskActivity> _collection;

    public TaskActivityRepository(IMongoDatabase database)
    {
        _collection = database.GetCollection<TaskActivity>("taskActivity");
    }

    public async Task<TaskActivity?> GetTimelineAsync(int taskId)
    {
        return await _collection
            .Find(a => a.TaskId == taskId)
            .FirstOrDefaultAsync();
    }

    public async Task AddCommentAsync(int taskId, int userId, string text)
    {
        var ev = new TaskEvent
        {
            Type = "comment",
            UserId = userId,
            Text = text,
            CreatedAt = DateTime.UtcNow
        };

        var filter = Builders<TaskActivity>.Filter.Eq(a => a.TaskId, taskId);
        var update = Builders<TaskActivity>.Update.Push(a => a.Events, ev);

        await _collection.UpdateOneAsync(
            filter,
            update,
            new UpdateOptions { IsUpsert = true });
    }
}