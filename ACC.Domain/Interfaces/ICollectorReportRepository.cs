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

        bool Delete(CollectorReportModel entity);
        bool CodeExist(string id);
        bool HasGenerated(int paymentCollectionsId);

        bool ReportNumberExist(string reporNo);

        DataTable GetSummary(int cid, int fid, int year);
        int InsertId(CollectorReportModel entity);
        bool HasReported(int id);
        bool Approved(CollectorReportModel entity);
        bool Cancel(int id);

        int GetReportId(int collectorId, string collectorReporrtNumber);
        DataTable GetRecords(int approved, string status, int fid, string date);
        bool Remarks(CollectorReportModel entity);
        DataTable GetRecords(string id);
        DataTable FilterRecords(string status, byte fundId, string keySearch, short collectingOfficerId);
        DataTable FilterRecords(string status, byte fundId, string keySearch);

        DataTable FilterRecords(sbyte fundId, ushort collectorId, string reportNo);
        DataTable GetRecordsByReportNumber(string reportNumber);
        DataTable GetCollectorsReportByReportNo(string reportNumber);

        string GetCollectorIdByReportNumber(string reportNumber);

        string GetRCDStatus(string reportNo);

        bool SetRCDStatus(byte status, string reportNo);

        bool SetRemarks(string reportNo, string remark);
        string GetRemarks(string reportNo);
    }
}
