using ACC.Domain.Interfaces;
using RPT.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace RPT.Domain.Interfaces
{
    public interface IRptAssessmentPostingRepository : IAccRepository<RptAssessmentPostsModel>
    {
        bool IsPropertyPosted(string arpNo);

        Dictionary<string, string> GetViewRecentAssessmentRecord(string completeArpNo, int assessmentYear);

        int GetMinAssessmentPostYear(string completeArpNo);

        Dictionary<string, string> GetRecordBy_ArpNo_Year(string completeArpNo, int year);

        DataTable GetRecordsByOwnerName_IsCancelled(string ownerName, bool isCancelled);

        DataTable GetViewRecordsByOwnerNamePeriod(string ownerName, DateTime periodFrom, DateTime periodTo);

        DataTable GetViewRecordsByArpNoPeriod(string arpNo, DateTime periodFrom, DateTime periodTo);

        bool BulkInsert(List<RptAssessmentPostsModel> assessmentPostingModels);

        DataTable GetViewDelinquentRecordsByBarangayNamePeriod(string barangayName, DateTime periodFrom, DateTime periodTo);

        DataTable GetViewDelinquentRecordsByOwnerNamePeriod(string ownerName, DateTime periodFrom, DateTime periodTo);

        DataTable GetBarangayRecords();

        DataTable GetViewRecordsByTaxpayerIdArpNoShowPaid(int realTaxpayersId, int calendarYear, string completeArpNo, bool showPaidAssessments);

        DataTable GetRecordsByRealTaxpayersId(int realTaxpayersId, bool showIsCancelled);

        DataTable GetViewRecordsByOwnerId(int taxpayerId);
    }
}