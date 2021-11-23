using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface ICollectorReportRepository : IRepository<CollectorReportModel>
    {
        Dictionary<string, string> GetRecordByID(string reportNo);
        bool CodeExist(string id);
        bool HasGenerated(int id);
        DataTable GetSummary(int cid, int fid, int year);
        int InsertId(CollectorReportModel entity);
        bool HasReported(int id);
        bool Approved(CollectorReportModel entity);
        bool Cancel(int id);

        int GetReportId(int collectorId, string collectorReporrtNumber);
        DataTable GetRecords(int approved, string status, int fid, string date);
        bool Remarks(CollectorReportModel entity);
        DataTable GetRecords(string id);
        DataTable FilterRecords(string status, byte fundId, string keySearch);
    }
}
