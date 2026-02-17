using Budget.Domain.Models;
using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Core.Interfaces.Services;
using OmniGov.Core.Interfaces.Factories;

namespace Budget.Domain.Interfaces
{
    public interface IBudgetAppropriationsHasRealignments : IRepository<BudgetAppropriationsHasRealignmentsModel>
    {
    }
}
