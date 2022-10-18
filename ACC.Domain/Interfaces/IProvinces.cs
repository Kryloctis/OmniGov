using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IProvinces : IRepository<ProvincesModel>
    {
        bool NameExist(string name);
        bool NameExist(int id, string name);
        int GetLastInsertedId();
        int GetIdByName(string name);
    }
}
