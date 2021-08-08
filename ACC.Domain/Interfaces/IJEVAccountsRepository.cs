using ACC.Domain.Models;
using System;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IJEVAccountsRepository : IRepository<JEVAccountsModel>
    {
        DataTable GetViewRecordsByJevId(int jevId);

        DataTable GetViewRecordsByFundJournalDate(byte fundId, byte journalId, DateTime dateEntry);

        DataTable GetViewRecordsByFundAndGeneralLedger(byte fundId, ushort generalLedgerId, short year);

        DataTable GetViewRecordsByFundAndSubsidiaryLedgerAndSubsidiaryLedger(byte fundId, ushort generalLedgerId, ushort subsidiaryLedgerId, short year);

        DataTable GetJEVAmount(byte fundId, ushort generalLedgerId, short year);

        bool DeleteByJevId(int jevId);

        int CountByJevId(int jevId);

        decimal GetJEVSumByGeneralLedgerId(byte fundsId, ushort generalLedgerId, short year);

        bool IsTransactionDebit(byte fundsId, ushort generalLedgerId, short year);
    }
}
