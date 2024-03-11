using ACC.Domain.Models;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IRptDelinquenciesRepository : IAccRepository<RptDelinquenciesModel>
    {
        DataTable GetViewRptDelinquencies();

        bool DuplicatedNotificationStatus(int rptAssessmentPostId, string status);
    }
}
