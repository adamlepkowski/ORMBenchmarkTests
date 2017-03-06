using System;
using System.Collections.Generic;

namespace ORMBenchmarkTests.Tests
{
    public class TestManager
    {
        public IList<ITestScenario> TestScenarios { get; private set; }

        public Dictionary<string, IList<long>> TestResults { get; private set; }

        public TestManager()
        {
            this.TestResults = new Dictionary<string, IList<long>>();
            this.TestScenarios = new List<ITestScenario>();
        }

        public void AddTest(ITestScenario testScenario)
        {
            this.TestScenarios.Add(testScenario);
        }

        public void Run()
        {
            foreach (var testScenario in this.TestScenarios)
            {
                Console.WriteLine($"\t Execute {testScenario.Name}");

                long responseTime = testScenario.GetEntity(DatabaseManager.TestedContactId);

                if (this.TestResults.ContainsKey(testScenario.Name))
                {
                    this.TestResults[testScenario.Name].Add(responseTime);
                }
                else
                {
                    this.TestResults.Add(testScenario.Name, new List<long>() { responseTime });
                }

                //Thread.Sleep(2000);
            }
        }
    }
}