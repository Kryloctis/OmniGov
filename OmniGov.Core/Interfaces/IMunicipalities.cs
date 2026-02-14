using OmniGov.Core.Entities;

namespace OmniGov.Core.Interfaces
{
    public interface IMunicipalities : IRepository<MunicipalitiesModel>
    {
        bool NameExistByProvinceName(string name, string provinceName);

        bool NameExistByProvinceName(int id, string name, string provinceName);

        int GetLastInsertedId();

        int GetIdByNameProvinceName(string name, string provinceName);
    }
}