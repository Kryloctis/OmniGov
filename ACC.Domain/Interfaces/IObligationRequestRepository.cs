using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface IObligationRequestRepository : IRepository<ObligationRequestModel>
    {
        decimal GetTotalObligationAmountByYear(int fundID, int fppID, int? othersFPPID, int allotmentClassID, int accountID, DateTime dateRequested);

        bool ObligationNumExist(string obligationNum);

        bool ObligationNumExist(int id, string obligationNum);

        bool AccountExist(int accountId, DateTime dateRequested);

        bool AccountExist(int id, int accountId, DateTime dateRequested);

        bool BulkInsert(List<ObligationRequestModel> obligationRequestModelList);

        Dictionary <string, string> GetRecordByObligation(string obligationNo);

        DataTable GetRecordsByObligation(string obligationNo);
    }
}
