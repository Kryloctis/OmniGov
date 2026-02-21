using OmniGov.Accounting.Domain.Interfaces;
using OmniGov.Accounting.Domain.Interfaces.Factories;
using OmniGov.Core.Interfaces.Services;

namespace OmniGov.Accounting.Data.Factories
{
    /// <summary>
    /// Instance-based factory for creating Core repository instances with dependency injection
    /// </summary>
    public class AccountingFactoryRepository : IAccountingFactory
    {
        private readonly IGenericCommands _genericCommands;

        public AccountingFactoryRepository(IGenericCommands genericCommands)
        {
            _genericCommands = genericCommands ?? throw new ArgumentNullException(nameof(genericCommands));
        }

        public IADADisbursementsJournalRepository adaDisbursementsJournalRepository() => new OmniGov.Accounting.Data.Repositories.ADADisbursementsJournalRepository(_genericCommands);

        public IAmortizationRepository amortizationRepository()
        => new OmniGov.Accounting.Data.Repositories.AmortizationRepository(_genericCommands);

        public IAmortizationScheduleRepository amortizationScheduleRepository()
        => new OmniGov.Accounting.Data.Repositories.AmortizationScheduleRepository(_genericCommands);

        public IBeginningBalancesRepository beginningBalancesRepository()
        => new OmniGov.Accounting.Data.Repositories.BeginningBalancesRepository(_genericCommands);

        public ICashDisbursementsJournalRepository cashDisbursementsJournalRepository()
        => new OmniGov.Accounting.Data.Repositories.CashDisbursementsJournalRepository(_genericCommands);

        public ICashReceiptsJournalRepository cashReceiptsJournalRepository()
        => new OmniGov.Accounting.Data.Repositories.CashReceiptsJournalRepository(_genericCommands);

        public ICheckDisbursementsJournalRepository checkDisbursementsJournalRepository()
        => new OmniGov.Accounting.Data.Repositories.CheckDisbursementsJournalRepository(_genericCommands);

        public IGeneralJournalRepository generalJournalRepository()
        => new OmniGov.Accounting.Data.Repositories.GeneralJournalRepository(_genericCommands);

        public IGeneralLedgerAccountsRepository generalLedgerAccountsRepository()
        => new OmniGov.Accounting.Data.Repositories.GeneralLedgerAccountsRepository(_genericCommands);

        public IJEVAccountsRepository jEVAccountsRepository()
        => new OmniGov.Accounting.Data.Repositories.JEVAccountsRepository(_genericCommands);

        public IJEVRepository jevRepository()
        => new OmniGov.Accounting.Data.Repositories.JEVRepository(_genericCommands,
                                            jEVAccountsRepository(),
                                            checkDisbursementsJournalRepository(),
                                            cashReceiptsJournalRepository(),
                                            adaDisbursementsJournalRepository(),
                                            cashDisbursementsJournalRepository(),
                                            generalJournalRepository());

        public ISubsidiaryLedgerAccountsRepository subsidiaryLedgerAccountsRepository()
        => new OmniGov.Accounting.Data.Repositories.SubsidiaryLedgerAccountsRepository(_genericCommands);
    }
}
