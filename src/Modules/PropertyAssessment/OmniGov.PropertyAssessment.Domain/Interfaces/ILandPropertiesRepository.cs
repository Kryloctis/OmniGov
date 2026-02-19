using OmniGov.Core.Interfaces.Repositories;
using PropertyAssessment.Domain.Entities;

namespace PropertyAssessment.Domain.Interfaces
{
    public interface ILandPropertiesRepository : IRepository<LandPropertiesModel>
    {
        public Dictionary<string, string> GetViewRecordByArpNo(string arpNo);
    }
}