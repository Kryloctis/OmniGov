using ACC.Domain.Models;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IFunctionalClassificationServiceRepository : IAccRepository<FunctionalClassificationServiceModel>
    {
        DataTable GetViewRecords();
        DataTable GetViewRecordsBySearch_And_Sector(string searchText, int sectorId);
        DataTable GetViewRecordsBySearch(string searchText);
        bool NameExist(string name);
        bool NameExist(string name, int id);
    }
}
