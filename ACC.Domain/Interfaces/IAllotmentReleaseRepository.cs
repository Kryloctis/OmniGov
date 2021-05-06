using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface IAllotmentReleaseRepository : IRepository<AllotmentReleaseModel>
    {
        DataTable GetRecordsByBudgetAppropriationID(int budgetAppropriationID);

        DataTable GetRecordsByBudgetAppropriationID(int budgetAppropriationID, string allotmentReleaseNum);

        Dictionary<string, string> GetTotalAllotmentReleaseAmount(int fundID, int fppID, int? othersFPPID, int allotmentClassID, int accountID, DateTime dateIssued);

        decimal GetTotalAllotmentReleaseAmount(int fundId, int fppId, int? othersFPPId, int allotmentClassId, int AccountId);

        decimal GetTotalAllotmentReleaseAmount(int fundId, int fppId, int? othersFPPId, int allotmentClassId, int accountId, int year);

        bool allotmentReleaseExist(int budgetAppropriationId, string dateIssued);

        bool allotmentReleaseExist(int id, int budgetAppropriationId, string dateIssued);

        bool BulkInsert(List<AllotmentReleaseModel> allotmentReleaseModelList);
    }
}
