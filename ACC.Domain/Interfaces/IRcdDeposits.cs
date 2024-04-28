using ACC.Domain.Models;
using System.Collections.Generic;

namespace ACC.Domain.Interfaces
{
    public interface IRcdDeposits : IAccRepository<RcdDepositsModel>
    {
        public string GetTableName();

        public bool BulkInsert(List<RcdDepositsModel> rcdDepositsModels);

        public bool DeleteByRcdId(RcdModel rcdModel);
    }
}