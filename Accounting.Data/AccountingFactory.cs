using Accounting.Data.Repositories;
using Accounting.Domain.Interfaces;
using OmniGov.Core.Repositories;
using OmniGov.Core.Services;

namespace Accounting.Data
{
    public class AccountingFactory
    {
        internal static GenericCommands genericCommands;

        public static IJEVRepository JEVRepository() => new JEVRepository(genericCommands,
                                                                   JEVAccountsRepository(),
                                                                   CheckDisbursementsJournalRepository(),
                                                                   CashReceiptsJournalRepository(),
                                                                   ADADisbursementsJournalRepository(),
                                                                   CashDisbursementsJournalRepository(),
                                                                   GeneralJournalRepository());

        public static IAmortizationRepository AmortizationRepository() => new AmortizationRepository(genericCommands);

        public static IAmortizationScheduleRepository AmortizationScheduleRepository() => new AmortizationScheduleRepository(genericCommands);

        public static IBeginningBalancesRepository BeginningBalancesRepository() => new BeginningBalancesRepository(genericCommands);

        public static IJEVAccountsRepository JEVAccountsRepository() => new JEVAccountsRepository(genericCommands);

        public static IGeneralJournalRepository GeneralJournalRepository() => new GeneralJournalRepository(genericCommands);

        public static ICashDisbursementsJournalRepository CashDisbursementsJournalRepository() => new CashDisbursementsJournalRepository(genericCommands);

        public static ICheckDisbursementsJournalRepository CheckDisbursementsJournalRepository() => new CheckDisbursementsJournalRepository(genericCommands);

        public static ICashReceiptsJournalRepository CashReceiptsJournalRepository() => new CashReceiptsJournalRepository(genericCommands);

        public static IADADisbursementsJournalRepository ADADisbursementsJournalRepository() => new ADADisbursementsJournalRepository(genericCommands);

        public static ISubsidiaryLedgerAccountsRepository SubsidiaryLedgerAccountsRepository() => new SubsidiaryLedgerAccountsRepository(genericCommands);

        public static IGeneralLedgerAccountsRepository GeneralLedgerAccountsRepository() => new GeneralLedgerAccountsRepository(genericCommands);
    }
}

