using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Treasury.Domain.Entities;

namespace OmniGov.Treasury.Domain.Interfaces
{
    public interface IRptPenaltiesRepository : IRepository<RptPenaltiesModel>
    {
        Dictionary<string, string> GetRecordByDescription(string description);
    }
}
