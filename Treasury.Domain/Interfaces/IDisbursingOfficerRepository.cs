using OmniGov.Core.Interfaces;
using Treasury.Domain.Entities;

namespace Treasury.Domain.Interfaces
{
    public interface IDisbursingOfficerRepository : IRepository<DisbursingOfficerModel>
    {
        Dictionary<string, string> GetRecordByUserID(int Id);
    }
}