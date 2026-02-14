using OmniGov.Core.Interfaces;
using System.Data;
using Treasury.Domain.Entities;

namespace Treasury.Domain.Interfaces
{
    public interface IRCIObligationsRepository : IRepository<RCIObligationsModel>
    {
        DataTable GetRecordsByRCIId(int rciId);

        bool DeleteRecordsByRCIId(int rcidId);
    }
}