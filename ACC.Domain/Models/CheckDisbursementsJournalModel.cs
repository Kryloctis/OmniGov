using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class CheckDisbursementsJournalModel
    {
        public int Id { get; set; }
        public int JevId { get; set; }
        public string CheckNumber { get; set; }
        public string Payee { get; set; }
    }
}
