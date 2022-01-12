using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;

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

        decimal GetSumObligationsByAppropriationId(int appropriationId, DateTime dateRequested);

        decimal GetSumObligations(string fppId, string subFPPId, int fundId, DateTime dateIssued, int allotmentClassId, byte isContinuing);

        decimal GetSumObligationsByBudgetAppropriationAndStatus(int budgetAppropriationsId);

        decimal GetSumObligationsById(int obligationRequestId);

        Dictionary<string, string> GetViewRecordById(int Id);

        DataTable GetViewRecordsById(int Id);

        DataTable GetViewRecordsByBudgetAppropriationId(int budgetAppropriationId);

        DataTable GetViewRecordsBySearchAndStatus(string searchText, string status, int fundId, int allotmentClassId, DateTime dateOfRequest);

        bool SetObligationRequestStatus(int obligationRequestId, string status, string dissaprovalMessage = null);

        string GetObligationRequestStatus(int obligationRequestId);

        string GetLeastAllotmentReleaseNumber();
    }
}
