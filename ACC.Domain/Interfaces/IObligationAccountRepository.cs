using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface IObligationAccountRepository : IAccRepository<ObligationAccountModel>
    {
        bool DeleteByObligationRequestId(int ObligationRequestId);

        bool CheckObligationRequestExistByBudgetAppropriationId(int budgetAppropriationId);

        int ObligationsRecordCount();
    }
}
