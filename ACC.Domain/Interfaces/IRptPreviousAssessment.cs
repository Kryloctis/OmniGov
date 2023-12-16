using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IRptPreviousAssessment : IAccRepository<RptPreviousAssessmentModel>
    {
        string tableName { get; }

        bool DeleteByRealPropertyId(int realPropertyId);

        DataTable GetRecordsByRptId(int rptId);
    }
}