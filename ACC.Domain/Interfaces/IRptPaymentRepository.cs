using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IRptPaymentRepository : IAccRepository<RptPaymentsModel>
    {
        bool InsertWithRptTaxDues(RptPaymentsModel rptPaymentModel, List<RptTaxDuesModel> rptTaxDuesModels);

        DataTable GetViewRecordsByDateTaxPayerName(DateTime dateFrom, DateTime dateTo, string taxPayerName);

        Dictionary<string, string> GetViewRecordById(int Id);

        int GetLastInsertedID();
    }
}