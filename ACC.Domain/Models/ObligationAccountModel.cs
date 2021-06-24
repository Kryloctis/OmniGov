using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class ObligationAccountModel
    {
        public int Id { get; set; }
        public int ObligationRequestId { get; set; }
        public int BudgetAppropriationId {get; set;}
        public decimal Amount { get; set; }
    }
}
