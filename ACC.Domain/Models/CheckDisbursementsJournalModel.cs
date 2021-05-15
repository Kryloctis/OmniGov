using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class CheckDisbursementsJournalModel
    {
        public int Id { get; set; }
        public int JevId { get; set; }
        public DateTime CheckDate { get; set; }
        public string CheckNo { get; set; }
        public string DVNo { get; set; }
        public string RCINo{ get; set; }

    }
}
