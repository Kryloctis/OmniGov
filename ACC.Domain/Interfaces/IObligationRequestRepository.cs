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

        DataTable GetViewRecordsByIdsAndMonthAndYear(int fppId, int? otherFPPId, int fundId, int allotmentClassId, int accountId, byte month, short year);

        Dictionary<string, string> GetViewRecordsById(int obligationId);
    }
}
