using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Core.Interfaces.Services;
using OmniGov.Core.Interfaces.Factories;
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
