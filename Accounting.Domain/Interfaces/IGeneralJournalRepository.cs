using Accounting.Domain.Entities;
using OmniGov.Core.Interfaces.Repositories;

namespace Accounting.Domain.Interfaces
{
    public interface IGeneralJournalRepository : IRepository<GeneralJournalModel>
    {
        bool UpdateByJevId(GeneralJournalModel entity);

        bool JevIdExist(int jevId);

        Dictionary<string, string> GetViewRecordByJevID(int jevId);

        bool DeleteByJevId(int jevId);
    }
}
