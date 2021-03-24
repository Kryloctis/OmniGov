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

        bool allotmentReleaseNumExist(string alltomentReleaseNum);
        bool allotmentReleaseNumExist(int id , string alltomentReleaseNum);
    }
}
