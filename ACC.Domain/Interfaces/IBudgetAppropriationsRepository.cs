using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface IBudgetAppropriationsRepository : IRepository<BudgetAppropriationsModel>
    {
        bool BudgetAllotmentExist(int fundID, int FPPId, int? othersFPPId, int allotmentClassID, int generalLedgerAccountId, short year);
        bool BudgetAllotmentExist(int id, int fundID, int FPPId, int? othersFPPId, int allotmentClassID, int generalLedgerAccountId, short year);

        DataTable GetViewRecordsByIds(int fppID, int allotmentClassID, int? othersFPPID, int typeOfFund, int year);
        DataTable GetViewRecordsByIds(int fppID, int allotmentClassID, int? othersFPPID, int typeOfFund, string dateEntry);
        DataTable GetExistedOthersFPPrecordsByFPPID(int fppID,int allotment_classes_id, int funds_id, short year);
        DataTable GetYearsBudgetAppropriations();
        Dictionary<string, string> GetTotalAppropriationBalanceRecord(int budgetAppropirationId);

        Dictionary<string, string> GetRecordByIDs(int budgetAppID, int fppID, int? othersFPPID, int allotmentClassID, int genLedgerAccID);
        Dictionary<string, string> GetViewRecordByIDs(int budgetAppID, int fppID, int? othersFPPID, int allotmentClassID, int genLedgerAccID);
        DataTable GetViewRecordsSAAOB(int fppID, short year);
    }
}
