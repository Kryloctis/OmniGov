using System;
using System.Collections.Generic;
using System.Text;
using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface ICashReceiptsJournalRepository : IRepository<CashReceiptsJournalModel>
    {
        Dictionary<string, string> GetRecordByJevID(int jevId);

        bool JevIdExist(int jevId);

        bool UpdateByJevId(CashReceiptsJournalModel entity);
    }
}
