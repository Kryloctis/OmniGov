using Accounting.Domain.Interfaces;
using Accounting.Domain.Interfaces.Factories;
using OmniGov.Core.Interfaces.Services;

namespace Accounting.Data.Repositories
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

        public IADADisbursementsJournalRepository adaDisbursementsJournalRepository() => new Repositories.ADADisbursementsJournalRepository(_genericCommands);

        public IAmortizationRepository amortizationRepository()
        => new Repositories.AmortizationRepository(_genericCommands);

        public IAmortizationScheduleRepository amortizationScheduleRepository()
        => new Repositories.AmortizationScheduleRepository(_genericCommands);

        public IBeginningBalancesRepository beginningBalancesRepository()
        => new Repositories.BeginningBalancesRepository(_genericCommands);

        public ICashDisbursementsJournalRepository cashDisbursementsJournalRepository()
        => new Repositories.CashDisbursementsJournalRepository(_genericCommands);

        public ICashReceiptsJournalRepository cashReceiptsJournalRepository()
        => new Repositories.CashReceiptsJournalRepository(_genericCommands);

        public ICheckDisbursementsJournalRepository checkDisbursementsJournalRepository()
        => new Repositories.CheckDisbursementsJournalRepository(_genericCommands);

        public IGeneralJournalRepository generalJournalRepository()
        => new Repositories.GeneralJournalRepository(_genericCommands);

        public IGeneralLedgerAccountsRepository generalLedgerAccountsRepository()
        => new Repositories.GeneralLedgerAccountsRepository(_genericCommands);

        public IJEVAccountsRepository jEVAccountsRepository()
        => new Repositories.JEVAccountsRepository(_genericCommands);

        public IJEVRepository jevRepository()
        => new Repositories.JEVRepository(_genericCommands,
                                            jEVAccountsRepository(),
                                            checkDisbursementsJournalRepository(),
                                            cashReceiptsJournalRepository(),
                                            adaDisbursementsJournalRepository(),
                                            cashDisbursementsJournalRepository(),
                                            generalJournalRepository());

        public ISubsidiaryLedgerAccountsRepository subsidiaryLedgerAccountsRepository()
        => new Repositories.SubsidiaryLedgerAccountsRepository(_genericCommands);
    }
}