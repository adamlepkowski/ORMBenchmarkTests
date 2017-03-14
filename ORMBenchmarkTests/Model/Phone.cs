namespace ORMBenchmarkTests.Model
{
    public class Phone : BaseEntity
    {
        public string PhoneNumber { get; set; }

        public int PhoneTypeId { get; set; }

        public PhoneType PhoneType { get; set; }

        public int ContactId { get; set; }

        public Contact Contact { get; set; }
    }
}