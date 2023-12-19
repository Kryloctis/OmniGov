using ACC.Domain.Models;
using System.Collections.Generic;

namespace ACC.Domain.Interfaces
{
    public interface IRptTaxRatesRepository : IAccRepository<RptTaxRatesModel>
    {
        decimal GetTaxRateByDescription(string description);
    }
}