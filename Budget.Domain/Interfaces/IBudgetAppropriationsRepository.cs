using Budget.Domain.Models;
using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Core.Interfaces.Services;
using OmniGov.Core.Interfaces.Factories;
using System.Data;

namespace Budget.Domain.Interfaces
{
    public interface IBudgetAppropriationsRepository : IRepository<BudgetAppropriationsModel>
    {
        // bool methods
        bool BudgetAppropriationContinuing(int fundId, int fppId, int? othersFPPId, int allotmentClassId, int generalLedgerAccountId);

        bool BudgetAppropriationContinuing(int id, int fundId, int fppId, int? othersFPPId, int allotmentClassId, int generalLedgerAccountId);

        bool BudgetAppropriationExist(int fundId, int fppId, int? othersFPPId, int allotmentClassId, int generalLedgerAccountId, short year, string remarks);

        bool BudgetAppropriationExist(int id, int fundId, int fppId, int? othersFPPId, int allotmentClassId, int generalLedgerAccountId, short year, string remarks);

        bool Insert(BudgetAppropriationsModel budgetAppropriationsModel, List<SupplementalAppropriationsModel> supplementalAppropriationsModelList);

        // DataTable methods
        DataTable GetHeaderOthersFPP(string fppID, int allotment_classes_id, int funds_id, short year);

        DataTable GetHeaderOthersFPP(int fppID, int allotment_classes_id, int funds_id, short year);

        DataTable GetViewRecords(int fundId, DateTime dateEntry, byte isSpecial);

        DataTable GetViewRecords(int fundId, DateTime dateEntry, short year, byte isContinuing, byte isSpecial);

        DataTable GetViewRecordsByFPPIdAndFundIdAndAllotmentClassIdAndDateEntry(string fppId, int? subFPPId, int funds_id, int allotment_class_id, DateTime date_entry);

        DataTable GetViewRecordsByFPPIdAndFundIdAndAllotmentClassIdAndDateEntryAndBudgetAppropriationId(string fppId, int? subFPPId, int funds_id, int allotment_class_id, DateTime date_entry, int budget_id);

        DataTable GetViewRecords(int fppId, int? subFppId, int alltmntClssId, int fundId);

        DataTable GetViewRecordsByIdsSearch(BudgetAppropriationsModel entity, string searchTxt);

        DataTable GetViewRecordsByIdsYear(BudgetAppropriationsModel entity);

        DataTable GetGenLdgrAccs(int fppId, int? othersFppId, int allotmentClassId, string searchKey);

        // decimal methods
        decimal GetSumBudgetAppropriations(string fppId, string subFPPId, int fundId, DateTime dateEntry, int allotment_classes_id, byte isContinuing);

        // Dictionary methods
        Dictionary<string, string> GetViewRecordByIdDateEntry(int budgetAppropriationId, DateTime dateEntry);

        Dictionary<string, string> GetViewRecordByID(int budgetAppId);

        // string methods
        string GetBudgetIdByGeneralLedgerId(string generalLedgerId);
    }
}
