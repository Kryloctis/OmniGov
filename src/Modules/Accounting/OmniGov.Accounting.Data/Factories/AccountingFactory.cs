using OmniGov.Accounting.Domain.Interfaces;

namespace OmniGov.Accounting.Data.Factories
{
    public class AccountingFactory
    {
        private static T Resolve<T>() where T : notnull => OmniGov.Core.Services.ServiceLocator.GetRequiredService<T>();

        public static IJevRepository JEVRepository() => Resolve<IJevRepository>();

        public static IAmortizationRepository AmortizationRepository() => Resolve<IAmortizationRepository>();

        public static IAmortizationScheduleRepository AmortizationScheduleRepository() => Resolve<IAmortizationScheduleRepository>();

        public static IBeginningBalancesRepository BeginningBalancesRepository() => Resolve<IBeginningBalancesRepository>();

        public static IJevAccountsRepository JEVAccountsRepository() => Resolve<IJevAccountsRepository>();

        public static IGeneralJournalRepository GeneralJournalRepository() => Resolve<IGeneralJournalRepository>();

        public static ICashDisbursementsJournalRepository CashDisbursementsJournalRepository() => Resolve<ICashDisbursementsJournalRepository>();

        public static ICheckDisbursementsJournalRepository CheckDisbursementsJournalRepository() => Resolve<ICheckDisbursementsJournalRepository>();

        public static ICashReceiptsJournalRepository CashReceiptsJournalRepository() => Resolve<ICashReceiptsJournalRepository>();

        public static IAdaDisbursementsJournalRepository ADADisbursementsJournalRepository() => Resolve<IAdaDisbursementsJournalRepository>();

        public static ISubsidiaryLedgerAccountsRepository SubsidiaryLedgerAccountsRepository() => Resolve<ISubsidiaryLedgerAccountsRepository>();

        public static IGeneralLedgerAccountsRepository GeneralLedgerAccountsRepository() => Resolve<IGeneralLedgerAccountsRepository>();
    }
}
