using System.Data;
using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IRCIRepository:IRepository<RCIModel>
    {
        DataTable GetRecordsByAccountId(int Id,string month);
        DataTable GetRecords(int id);
        bool SaveRCIDVObligations(short rciId, string obligationNo);
        bool SaveRCIDeductions(short rciId, string description, decimal amount);
        string GetRecentRCIId();

    }
}
