using OmniGov.Core.Entities;
using System.Data;

namespace OmniGov.Core.Interfaces.Repositories
{
    public interface IBarangayRepository : IRepository<BarangayModel>
    {
        bool CodeExist(string code);

        bool CodeExist(string code, int id);

        bool NameExist(string name);

        bool NameExist(string name, int id);

        int GetLastInsertedId();

        Dictionary<string, string> GetViewRecordById(int id);

        bool NameExistByMunicipalitiesName_ProvincesName(string name, string municipalityName, string provinceName);

        bool NameExistByMunicipalitiesName_ProvincesName(string name, string municipalityName, string provinceName, int id);

        int GetIdByName_MunicipalitiesName_ProvincesName(string name, string municipalityName, string provinceName);

        DataTable GetRecordsBySearch(int rowLimit, string searchText, int municipalityId);
    }
}
