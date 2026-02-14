using OmniGov.Core.Interfaces;
using Treasury.Domain.Entities;

namespace Treasury.Domain.Interfaces
{
    public interface IRptTaxRatesRepository : IRepository<RptTaxRatesModel>
    {
        decimal GetTaxRateByDescription(string description);
    }
}