using OmniGov.Core.Interfaces.Repositories;
using OmniGov.PropertyAssessment.Domain.Entities;
using System.Data;

namespace OmniGov.PropertyAssessment.Domain.Interfaces
{
    public interface IRealPropertiesRepository : IRepository<RealPropertiesModel>
    {
        Dictionary<string, string> GetViewRealPropertiesById(int Id);

        DataTable GetViewPropertiesByPropertyKindAndSearch(string propertyKind, string searchText);

        DataTable GetBarangays();

        DataTable GetPropertiesBy_Quarter_Year_BarangayId_Search(int effectivityYear, int barangayId, string searchText);

        decimal GetOtherImprovementsAssessedValueBy_ArpNo_ActualUseCode(string arpNo);

        Dictionary<string, string> GetViewLFSRealPropertiesRecordById(int Id);

        DataTable GetViewLFSRealPropertiesRecords();
    }
}
