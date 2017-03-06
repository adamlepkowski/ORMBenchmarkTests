using System;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Dapper;
using ORMBenchmarkTests.Model;

namespace ORMBenchmarkTests.Tests
{
    public class DapperContactWithManyTestScenario : ITestScenario
    {
        private readonly SqlConnection _sqlConnection;
        public string Name { get; private set; }

        public DapperContactWithManyTestScenario(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
            Name = "Stored Procedure Dapper - with multiple 1:N relationships";
        }

        public long GetEntity(int id)
        {
            var watch = new Stopwatch();
            watch.Start();

            using (var multi = _sqlConnection.QueryMultiple("GetContactByIdDapperWithMany", commandType: CommandType.StoredProcedure, param: new { ContactId = id }))
            {
                var contactItem = multi.Read<Contact>(new Type[]
                     {
                        typeof (Contact),typeof(Profession),typeof(Nationality)
                        ,typeof(Company),typeof(User), typeof(UserType),typeof(Department)
                        ,typeof (AttributeValues), typeof (Price), typeof (CurrencyDefinition)
                        , typeof (Price), typeof (CurrencyDefinition)
                     }, (objects) =>
                     {
                         var contact = objects[0] as Contact;
                         var profession = objects[1] as Profession;
                         var nationality = objects[2] as Nationality;
                         var company = objects[3] as Company;
                         var user = objects[4] as User;
                         var userType = objects[5] as UserType;
                         var userDepartment = objects[6] as Department;
                         var attributeValue = objects[7] as AttributeValues;
                         var priceMin = objects[8] as Price;
                         var priceMinCurrency = objects[9] as CurrencyDefinition;
                         var priceMax = objects[10] as Price;
                         var priceMaxCurrency = objects[11] as CurrencyDefinition;

                         contact.Profession = profession;
                         contact.Nationality = nationality;
                         contact.Company = company;
                         user.UserType = userType;
                         user.Department = userDepartment;
                         contact.CreatedBy = user;
                         contact.AttributeValues = attributeValue;
                         attributeValue.MinPrice = priceMin;
                         attributeValue.MinPrice.CurrencyDefinition = priceMinCurrency;
                         attributeValue.MaxPrice = priceMax;
                         attributeValue.MaxPrice.CurrencyDefinition = priceMaxCurrency;

                         return contact;
                     }).FirstOrDefault();

                var contactPhones = multi.Read<Phone>(new Type[]
                    {
                        typeof (Phone),typeof(PhoneType)
                    }, (objects) =>
                    {
                        var phone = objects[0] as Phone;
                        var phoneType = objects[1] as PhoneType;
                        phone.PhoneType = phoneType;

                        return phone;
                    }).ToList();


                contactPhones.ForEach(x => contactItem.Phones.Add(x));

                var contactEmails = multi.Read<Email>(new Type[]
                   {
                        typeof (Email),typeof(EmailType)
                   }, (objects) =>
                   {
                       var email = objects[0] as Email;
                       var emailType = objects[1] as EmailType;
                       email.EmailType = emailType;

                       return email;
                   }).ToList();

                contactEmails.ForEach(x => contactItem.Emails.Add(x));

                var contactNegotiators = multi.Read<ContactNegotiator>(new Type[]
                  {
                        typeof (ContactNegotiator),typeof(User),typeof(UserType),typeof(Department)
                  }, (objects) =>
                  {
                      var contactNegotiator = objects[0] as ContactNegotiator;
                      var user = objects[1] as User;
                      var userType = objects[2] as UserType;
                      var userDepartment = objects[3] as Department;

                      user.UserType = userType;
                      user.Department = userDepartment;
                      contactNegotiator.CreatedBy = user;

                      return contactNegotiator;
                  }).ToList();

                contactNegotiators.ForEach(x => contactItem.ContactNegotiators.Add(x));

                var contactAgents = multi.Read<Agent>(new Type[]
              {
                        typeof (Agent),typeof(User),typeof(UserType),typeof(Department),typeof(Company)
              }, (objects) =>
              {
                  var agent = objects[0] as Agent;
                  var user = objects[1] as User;
                  var userType = objects[2] as UserType;
                  var userDepartment = objects[3] as Department;
                  var company = objects[4] as Company;

                  user.UserType = userType;
                  user.Department = userDepartment;
                  agent.CreatedBy = user;
                  agent.Company = company;

                  return agent;
              }).ToList();

                contactAgents.ForEach(x => contactItem.Agents.Add(x));
            }

            watch.Stop();
            return watch.ElapsedMilliseconds;
        }
    }
}