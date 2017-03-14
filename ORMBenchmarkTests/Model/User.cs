using System;

namespace ORMBenchmarkTests.Model
{
    public class User : BaseEntity
    {
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

        public int UserTypeId { get; set; }
        public UserType UserType { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}