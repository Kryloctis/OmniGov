using ACC.Domain.Models;
using System;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IJEVAccountsRepository : IRepository<JEVAccountsModel>
    {
        DataTable GetViewRecordsByJevId(int jevId);

        DataTable GetViewRecordsByFundJournalDate(byte fundId, byte journalId, DateTime dateEntry);

        //GENERAL LEDGER
        DataTable GetViewRecordsByFundAndGeneralLedgerAndYear(int fundId, int generalLedgerId, short year);

        //SUBSIDIARY LEDGER
        DataTable GetViewRecordsByFundAndSubsidiaryLedgerAndSubsidiaryLedgerAndYear(int fundId, int generalLedgerId, int subsidiaryLedgerId, short year);

        //STATEMENT OF FINANCIAL PERFORMANCE
        Decimal GetSumTransactionsByFundAndAccountAndIsDebitAndDateEntry(int fundId, int generalLedgerId, bool isDebit, DateTime dateEntry);


        DataTable GetJEVAmount(byte fundId, ushort generalLedgerId, short year);

        bool DeleteByJevId(int jevId);

        int CountByJevId(int jevId);

        decimal GetJEVSumByGeneralLedgerId(byte fundsId, ushort generalLedgerId, short year);

        bool IsTransactionDebit(byte fundsId, ushort generalLedgerId, short year);
    }
}
