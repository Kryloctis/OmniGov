using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface IObligationRequestRepository : IRepository<ObligationRequestModel>
    {
        Dictionary<string, string> GetViewRecordByObligationNum(string obligationNum);
        Dictionary<string, string> GetTotalObligationAmount(int fundID, int fppID, int? otherFPPID, int allotmentClassesID, int general_ledger_accounts_id, short year);

        bool ObligationNumExist(string obligationNum);
        bool ObligationNumExist(int id, string obligationNum);
    }
}
