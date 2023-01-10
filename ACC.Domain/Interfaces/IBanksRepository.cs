using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IBanksRepository : IAccRepository<BanksModel>
    {
        bool CodeExist(string code);

        bool CodeExist(string code, int id);

        int GetLastInsertedId();
    }
}