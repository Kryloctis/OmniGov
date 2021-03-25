using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class CashReceiptsJournalModel
    {
        public int Id { get; set; }
        public int JevId { get; set; }
        public byte CollectingOfficerId { get; set; }
        public string RCDNumber { get; set; }
    }
}
