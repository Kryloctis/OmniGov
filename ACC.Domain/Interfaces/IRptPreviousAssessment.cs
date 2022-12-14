using ACC.Domain.Models;
using System.Collections.Generic;

namespace ACC.Domain.Interfaces
{
    public interface IRptPreviousAssessment : IAccRepository<RptPreviousAssessmentModel>
    {
        bool DeleteByRealPropertyId(int realPropertyId);

        Dictionary<string, string> GetRecordsByARPNo(string ARPNo);
    }
}