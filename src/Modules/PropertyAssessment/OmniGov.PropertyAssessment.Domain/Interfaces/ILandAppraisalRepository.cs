using OmniGov.Core.Interfaces.Repositories;
using OmniGov.PropertyAssessment.Domain.Entities;

namespace OmniGov.PropertyAssessment.Domain.Interfaces
{
    public interface ILandAppraisalRepository : IRepository<LandAppraisalModel>
    {
        decimal GetTotalAreaByLandPropertiesId(int landPropertiesId);
    }
}
