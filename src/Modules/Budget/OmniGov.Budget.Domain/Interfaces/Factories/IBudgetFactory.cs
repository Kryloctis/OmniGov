using ACC.Domain.Interfaces;

namespace Budget.Domain.Interfaces.Factories
{
    public interface IBudgetFactory
    {
        IAllotmentAccountRepository AllotmentAccountRepository();

        IAllotmentReleaseRepository AllotmentReleaseRepository();

        IAugmentations AugmentationsRepository();

        IBudgetAppropriationHasAugmentations BudgetAppoprationHasAugmentationsRepository();

        IBudgetAppropriationsHasRealignments BudgetAppropriationsHasRealignmentsRepository();

        IBudgetAppropriationsRepository BudgetAppropriationsRepository();

        IObligationAccountRepository ObligationAccountRepository();

        IObligationRequestRepository ObligationRequestRepository();

        IRealignments RealignmentsRepository();

        ISupplementalAppropriationsRepository SupplementalAppropriationsRepository();
    }
}