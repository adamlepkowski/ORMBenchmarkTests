using System;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;

namespace ORMBenchmarkTests.Tests
{
    public class EntityFrameworkContactWithManyTestScenario : ITestScenario
    {
        private readonly SqlConnection _sqlConnection;
        public string Name { get; private set; }

        public EntityFrameworkContactWithManyTestScenario(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
            Name = "Entity Framework with many";
        }

        public long GetEntity(int id)
        {
            var watch = new Stopwatch();
            watch.Start();

            using (var dbContext = new DatabaseContext(_sqlConnection))
            {
                var contact = dbContext.Contacts.AsNoTracking()
                    .Include(c => c.Profession)
                    .Include(c => c.Nationality)
                    .Include(c => c.Company)
                    .Include(c => c.CreatedBy.UserType)
                    .Include(c => c.CreatedBy.Department)
                    .Include(c => c.AttributeValues.MinPrice.CurrencyDefinition)
                    .Include(c => c.AttributeValues.MaxPrice.CurrencyDefinition)
                    .Include(c => c.Phones.Select(t => t.PhoneType))
                    .Include(c => c.Emails.Select(t => t.EmailType))
                    .Include(c => c.ContactNegotiators.Select(t => t.CreatedBy.UserType))
                    .Include(c => c.ContactNegotiators.Select(t => t.CreatedBy.Department))
                    .Include(c => c.Agents.Select(t => t.Company))
                    .Include(c => c.Agents.Select(t => t.CreatedBy.UserType))
                    .Include(c => c.Agents.Select(t => t.CreatedBy.Department))
                    .First(x => x.ContactId == id);
            }

            watch.Stop();
            return watch.ElapsedMilliseconds;
        }
    }
}