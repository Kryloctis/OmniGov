namespace OmniGov.Accounting.Domain.Interfaces.Factories
{
    public interface IAccountingFactory
    {
        IADADisbursementsJournalRepository adaDisbursementsJournalRepository();

        IAmortizationRepository amortizationRepository();

        IAmortizationScheduleRepository amortizationScheduleRepository();

        IBeginningBalancesRepository beginningBalancesRepository();

        ICashDisbursementsJournalRepository cashDisbursementsJournalRepository();

        ICashReceiptsJournalRepository cashReceiptsJournalRepository();

        ICheckDisbursementsJournalRepository checkDisbursementsJournalRepository();

        IGeneralJournalRepository generalJournalRepository();

        IGeneralLedgerAccountsRepository generalLedgerAccountsRepository();

        IJEVAccountsRepository jEVAccountsRepository();

        IJEVRepository jevRepository();

        ISubsidiaryLedgerAccountsRepository subsidiaryLedgerAccountsRepository();
    }
}
