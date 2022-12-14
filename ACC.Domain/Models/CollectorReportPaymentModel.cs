namespace ACC.Domain.Models
{
    public class CollectorReportPaymentModel
    {
        public int Id { get; set; }
        public int CollectorsReportId { get; set; }
        public int PaymentCollectionsId { get; set; }
    }
}