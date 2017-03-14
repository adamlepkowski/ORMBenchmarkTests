namespace ORMBenchmarkTests.Model
{
    public class Price : BaseEntity
    {
        public int CurrencyDefinitionId { get; set; }

        public CurrencyDefinition CurrencyDefinition { get; set; }

        public decimal Value { get; set; }
    }
}