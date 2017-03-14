using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;

namespace ORMBenchmarkTests.Tests
{
    public class EntityFrameworkContactWithoutManyTestScenario : ITestScenario
    {
        private readonly SqlConnection _sqlConnection;
        public string Name { get; private set; }

        public EntityFrameworkContactWithoutManyTestScenario(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
            Name = "Entity Framework without multiple 1:N relationships";
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
                    .First(x => x.Id == id);
            }

            watch.Stop();
            return watch.ElapsedMilliseconds;
        }
    }
}