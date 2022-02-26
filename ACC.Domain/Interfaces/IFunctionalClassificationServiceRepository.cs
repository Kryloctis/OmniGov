using ACC.Domain.Models;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IFunctionalClassificationServiceRepository : IRepository<FunctionalClassificationServiceModel>
    {
        DataTable GetViewRecordsByClassificationId(byte id);
        DataTable GetViewRecords();
        DataTable GetViewRecordsBySearch_And_Sector(string searchText, int sectorId);
        DataTable GetViewRecordsBySearch(string searchText);
        bool CodeExist(string code);
        bool CodeExist(string code, int id);
        bool NameExist(string name);
        bool NameExist(string name, int id);
    }
}
