using OmniGov.Core.Interfaces.Repositories;
using System.Data;
using Treasury.Domain.Entities;

namespace Treasury.Domain.Interfaces
{
    public interface ICollectingOfficerRepository : IRepository<CollectingOfficerModel>
    {
        bool FullNameExist(string firstname, string middleinitial, string lastname, int id);

        Dictionary<string, string> GetRecordByUserID(int Id);

        DataTable GetCollectorsWithReceiptsIssuedByReceiptId(int rid);

        int CollectingOfficerJOCount(int collectingOfficerId);

        bool IsUserCollectingOfficer(int userId);
    }
}