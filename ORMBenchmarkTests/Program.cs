using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FizzWare.NBuilder.Implementation;
using FizzWare.NBuilder.PropertyNaming;
using ORMBenchmarkTests.Model;

namespace ORMBenchmarkTests
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseManager.ClearData();

            DatabaseManager.CreateContactTestData();

            Console.WriteLine("Prepare test data");

            using (var dbContext = new DatabaseContext())
            {
                Console.WriteLine("Retrieve contact data");
                var retrievedContact = dbContext.Contacts
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
                    .First(x => x.ContactId == DatabaseManager.TestedContactId);
            }
        }
    }
}
