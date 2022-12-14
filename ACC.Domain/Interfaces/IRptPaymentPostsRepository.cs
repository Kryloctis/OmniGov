using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IRptPaymentPostsRepository : IAccRepository<RptPaymentPostsModel>
    {
        bool InsertWithRptTaxDues(RptPaymentPostsModel rptPaymentPostsModel, List<RptTaxDuesModel> rptTaxDuesModels);

        DataTable GetViewRecordsByDateTaxPayerName(DateTime dateFrom, DateTime dateTo, string taxPayerName);

        Dictionary<string, string> GetViewRecordById(int Id);

        int GetLastInsertedID();
    }
}