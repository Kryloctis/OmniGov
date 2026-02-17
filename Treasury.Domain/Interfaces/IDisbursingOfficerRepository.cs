using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Core.Interfaces.Services;
using OmniGov.Core.Interfaces.Factories;
using Treasury.Domain.Entities;

namespace Treasury.Domain.Interfaces
{
    public interface IDisbursingOfficerRepository : IRepository<DisbursingOfficerModel>
    {
        Dictionary<string, string> GetRecordByUserID(int Id);
    }
}
