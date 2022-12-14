using ACC.Domain.Models;
using System.Collections.Generic;

namespace ACC.Domain.Interfaces
{
    public interface IBarangayRepository : IAccRepository<BarangayModel>
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
    }
}