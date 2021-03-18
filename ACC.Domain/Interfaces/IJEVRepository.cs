using System.Collections.Generic;
using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IJEVRepository : IRepository<JEVModel>
    {
        bool Insert(JEVModel entity, List<JEVAccountsModel> jevAccountsModelList);
        bool Update(JEVModel entity, List<JEVAccountsModel> jevAccountsModelList);
        bool Delete(JEVModel entity);
        int GetLastInsertedID();
        Dictionary<string, string> GetRecordByJEV(string jevNo);
        bool JevNumberExist(string jevNo);
        bool JevNumberExist(string jevNo, uint jevId);
    }
}
