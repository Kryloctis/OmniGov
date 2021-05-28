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

        DataTable GetViewRecordsByFundAndGeneralLedger(byte fundId, ushort generalLedgerId, short year);

        bool DeleteByJevId(int jevId);

        int CountByJevId(int jevId);
    }
}
