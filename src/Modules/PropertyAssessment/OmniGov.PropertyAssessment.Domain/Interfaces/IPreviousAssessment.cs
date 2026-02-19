using OmniGov.Core.Interfaces.Repositories;
using PropertyAssessment.Domain.Entities;

namespace PropertyAssessment.Domain.Interfaces
{
    public interface IPreviousAssessment : IRepository<PreviousAssessmentModel>
    {
        Dictionary<string, string> GetRecordByRealPropertiesId(int realPropertiesId);
    }
}