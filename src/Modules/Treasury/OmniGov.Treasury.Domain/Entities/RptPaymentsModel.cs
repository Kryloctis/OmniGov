namespace Treasury.Domain.Entities
{
    public class RptPaymentsModel
    {
        public int Id { get; set; }
        public int PaymentCollectionsId { get; set; }
        public int PostedBy { get; set; }
    }
}
