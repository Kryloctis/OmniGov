using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface ICollectorReportRepository : IRepository<CollectorReportModel>
    {
        Dictionary<string, string> GetRecordByID(string Id);
        bool CodeExist(string id);
        bool HasGenerated(int id);
        DataTable GetSummary(int cid, int fid, int year);
        int InsertId(CollectorReportModel entity);
        bool HasReported(int id);
        bool Approved(CollectorReportModel entity);
        bool Cancel(int id);
        DataTable GetRecords(int approved, string status, int fid, string date);
        bool Remarks(CollectorReportModel entity);
        DataTable GetRecords(string id);
    }
}
