using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface IObligationRequestRepository : IRepository<ObligationRequestModel>
    {
        bool ObligationRequestNoExist(string obligationNo);

        bool ObligationRequestNoExist(int Id, string obligationNo);

        bool Insert(ObligationRequestModel entity, List<ObligationAccountModel> obligationAccountModels);

        bool Update(ObligationRequestModel entity, List<ObligationAccountModel> obligationAccountModels);

        bool Delete(int obligationRequestId);

        //SAAOB and SAAOBB
        DataTable GetViewRecords(int budgetAppropriationId, DateTime dateRequested);

        //DASHBOARD
        DataTable GetViewRecordsFPPIdFundIdDateEntry(int fppId, int fundId, DateTime dateIssued);
        decimal GetSumObligations(string fppId, int fundId, DateTime dateIssued, int allotmentClassId, byte isContinuing);

        DataTable GetViewRecordsById(int Id);

        DataTable GetViewRecordsByBudgetAppropriationId(int budgetAppropriationId);
    }
}
