using OmniGov.Core.Interfaces.Repositories;
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