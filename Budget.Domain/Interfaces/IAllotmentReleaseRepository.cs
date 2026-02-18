using Budget.Domain.Models;
using OmniGov.Core.Interfaces.Repositories;
using System.Data;

namespace Budget.Domain.Interfaces
{
    public interface IAllotmentReleaseRepository : IRepository<AllotmentReleaseModel>
    {
        bool Insert(AllotmentReleaseModel entity, List<AllotmentAccountModel> listAllotmentAccount);

        bool Update(AllotmentReleaseModel entity, List<AllotmentAccountModel> listAllotmentAccount);

        bool Delete(int allotmentReleaseId);

        bool AllotmentReleaseNoExist(string allotmentReleaseNo, short year);

        bool AllotmentReleaseNoExist(int Id, string allotmentReleaseNo, short year);

        bool AllotmentReleaseExist(int budgetAppropriationId, DateTime dateIssued);

        bool AllotmentReleaseExist(int Id, int budgetAppropriationId, DateTime dateIssued);

        decimal GetTotalAllotmentReleaseById(int allotmentReleaseId);

        DataTable GetViewRecords();

        DataTable GetViewRecordsBySearch(int fundId, int AllotmentClassId, DateTime dateIssued, string searchText);

        DataTable GetViewRecordsByBudgetAppropriationIdDateIssued(int budgetAppropriationId, DateTime dateIssued);

        DataTable GetViewRecordsByBudgetAppropriationId(int budgetAppropriationId);

        DataTable GetViewRecordsById(int Id);

        //DASHBOARD SUMMARY
        decimal GetSumAllotments(int budgetAppropriationId, DateTime dateIssued);

        //DASHBOARD DETAILED
        decimal GetSumAllotments(string fppId, string subFPPId, int fundId, DateTime dateIssued, int allotmentClassId, byte isContinuing);

        string GetLeastAllotmentReleaseNumber();

        DataTable GetViewRecords(int fppId, int? othersFppId, int allotmentClssId, string searchKey);

        DataTable GetViewRecords(int id);
    }
}
