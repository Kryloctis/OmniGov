using System;
using System.Collections.Generic;
using System.Text;
using ACC.Domain.Models;

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
