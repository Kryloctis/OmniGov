using ACC.Data;
using ACC.Domain.Interfaces;
using Budget.Data.Repositories;
using Budget.Domain.Interfaces;
using OmniGov.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Data
{
    public class BudgetFactory
    {
        internal static GenericCommands genericCommands;

        public static IBudgetAppropriationsRepository BudgetAppropriationsRepository() => new BudgetAppropriationsRepository(genericCommands, SupplementalAppropriationsRepository());

        public static IRealignments RealignmentsRepository() => new RealignmentsRepository(genericCommands);

        public static IBudgetAppropriationsHasRealignments BudgetAppropriationsHasRealignments() => new BudgetAppropriationsHasRealignmentsRepository(genericCommands);

        public static ISupplementalAppropriationsRepository SupplementalAppropriationsRepository() => new SupplementalAppropriationsRepository(genericCommands);

        public static IAugmentations AugmentationsRepository() => new AugmentationsRepository(genericCommands);

        public static IBudgetAppropriationHasAugmentations BudgetAppropriationHasAugmentationsRepository() => new BudgetAppropriationHasAugmentationsRepository(genericCommands);

        public static IAllotmentReleaseRepository AllotmentReleaseRepository() => new AllotmentReleaseRepository(genericCommands, AllotmentAccountRepository());

        public static IAllotmentAccountRepository AllotmentAccountRepository() => new AllotmentAccountRepository(genericCommands);

        public static IObligationRequestRepository ObligationRequestRepository() => new ObligationRequestRepository(genericCommands, ObligationAccountRepository());

        public static IObligationAccountRepository ObligationAccountRepository() => new ObligationAccountRepository(genericCommands);
    }
}