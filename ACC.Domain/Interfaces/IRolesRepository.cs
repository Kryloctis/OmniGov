using ACC.Domain.Models;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IRolesRepository : IAccRepository<RolesModel>
    {
        DataTable GetRecords(int rowLimit, string searchText);

        bool NameExist(string name);

        bool NameExist(string name, int id);
    }
}