using System;
using System.Collections.Generic;
using System.Text;
using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface ICashDisbursementsJournalRepository : IRepository<CashDisbursementsJournalModel>
    {
        bool UpdateByJevId(CashDisbursementsJournalModel entity);

        bool JevIdExist(int jevId);

        Dictionary<string, string> GetViewRecordByJevID(int jevId);
    }
}
