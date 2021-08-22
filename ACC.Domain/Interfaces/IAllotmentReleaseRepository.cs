using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IAllotmentReleaseRepository : IRepository<AllotmentReleaseModel>
    {

        bool Insert(AllotmentReleaseModel entity, List<AllotmentAccountModel> listAllotmentAccount);

        bool Update(AllotmentReleaseModel entity, List<AllotmentAccountModel> listAllotmentAccount);

        bool Delete(int allotmentReleaseId);

        bool AllotmentReleaseNoExist(string allotmentReleaseNo);

        bool AllotmentReleaseNoExist(int Id, string allotmentReleaseNo);

        bool AllotmentReleaseExist(int budgetAppropriationId, DateTime dateIssued);

        bool AllotmentReleaseExist(int Id, int budgetAppropriationId, DateTime dateIssued);


        //VIEWS
        DataTable GetViewRecords();

        DataTable GetViewRecordsByBudgetAppropriationIdDateIssued(int budgetAppropriationId, DateTime dateIssued);

        DataTable GetViewRecordsByBudgetAppropriationId(int budgetAppropriationId);

        DataTable GetViewRecordsById(int Id);


        //DASHBOARD

        #region BUDGET DASHBOARD
        //SUMMARY
        decimal GetSumAllotments(int budgetAppropriationId, DateTime dateIssued);

        //DETAILED
        decimal GetSumAllotments(string fppId, string subFPPId, int fundId, DateTime dateIssued, int allotmentClassId, byte isContinuing);
        #endregion
    }
}
