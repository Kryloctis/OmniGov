using ACC.Domain.Models;
using System.Collections.Generic;

namespace ACC.Domain.Interfaces
{
    public interface IRcdCollections : IAccRepository<RcdCollectionsModel>
    {
        public bool BulkInsert(List<RcdCollectionsModel> rcdCollectionsModels);

        public bool DeleteByRcdId(RcdModel rcdModel);
    }
}