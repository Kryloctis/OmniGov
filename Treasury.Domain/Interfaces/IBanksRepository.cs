using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Core.Interfaces.Services;
using OmniGov.Core.Interfaces.Factories;
using System.Data;
using Treasury.Domain.Entities;

namespace Treasury.Domain.Interfaces
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
