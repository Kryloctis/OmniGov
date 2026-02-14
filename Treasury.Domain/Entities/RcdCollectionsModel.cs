namespace Treasury.Domain.Entities
{
    public class RcdCollectionsModel
    {
        public int Id { get; set; }
        public RcdModel RcdModel { get; set; }
        public PaymentCollectionsModel PaymentCollectionsModel { get; set; }
    }
}