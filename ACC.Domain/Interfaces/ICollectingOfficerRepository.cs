using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface ICollectingOfficerRepository : IRepository<CollectingOfficerModel>
    {       
        bool FullNameExist(string firstname, string middleinitial, string lastname, int id);
        Dictionary<string, string> GetRecordByUserID(int Id);
        DataTable GetRecords(int rid);
        bool ReceiptsAssigned(int id);
    }
}
