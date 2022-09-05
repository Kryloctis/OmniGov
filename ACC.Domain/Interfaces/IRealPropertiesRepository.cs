using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface IRealPropertiesRepository : IRepository<RealPropertiesModel>
    {
        bool CompleteArpNoExist(string completeArpNo);
        bool CompleteArpNoExist(string completeArpNo, int Id);
        bool SynchronizeData(List<RealPropertiesModel> realPropertiesModels);
        bool UpdateByArpNo(RealPropertiesModel realPropertiesModel);
        string GetLastInsertedId();
    }
}
