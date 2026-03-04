using OmniGov.Core.Entities;
using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Treasury.Domain.Entities;
using System.Data;

namespace OmniGov.Treasury.Domain.Interfaces
{
    public interface IRcdRepository : IRepository<RcdModel>
    {
        int GetLastInsertedId(UsersModel usersModel);

        bool reportNoExist(string reportNo);

        bool reportNoExist(string reportNo, int id);

        DataTable GetViewRecords(string searchKey, DateTime date, int rowFilter);

        bool InsertWithCollectionsDeposits(RcdModel rcdModel, List<RcdCollectionsModel> rcdCollectionsModels, List<RcdDepositsModel> rcdDepositsModels);

        bool UpdateWithCollectionsDeposits(RcdModel rcdModel, List<RcdCollectionsModel> rcdCollectionsModels, List<RcdDepositsModel> rcdDepositsModels);

        Dictionary<string, string> GetViewRecord(int id);
    }
}
