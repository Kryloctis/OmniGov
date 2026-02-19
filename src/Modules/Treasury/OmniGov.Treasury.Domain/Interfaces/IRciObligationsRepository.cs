using OmniGov.Core.Interfaces.Repositories;
using System.Data;
using Treasury.Domain.Entities;

namespace Treasury.Domain.Interfaces
{
    public interface IRciObligationsRepository : IRepository<RCIObligationsModel>
    {
        DataTable GetRecordsByRCIId(int rciId);

        bool DeleteRecordsByRCIId(int rcidId);
    }
}