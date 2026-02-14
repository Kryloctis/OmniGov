using OmniGov.Core.Interfaces;
using System.Data;
using Treasury.Domain.Entities;

namespace Treasury.Domain.Interfaces
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