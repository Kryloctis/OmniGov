using System.Data;
using ACC.Domain.Interfaces;
using RPT.Domain.Models;

namespace RPT.Domain.Interfaces
{
    public interface IAssessmentPostingRepository : IRepository<AssessmentPostingModel>
    {
        bool IsPropertyPosted(string arpNo);

        DataTable GetRecordsByOwnerName_IsCancelled(string ownerName, bool isCancelled);

        DataTable GetRecordsByArpNo(string arpNo);
    }
}
