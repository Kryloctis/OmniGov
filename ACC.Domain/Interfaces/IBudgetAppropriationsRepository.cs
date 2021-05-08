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

        DataTable GetViewRecordsByIds(int fppID, int allotmentClassID, int? othersFPPID, int typeOfFund, DateTime dateEntry);

        DataTable GetYearsBudgetAppropriations();

        Dictionary<string, string> GetViewRecordByIDs(int budgetAppId, int fppId, int? othersFPPId, int allotmentClassId, int genLedgerAccId);

        DataTable GetViewRecordsSAAOB(int fppID, short year);

        //Budget Appropriations Display

        DataTable GetViewRecordsByIds(BudgetAppropriationsModel entity);

        DataTable GetHeaderOthersFPP(int fppID, int allotment_classes_id, int funds_id, short year);

    }
}
