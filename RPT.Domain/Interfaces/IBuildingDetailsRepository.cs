using RPT.Domain.Models;

namespace RPT.Domain.Interfaces
{
    public interface IBuildingDetailsRepository : IRptRepository<BuildingDetailsModel>
    {
        public decimal GetTotalAreaByBuildingPropertiesId(int buildingPropertiesId);
    }
}