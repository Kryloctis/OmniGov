using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class RealignmentsModel
    {
        public int Id { get; set; }
        public int BudgetAppropriationsId { get; set; }
        public decimal Amount { get; set; }
    }
}