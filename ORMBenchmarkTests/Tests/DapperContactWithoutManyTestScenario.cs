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
    public class DapperContactWithoutManyTestScenario : ITestScenario
    {
        private readonly SqlConnection _sqlConnection;
        public string Name { get; private set; }

        public DapperContactWithoutManyTestScenario(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
            Name = "Stored Procedure Dapper - without multiple 1:N relationships";
        }

        public long GetEntity(int id)
        {
            var watch = new Stopwatch();
            watch.Start();

            var contactItem = _sqlConnection.Query<Contact>("GetContactByIdDapperWithoutMany",
                   new Type[]
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
                   }, commandType: CommandType.StoredProcedure,
                   param: new { ContactId = id }).FirstOrDefault();


            watch.Stop();
            return watch.ElapsedMilliseconds;
        }
    }
}