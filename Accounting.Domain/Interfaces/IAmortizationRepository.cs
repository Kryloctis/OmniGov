using Accounting.Domain.Entities;
using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Core.Interfaces.Services;
using OmniGov.Core.Interfaces.Factories;

namespace Accounting.Domain.Interfaces
{
    public interface IAmortizationRepository : IRepository<AmortizationModel>
    {
    }
}
