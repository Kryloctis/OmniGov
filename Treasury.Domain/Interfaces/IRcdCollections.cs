using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Core.Interfaces.Services;
using OmniGov.Core.Interfaces.Factories;
using Treasury.Domain.Entities;

namespace Treasury.Domain.Interfaces
{
    public interface IRcdCollections : IRepository<RcdCollectionsModel>
    {
        public string GetTableName();

        public bool BulkInsert(List<RcdCollectionsModel> rcdCollectionsModels);

        public bool DeleteByRcdId(RcdModel rcdModel);
    }
}
