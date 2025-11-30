using Microsoft.AspNetCore.Mvc;

namespace ProjectManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        private readonly TaskActivitySeeder _seeder;

        public AdminController(TaskActivitySeeder seeder)
        {
            _seeder = seeder;
        }

        public async Task<IActionResult> SeedMongo()
        {
            await _seeder.SeedAsync();
            return Content("Mongo seeding done.");
        }
    }
}
