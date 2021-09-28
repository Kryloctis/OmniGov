using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IJournalsDefaultAccountsRepository : IRepository<JournalsDefaultAccountsModel>
    {
        bool Insert(List<JournalsDefaultAccountsModel> entityList);

        bool Delete(JournalsDefaultAccountsModel entity);

        DataTable GetViewRecordsByJournalId(int journalId);

        bool GeneralLedgerAccountExist(int journalId, int generalLedgerAccountId);
    }
}
