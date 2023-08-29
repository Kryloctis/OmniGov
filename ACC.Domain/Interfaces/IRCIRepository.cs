using ACC.Domain.Models;
using System;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IRCIRepository : IAccRepository<RCIModel>
    {
        DataTable GetViewRecordsByBankAccountIdAndMonth(int bankAccountID, string month);
        DataTable GetViewRecords();
        DataTable GetViewRecordsBySearch(string searchText);
        DataTable GetRecordsByBankAndAccountID(int bankID, int bankAccountID);
        bool SaveRCIDVObligations(int rciId, string obligationNo, DateTime dateEntry);
        bool SaveRCIDeductions(int rciId, string description, decimal amount);
        int GetLastInsertId();


    }
}