using ACC.Domain.Models;
using System;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface ISupplementalAppropriationsRepository : IRepository<SupplementalAppropriationsModel>
    {
        DataTable GetRecordsByBudgetAppropriationId(int budgetAppropriationsId);

        DataTable GetRecordsByBudgetAppropriationIdDateEntry(int budgetAppropriationId, DateTime dateEntry);

        //DASHBOARD
        #region DASHBOARD BUDGET
        //DETAILED
        decimal GetSumSupplementalAppropriations(int budgetAppropriationId, DateTime dateEntry);
        //SUMMARY
        decimal GetSumSupplementalAppropriations(string fppId, int fundId, DateTime dateEntry, int allotmentClassId, Byte isContinuing);
        #endregion
    }
}
