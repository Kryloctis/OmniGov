using System.Data;
using ACC.Domain.Interfaces;
using RPT.Domain.Models;

namespace RPT.Domain.Interfaces
{
    public interface IRealPropertiesRepository : IRepository<RealPropertiesModel> 
    {
        DataTable GetViewPropertiesByPropertyKindAndSearch(string propertyKind, string searchText);
        DataTable GetBarangays();
        DataTable GetProperties(string barangayName, string searchKey);
        decimal GetAssessedValueByARPNo(string arpNo);


        
    }
}
