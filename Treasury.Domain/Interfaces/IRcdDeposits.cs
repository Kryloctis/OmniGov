using OmniGov.Core.Interfaces.Repositories;
using Treasury.Domain.Entities;

namespace Treasury.Domain.Interfaces
{
    public interface IRcdDeposits : IRepository<RcdDepositsModel>
    {
        public string GetTableName();

        public bool BulkInsert(List<RcdDepositsModel> rcdDepositsModels);

        public bool DeleteByRcdId(RcdModel rcdModel);
    }
}