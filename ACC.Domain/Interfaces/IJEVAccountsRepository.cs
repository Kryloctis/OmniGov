using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IJEVAccountsRepository : IRepository<JEVAccountsModel>
    {
        DataTable GetViewRecordsByJevId(int jevId);
        DataTable GetViewRecordsByFundJournalDate(byte fundId, byte journalId, DateTime dateEntry);
        bool DeleteByJevId(int jevId);
        int CountByJevId(int jevId);
    }
}
