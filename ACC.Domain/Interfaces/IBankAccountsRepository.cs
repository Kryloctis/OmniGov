using ACC.Domain.Models;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IBankAccountsRepository : IAccRepository<BankAccountsModel>
    {
        DataTable GetViewRecordsBySearch(string searchKey);

        DataTable GetViewRecords();
    }
}