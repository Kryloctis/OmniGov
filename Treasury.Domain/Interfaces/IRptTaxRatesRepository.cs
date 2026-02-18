using OmniGov.Core.Interfaces.Repositories;
using Treasury.Domain.Entities;

namespace Treasury.Domain.Interfaces
{
    public interface IRptTaxRatesRepository : IRepository<RptTaxRatesModel>
    {
        decimal GetTaxRateByDescription(string description);
    }
}