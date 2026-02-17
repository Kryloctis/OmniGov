using OmniGov.Core.Entities;
using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Core.Interfaces.Services;
using OmniGov.Core.Interfaces.Factories;
using System.Data;
using Treasury.Domain.Entities;

namespace Treasury.Domain.Interfaces
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
