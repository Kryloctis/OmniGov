using System;

namespace ACC.Domain.Models
{
    public class BudgetAppropriationsModel
    {
        public int Id { get; set; }
        public int FundsId { get; set; }
        public int FunctionProgramProjectId { get; set; }
        public int? OthersFPPId { get; set; }
        public int AllotmentClassesId { get; set; }
        public int GeneralLedgerAccountsId { get; set; }
        public short Year { get; set; }
        public DateTime DateEntry { get; set; }
        public decimal Amount { get; set; }
        public bool Continuing { get; set; }
        public string Remarks { get; set; }
    }
}