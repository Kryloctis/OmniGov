using System.Collections.Generic;
using System.Data;
using ACC.Domain.Interfaces;
using RPT.Domain.Models;

namespace RPT.Domain.Interfaces
{
    public interface IAssessmentPostingRepository : IRepository<AssessmentPostingModel>
    {
        bool IsPropertyPosted(string arpNo);

        Dictionary<string, string> GetRecordBy_ArpNo_Year(string completeArpNo, int year);

        DataTable GetRecordsByOwnerName_IsCancelled(string ownerName, bool isCancelled);

        DataTable GetRecordsByArpNo(string arpNo);

        bool BulkInsert(List<AssessmentPostingModel> assessmentPostingModels);
    }
}
