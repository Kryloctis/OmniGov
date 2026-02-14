using Accounting.Domain.Entities;
using OmniGov.Core.Interfaces;

namespace Accounting.Domain.Interfaces
{
    public interface ICheckDisbursementsJournalRepository : IRepository<CheckDisbursementsJournalModel>
    {
        Dictionary<string, string> GetRecordByJevID(int jevId);

        bool UpdateByJevID(CheckDisbursementsJournalModel entity);

        bool DeleteByJevId(int jevId);
    }
}