using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IRptTaxDuesRepository : IAccRepository<RptTaxDuesModel>
    {
        DataTable GetViewRecordsByRptPaymentPostsId(int rptPaymentsId);

        bool BulkInsert(List<RptTaxDuesModel> entityList);
    }
}