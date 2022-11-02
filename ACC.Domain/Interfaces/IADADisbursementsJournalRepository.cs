using System;
using System.Collections.Generic;
using System.Text;
using ACC.Domain.Models;

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
