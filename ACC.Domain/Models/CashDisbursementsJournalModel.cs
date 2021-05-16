using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class CashDisbursementsJournalModel
    {
        public int Id { get; set; }
        public int JevId { get; set; }
        public int DisbursingOfficerId { get; set; }
        public string DVNo { get; set; }
        public DateTime DatePaid { get; set; }
    }
}
