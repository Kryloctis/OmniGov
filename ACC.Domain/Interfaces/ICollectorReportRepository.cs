using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface ICollectorReportRepository : IAccRepository<CollectorReportModel>
    {
        Dictionary<string, string> GetRecordByID(string reportNo);

        bool Delete(CollectorReportModel entity);

        bool ReportNumberExist(string reporNo);
        bool ReportNumberExist(int reportId, string reporNo);
        bool HasReported(int id);
        bool HasGenerated(int paymentCollectionsId);
        int GetReportID(int collectorId, string collectorReportNumber, bool isJO);
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
        int GetApprovedRCDCount(int fundId, short month, short year);
        int GetPendingRCDCount(int fundId, short month, short year);
        int GetDisapprovedRCDCount(int fundId, short month, short year);
        int GetCancelledRCDCount(int fundId, short month, short year);
        bool InsertWithCollectorReportPayments(CollectorReportModel collectorReportModel, List<CollectorReportPaymentModel> collectorReportPaymentModel);
      
    }
}
