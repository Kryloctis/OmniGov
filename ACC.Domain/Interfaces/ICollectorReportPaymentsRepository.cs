using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface ICollectorReportPaymentsRepository : IAccRepository<CollectorReportPaymentModel>
    {
        bool Delete(CollectorReportPaymentModel entity);

        DataTable GetRecordsByReportNo(string reportNo);

        DataTable GetCollectorsReportByReportNo(string reportNo);

        bool Append(List<CollectorReportPaymentModel> entityList);
    }
}