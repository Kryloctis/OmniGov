using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class BudgetAppropriationsModel
    {
        public int ID { get; set; }
        public int FundsId { get; set; }
        public int FunctionProgramProjectId { get; set; }
        public int? OthersFPPId { get; set; }
        public int AllotmentClassesId { get; set; }
        public int GeneralLedgerAccountsId { get; set; }
        public short Year { get; set; }
        public DateTime DateEntry { get; set; }
        public decimal amount { get; set; }
    }
}
