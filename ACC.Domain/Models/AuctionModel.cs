using System;


namespace ACC.Domain.Models
{
    public class AuctionModel
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public int CreatedBy { get; set; }
    }
}
