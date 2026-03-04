using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Treasury.Domain.Entities;
using System.Data;

namespace OmniGov.Treasury.Domain.Interfaces
{
    public interface IBanksRepository : IRepository<BanksModel>
    {
        bool CodeExist(string code);

        bool CodeExist(string code, int id);

        bool BankExistByNameBranch(string name, string branch);

        int GetIdByNameBranch(string name, string branch);

        int GetLastInsertedId();

        DataTable GetRecords(int rowLimit, string searchKey);
    }
}
