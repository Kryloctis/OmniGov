using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface IAllotmentReleaseRepository : IRepository<AllotmentReleaseModel>
    {

        bool AllotmentReleaseNoExist(string allotmentReleaseNo);

        bool Insert(AllotmentReleaseModel entity, List<AllotmentAccountModel> listAllotmentAccount);

        DataTable GetViewRecordsByBudgetAppropriationId(int budgetAppropriationId);
    }
}
