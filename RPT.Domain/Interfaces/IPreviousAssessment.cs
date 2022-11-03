using RPT.Domain.Models;
using System.Collections.Generic;

namespace RPT.Domain.Interfaces
{
    public interface IPreviousAssessment : IRptRepository<PreviousAssessmentModel>
    {
        Dictionary<string, string> GetRecordByRealPropertiesId(int realPropertiesId);
    }
}
