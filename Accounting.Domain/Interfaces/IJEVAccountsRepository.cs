using Accounting.Domain.Entities;
using OmniGov.Core.Interfaces;
using System.Data;

namespace Accounting.Domain.Interfaces
{
    public interface IJEVAccountsRepository : IRepository<JEVAccountsModel>
    {
        bool BulkInsert(List<JEVAccountsModel> jEVAccountsModels);

        DataTable GetViewRecordsByLedgerAccounts();

        DataTable GetViewRecords();

        DataTable GetViewRecordsByJevId(int jevId);

        DataTable GetViewRecordsByFundJournalDate(string fundName, string journalName, DateTime dateEntry);

        //GENERAL LEDGER
        DataTable GetViewRecords(int fundId, int generalLedgerId, short year);

        //SUBSIDIARY LEDGER
        DataTable GetViewRecords(int fundId, int generalLedgerId, int subsidiaryLedgerId, short year);

        //Summary Subsidiary
        Dictionary<string, string> GetViewSummarySubidiaryRecord(int fundId, int generalLedgerId, int subsidiaryLedgerId, short year);

        //TRIAL BALANCE
        Dictionary<string, decimal> GetSumTransactionsByAccGrpId(int fundsId, int accountGroupId, DateTime date);

        Dictionary<string, decimal> GetSumTransactionsByMajAccGrpId(int fundId, int majAccGrpId, DateTime date);

        Dictionary<string, decimal> GetSumTransactionsBySubMajAccGrpId(int fundId, int SubMajAccGrpId, DateTime date);

        Dictionary<string, decimal> GetSumTransactionsByGenLedgerId(int fundsId, int generalLedgerId, DateTime date);

        bool DeleteByJevId(int jevId);

        int CountByJevId(int jevId);
    }
}