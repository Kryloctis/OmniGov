using ACC.Domain.Models;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IRptDelinquenciesRepository : IAccRepository<RptDelinquenciesModel>
    {
        DataTable GetViewRptDelinquencies(string status, string searchText);
        DataTable GetViewRptDelinquenciesByStatusAndTaxpayerId(string status, int taxpayerId);

        bool DuplicatedNotificationStatus(int rptAssessmentPostId, string status);
    }
}
