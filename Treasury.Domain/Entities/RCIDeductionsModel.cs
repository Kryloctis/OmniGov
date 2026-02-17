namespace Treasury.Domain.Entities
{
    public class RCIDeductionsModel
    {
        public int Id { get; set; }
        public int Rcid { get; set; }
        public String Description { get; set; }
        public Decimal Amount { get; set; }
    }
}
