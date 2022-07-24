using System.Data;
using ACC.Domain.Interfaces;
using RPT.Domain.Models;

namespace RPT.Domain.Interfaces
{
    public interface IAssessmentPostsRepository : IRepository<AssessmentPostsModel>
    {
        bool IsPropertyPosted(string arpNo);
    }
}
