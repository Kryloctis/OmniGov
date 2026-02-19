using Accounting.Domain.Entities;
using OmniGov.Core.Interfaces.Repositories;

namespace Accounting.Domain.Interfaces
{
    public interface ICashReceiptsJournalRepository : IRepository<CashReceiptsJournalModel>
    {
        Dictionary<string, string> GetViewRecordByJevID(int jevId);

        bool UpdateByJevId(CashReceiptsJournalModel entity);

        bool DeleteByJevId(int jevId);
    }
}
