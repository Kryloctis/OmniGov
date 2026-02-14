using OmniGov.Core.Entities;
using System.Data;

namespace OmniGov.Core.Interfaces
{
    public interface IFunctionalClassificationServiceRepository : IRepository<FunctionalClassificationServiceModel>
    {
        DataTable GetViewRecords();

        DataTable GetViewRecordsBySearch_And_Sector(string searchText, int sectorId);

        DataTable GetViewRecordsBySearch(string searchText);

        bool NameExist(string name);

        bool NameExist(string name, int id);
    }
}