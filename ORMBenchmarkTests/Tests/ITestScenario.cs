namespace ORMBenchmarkTests.Tests
{
    public interface ITestScenario
    {
        string Name { get; }
        long GetEntity(int id);
    }
}