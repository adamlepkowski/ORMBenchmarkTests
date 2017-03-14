using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Dapper;
using ORMBenchmarkTests.Model;

namespace ORMBenchmarkTests.Tests
{
    public class EntityFrameworkContactWithManyQuerySyntaxTestScenario : ITestScenario
    {
        private readonly SqlConnection _sqlConnection;
        public string Name { get; private set; }

        public EntityFrameworkContactWithManyQuerySyntaxTestScenario(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
            Name = "Entity Framework with multiple 1:N relationships - Linq Query Syntax";
        }

        public long GetEntity(int id)
        {
            var watch = new Stopwatch();
            watch.Start();

            using (var dbContext = new DatabaseContext(_sqlConnection))
            {
                // retrieve data without connecting them

                var contactItem =
                    (from c in dbContext.Contacts.AsNoTracking()
                     join profession in dbContext.Professions.AsNoTracking() on c.ProfessionId equals profession.ProfessionId
                     join nationality in dbContext.Nationalities.AsNoTracking() on c.NationalityId equals nationality.NationalityId
                     join company in dbContext.Companies.AsNoTracking() on c.CompanyId equals company.CompanyId
                     join createdByUser in dbContext.Users.AsNoTracking() on c.CreatedById equals createdByUser.UserId
                     join createdByUserType in dbContext.UserTypes.AsNoTracking() on createdByUser.UserTypeId equals createdByUserType.UserTypeId
                     join department in dbContext.Departments.AsNoTracking() on createdByUser.DepartmentId equals department.DepartmentId
                     where c.ContactId == id
                     select new
                     {
                         Profession = profession,
                         Nationality = nationality,
                         Company = company,
                         CreatedBy = createdByUser,
                         CreatedByUserType = createdByUserType,
                         Department = department
                     }).First();

                var contactPhones = (from p in dbContext.Phones.AsNoTracking()
                                     join phoneType in dbContext.PhoneTypes.AsNoTracking() on p.PhoneTypeId equals phoneType.PhoneTypeId
                                     where p.ContactId == id
                                     select new
                                     {
                                         phone = p,
                                         phoneType = phoneType
                                     }).ToList();

                var contactEmails = (from e in dbContext.Emails.AsNoTracking()
                                     join phoneType in dbContext.EmailTypes.AsNoTracking() on e.EmailTypeId equals phoneType.EmailTypeId
                                     where e.ContactId == id
                                     select new
                                     {
                                         email = e,
                                         emailType = phoneType
                                     }).ToList();

                var contactNegotiators = (from n in dbContext.ContactNegotiators.AsNoTracking()
                                          join createdByUser in dbContext.Users.AsNoTracking() on n.CreatedById equals createdByUser.UserId
                                          join createdByUserType in dbContext.UserTypes.AsNoTracking() on createdByUser.UserTypeId equals createdByUserType.UserTypeId
                                          join department in dbContext.Departments.AsNoTracking() on createdByUser.DepartmentId equals department.DepartmentId
                                          where n.ContactId == id
                                          select new
                                          {
                                              contactNegotiators = n,
                                              CreatedBy = createdByUser,
                                              CreatedByUserType = createdByUserType,
                                              Department = department
                                          }).ToList();

                var contactAgents = (from agent in dbContext.Agents.AsNoTracking()
                                     join company in dbContext.Companies.AsNoTracking() on agent.CompanyId equals company.CompanyId
                                     join createdByUser in dbContext.Users.AsNoTracking() on agent.CreatedById equals createdByUser.UserId
                                     join createdByUserType in dbContext.UserTypes.AsNoTracking() on createdByUser.UserTypeId equals createdByUserType.UserTypeId
                                     join department in dbContext.Departments.AsNoTracking() on createdByUser.DepartmentId equals department.DepartmentId
                                     where agent.ContactId == id
                                     select new
                                     {
                                         agent = agent,
                                         Company = company,
                                         CreatedBy = createdByUser,
                                         CreatedByUserType = createdByUserType,
                                         Department = department
                                     }).ToList();

            }

            watch.Stop();
            return watch.ElapsedMilliseconds;
        }
    }
}