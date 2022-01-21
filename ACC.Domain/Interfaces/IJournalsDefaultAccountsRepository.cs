using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IJournalsDefaultAccountsRepository : IRepository<JournalsDefaultAccountsModel>
    {
        bool Insert(List<JournalsDefaultAccountsModel> entityList);

        bool DeleteByFundId(List<JournalsDefaultAccountsModel> entityList);

        DataTable GetViewRecordsByJournalId(int journalId, int fundId);

        bool GeneralLedgerAccountExist(int journalId, int generalLedgerAccountId);

        bool GeneralLedgerAccountExist(int journalId, int generalLedgerAccountId, int fundId);
    }
}
