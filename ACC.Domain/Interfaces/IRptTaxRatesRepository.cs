using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface IRptTaxRatesRepository : IAccRepository<RptTaxRatesModel>
    {
        Dictionary<string, string> GetRecordByDescription(string description);
    }
}
