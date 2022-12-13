using ACC.Domain.Models;
using System.Collections.Generic;

namespace ACC.Domain.Interfaces
{
    public interface ICashReceiptsJournalRepository : IAccRepository<CashReceiptsJournalModel>
    {
        Dictionary<string, string> GetViewRecordByJevID(int jevId);

        bool JevIdExist(int jevId);

        bool UpdateByJevId(CashReceiptsJournalModel entity);

        bool DeleteCashReceiptsJournalByJevID(int jevId);
    }
}