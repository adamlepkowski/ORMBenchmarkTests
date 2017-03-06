using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FizzWare.NBuilder.Implementation;
using FizzWare.NBuilder.PropertyNaming;
using ORMBenchmarkTests.Model;
using ORMBenchmarkTests.Tests;

namespace ORMBenchmarkTests
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseManager.ClearData();

            DatabaseManager.CreateContactTestData();

            DatabaseManager.UploadStoredProcedures();

            Console.WriteLine("Prepare test data");

            var testManager = new TestManager();

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ORMBenchmarkTests"].ConnectionString))
            {
                connection.Open();

                testManager.AddTest(new ForJsonContactWithoutManyTestScenario(connection));
                testManager.AddTest(new EntityFrameworkContactWithoutManyTestScenario(connection));
                testManager.AddTest(new EntityFrameworkContactWithManyTestScenario(connection));


                testManager.Run();
            }

            foreach (KeyValuePair<string, IList<long>> item in testManager.TestResults)
            {
                Console.WriteLine($"\n Test Scenario: {item.Key}");

                foreach (var responseTime in item.Value)
                {
                    Console.WriteLine($"\t Response time = {responseTime}");
                }
            }
        }
    }
}
