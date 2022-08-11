using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface IRptPaymentPostsRepository : IRepository<RptPaymentPostsModel>
    {
        bool InsertWithRptTaxDues(RptPaymentPostsModel rptPaymentPostsModel, List<RptTaxDuesModel> rptTaxDuesModels);

        DataTable GetViewRecordsByDateTaxPayerName(DateTime dateFrom, DateTime dateTo, string taxPayerName);

        int GetLastInsertedID();
    }
}
