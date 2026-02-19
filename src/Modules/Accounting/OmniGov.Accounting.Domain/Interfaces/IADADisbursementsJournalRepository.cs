using Accounting.Domain.Entities;
using OmniGov.Core.Interfaces.Repositories;

namespace Accounting.Domain.Interfaces
{
    public interface IADADisbursementsJournalRepository : IRepository<ADADisbursementsJournalModel>
    {
        Dictionary<string, string> GetRecordByJevID(int jevId);

        bool UpdateByJevId(ADADisbursementsJournalModel entity);

        Dictionary<string, string> GetViewRecordByJevID(int jevId);

        bool JevIdExist(int jevId);

        bool DeleteByJevId(int jevId);
    }
}
