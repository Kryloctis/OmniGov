using Accounting.Domain.Entities;
using OmniGov.Core.Interfaces;

namespace Accounting.Domain.Interfaces
{
    public interface ICashDisbursementsJournalRepository : IRepository<CashDisbursementsJournalModel>
    {
        bool UpdateByJevId(CashDisbursementsJournalModel entity);

        bool JevIdExist(int jevId);

        Dictionary<string, string> GetViewRecordByJevID(int jevId);

        bool DeleteByJevId(int jevId);
    }
}