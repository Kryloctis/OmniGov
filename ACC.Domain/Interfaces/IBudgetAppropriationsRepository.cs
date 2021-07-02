using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface IBudgetAppropriationsRepository : IRepository<BudgetAppropriationsModel>
    {
        Dictionary<string, string> GetViewRecordByIdDateEntry(int budgetAppropriationId, DateTime dateEntry);

        Dictionary<string, string> GetViewRecordByID(int budgetAppId);

        DataTable GetViewRecords(int fundId, DateTime dateEntry, short year, byte isContinuing, byte isSpecial);

        DataTable GetViewRecordsByIds(BudgetAppropriationsModel entity);

        DataTable GetViewRecordsByIdsSearch(BudgetAppropriationsModel entity, string searchTxt);

        DataTable GetViewRecordsByIdsYear(BudgetAppropriationsModel entity);

        DataTable GetHeaderOthersFPP(int fppID, int allotment_classes_id, int funds_id, short year);



       //Validations

        bool BudgetAppropriationExist(int fundId, int fppId, int? othersFPPId, int allotmentClassId, int generalLedgerAccountId, short year, string remarks);

        bool BudgetAppropriationExist(int id, int fundId, int fppId, int? othersFPPId, int allotmentClassId, int generalLedgerAccountId, short year, string remarks);

        bool BudgetAppropriationContinuing(int fundId, int fppId, int? othersFPPId, int allotmentClassId, int generalLedgerAccountId);

        bool BudgetAppropriationContinuing(int id, int fundId, int fppId, int? othersFPPId, int allotmentClassId, int generalLedgerAccountId);

    }
}
