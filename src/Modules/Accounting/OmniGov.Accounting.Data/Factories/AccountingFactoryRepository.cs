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

        public IAdaDisbursementsJournalRepository adaDisbursementsJournalRepository() => new OmniGov.Accounting.Data.Repositories.AdaDisbursementsJournalRepository(_genericCommands);

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

        public IJevAccountsRepository jEVAccountsRepository()
        => new OmniGov.Accounting.Data.Repositories.JevAccountsRepository(_genericCommands);

        public IJevRepository jevRepository()
        => new OmniGov.Accounting.Data.Repositories.JevRepository(_genericCommands,
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