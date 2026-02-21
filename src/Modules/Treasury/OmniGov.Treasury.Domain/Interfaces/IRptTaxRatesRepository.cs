using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Treasury.Domain.Entities;

namespace OmniGov.Treasury.Domain.Interfaces
{
    public interface IRptTaxRatesRepository : IRepository<RptTaxRatesModel>
    {
        decimal GetTaxRateByDescription(string description);
    }
}
