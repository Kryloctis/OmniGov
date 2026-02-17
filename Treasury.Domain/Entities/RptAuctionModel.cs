namespace Treasury.Domain.Entities
{
    public class RptAuctionModel
    {
        public int Id { get; set; }
        public int RptPropertiesId { get; set; }

        public int AuctionId { get; set; }

        public int CreatedBy { get; set; }
    }
}
