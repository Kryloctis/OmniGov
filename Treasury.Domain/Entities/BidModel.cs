namespace Treasury.Domain.Entities
{
    public class BidModel
    {
        public int Id { get; set; }
        public int RptAuctionId { get; set; }
        public int BiddersId { get; set; }
        public string OrdinanceNo { get; set; }
        public DateTime Date { get; set; }
        public decimal BidAmount { get; set; }
        public int CreatedBy { get; set; }
    }
}