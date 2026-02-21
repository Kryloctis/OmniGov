namespace OmniGov.Treasury.Domain.Entities
{
    public class RptTaxRatesModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
    }
}
