using ACC.Data;
using ACC.Domain.Interfaces;

using System;

namespace AccountingSystem
{
    public static class AccFactory
    {
        private static MySqlGenericCommands mySqlGenericCommandsLFS = new MySqlGenericCommands("LocalFinanceInstance");
        public static byte UserId = 2;
        public static IJEVRepository JEVRepository() => new JEVRepository(mySqlGenericCommandsLFS,
                                                                          JEVAccountsRepository(),
                                                                          CheckDisbursementsJournalRepository(),
                                                                          CashReceiptsJournalRepository(),
                                                                          ADADisbursementsJournalRepository(),
                                                                          CashDisbursementsJournalRepository(),
                                                                          GeneralJournalRepository());

        public static IJEVAccountsRepository JEVAccountsRepository() => new JEVAccountsRepository(mySqlGenericCommandsLFS);

        public static IGeneralJournalRepository GeneralJournalRepository() => new GeneralJournalRepository(mySqlGenericCommandsLFS);

        public static ICashDisbursementsJournalRepository CashDisbursementsJournalRepository() => new CashDisbursementsJournalRepository(mySqlGenericCommandsLFS);

        public static ICheckDisbursementsJournalRepository CheckDisbursementsJournalRepository() => new CheckDisbursementsJournalRepository(mySqlGenericCommandsLFS);

        public static ICashReceiptsJournalRepository CashReceiptsJournalRepository() => new CashReceiptsJournalRepository(mySqlGenericCommandsLFS);

        public static IADADisbursementsJournalRepository ADADisbursementsJournalRepository() => new ADADisbursementsJournalRepository(mySqlGenericCommandsLFS);

        public static ISubsidiaryLedgerAccountsRepository SubsidiaryLedgerAccountsRepository() => new SubsidiaryLedgerAccountsRepository(mySqlGenericCommandsLFS);

        public static IGeneralLedgerAccountsRepository GeneralLedgerAccountsRepository() => new GeneralLedgerAccountsRepository(mySqlGenericCommandsLFS);

        public static ISubMajorAccountGroupRepository SubMajorAccountGroupRepository() => new SubMajorAccountGroupRepository(mySqlGenericCommandsLFS);

        public static IMajorAccountGroupRepository MajorAccountGroupRepository() => new MajorAccountGroupRepository(mySqlGenericCommandsLFS);

        public static IAccountGroupRepository AccountGroupRepository() => new AccountGroupRepository(mySqlGenericCommandsLFS);

        public static IBeginningBalancesRepository BeginningBalancesRepository() => new BeginningBalancesRepository(mySqlGenericCommandsLFS);

        public static IJournalsRepository JournalsRepository() => new JournalsRepository(mySqlGenericCommandsLFS);

        public static IFundsRepository FundsRepository() => new FundsRepository(mySqlGenericCommandsLFS);

        public static IAllotmentClassesRepository AllotmentClassesRepository() => new AllotmentClassesRepository(mySqlGenericCommandsLFS);

        public static IFunctionalClassificationRepository FunctionalClassificationRepository() => new FunctionalClassificationRepository(mySqlGenericCommandsLFS);

        public static IFunctionalClassificationServiceRepository FunctionalClassificationServiceRepository() => new FunctionalClassificationServiceRepository(mySqlGenericCommandsLFS);

        public static IFunctionProgramProjectRepository FunctionProgramProjectRepository() => new FunctionProgramProjectRepository(mySqlGenericCommandsLFS);

        public static IDisbursingOfficerRepository DisbursingOfficerRepository() => new DisbursingOfficerRepository(mySqlGenericCommandsLFS);

        public static ICollectingOfficerRepository CollectingOfficerRepository() => new CollectingOfficerRepository(mySqlGenericCommandsLFS);

        public static IRoleHasPermissionsRepository RoleHasPermissionsRepository() => new RoleHasPermissionsRepository(mySqlGenericCommandsLFS);

        public static IRolesRepository RolesRepository() => new RolesRepository(mySqlGenericCommandsLFS, RoleHasPermissionsRepository());

        public static IUsersRepository UsersRepository() => new UsersRepository(mySqlGenericCommandsLFS);

        public static IPermissionsRepository PermissionsRepository() => new PermissionsRepository(mySqlGenericCommandsLFS);

        public static ISubFPPRepository SubFPPRepository() => new SubFPPRepository(mySqlGenericCommandsLFS);


        //A part of Budget System
        public static IBudgetAppropriationsRepository BudgetAppropriationsRepository() => new BudgetAppropriationsRepository(mySqlGenericCommandsLFS, SupplementalAppropriationsRepository());

        public static IAllotmentReleaseRepository AllotmentReleaseRepository() => new AllotmentReleaseRepository(mySqlGenericCommandsLFS, AllotmentAccountRepository());

        public static IAllotmentAccountRepository AllotmentAccountRepository() => new AllotmentAccountRepository(mySqlGenericCommandsLFS);

        public static ISupplementalAppropriationsRepository SupplementalAppropriationsRepository() => new SupplementalAppropriationsRepository(mySqlGenericCommandsLFS);

        public static IObligationRequestRepository ObligationRequestRepository() => new ObligationRequestRepository(mySqlGenericCommandsLFS, ObligationAccountRepository());

        public static IObligationAccountRepository ObligationAccountRepository() => new ObligationAccountRepository(mySqlGenericCommandsLFS);

        public static IError CreateErrors(Array errors) => new Error(errors);

        public static IBanksRepository BanksRepository() => new BanksRepository(mySqlGenericCommandsLFS);

        public static IRCIObligationsRepository RCIObligationsRepository() => new RCIObligationsRepository(mySqlGenericCommandsLFS);

        public static IRCIDeductionsRepository RCIDeductionsRepository() => new RCIDeductionsRepository(mySqlGenericCommandsLFS);

        public static IRCIRepository RCIRepository() => new RCIRepository(mySqlGenericCommandsLFS);

        public static IAccountableRepository AccountableFormsRepository() => new AccountableFormsRepository(mySqlGenericCommandsLFS);

        public static IPaymentCollectionRepository PaymentCollectionRepository() => new PaymentCollectionRepository(mySqlGenericCommandsLFS);

        public static IBankDepositsRepository BankDepositsRepository() => new BankDepositsRepository(mySqlGenericCommandsLFS);

        public static ICollectorReportRepository CollectorReportRepository() => new CollectorReportRepository(mySqlGenericCommandsLFS);

        public static ICollectorReportPaymentsRepository CollectorReportPaymentsRepository() => new CollectorReportPaymentsRepository(mySqlGenericCommandsLFS);

        public static IGeneralCollectionsRepository GeneralCollectionsRepository() => new GeneralCollectionsRepository(mySqlGenericCommandsLFS);

        public static IGeneralCollectionsPaymentsRepository GeneralCollectionsPaymentsRepository() => new GeneralCollectionsPaymentsRepository(mySqlGenericCommandsLFS);

        public static IGeneralCollectionsDepositsRepository GeneralCollectionsDepositsRepository() => new GeneralCollectionsDepositsRepository(mySqlGenericCommandsLFS);

        public static IReceiptsRepository ReceiptsRepository() => new ReceiptsRepository(mySqlGenericCommandsLFS);

        public static IReceiptsIssuedRepository ReceiptsIssuedRepository() => new ReceiptsIssuedRepository(mySqlGenericCommandsLFS);

        public static IJournalsDefaultAccountsRepository JournalsDefaultAccountsRepository() => new JournalsDefaultAccountsRepository(mySqlGenericCommandsLFS);

        public static IBudgetRealignmentRepository BudgetRealignmentRepository() => new BudgetRealignmentRepository(mySqlGenericCommandsLFS);
        public static IAmortizationRepository AmortizationRepository() => new AmortizationRepository(mySqlGenericCommandsLFS);
        public static IAmortizationScheduleRepository AmortizationScheduleRepository() => new AmortizationScheduleRepository(mySqlGenericCommandsLFS);
        public static IFaceValueRepository FaceValueRepository() => new FaceValueRepository(mySqlGenericCommandsLFS);

        public static ISignatories SignatoriesRepository() => new SignatoriesRepository(mySqlGenericCommandsLFS, SignatoriesHasReferencesRepository());

        public static ISignatoriesHasReferences SignatoriesHasReferencesRepository() => new SignatoriesHasReferencesRepository(mySqlGenericCommandsLFS);

        public static IDocumentReferences DocumentReferencesRepository() => new DocumentReferencesRepository(mySqlGenericCommandsLFS);

        public static IDocuments DocumentsRepository() => new DocumentsRepository(mySqlGenericCommandsLFS);

        public static IJobOrder JobOrderRepository() => new JobOrderRepository(mySqlGenericCommandsLFS);

        public static ICollectingOfficerHasJobOrders CollectingOfficerHasJobOrdersRepository() => new CollectingOfficerHasJobOrdersRepository(mySqlGenericCommandsLFS);

        public static IRptDiscountsRepository rptDiscountRepository() => new RptDiscountsRepository(mySqlGenericCommandsLFS);

        public static IRptPenaltiesRepository rptPenaltiesRepository() => new RptPenaltiesRepository(mySqlGenericCommandsLFS);

        public static IRptTaxRatesRepository rptTaxRatesRepository() => new RptTaxRatesRepository(mySqlGenericCommandsLFS);
    }
}
