using ACC.Domain.Models;
using System.Collections.Generic;

namespace ACC.Domain.Interfaces
{
    public interface IRptPenaltiesRepository : IAccRepository<RptPenaltiesModel>
    {
        Dictionary<string, string> GetRecordByDescription(string description);
    }
}