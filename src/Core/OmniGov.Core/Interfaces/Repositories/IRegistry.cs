using OmniGov.Core.Entities;
using System.Data;

namespace OmniGov.Core.Interfaces.Repositories
{
    public interface IRegistry : IRepository<RegistryModel>
    {
        DataTable GetRecordsBySearh_Limit(string searchKey, int limitCount);
    }
}
