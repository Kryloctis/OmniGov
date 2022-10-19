using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IRealPropertiesRepository : IRepository<RealPropertiesModel>
    {
        bool CompleteArpNoExist(string completeArpNo);
        bool CompleteArpNoExist(string completeArpNo, int Id);
        bool SynchronizeData(List<RealPropertiesModel> realPropertiesModels, List<ProvincesModel> provincesModels);
        DataTable GetRecordsBy_EffectivivtyYear_Barangay_Search(int effectivityYear, string barangay, string searchText);
        string GetLastInsertedId();
    }
}
