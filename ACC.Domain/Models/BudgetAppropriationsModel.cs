using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class BudgetAppropriationsModel
    {
        int ID { get; set; }
        int FunctionProgramProjectId { get; set; }
        int OthersFPPId { get; set; }
        int AllotmentClassesId { get; set; }
        int GeneralLedgerAccountsId { get; set; }
        decimal amount { get; set; }
    }
}
