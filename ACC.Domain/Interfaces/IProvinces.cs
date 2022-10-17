using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IProvinces : IRepository<ProvincesModel>
    {
        bool nameExist(string name);
        bool nameExist(int id, string name);
    }
}
