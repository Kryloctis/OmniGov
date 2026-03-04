using OmniGov.Budget.Domain.Interfaces;

namespace OmniGov.Budget.Data.Factories
{
    public class BudgetFactory
    {
        private static T Resolve<T>() where T : notnull => OmniGov.Core.Services.ServiceLocator.GetRequiredService<T>();

        public static IBudgetAppropriationsRepository BudgetAppropriationsRepository() => Resolve<IBudgetAppropriationsRepository>();

        public static IRealignments RealignmentsRepository() => Resolve<IRealignments>();

        public static IBudgetAppropriationsHasRealignments BudgetAppropriationsHasRealignments() => Resolve<IBudgetAppropriationsHasRealignments>();

        public static ISupplementalAppropriationsRepository SupplementalAppropriationsRepository() => Resolve<ISupplementalAppropriationsRepository>();

        public static IAugmentations AugmentationsRepository() => Resolve<IAugmentations>();

        public static IBudgetAppropriationHasAugmentations BudgetAppropriationHasAugmentationsRepository() => Resolve<IBudgetAppropriationHasAugmentations>();

        public static IAllotmentReleaseRepository AllotmentReleaseRepository() => Resolve<IAllotmentReleaseRepository>();

        public static IAllotmentAccountRepository AllotmentAccountRepository() => Resolve<IAllotmentAccountRepository>();

        public static IObligationRequestRepository ObligationRequestRepository() => Resolve<IObligationRequestRepository>();

        public static IObligationAccountRepository ObligationAccountRepository() => Resolve<IObligationAccountRepository>();
    }
}
