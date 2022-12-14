namespace ACC.Domain.Models
{
    public class RptPaymentPostsModel
    {
        public int Id { get; set; }
        public int PaymentCollectionsId { get; set; }

        public int PostedBy { get; set; }
    }
}