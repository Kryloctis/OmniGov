namespace OmniGov.Accounting.Domain.Interfaces.Factories
{
    public interface IAccountingFactory
    {
        IAdaDisbursementsJournalRepository adaDisbursementsJournalRepository();

        IAmortizationRepository amortizationRepository();

        IAmortizationScheduleRepository amortizationScheduleRepository();

        IBeginningBalancesRepository beginningBalancesRepository();

        ICashDisbursementsJournalRepository cashDisbursementsJournalRepository();

        ICashReceiptsJournalRepository cashReceiptsJournalRepository();

        ICheckDisbursementsJournalRepository checkDisbursementsJournalRepository();

        IGeneralJournalRepository generalJournalRepository();

        IGeneralLedgerAccountsRepository generalLedgerAccountsRepository();

        IJevAccountsRepository jEVAccountsRepository();

        IJevRepository jevRepository();

        ISubsidiaryLedgerAccountsRepository subsidiaryLedgerAccountsRepository();
    }
}
