using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IMunicipalities : IRepository<MunicipalitiesModel>
    {
        bool NameExist(string name);
        bool NameExist(int id, string name);
    }
}
