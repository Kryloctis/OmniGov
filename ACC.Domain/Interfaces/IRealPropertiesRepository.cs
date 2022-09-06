using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface IRealPropertiesRepository : IRepository<RealPropertiesModel>
    {
        bool CompleteArpNoExist(string completeArpNo);
        bool CompleteArpNoExist(string completeArpNo, int Id);
        bool SynchronizeData(List<RealPropertiesModel> realPropertiesModels);
        bool UpdateByArpNo(RealPropertiesModel realPropertiesModel);
        DataTable GetRecordsBy_EffectivivtyYear_Barangay_Search(int effectivityYear, string barangay, string searchText);   
        string GetLastInsertedId();
    }
}
