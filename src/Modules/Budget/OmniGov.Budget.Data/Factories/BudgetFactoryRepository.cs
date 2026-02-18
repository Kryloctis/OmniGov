using ACC.Domain.Interfaces;
using Budget.Data.Repositories;
using Budget.Domain.Interfaces;
using Budget.Domain.Interfaces.Factories;
using OmniGov.Core.Interfaces.Services;

namespace Budget.Data.Factories
{
    public class BudgetFactoryRepository : IBudgetFactory
    {
        private readonly IGenericCommands _genericCommands;

        public BudgetFactoryRepository(IGenericCommands genericCommands)
        {
            _genericCommands = genericCommands;
        }

        public IAllotmentAccountRepository AllotmentAccountRepository()
        => new AllotmentAccountRepository(_genericCommands);

        public IAllotmentReleaseRepository AllotmentReleaseRepository()
        => new AllotmentReleaseRepository(_genericCommands, AllotmentAccountRepository());

        public IAugmentations AugmentationsRepository()
        => new AugmentationsRepository(_genericCommands);

        public IBudgetAppropriationHasAugmentations BudgetAppoprationHasAugmentationsRepository()
        => new BudgetAppropriationHasAugmentationsRepository(_genericCommands);

        public IBudgetAppropriationsHasRealignments BudgetAppropriationsHasRealignmentsRepository()
        => new BudgetAppropriationsHasRealignmentsRepository(_genericCommands);

        public ISupplementalAppropriationsRepository SupplementalAppropriationsRepository()
        => new SupplementalAppropriationsRepository(_genericCommands);

        public IBudgetAppropriationsRepository BudgetAppropriationsRepository()
        => new BudgetAppropriationsRepository(_genericCommands, SupplementalAppropriationsRepository());

        public IObligationAccountRepository ObligationAccountRepository()
        => new ObligationAccountRepository(_genericCommands);

        public IObligationRequestRepository ObligationRequestRepository()
        => new ObligationRequestRepository(_genericCommands, ObligationAccountRepository());

        public IRealignments RealignmentsRepository()
        => new RealignmentsRepository(_genericCommands);
    }
}