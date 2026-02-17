using Accounting.Domain.Entities;
using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Core.Interfaces.Services;
using OmniGov.Core.Interfaces.Factories;

namespace Accounting.Domain.Interfaces
{
    public interface ICheckDisbursementsJournalRepository : IRepository<CheckDisbursementsJournalModel>
    {
        Dictionary<string, string> GetRecordByJevID(int jevId);

        bool UpdateByJevID(CheckDisbursementsJournalModel entity);

        bool DeleteByJevId(int jevId);
    }
}
