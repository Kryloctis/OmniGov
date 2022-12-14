using RPT.Domain.Models;
using System.Collections.Generic;

namespace RPT.Domain.Interfaces
{
    public interface ILandPropertiesRepository : IRptRepository<LandPropertiesModel>
    {
        public Dictionary<string, string> GetViewRecordByArpNo(string arpNo);
    }
}