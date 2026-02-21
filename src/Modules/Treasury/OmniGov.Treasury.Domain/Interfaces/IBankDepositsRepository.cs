using OmniGov.Core.Entities;
using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Treasury.Domain.Entities;
using System.Data;

namespace OmniGov.Treasury.Domain.Interfaces
{
    public interface IBankDepositsRepository : IRepository<BankDepositsModel>
    {
        DataTable GetRecordsByBankAndAccountID(int bankID, int bankAccountID);

        DataTable GetViewRcdRecord(DateTime date, UsersModel createdBy);

        DataTable GetViewRcdRecord(RcdDepositsModel rcdDepositsModel);

        DataTable GetViewRecordBySearch(string searchKey, DateTime date, int filterRow);

        Dictionary<string, string> GetViewRecordById(int id);
    }
}
