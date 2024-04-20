using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IRcd : IAccRepository<RcdModel>
    {
        bool reportNoExist(string reportNo);

        bool reportNoExist(string reportNo, int id);

        DataTable GetViewRecords(string searchKey, DateTime date, int rowFilter);

        bool InsertWithCollectionsDeposits(RcdModel rcdModel, List<RcdCollectionsModel> rcdCollectionsModels, List<RcdDepositsModel> rcdDepositsModels);
    }
}