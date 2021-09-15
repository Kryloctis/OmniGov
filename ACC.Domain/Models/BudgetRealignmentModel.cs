using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class BudgetRealignmentModel
    {
        public int Id { get; set; }

        public DateTime DateEntry { get; set; }

        public string Remarks { get; set; }

        public int Amount { get; set; }
    }
}
