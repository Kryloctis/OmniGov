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
        bool SaveRCIDVObligations(short rciId, string obligationNo, DateTime dateEntry);
        bool SaveRCIDeductions(short rciId, string description, decimal amount);
        string GetRecentRCIId();


    }
}