using ACC.Domain.Models;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IBanksRepository : IAccRepository<BanksModel>
    {
        bool CodeExist(string code);

        bool CodeExist(string code, int id);

        bool BankExistByNameBranch(string name, string branch);

        int GetIdByNameBranch(string name, string branch);

        int GetLastInsertedId();

        DataTable GetRecords(int rowLimit, string searchKey);
    }
}