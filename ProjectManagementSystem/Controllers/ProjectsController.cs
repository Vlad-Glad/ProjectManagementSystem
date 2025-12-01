using Microsoft.AspNetCore.Mvc;
using ProjectManagementSystem.Models;

public class ProjectsController : Controller
{
    private readonly IUnitOfWork _uow;
    private readonly AppDbContext _context;

    public ProjectsController(IUnitOfWork uow, AppDbContext context)
    {
        _uow = uow;
        _context = context;
    }

    public IActionResult Index()
    {
        var projects = _uow.Projects.GetAll();
        return View(projects);
    }

    public IActionResult Details(int id)
    {
        var project = _uow.Projects.GetById(id);
        if (project == null) return NotFound();

        var tasks = _uow.Tasks.GetByProject(id);

        var vm = new ProjectDetailsViewModel
        {
            Project = project,
            Tasks = tasks
        };

        return View(vm);
    }

    [HttpPost]
    public IActionResult SoftDelete(int id)
    {
        var ownerId = _context.Projects
              .Where(p => p.Id == id)
              .Select(p => (int?)p.OwnerUserId)
              .FirstOrDefault();

        int currentUserId = ownerId ?? 1;

        _uow.BeginTransaction();
        try
        {
            _uow.Projects.SoftDelete(id, currentUserId);
            _uow.Commit();
        }
        catch
        {
            _uow.Rollback();
            throw;
        }

        return RedirectToAction("Index");
    }
}
