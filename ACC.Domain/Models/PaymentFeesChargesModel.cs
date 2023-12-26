namespace ACC.Domain.Models
{
    internal class PaymentFeesChargesModel
    {
        public PaymentCollectionsModel PaymentCollectionsModel { get; set; }
        public OtherPaymentRatesModel OtherPaymentRatesModel { get; set; }
        public int Unit { get; set; }
        public decimal SubTotal { get; set; }
    }
}