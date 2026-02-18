namespace Treasury.Domain.Entities
{
    public class BiddersModel
    {
        public int Id { get; set; }
        public int TaxpayersId { get; set; }
        public int AuctionId { get; set; }
        public int PaymentCollectionsId { get; set; }
        public string BidderNo { get; set; }
        public int CreatedAt { get; set; }

        public int CreatedBy { get; set; }
    }
}
