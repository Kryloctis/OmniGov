using Budget.Domain.Models;
using OmniGov.Core.Interfaces.Repositories;
using System.Data;

namespace Budget.Domain.Interfaces
{
    public interface ISupplementalAppropriationsRepository : IRepository<SupplementalAppropriationsModel>
    {
        bool Insert(List<SupplementalAppropriationsModel> supplementalAppropriationsModelList, int budgetAppropriationId);

        bool DeleteByBudgerAppropriationId(int budgetAppropriationId);

        DataTable GetRecordsByBudgetAppropriationId(int budgetAppropriationsId);

        DataTable GetRecordsByBudgetAppropriationIdDateEntry(int budgetAppropriationId, DateTime dateEntry);

        decimal GetSumSupplementalAppropriationsBy_BudgetAppropriationsId(int budgetAppropriationId);

        decimal GetSumSupplementalAppropriationsBy_BudgetAppropriationsId_DateEntry(int budgetAppropriationId, DateTime dateEntry);

        decimal GetSumSupplementalAppropriationsBy_FppId_SubFPPId_DateEntry_AllotmentClassId_IsContinuing(string fppId, string subFPPId, int fundId, DateTime dateEntry, int allotmentClassId, Byte isContinuing);
    }
}
