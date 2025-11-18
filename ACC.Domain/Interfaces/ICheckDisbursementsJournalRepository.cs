using ACC.Domain.Models;
using System.Collections.Generic;

namespace ACC.Domain.Interfaces
{
    public interface ICheckDisbursementsJournalRepository : IAccRepository<CheckDisbursementsJournalModel>
    {
        Dictionary<string, string> GetRecordByJevID(int jevId);

        bool JevIdExist(int jevId);

        bool UpdateByJevID(CheckDisbursementsJournalModel entity);

        bool DeleteByJevId(int jevId);
    }
}