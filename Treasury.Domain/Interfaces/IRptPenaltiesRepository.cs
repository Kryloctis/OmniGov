using OmniGov.Core.Interfaces;
using Treasury.Domain.Entities;

namespace Treasury.Domain.Interfaces
{
    public interface IRptPenaltiesRepository : IRepository<RptPenaltiesModel>
    {
        Dictionary<string, string> GetRecordByDescription(string description);
    }
}