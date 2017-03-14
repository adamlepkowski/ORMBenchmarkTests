using System;
using System.Collections.Generic;

namespace ORMBenchmarkTests.Model
{
    public class Company : BaseEntity
    {
        public int IntA { get; set; }

        public int? IntB { get; set; }

        public bool BooleanAttributeAttributeA { get; set; }

        public bool? BooleanAttributeB { get; set; }

        public string StringAttributeA { get; set; }

        public string StringAttributeB { get; set; }

        public DateTime DataTimeAttributeA { get; set; }

        public DateTime? DataTimeAttributeB { get; set; }

        public decimal DecimalAttributeA { get; set; }

        public decimal? DecimalAttributeB { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();

    }
}