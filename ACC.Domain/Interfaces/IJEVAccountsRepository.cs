using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IJEVAccountsRepository : IRepository<JEVAccountsModel>
    {
        DataTable GetViewRecordsByLedgerAccounts();

        DataTable GetViewRecords();

        DataTable GetViewRecordsByJevId(int jevId);

        DataTable GetViewRecordsByFundJournalDate(string fundName, string journalName, DateTime dateEntry);

        //GENERAL LEDGER
        DataTable GetViewRecords(int fundId, int generalLedgerId, short year);

        //SUBSIDIARY LEDGER
        DataTable GetViewRecords(int fundId, int generalLedgerId, int subsidiaryLedgerId, short year);


        //TRIAL BALANCE
        Dictionary<string, decimal> GetSumTransactionsByAccGrpId(int fundsId, int accountGroupId, DateTime dateEntry);

        Dictionary<string, decimal> GetSumTransactionsByGenLedgerId(int fundsId, int generalLedgerId, DateTime dateEntry);

        bool DeleteByJevId(int jevId);

        int CountByJevId(int jevId);
    }
}
