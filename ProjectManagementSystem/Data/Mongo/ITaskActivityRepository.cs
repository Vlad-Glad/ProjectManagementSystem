using MongoDB.Driver;

public interface ITaskActivityRepository
{
    Task<TaskActivity?> GetTimelineAsync(int taskId);
    Task AddCommentAsync(int taskId, int userId, string text);
}