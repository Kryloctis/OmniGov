using ACC.Domain.Models;
using System.Collections.Generic;

namespace ACC.Domain.Interfaces
{
    public interface ICashDisbursementsJournalRepository : IAccRepository<CashDisbursementsJournalModel>
    {
        bool UpdateByJevId(CashDisbursementsJournalModel entity);

        bool JevIdExist(int jevId);

        Dictionary<string, string> GetViewRecordByJevID(int jevId);

        bool DeleteCashDisbursementJournalByJevID(int jevId);
    }
}