using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IJEVAccountsRepository : IRepository<JEVAccountsModel>
    {
        DataTable GetViewRecordsByJevId(uint jevId);
        DataTable GetViewRecordsByFundAndJournal(byte fundId, byte journalId);
        bool DeleteByJevId(uint jevId);
        int CountByJevId(uint jevId);
    }
}
