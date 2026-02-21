using OmniGov.Core.Interfaces.Repositories;
using OmniGov.PropertyAssessment.Domain.Entities;

namespace OmniGov.PropertyAssessment.Domain.Interfaces
{
    public interface IPreviousAssessment : IRepository<PreviousAssessmentModel>
    {
        Dictionary<string, string> GetRecordByRealPropertiesId(int realPropertiesId);
    }
}
