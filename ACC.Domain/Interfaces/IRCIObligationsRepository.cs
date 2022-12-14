using ACC.Domain.Models;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IRCIObligationsRepository : IAccRepository<RCIObligationsModel>
    {
        DataTable GetRecordsByRCIId(int rciId);

        bool DeleteRecordsByRCIId(int rcidId);
    }
}