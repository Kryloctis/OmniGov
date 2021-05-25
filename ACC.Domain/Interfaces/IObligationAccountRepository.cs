using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface IObligationAccountRepository : IRepository<ObligationAccountModel>
    {
        bool DeleteByObligationRequestId(int ObligationRequestId);

        int ObligationsRecordCount();
    }
}
