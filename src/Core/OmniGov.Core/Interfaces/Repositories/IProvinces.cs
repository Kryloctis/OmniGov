using OmniGov.Core.Entities;

namespace OmniGov.Core.Interfaces.Repositories
{
    public interface IProvinces : IRepository<ProvincesModel>
    {
        bool NameExist(string name);

        bool NameExist(int id, string name);

        int GetLastInsertedId();

        int GetIdByName(string name);
    }
}
