using System;

namespace ACC.Domain.Models
{
    public class GeneralCollectionsModel
    {
        public int Id { get; set; }
        public string RcdNo { get; set; }
        public DateTime Rcddate { get; set; }
        public int FundId { get; set; }
        public int Userid { get; set; }
    }
}