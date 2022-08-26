using System.Collections.Generic;
using System.Data;
using ACC.Domain.Interfaces;
using RPT.Domain.Models;

namespace RPT.Domain.Interfaces
{
    public interface IRptAssessmentPostingRepository : IRepository<RptAssessmentPostsModel>
    {
        bool IsPropertyPosted(string arpNo);

        int PreviousAssessmentPostCount(string completeArpNo, int year);

        int GetMinAssessmentPostYear(string completeArpNo);

        Dictionary<string, string> GetRecordBy_ArpNo_Year(string completeArpNo, int year);

        DataTable GetRecordsByOwnerName_IsCancelled(string ownerName, bool isCancelled);

        DataTable GetViewRptPropertyAssessmentsRecordsBy_OwnerName_Years(string ownerName, int yearFrom, int yearTo);

        DataTable GetRecordsByArpNo(string arpNo);

        bool BulkInsert(List<RptAssessmentPostsModel> assessmentPostingModels);
    }
}
