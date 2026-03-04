using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Treasury.Domain.Entities;
using System.Data;

namespace OmniGov.Treasury.Domain.Interfaces
{
    public interface IRptPreviousAssessment : IRepository<RptPreviousAssessmentModel>
    {
        string tableName { get; }

        bool DeleteByRealPropertyId(int realPropertyId);

        DataTable GetRecordsByRptId(int rptId);
    }
}
