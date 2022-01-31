using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IGeneralLedgerAccountsRepository : IRepository<GeneralLedgerAccountsModal>
    {
        DataTable GetViewRecords();

        Dictionary<string, string> GetViewRecordByID(ushort generalLedgerId);

        DataTable GetViewRecordsBySearch(string searchText);

        DataTable GetRecordsBySearch();

        DataTable GetGeneralLedgerAccountsIncomeRecords(string searchText);

        DataTable GetGeneralLedgerAccountsIncomeRecords();

        DataTable GetViewRecordsBy_AccountGroupId(int accountGroupId);

        DataTable GetViewRecordsBy_AccountGroupId_Search(int accountGroupId, string searchText);

        DataTable GetViewRecordsByMajorAccGroupName(string majAccGroupName);

        DataTable GetViewRecordsByMajorAccGroupNameSearch(string majAccGroupName, string searchText);



        DataTable GetViewRecordsByAccountGroupName(string accountGroupName);

        DataTable GetViewRecordsByAccountGroupNameSearch(string accountGroupName, string searchText);
    }
}
