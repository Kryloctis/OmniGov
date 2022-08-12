using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface IRptTaxDuesRepository : IRepository<RptTaxDuesModel>
    {
        DataTable GetViewRecordsByRptPaymentPostsId(int rptPaymentPostsId);
    }
}
