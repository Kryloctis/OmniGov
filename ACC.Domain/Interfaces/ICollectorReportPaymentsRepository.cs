using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface ICollectorReportPaymentsRepository : IRepository<CollectorReportPaymentModel>
    {
        bool Delete(CollectorReportPaymentModel entity);
        DataTable GetRecordsByReportNo(string reportNo);
        DataTable GetCollectorsReportByReportNo(string reportNo);
        bool Append(List<CollectorReportPaymentModel> entityList);
    }
}
