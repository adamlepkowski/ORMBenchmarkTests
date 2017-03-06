using System;
using FizzWare.NBuilder;
using ORMBenchmarkTests.Model;

namespace ORMBenchmarkTests
{
    public static class DatabaseManager
    {
        public static int TestedContactId = 1;

        public static void ClearData()
        {
            Console.WriteLine("Clear Data");

            using (var dbContext = new DatabaseContext())
            {
                dbContext.Database.ExecuteSqlCommand("DELETE FROM[dbo].[Phones]");
                dbContext.Database.ExecuteSqlCommand("DELETE FROM[dbo].[PhoneTypes]");
                dbContext.Database.ExecuteSqlCommand("DELETE FROM[dbo].[Emails]");
                dbContext.Database.ExecuteSqlCommand("DELETE FROM[dbo].[EmailTypes]");
                dbContext.Database.ExecuteSqlCommand("DELETE FROM[dbo].[Agents]");
                dbContext.Database.ExecuteSqlCommand("DELETE FROM[dbo].[ContactNegotiators]");
                dbContext.Database.ExecuteSqlCommand("DELETE FROM[dbo].[Contacts]");
                dbContext.Database.ExecuteSqlCommand("DELETE FROM[dbo].[Professions]");
                dbContext.Database.ExecuteSqlCommand("DELETE FROM[dbo].[Nationalities]");
                dbContext.Database.ExecuteSqlCommand("DELETE FROM[dbo].[Users]");
                dbContext.Database.ExecuteSqlCommand("DELETE FROM[dbo].[UserTypes]");
                dbContext.Database.ExecuteSqlCommand("DELETE FROM[dbo].[Departments]");
                dbContext.Database.ExecuteSqlCommand("DELETE FROM[dbo].[Companies]");
                dbContext.Database.ExecuteSqlCommand("DELETE FROM[dbo].[AttributeValues]");
                dbContext.Database.ExecuteSqlCommand("DELETE FROM[dbo].[Prices]");
                dbContext.Database.ExecuteSqlCommand("DELETE FROM[dbo].[CurrencyDefinitions]");
            }

            Console.WriteLine("END Clear Data");
        }

        public static void CreateContactTestData()
        {
            Console.WriteLine("Create Test Data");

            using (var dbContext = new DatabaseContext())
            {
                ISingleObjectBuilder<User> userBuilder =
                    Builder<User>.CreateNew()
                        .With(y => y.UserType = Builder<UserType>.CreateNew().Build())
                        .And(y => y.Department = Builder<Department>.CreateNew().Build());

                ISingleObjectBuilder<Price> priceBuilder =
                    Builder<Price>.CreateNew()
                        .With(y => y.CurrencyDefinition = Builder<CurrencyDefinition>.CreateNew().Build());

                var contact = Builder<Contact>.CreateNew()
                  .With(x => x.ContactId = DatabaseManager.TestedContactId)
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
            }

            Console.WriteLine("END Create Test Data");
        }
    }
}
