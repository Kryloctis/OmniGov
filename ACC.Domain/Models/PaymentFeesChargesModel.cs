namespace ACC.Domain.Models
{
    public class PaymentFeesChargesModel
    {
        public int Id { get; set; }
        public PaymentCollectionsModel PaymentCollectionsModel { get; set; }
        public OtherPaymentRatesModel OtherPaymentRatesModel { get; set; }
        public int Unit { get; set; }
        public decimal SubTotal { get; set; }
    }
}