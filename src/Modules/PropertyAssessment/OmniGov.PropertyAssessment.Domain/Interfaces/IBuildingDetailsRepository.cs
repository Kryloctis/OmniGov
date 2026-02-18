using OmniGov.Core.Interfaces.Repositories;
using PropertyAssessment.Domain.Entities;

namespace PropertyAssessment.Domain.Interfaces
{
    public interface IBuildingDetailsRepository : IRepository<BuildingDetailsModel>
    {
        public decimal GetTotalAreaByBuildingPropertiesId(int buildingPropertiesId);
    }
}