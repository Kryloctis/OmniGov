using OmniGov.Core.Interfaces.Repositories;
using Treasury.Domain.Entities;

namespace Treasury.Domain.Interfaces
{
    public interface IDisbursingOfficerRepository : IRepository<DisbursingOfficerModel>
    {
        Dictionary<string, string> GetRecordByUserID(int Id);
    }
}