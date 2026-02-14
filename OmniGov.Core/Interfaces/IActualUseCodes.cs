using OmniGov.Core.Entities;

namespace OmniGov.Core.Interfaces
{
    public interface IActualUseCodes : IRepository<ActualUseCodesModel>
    {
        bool NameExist(string name);

        bool NameExist(string name, int id);

        int GetIdByName(string name);

        int GetLastInsertedId();
    }
}