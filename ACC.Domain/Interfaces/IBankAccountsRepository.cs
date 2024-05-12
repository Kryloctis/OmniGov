using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IBankAccountsRepository : IAccRepository<BankAccountsModel>
    {
        DataTable GetViewRecordsBySearch(int rowLimit, string searchKey);

        Dictionary<string, string> GetViewRecordById(int id);

        DataTable GetViewRecords();

        DataTable GetBankAccountsByBankID(int bankID);
    }
}