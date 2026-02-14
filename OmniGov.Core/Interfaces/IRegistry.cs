using OmniGov.Core.Entities;
using System.Data;

namespace OmniGov.Core.Interfaces
{
    public interface IRegistry : IRepository<RegistryModel>
    {
        DataTable GetRecordsBySearh_Limit(string searchKey, int limitCount);
    }
}