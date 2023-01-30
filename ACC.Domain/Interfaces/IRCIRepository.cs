using ACC.Domain.Models;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IRCIRepository : IAccRepository<RCIModel>
    {
        DataTable GetViewRecordsByBankIdAndMonth(int Id, string month);
        DataTable GetViewRecords();
        DataTable GetViewRecordsBySearch(string searchText);
        DataTable GetRecordsByBankAndAccountID(int bankID, int bankAccountID);
        bool SaveRCIDVObligations(short rciId, string obligationNo);
        bool SaveRCIDeductions(short rciId, string description, decimal amount);
        string GetRecentRCIId();


    }
}