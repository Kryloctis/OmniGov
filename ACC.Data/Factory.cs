using ACC.Data;
using ACC.Domain.Interfaces;
using System;

namespace AccountingSystem
{
    public static class Factory
    {
        private static MySqlGenericCommands mySqlGenericCommands = new MySqlGenericCommands(false);
        public static byte UserId = 2;
        public static IJEVRepository JEVRepository() => new JEVRepository(mySqlGenericCommands,
                                                                          JEVAccountsRepository(),
                                                                          CheckDisbursementsJournalRepository(),
                                                                          CashReceiptsJournalRepository(),
                                                                          ADADisbursementsJournalRepository(),
                                                                          CashDisbursementsJournalRepository(),
                                                                          GeneralJournalRepository());

        public static IJEVAccountsRepository JEVAccountsRepository() => new JEVAccountsRepository(mySqlGenericCommands);

        public static IGeneralJournalRepository GeneralJournalRepository() => new GeneralJournalRepository(mySqlGenericCommands);

        public static ICashDisbursementsJournalRepository CashDisbursementsJournalRepository() => new CashDisbursementsJournalRepository(mySqlGenericCommands);

        public static ICheckDisbursementsJournalRepository CheckDisbursementsJournalRepository() => new CheckDisbursementsJournalRepository(mySqlGenericCommands);

        public static ICashReceiptsJournalRepository CashReceiptsJournalRepository() => new CashReceiptsJournalRepository(mySqlGenericCommands);

        public static IADADisbursementsJournalRepository ADADisbursementsJournalRepository() => new ADADisbursementsJournalRepository(mySqlGenericCommands);

        public static ISubsidiaryLedgerAccountsRepository SubsidiaryLedgerAccountsRepository() => new SubsidiaryLedgerAccountsRepository(new MySqlGenericCommands(false));

        public static IGeneralLedgerAccountsRepository GeneralLedgerAccountsRepository() => new GeneralLedgerAccountsRepository(new MySqlGenericCommands(false));

        public static ISubMajorAccountGroupRepository SubMajorAccountGroupRepository() => new SubMajorAccountGroupRepository(new MySqlGenericCommands(false));

        public static IMajorAccountGroupRepository MajorAccountGroupRepository() => new MajorAccountGroupRepository(new MySqlGenericCommands(false));

        public static IAccountGroupRepository AccountGroupRepository() => new AccountGroupRepository(new MySqlGenericCommands(false));

        public static IBeginningBalancesRepository BeginningBalancesRepository() => new BeginningBalancesRepository(new MySqlGenericCommands(false));

        public static IJournalsRepository JournalsRepository() => new JournalsRepository(new MySqlGenericCommands(false));

        public static IFundsRepository FundsRepository() => new FundsRepository(new MySqlGenericCommands(false));

        public static IAllotmentClassesRepository AllotmentClassesRepository() => new AllotmentClassesRepository(new MySqlGenericCommands(false));

        public static IFunctionalClassificationRepository FunctionalClassificationRepository() => new FunctionalClassificationRepository(new MySqlGenericCommands(false));

        public static IFunctionalClassificationServiceRepository FunctionalClassificationServiceRepository() => new FunctionalClassificationServiceRepository(new MySqlGenericCommands(false));

        public static IFunctionProgramProjectRepository FunctionProgramProjectRepository() => new FunctionProgramProjectRepository(new MySqlGenericCommands(false));

        public static IDisbursingOfficerRepository DisbursingOfficerRepository() => new DisbursingOfficerRepository(new MySqlGenericCommands(false));

        public static ICollectingOfficerRepository CollectingOfficerRepository() => new CollectingOfficerRepository(new MySqlGenericCommands(false));

        public static IRoleHasPermissionsRepository RoleHasPermissionsRepository() => new RoleHasPermissionsRepository(mySqlGenericCommands);

        public static IRolesRepository RolesRepository() => new RolesRepository(mySqlGenericCommands, RoleHasPermissionsRepository());

        public static IUsersRepository UsersRepository() => new UsersRepository(new MySqlGenericCommands(false));

        public static IPermissionsRepository PermissionsRepository() => new PermissionsRepository(new MySqlGenericCommands(false));

        public static ISubFPPRepository SubFPPRepository() => new SubFPPRepository(new MySqlGenericCommands(false));


        //A part of Budget System
        public static IBudgetAppropriationsRepository BudgetAppropriationsRepository() => new BudgetAppropriationsRepository(mySqlGenericCommands, SupplementalAppropriationsRepository());

        public static IAllotmentReleaseRepository AllotmentReleaseRepository() => new AllotmentReleaseRepository(new MySqlGenericCommands(false), AllotmentAccountRepository());

        public static IAllotmentAccountRepository AllotmentAccountRepository() => new AllotmentAccountRepository(new MySqlGenericCommands(false));

        public static ISupplementalAppropriationsRepository SupplementalAppropriationsRepository() => new SupplementalAppropriationsRepository(new MySqlGenericCommands(false));

        public static IObligationRequestRepository ObligationRequestRepository() => new ObligationRequestRepository(new MySqlGenericCommands(false), ObligationAccountRepository());

        public static IObligationAccountRepository ObligationAccountRepository() => new ObligationAccountRepository(new MySqlGenericCommands(false));

        public static IError CreateErrors(Array errors) => new Error(errors);

        public static IBanksRepository BanksRepository() => new BanksRepository(new MySqlGenericCommands(false));

        public static IRCIObligationsRepository RCIObligationsRepository() => new RCIObligationsRepository(new MySqlGenericCommands(false));

        public static IRCIDeductionsRepository RCIDeductionsRepository() => new RCIDeductionsRepository(new MySqlGenericCommands(false));

        public static IRCIRepository RCIRepository() => new RCIRepository(new MySqlGenericCommands(false));

        public static IAccountableRepository AccountableFormsRepository() => new AccountableFormsRepository(new MySqlGenericCommands(false));

        public static IPaymentCollectionRepository PaymentCollectionRepository() => new PaymentCollectionRepository(new MySqlGenericCommands(false));

        public static IBankDepositsRepository BankDepositsRepository() => new BankDepositsRepository(new MySqlGenericCommands(false));

        public static ICollectorReportRepository CollectorReportRepository() => new CollectorReportRepository(new MySqlGenericCommands(false));

        public static ICollectorReportPaymentsRepository CollectorReportPaymentsRepository() => new CollectorReportPaymentsRepository(new MySqlGenericCommands(false));

        public static IGeneralCollectionsRepository GeneralCollectionsRepository() => new GeneralCollectionsRepository(new MySqlGenericCommands(false));

        public static IGeneralCollectionsPaymentsRepository GeneralCollectionsPaymentsRepository() => new GeneralCollectionsPaymentsRepository(new MySqlGenericCommands(false));

        public static IGeneralCollectionsDepositsRepository GeneralCollectionsDepositsRepository() => new GeneralCollectionsDepositsRepository(new MySqlGenericCommands(false));

        public static IReceiptsRepository ReceiptsRepository() => new ReceiptsRepository(new MySqlGenericCommands(false));

        public static IReceiptsIssuedRepository ReceiptsIssuedRepository() => new ReceiptsIssuedRepository(new MySqlGenericCommands(false));

        public static IJournalsDefaultAccountsRepository JournalsDefaultAccountsRepository() => new JournalsDefaultAccountsRepository(new MySqlGenericCommands(false));

        public static IBudgetRealignmentRepository BudgetRealignmentRepository() => new BudgetRealignmentRepository(new MySqlGenericCommands(false));
        public static IAmortizationRepository AmortizationRepository() => new AmortizationRepository(new MySqlGenericCommands(false));
        public static IAmortizationScheduleRepository AmortizationScheduleRepository() => new AmortizationScheduleRepository(new MySqlGenericCommands(false));
        public static IFaceValueRepository FaceValueRepository() => new FaceValueRepository(new MySqlGenericCommands(false));

        public static ISignatories SignatoriesRepository() => new SignatoriesRepository(new MySqlGenericCommands(false), SignatoriesHasReferencesRepository());

        public static ISignatoriesHasReferences SignatoriesHasReferencesRepository() => new SignatoriesHasReferencesRepository(new MySqlGenericCommands(false));

        public static IDocumentReferences DocumentReferencesRepository() => new DocumentReferencesRepository(new MySqlGenericCommands(false));

        public static IDocuments DocumentsRepository() => new DocumentsRepository(new MySqlGenericCommands(false));

        public static IJobOrder JobOrderRepository() => new JobOrderRepository(new MySqlGenericCommands(false));

        public static ICollectingOfficerHasJobOrders CollectingOfficerHasJobOrdersRepository() => new CollectingOfficerHasJobOrdersRepository(new MySqlGenericCommands(false));

        public static IRealPropertiesRepository RealPropertiesRepository() => new RealPropertiesRepository(new MySqlGenericCommands(true));
    }
}
