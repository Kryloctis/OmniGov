using OmniGov.Core.Interfaces.Repositories;
using System.Data;
using Treasury.Domain.Entities;

namespace Treasury.Domain.Interfaces
{
    public interface IBankAccountsRepository : IRepository<BankAccountsModel>
    {
        DataTable GetViewRecordsBySearch(int rowLimit, string searchKey);

        Dictionary<string, string> GetViewRecordById(int id);

        DataTable GetViewRecords();

        DataTable GetBankAccountsByBankID(int bankID);
    }
}