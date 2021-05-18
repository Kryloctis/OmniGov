using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface IBudgetAppropriationsRepository : IRepository<BudgetAppropriationsModel>
    {
        DataTable GetYearsBudgetAppropriations();

        Dictionary<string, string> GetViewRecordByID(int budgetAppId);

        DataTable GetViewRecordsSAAOB(int fppID, short year);

        Dictionary<string, string> GetViewRecord(int fppId, int? othersFPPId, int fundsId, int allotmentClassId, int generalLedgerAccountId, DateTime dateEntry, short year);


        //Budget Appropriations Display

        DataTable GetViewRecordsByIds(BudgetAppropriationsModel entity);

        DataTable GetHeaderOthersFPP(int fppID, int allotment_classes_id, int funds_id, short year);


        DataTable GetViewRecords();


        #region Validations

        bool BudgetAppropriationExist(int fundId, int fppId, int? othersFPPId, int allotmentClassId, int generalLedgerAccountId, short year);

        bool BudgetAppropriationExist(int id, int fundId, int fppId, int? othersFPPId, int allotmentClassId, int generalLedgerAccountId, short year);

        bool BudgetAppropriationContinuing(int fundId, int fppId, int? othersFPPId, int allotmentClassId, int generalLedgerAccountId);

        bool BudgetAppropriationContinuing(int id, int fundId, int fppId, int? othersFPPId, int allotmentClassId, int generalLedgerAccountId);

        #endregion Validations

    }
}
