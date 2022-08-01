using System.Data;
using ACC.Domain.Interfaces;
using RPT.Domain.Models;

namespace RPT.Domain.Interfaces
{
    public interface IRealPropertiesRepository : IRepository<RealPropertiesModel> 
    {
        DataTable GetViewPropertiesByPropertyKindAndSearch(string propertyKind, string searchText);

        DataTable GetBarangays();

        DataTable GetPropertiesBy_Quarter_Year_BarangayId_Search(int effectivityYear, int barangayId, string searchText);

        decimal GetAssessedValueByARPNo(string arpNo);
    }
}
