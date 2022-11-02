using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IMunicipalities : IAccRepository<MunicipalitiesModel>
    {
        bool NameExistByProvinceName(string name, string provinceName);
        bool NameExistByProvinceName(int id, string name, string provinceName);
        int GetLastInsertedId();
        int GetIdByNameProvinceName(string name, string provinceName);
    }
}
