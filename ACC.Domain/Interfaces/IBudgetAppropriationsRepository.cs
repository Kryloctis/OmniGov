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

        //SAOOBB
        DataTable GetViewRecords(int fundId, DateTime dateEntry, byte isSpecial);

        //SAAOB
        DataTable GetViewRecords(int fundId, DateTime dateEntry, short year, byte isContinuing, byte isSpecial);

        //DASHBOARD
        DataTable GetViewRecordsFPPIdFundIdDateEntry(int fppId, int fundId, DateTime dateEntry);

        decimal GetBudgetAppropriations(string fppId, int fundId, DateTime dateEntry, int allotment_classes_id, byte isContinuing);


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
