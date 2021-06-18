using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface IAllotmentReleaseRepository : IRepository<AllotmentReleaseModel>
    {

        bool Insert(AllotmentReleaseModel entity, List<AllotmentAccountModel> listAllotmentAccount);

        bool Update(AllotmentReleaseModel entity, List<AllotmentAccountModel> listAllotmentAccount);

        bool Delete(int allotmentReleaseId);

        bool AllotmentReleaseNoExist(string allotmentReleaseNo);

        bool AllotmentReleaseNoExist(int Id, string allotmentReleaseNo);

        DataTable GetViewRecordsByBudgetAppropriationId(int budgetAppropriationId);

        DataTable GetViewRecordsByARONo(string aroNo);

        bool AllotmentReleaseExist(int budgetAppropriationId, DateTime dateIssued);

        bool AllotmentReleaseExist(int Id ,int budgetAppropriationId, DateTime dateIssued);
    }
}
