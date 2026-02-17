namespace Treasury.Domain.Entities
{
    public class OtherPaymentRatesModel
    {
        public int Id { get; set; }
        public int TaxTypeID { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public int StartingYear { get; set; }
        public bool IsRateEditable { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
