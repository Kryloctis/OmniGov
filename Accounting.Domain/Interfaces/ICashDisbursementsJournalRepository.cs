using Accounting.Domain.Entities;
using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Core.Interfaces.Services;
using OmniGov.Core.Interfaces.Factories;

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
