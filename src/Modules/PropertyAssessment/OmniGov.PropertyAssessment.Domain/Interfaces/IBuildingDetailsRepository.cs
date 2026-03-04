using OmniGov.Core.Interfaces.Repositories;
using OmniGov.PropertyAssessment.Domain.Entities;

namespace OmniGov.PropertyAssessment.Domain.Interfaces
{
    public interface IBuildingDetailsRepository : IRepository<BuildingDetailsModel>
    {
        public decimal GetTotalAreaByBuildingPropertiesId(int buildingPropertiesId);
    }
}
