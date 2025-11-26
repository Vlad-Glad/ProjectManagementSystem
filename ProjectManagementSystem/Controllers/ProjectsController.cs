using Microsoft.AspNetCore.Mvc;

public class ProjectsController : Controller
{
    private readonly IUnitOfWork _uow;

    public ProjectsController(IUnitOfWork uow)
    {
        _uow = uow;
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
        int currentUserId = 1; // тимчасово, для прикладу

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
