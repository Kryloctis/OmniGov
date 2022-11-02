using ACC.Domain.Models;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IRolesRepository : IAccRepository<RolesModel>
    {
        DataTable GetRecordsByOffice(string office);

        bool NameExist(string name, string office);
        bool NameExist(string name, string office, int id);
    }
}
