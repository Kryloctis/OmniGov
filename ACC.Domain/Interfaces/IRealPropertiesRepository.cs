using System.Data;
using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IRealPropertiesRepository : IRepository<RealPropertiesModel>
    {
        DataTable GetViewPropertiesByPropertyKindAndSearch(string propertyKind, string searchText);
        DataTable GetBarangays();
        DataTable GetProperties();



        
    }
}
