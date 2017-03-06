using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORMBenchmarkTests.Model
{
    public class AttributeValues
    {
        public int AttributeValuesId { get; set; }

        public int MinIntAttributeA { get; set; }
        public int MaxIntAttributeA { get; set; }
        public int? MinIntAttributeB { get; set; }
        public int? MaxIntAttributeB { get; set; }

        public Guid MinGuidAttributeA { get; set; }
        public Guid MaxGuidAttributeA { get; set; }
        public Guid? MinGuidAttributeB { get; set; }
        public Guid? MaxGuidAttributeB { get; set; }

        public String MinStringAttributeA { get; set; }
        public String MaxStringAttributeA { get; set; }
        public String MinStringAttributeB { get; set; }
        public String MaxStringAttributeB { get; set; }

        public decimal MinDecimalAttributeA { get; set; }
        public decimal MaxDecimalAttributeA { get; set; }
        public decimal? MinDecimalAttributeB { get; set; }
        public decimal? MaxDecimalAttributeB { get; set; }

        public DateTime MinDateTimeAttributeA { get; set; }
        public DateTime MaxDateTimeAttributeA { get; set; }
        public DateTime? MinDateTimeAttributeB { get; set; }
        public DateTime? MaxDateTimeAttributeB { get; set; }

        public int MinPriceId { get; set; }
        [ForeignKey("MinPriceId")]
        public Price MinPrice { get; set; }

        public int MaxPriceId { get; set; }
        [ForeignKey("MaxPriceId")]
        public Price MaxPrice { get; set; }
    }
}