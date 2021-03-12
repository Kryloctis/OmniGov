using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface IBudgetAppropriationsRepository : IRepository<BudgetAppropriationsModel>
    {
        bool BudgetAllotmentExist(int FPPId, int? othersFPPId, int allotmentClassID, int generalLedgerAccountId);
        bool BudgetAllotmentExist(int id, int FPPId, int? othersFPPId, int allotmentClassID, int generalLedgerAccountId);
    }
}
