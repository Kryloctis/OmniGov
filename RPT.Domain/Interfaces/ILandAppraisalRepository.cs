using OmniGov.Core.Interfaces.Repositories;
using PropertyAssessment.Domain.Entities;

namespace PropertyAssessment.Domain.Interfaces
{
    public interface ILandAppraisalRepository : IRepository<LandAppraisalModel>
    {
        decimal GetTotalAreaByLandPropertiesId(int landPropertiesId);
    }
}