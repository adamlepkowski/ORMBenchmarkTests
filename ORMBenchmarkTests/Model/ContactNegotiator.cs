using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORMBenchmarkTests.Model
{
    public class ContactNegotiator : BaseEntity
    {
        public int ContactId { get; set; }

        public Contact Contact { get; set; }

        public int CreatedById { get; set; }
        [ForeignKey("CreatedById")]
        public User CreatedBy { get; set; }

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
    }
}