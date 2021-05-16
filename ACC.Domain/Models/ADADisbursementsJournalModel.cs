using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class ADADisbursementsJournalModel
    {
        public int Id { get; set; }
        public int JevId { get; set; }
        public string ADANumber { get; set; }
        public string DVNo { get; set; }
    }
}
