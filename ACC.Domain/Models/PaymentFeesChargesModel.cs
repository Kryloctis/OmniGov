namespace ACC.Domain.Models
{
    public class PaymentFeesChargesModel
    {
        public int Id { get; set; }
        public int PaymentCollectionsId{ get; set; }
        public int OtherPaymentRatesId { get; set; }
        public int Unit { get; set; }
        public decimal SubTotal { get; set; }
    }
}