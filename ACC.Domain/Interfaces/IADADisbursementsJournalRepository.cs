using ACC.Domain.Models;
using System.Collections.Generic;

namespace ACC.Domain.Interfaces
{
    public interface IADADisbursementsJournalRepository : IAccRepository<ADADisbursementsJournalModel>
    {
        Dictionary<string, string> GetRecordByJevID(int jevId);

        bool UpdateByJevId(ADADisbursementsJournalModel entity);

        Dictionary<string, string> GetViewRecordByJevID(int jevId);

        bool JevIdExist(int jevId);
    }
}