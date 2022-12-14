using RPT.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace RPT.Domain.Interfaces
{
    public interface IRealPropertiesRepository : IRptRepository<RealPropertiesModel>
    {
        Dictionary<string, string> GetViewRealPropertiesById(int Id);

        DataTable GetViewPropertiesByPropertyKindAndSearch(string propertyKind, string searchText);

        DataTable GetBarangays();

        DataTable GetPropertiesBy_Quarter_Year_BarangayId_Search(int effectivityYear, int barangayId, string searchText);

        decimal GetAssessedValueByARPNo(string arpNo);

        decimal GetOtherImprovementsAssessedValueBy_ArpNo_ActualUseCode(string arpNo);

        Dictionary<string, string> GetViewLFSRealPropertiesRecordById(int Id);

        DataTable GetViewLFSRealPropertiesRecords();
    }
}