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

        DataTable GetRecordsByArpNo(string arpNo);

        bool BulkInsert(List<RptAssessmentPostsModel> assessmentPostingModels);

        DataTable GetViewRecordsByBarangayNamePeriod(string barangayName, DateTime periodFrom, DateTime periodTo);

        DataTable GetBarangayRecords();

        DataTable Get_Grouped_Municipality_Records();

        DataTable GetViewRecords(int realTaxpayersId, string completeArpNo, bool showPaidAssessments);

        DataTable GetRecordsByRealTaxpayersId(int realTaxpayersId, bool showIsCancelled);
    }
}