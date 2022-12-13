using System;

namespace ACC.Domain.Models
{
    public class CashReceiptsJournalModel
    {
        public int Id { get; set; }
        public int JevId { get; set; }
        public byte CollectingOfficerId { get; set; }
        public string RCDNo { get; set; }
        public string ORNo { get; set; }
        public DateTime ORDate { get; set; }
    }
}