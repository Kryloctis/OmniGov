using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Treasury.Domain.Entities;

namespace OmniGov.Treasury.Domain.Interfaces
{
    public interface IRcdDeposits : IRepository<RcdDepositsModel>
    {
        public string GetTableName();

        public bool BulkInsert(List<RcdDepositsModel> rcdDepositsModels);

        public bool DeleteByRcdId(RcdModel rcdModel);
    }
}
