using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class BudgetRealignmentModel
    {
        public int RealignmentId { get; set; }
        public int BudgetAppropriationId { get; set; }
        public ushort FromBudgetAppropriationId { get; set; }
        public int ToBudgetAppropriationId { get; set; }
        public DateTime DateEntry { get; set; }
        public string Remarks { get; set; }
        public Decimal Amount { get; set; }
    }
}
