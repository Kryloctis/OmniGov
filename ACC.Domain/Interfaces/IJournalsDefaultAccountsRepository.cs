using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IJournalsDefaultAccountsRepository : IAccRepository<JournalsDefaultAccountsModel>
    {
        bool Insert(int journalId, int fundId, bool isDebit, List<JournalsDefaultAccountsModel> entityList);

        bool DeleteByJournalIdAndFundAndIsDebit(int journalId, int fundId, bool isDebit);

        DataTable GetViewRecordsByJournalId(int journalId, int fundId, bool isDebit);

        bool GeneralLedgerAccountExist(int journalId, int generalLedgerAccountId);

        bool GeneralLedgerAccountExist(int journalId, int generalLedgerAccountId, int fundId, bool isDebit);
    }
}