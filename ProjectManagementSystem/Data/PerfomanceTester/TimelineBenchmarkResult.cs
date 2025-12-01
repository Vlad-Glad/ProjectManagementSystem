public class TimelineBenchmarkResult
{
    public int TaskId { get; set; }
    public int Iterations { get; set; }

    public long SqlTotalMilliseconds { get; set; }
    public double SqlAverageMilliseconds => Iterations > 0
        ? (double)SqlTotalMilliseconds / Iterations
        : 0;

    public long MongoTotalMilliseconds { get; set; }
    public double MongoAverageMilliseconds => Iterations > 0
        ? (double)MongoTotalMilliseconds / Iterations
        : 0;
}
