using OmniGov.Accounting.Domain.Entities;
using OmniGov.Core.Interfaces.Repositories;

namespace OmniGov.Accounting.Domain.Interfaces
{
    public interface ICheckDisbursementsJournalRepository : IRepository<CheckDisbursementsJournalModel>
    {
        Dictionary<string, string> GetRecordByJevID(int jevId);

        bool UpdateByJevID(CheckDisbursementsJournalModel entity);

        bool DeleteByJevId(int jevId);
    }
}
