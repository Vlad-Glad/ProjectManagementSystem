namespace ProjectManagementSystem.Data.SqlAnalogue
{
    public interface ITaskTimelineSqlRepository
    {
        IEnumerable<TaskEvent> GetTimeline(int taskId);
        void AddComment(int taskId, int userId, string text);
    }
}
