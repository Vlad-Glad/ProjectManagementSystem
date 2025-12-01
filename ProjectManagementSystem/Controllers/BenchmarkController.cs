using Microsoft.AspNetCore.Mvc;

namespace ProjectManagementSystem.Controllers
{
    public class BenchmarkController : Controller
    {
        private readonly PerformanceTester _tester;

        public BenchmarkController(PerformanceTester tester)
        {
            _tester = tester;
        }

        // /Benchmark/Timeline?taskId=1&iterations=100
        public async System.Threading.Tasks.Task<IActionResult> Timeline(int taskId = 1, int iterations = 100)
        {
            var result = await _tester.BenchmarkTimelineAsync(taskId, iterations);

            // можна окреме View зробити, але для простоти віддамо текстом
            var text =
                $"TaskId: {result.TaskId}\n" +
                $"Iterations: {result.Iterations}\n\n" +
                $"SQL total:   {result.SqlTotalMilliseconds} ms\n" +
                $"SQL average: {result.SqlAverageMilliseconds:F3} ms per call\n\n" +
                $"Mongo total:   {result.MongoTotalMilliseconds} ms\n" +
                $"Mongo average: {result.MongoAverageMilliseconds:F3} ms per call\n";

            return Content(text, "text/plain");
        }
    }
}
