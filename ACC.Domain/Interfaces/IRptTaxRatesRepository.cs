using ACC.Domain.Models;
using System.Collections.Generic;

namespace ACC.Domain.Interfaces
{
    public interface IRptTaxRatesRepository : IAccRepository<RptTaxRatesModel>
    {
        Dictionary<string, string> GetRecordByDescription(string description);
    }
}