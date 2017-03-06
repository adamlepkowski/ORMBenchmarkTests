using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORMBenchmarkTests.Model
{
    public class Contact
    {
        public int ContactId { get; set; }

        public int IntA { get; set; }

        public int? IntB { get; set; }

        public bool BooleanAttributeA { get; set; }

        public bool? BooleanAttributeB { get; set; }

        public string StringAttributeA { get; set; }

        public string StringAttributeB { get; set; }

        public DateTime DataTimeAttributeA { get; set; }

        public DateTime? DataTimeAttributeB { get; set; }

        public decimal DecimalAttributeA { get; set; }

        public decimal? DecimalAttributeB { get; set; }

        public int ProfessionId { get; set; }

        public virtual Profession Profession { get; set; }

        public int? NationalityId { get; set; }

        public virtual Nationality Nationality { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public int CreatedById { get; set; }

        [ForeignKey("CreatedById")]
        public User CreatedBy { get; set; }

        public int AttributeValuesId { get; set; }
        public AttributeValues AttributeValues { get; set; }

        public virtual ICollection<Email> Emails { get; set; } = new List<Email>();

        public virtual ICollection<Phone> Phones { get; set; } = new List<Phone>();

        public virtual ICollection<ContactNegotiator> ContactNegotiators { get; set; } = new List<ContactNegotiator>();

        public virtual ICollection<Agent> Agents { get; set; } = new List<Agent>();
    }
}