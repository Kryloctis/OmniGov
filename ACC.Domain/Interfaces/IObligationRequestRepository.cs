using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IObligationRequestRepository : IAccRepository<ObligationRequestModel>
    {
        DataTable GetRecords(string srchKey,
                            string status,
                            DateTime dtFrom,
                            DateTime dtTo,
                            int rowLimit);

        DataTable GetViewRecords(int budgetAppropriationId, DateTime dateRequested);

        DataTable GetViewRecordsById(int Id);

        DataTable GetViewRecordsByBudgetAppropriationId(int budgetAppropriationId);

        DataTable GetViewRecordsBySearchAndStatus(string searchText,
                                                string status,
                                                int fundId,
                                                int allotmentClassId,
                                                DateTime dateOfRequest);

        Dictionary<string, string> GetViewRecordById(int Id);

        decimal GetSumObligationsByAppropriationId(int appropriationId, DateTime dateRequested);

        decimal GetSumObligations(string fppId, string subFPPId, int fundId, DateTime dateIssued, int allotmentClassId, byte isContinuing);

        decimal GetSumObligationsByBudgetAppropriationAndStatus(int budgetAppropriationsId);

        decimal GetSumObligationsById(int obligationRequestId);

        bool ObligationRequestNoExist(string obligationNo);

        bool ObligationRequestNoExist(int Id, string obligationNo);

        bool Insert(ObligationRequestModel entity, List<ObligationAccountModel> obligationAccountModels);

        bool Update(ObligationRequestModel entity, List<ObligationAccountModel> obligationAccountModels);

        bool Delete(int obligationRequestId);

        bool SetObligationRequestStatus(int obligationRequestId, string status, string dissaprovalMessage = null);

        string GetObligationRequestStatus(int obligationRequestId);

        string GetLeastOblgtnNo();
    }
}