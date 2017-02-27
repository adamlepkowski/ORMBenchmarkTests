namespace ORMBenchmarkTests.Model
{
    public class Price
    {
        public int PriceId { get; set; }

        public int CurrencyDefinitionId { get; set; }

        public CurrencyDefinition CurrencyDefinition { get; set; }

        public decimal Value { get; set; }
    }
}