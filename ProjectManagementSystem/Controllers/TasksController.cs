using Microsoft.AspNetCore.Mvc;
using ProjectManagementSystem.Models;

public class TaskDetailsViewModel
{
    public VTask Task { get; set; } = null!;
    public TaskActivity? Activity { get; set; }
    public string? NewCommentText { get; set; }
}

public class TasksController : Controller
{
    private readonly IUnitOfWork _uow;                  // SQL
    private readonly ITaskActivityRepository _activity; // Mongo

    public TasksController(IUnitOfWork uow, ITaskActivityRepository activity)
    {
        _uow = uow;
        _activity = activity;
    }

    public async Task<IActionResult> Details(int id)
    {
        var task = _uow.Tasks.GetById(id);  // SQL
        if (task == null) return NotFound();

        var activity = await _activity.GetTimelineAsync(id); // Mongo

        var vm = new TaskDetailsViewModel
        {
            Task = task,
            Activity = activity
        };

        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> AddComment(int taskId, string newCommentText)
    {
        int currentUserId = 1;

        if (!string.IsNullOrWhiteSpace(newCommentText))
        {
            await _activity.AddCommentAsync(taskId, currentUserId, newCommentText); // Mongo
        }

        return RedirectToAction("Details", new { id = taskId });
    }
}
