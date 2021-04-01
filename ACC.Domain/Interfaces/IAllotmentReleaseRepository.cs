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
        DataTable GetViewRecords();
        DataTable GetViewRecords(int fppId, int? othersFPPId, int fundID, int allotmentClassId, Int16 year);
        DataTable GetFPPRecords();
        DataTable GetOthersFPPRecords(int fppId, int allotmentClassId, int fundId, Int16 year);


        bool allotmentReleaseNumExist(string alltomentReleaseNum);
        bool allotmentReleaseNumExist(int id , string alltomentReleaseNum);
    }
}
