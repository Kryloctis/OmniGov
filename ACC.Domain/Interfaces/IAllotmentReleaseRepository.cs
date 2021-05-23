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



        //For Obligation Request Module
        decimal GetTotalAllotmentReleaseByDateYear(int fundID, int fppID, int? othersFPPID, int allotmentClassID, int accountID, DateTime dateIssued,  short year);

        decimal GetTotalAllotmentReleaseByYear(int fundId, int fppId, int? othersFPPId, int allotmentClassId, int AccountId, short year);



        decimal GetViewTotalAllotmentReleaseAmountById(int budgetAppropriationId);

        decimal GetViewTotalAllotmentReleaseByIdDateYear(int budgetAppropriationId, DateTime dateIssued, short year);


        bool allotmentReleaseExist(int budgetAppropriationId, string dateIssued);

        bool allotmentReleaseExist(int id, int budgetAppropriationId, string dateIssued);

        bool BulkInsert(List<AllotmentReleaseModel> allotmentReleaseModelList);
    }
}
