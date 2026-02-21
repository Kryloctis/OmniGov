using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Treasury.Domain.Entities;
using System.Data;

namespace OmniGov.Treasury.Domain.Interfaces
{
    public interface IRciRepository : IRepository<RciModel>
    {
        DataTable GetViewRecordsByBankAccountIdAndMonth(int bankAccountID, string month);

        DataTable GetViewRecords();

        Dictionary<string, string> GetViewRecordById(int Id);

        DataTable GetViewRecordsBySearch(string searchText);

        DataTable GetRecordsByBankAndAccountID(int bankID, int bankAccountID);

        bool SaveRciDvObligations(int rciId, string obligationNo, DateTime dateEntry);

        bool SaveRciDeductions(int rciId, string description, decimal amount);

        int GetLastInsertId();
    }
}
