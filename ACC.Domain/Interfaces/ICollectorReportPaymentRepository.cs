using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface ICollectorReportPaymentRepository : IRepository<CollectorReportPaymentModel>
    {
        bool Insert(List<CollectorReportPaymentModel> entityList);
        DataTable GetRecordByLedger(string Id);
    }
}
