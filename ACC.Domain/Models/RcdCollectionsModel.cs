namespace ACC.Domain.Models
{
    internal class RcdCollectionsModel
    {
        internal int Id { get; set; }
        internal RcdModel RcdId { get; set; }
        internal PaymentCollectionsModel PaymentCollectionsModel { get; set; }
    }
}