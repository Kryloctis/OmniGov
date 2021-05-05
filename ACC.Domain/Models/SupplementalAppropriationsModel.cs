using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class SupplementalAppropriationsModel
    {
        public int ID { get; set; }
        public int BudgetAppropriationID { get; set; }
        public DateTime date_entry { get; set; }
        public decimal amount { get; set; }
        public string remarks { get; set; }
    }
}
