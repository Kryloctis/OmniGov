using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface ISupplementalAppropriationsRepository : IRepository<SupplementalAppropriationsModel>
    {
        bool Insert(List<SupplementalAppropriationsModel> supplementalAppropriationsModelList);

        bool DeleteByBudgerAppropriationId(int budgetAppropriationId);

        DataTable GetRecordsByBudgetAppropriationId(int budgetAppropriationsId);

        DataTable GetRecordsByBudgetAppropriationIdDateEntry(int budgetAppropriationId, DateTime dateEntry);

        //DASHBOARD
        #region DASHBOARD BUDGET
        //DETAILED
        decimal GetSumSupplementalAppropriations(int budgetAppropriationId, DateTime dateEntry);
        //SUMMARY
        decimal GetSumSupplementalAppropriations(string fppId, string subFPPId, int fundId, DateTime dateEntry, int allotmentClassId, Byte isContinuing);
        #endregion
    }
}
