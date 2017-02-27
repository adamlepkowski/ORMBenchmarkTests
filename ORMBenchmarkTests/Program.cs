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
            Console.WriteLine("Prepare test data");

            using (var dbContext = new DatabaseContext())
            {
                ISingleObjectBuilder<User> userBuilder =
                    Builder<User>.CreateNew()
                        .With(y => y.UserType = Builder<UserType>.CreateNew().Build())
                        .And(y => y.Department = Builder<Department>.CreateNew().Build());

                ISingleObjectBuilder<Price> priceBuilder = Builder<Price>.CreateNew().With(y => y.CurrencyDefinition = Builder<CurrencyDefinition>.CreateNew().Build());

                var contact = Builder<Contact>.CreateNew()
                    .With(x => x.Profession = Builder<Profession>.CreateNew().Build())
                    .With(x => x.Nationality = Builder<Nationality>.CreateNew().Build())
                    .With(x => x.Company = Builder<Company>.CreateNew().Build())
                    .With(x => x.CreatedBy = userBuilder.Build())
                    .With(x => x.AttributeValues = Builder<AttributeValues>.CreateNew().Do(y => y.MinPrice = priceBuilder.Build()).Do(y => y.MaxPrice = priceBuilder.Build()).Build())
                    .With(x => x.Phones = Builder<Phone>.CreateListOfSize(5).All().Do(y => y.PhoneType = Builder<PhoneType>.CreateNew().Build()).Build())
                    .With(x => x.Emails = Builder<Email>.CreateListOfSize(5).All().Do(y => y.EmailType = Builder<EmailType>.CreateNew().Build()).Build())
                    .With(x => x.ContactNegotiators = Builder<ContactNegotiator>.CreateListOfSize(5).All().Do(y => y.CreatedBy = userBuilder.Build()).Build())
                    .With(x => x.Agents = Builder<Agent>.CreateListOfSize(5).All().Do(y => y.CreatedBy = userBuilder.Build()).Do(y => y.Company = Builder<Company>.CreateNew().Build()).Build())
                    .Build();


                dbContext.Contacts.Add(contact);
                dbContext.SaveChanges();

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
                    .First(x => x.ContactId == contact.ContactId);
            }
        }
    }
}
