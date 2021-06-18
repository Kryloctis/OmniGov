using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface ICollectorReportRepository : IRepository<CollectorReportModel>
    {
        Dictionary<string, string> GetRecordByID(string Id);
        bool CodeExist(string id);
        bool HasGenerated(int id);
        int InsertId(CollectorReportModel entity);
    }
}
