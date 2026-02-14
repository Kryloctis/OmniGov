using OmniGov.Core.Entities;
using System.Data;

namespace OmniGov.Core.Interfaces
{
    public interface IRolesRepository : IRepository<RolesModel>
    {
        DataTable GetRecords(int rowLimit, string searchText);

        bool NameExist(string name);

        bool NameExist(string name, int id);
    }
}