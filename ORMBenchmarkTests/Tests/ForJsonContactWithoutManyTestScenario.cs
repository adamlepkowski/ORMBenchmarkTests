using System;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using ORMBenchmarkTests.Model;

namespace ORMBenchmarkTests.Tests
{
    public class ForJsonContactWithoutManyTestScenario : ITestScenario
    {
        private readonly SqlConnection _sqlConnection;
        public string Name { get; private set; }

        public ForJsonContactWithoutManyTestScenario(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
            Name = "Stored Procedure ForJSON - without multiple 1:N relationships";
        }

        public long GetEntity(int id)
        {
            var watch = new Stopwatch();
            watch.Start();

            SqlCommand cmd = new SqlCommand("GetContactByIdInJsonFormat", _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add("ContactId", SqlDbType.Int).Value = id;

            var jsonResult = new StringBuilder();

            using (var reader = cmd.ExecuteReader())
            {
                if (!reader.HasRows)
                {
                    throw new Exception();
                }
                else
                {
                    while (reader.Read())
                    {
                        jsonResult.Append(reader.GetValue(0).ToString());
                    }
                }
            }

            var watchSerializer = new Stopwatch();
            watchSerializer.Start();
            ServiceStack.Text.JsonSerializer.DeserializeFromString<Contact>(jsonResult.ToString());
            watchSerializer.Stop();
            Console.WriteLine($"JSON serialization time: {watchSerializer.ElapsedMilliseconds}");
            
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }
    }
}