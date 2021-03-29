using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface IBudgetAppropriationsRepository : IRepository<BudgetAppropriationsModel>
    {
        bool BudgetAllotmentExist(int FPPId, int? othersFPPId, int allotmentClassID, int generalLedgerAccountId);
        bool BudgetAllotmentExist(int id, int FPPId, int? othersFPPId, int allotmentClassID, int generalLedgerAccountId);

        DataTable GetViewRecords();
        DataTable GetViewRecordsBySearch(string searchTxt);
        DataTable GetViewRecordsByIds(int fppID, int allotmentClassID, int? othersFPPID, int typeOfFund, int year);
        DataTable GetViewRecordsFPPWithBudgetAppropriations();
        DataTable GetExistedOthersFPPrecordsByFPPID(int fppID,int allotment_classes_id, int funds_id, Int16 year);
        DataTable GetYearsBudgetAppropriations();
        Dictionary<string, string> GetTotalAppropriationBalanceRecord(int budgetAppropirationId);

        Dictionary<string, string> GetRecordByIDs(int budgetAppID, int fppID, int? othersFPPID, int allotmentClassID, int genLedgerAccID);
        Dictionary<string, string> GetViewRecordByIDs(int budgetAppID, int fppID, int? othersFPPID, int allotmentClassID, int genLedgerAccID);
    }
}
