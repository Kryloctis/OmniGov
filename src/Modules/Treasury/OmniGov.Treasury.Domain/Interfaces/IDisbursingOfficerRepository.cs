using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Treasury.Domain.Entities;

namespace OmniGov.Treasury.Domain.Interfaces
{
    public interface IDisbursingOfficerRepository : IRepository<DisbursingOfficerModel>
    {
        Dictionary<string, string> GetRecordByUserID(int Id);
    }
}
