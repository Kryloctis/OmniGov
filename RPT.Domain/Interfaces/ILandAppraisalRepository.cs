using RPT.Domain.Models;

namespace RPT.Domain.Interfaces
{
    public interface ILandAppraisalRepository : IRptRepository<LandAppraisalModel>
    {
        decimal GetTotalAreaByLandPropertiesId(int landPropertiesId);
    }
}
