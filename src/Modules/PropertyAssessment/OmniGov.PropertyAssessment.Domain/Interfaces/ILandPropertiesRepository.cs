using OmniGov.Core.Interfaces.Repositories;
using OmniGov.PropertyAssessment.Domain.Entities;

namespace OmniGov.PropertyAssessment.Domain.Interfaces
{
    public interface ILandPropertiesRepository : IRepository<LandPropertiesModel>
    {
        public Dictionary<string, string> GetViewRecordByArpNo(string arpNo);
    }
}
