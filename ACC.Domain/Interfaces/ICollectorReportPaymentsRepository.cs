using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface ICollectorReportPaymentsRepository : IRepository<CollectorReportPaymentModel>
    {
        DataTable GetRecordByLedger(string Id);
        DataTable GetRecords(int id);
        DataTable GetRecords(string reportno);
        DataTable GetRecordsByReportNo(string reportNo);
        decimal SumRecords(string reportno);
        decimal SumRecords(int id);
        bool Append(List<CollectorReportPaymentModel> entityList);
    }
}
