using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class AllotmentReleaseModel
    {
        public int ID { get; set; }
        public int BudgetAppropriationsID { get; set; }
        public string ARONumber { get; set; }
        public string Purpose { get; set; }
        public DateTime DateIssued { get; set; }
        public decimal amount { get; set; }
    }
}
