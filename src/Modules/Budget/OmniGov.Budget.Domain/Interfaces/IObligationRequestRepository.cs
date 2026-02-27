using OmniGov.Budget.Domain.Entities;
using OmniGov.Core.Interfaces.Repositories;
using System.Data;

namespace OmniGov.Budget.Domain.Interfaces
{
    public interface IObligationRequestRepository : IRepository<ObligationRequestModel>
    {
        DataTable GetRecords(string srchKey,
                            string status,
                            DateTime dtFrom,
                            DateTime dtTo,
                            int rowLimit);

        DataTable GetViewRecords(int budgetAppropriationId, DateTime dateRequested);

        DataTable GetViewRecordsById(int Id);

        DataTable GetViewRecordsBySearchAndStatus(string searchText,
                                                string status,
                                                int fundId,
                                                int allotmentClassId,
                                                DateTime dateOfRequest);

        Dictionary<string, string> GetViewRecordById(int Id);

        decimal GetSumObligationsByAppropriationId(int appropriationId, DateTime dateRequested);

        decimal GetSumObligations(string fppId, string subFPPId, int fundId, DateTime dateIssued, int allotmentClassId, byte isContinuing);

        decimal GetSumObligationsByBudgetAppropriationAndStatus(int budgetAppropriationsId);

        bool Insert(ObligationRequestModel entity, List<ObligationAccountModel> obligationAccountModels);

        bool Update(ObligationRequestModel entity, List<ObligationAccountModel> obligationAccountModels);

        bool DeleteById(int obligationRequestId);

        public string GetTransactionNo(int year);
    }
}