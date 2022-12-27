using ACC.Domain.Models;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IRptTaxDuesRepository : IAccRepository<RptTaxDuesModel>
    {
        DataTable GetViewRecordsByRptPaymentPostsId(int rptPaymentsId);
    }
}