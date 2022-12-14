using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IActualUseCodes : IAccRepository<ActualUseCodesModel>
    {
        bool NameExist(string name);

        bool NameExist(string name, int id);

        int GetIdByName(string name);

        int GetLastInsertedId();
    }
}