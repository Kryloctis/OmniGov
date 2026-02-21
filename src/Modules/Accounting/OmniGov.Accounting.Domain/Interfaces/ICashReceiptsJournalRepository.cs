using OmniGov.Accounting.Domain.Entities;
using OmniGov.Core.Interfaces.Repositories;

namespace OmniGov.Accounting.Domain.Interfaces
{
    public interface ICashReceiptsJournalRepository : IRepository<CashReceiptsJournalModel>
    {
        Dictionary<string, string> GetViewRecordByJevID(int jevId);

        bool UpdateByJevId(CashReceiptsJournalModel entity);

        bool DeleteByJevId(int jevId);
    }
}
