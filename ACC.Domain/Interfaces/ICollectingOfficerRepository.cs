using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface ICollectingOfficerRepository : IAccRepository<CollectingOfficerModel>
    {       
        bool FullNameExist(string firstname, string middleinitial, string lastname, int id);
        Dictionary<string, string> GetRecordByUserID(int Id);
        DataTable GetCollectorsWithReceiptsIssuedByReceiptId(int rid);
        int CollectingOfficerJOCount(int collectingOfficerId);
    }
}
