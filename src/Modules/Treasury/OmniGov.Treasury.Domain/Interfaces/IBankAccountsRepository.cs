using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Treasury.Domain.Entities;
using System.Data;

namespace OmniGov.Treasury.Domain.Interfaces
{
    public interface IBankAccountsRepository : IRepository<BankAccountsModel>
    {
        DataTable GetViewRecordsBySearch(int rowLimit, string searchKey);

        Dictionary<string, string> GetViewRecordById(int id);

        DataTable GetViewRecords();

        DataTable GetBankAccountsByBankID(int bankID);
    }
}
