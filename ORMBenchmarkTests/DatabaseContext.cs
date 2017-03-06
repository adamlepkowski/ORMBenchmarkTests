using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ORMBenchmarkTests.Model;

namespace ORMBenchmarkTests
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("ORMBenchmarkTests")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Contact>()
                .Property(f => f.ContactId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }

        public DbSet<Company> Companies{ get; set; }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Profession> Professions { get; set; }

        public DbSet<Nationality> Nationalities { get; set; }

        public DbSet<Email> Emails { get; set; }

        public DbSet<EmailType> EmailTypes { get; set; }
        
        public DbSet<Phone> Phones { get; set; }

        public DbSet<PhoneType> PhoneTypes { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<ContactNegotiator> ContactNegotiators { get; set; }

        public DbSet<Agent> Agents { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<AttributeValues> AttributeValues { get; set; }

        public DbSet<Price> Prices { get; set; }

        public DbSet<CurrencyDefinition> CurrencyDefinitions { get; set; }
    }
}