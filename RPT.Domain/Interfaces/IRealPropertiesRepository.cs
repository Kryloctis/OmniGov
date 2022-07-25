using System.Data;
using ACC.Domain.Interfaces;
using RPT.Domain.Models;

namespace RPT.Domain.Interfaces
{
    public interface IRealPropertiesRepository : IRepository<RealPropertiesModel> 
    {
        DataTable GetViewPropertiesByPropertyKindAndSearch(string propertyKind, string searchText);
        DataTable GetBarangays();
        DataTable GetProperties(string barangayName, int effectivityQuarter, int effectivityYear, string searchKey);
        decimal GetAssessedValueByARPNo(string arpNo);


        
    }
}
