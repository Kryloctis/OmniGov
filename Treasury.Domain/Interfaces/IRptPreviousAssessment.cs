using OmniGov.Core.Interfaces.Repositories;
using System.Data;
using Treasury.Domain.Entities;

namespace Treasury.Domain.Interfaces
{
    public interface IRptPreviousAssessment : IRepository<RptPreviousAssessmentModel>
    {
        string tableName { get; }

        bool DeleteByRealPropertyId(int realPropertyId);

        DataTable GetRecordsByRptId(int rptId);
    }
}