using System;
using ACC.Domain.Interfaces;
using ACC.Data;

namespace AccountingSystem
{
    public static class Factory
    {
        private static MySqlGenericCommands mySqlGenericCommands = new MySqlGenericCommands();

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

        public static ISubsidiaryLedgerAccountsRepository SubsidiaryLedgerAccountsRepository() => new SubsidiaryLedgerAccountsRepository(new MySqlGenericCommands());

        public static IGeneralLedgerAccountsRepository GeneralLedgerAccountsRepository() => new GeneralLedgerAccountsRepository(new MySqlGenericCommands());

        public static ISubMajorAccountGroupRepository SubMajorAccountGroupRepository() => new SubMajorAccountGroupRepository(new MySqlGenericCommands());

        public static IMajorAccountGroupRepository MajorAccountGroupRepository() => new MajorAccountGroupRepository(new MySqlGenericCommands());

        public static IAccountGroupRepository AccountGroupRepository() => new AccountGroupRepository(new MySqlGenericCommands());

        public static IBeginningBalancesRepository BeginningBalancesRepository() => new BeginningBalancesRepository(new MySqlGenericCommands());

        public static IJournalsRepository JournalsRepository() => new JournalsRepository(new MySqlGenericCommands());

        public static IFundsRepository FundsRepository() => new FundsRepository(new MySqlGenericCommands());

        public static IAllotmentClassesRepository AllotmentClassesRepository() => new AllotmentClassesRepository(new MySqlGenericCommands());

        public static IFunctionalClassificationRepository FunctionalClassificationRepository() => new FunctionalClassificationRepository(new MySqlGenericCommands());

        public static IFunctionalClassificationServiceRepository FunctionalClassificationServiceRepository() => new FunctionalClassificationServiceRepository(new MySqlGenericCommands());

        public static IFunctionProgramProjectRepository FunctionProgramProjectRepository() => new FunctionProgramProjectRepository(new MySqlGenericCommands());

        public static IDisbursingOfficerRepository DisbursingOfficerRepository() => new DisbursingOfficerRepository(new MySqlGenericCommands());

        public static ICollectingOfficerRepository CollectingOfficerRepository() => new CollectingOfficerRepository(new MySqlGenericCommands());

        public static IRoleHasPermissionsRepository RoleHasPermissionsRepository() => new RoleHasPermissionsRepository(mySqlGenericCommands);

        public static IRolesRepository RolesRepository() => new RolesRepository(mySqlGenericCommands, RoleHasPermissionsRepository());

        public static IUsersRepository UsersRepository() => new UsersRepository(new MySqlGenericCommands());

        public static IPermissionsRepository PermissionsRepository() => new PermissionsRepository(new MySqlGenericCommands());

        public static IOthersFPPRepository OthersFPPRepository() => new OthersFPPRepository(new MySqlGenericCommands());


        //A part of Budget System
        public static IBudgetAppropriationsRepository BudgetAppropriationsRepository() => new BudgetAppropriationsRepository(new MySqlGenericCommands());

        public static IAllotmentReleaseRepository AllotmentReleaseRepository() => new AllotmentReleaseRepository(new MySqlGenericCommands());

        public static ISupplementalAppropriationsRepository SupplementalAppropriationsRepository() => new SupplementalAppropriationsRepository(new MySqlGenericCommands());

        public static IObligationRequestRepository ObligationRequestRepository() => new ObligationRequestRepository(new MySqlGenericCommands(), ObligationAccountRepository());

        public static IObligationAccountRepository ObligationAccountRepository() => new ObligationAccountRepository(new MySqlGenericCommands());

        public static IError CreateErrors(Array errors) => new Error(errors);
        public static IBanksRepository BanksRepository() => new BanksRepository(new MySqlGenericCommands());
        public static IRCIRepository RCIRepository() => new RCIRepository(new MySqlGenericCommands());
        public static IAccountableRepository AccountableRepository() => new AccountableRepository(new MySqlGenericCommands());
        public static IPaymentCollectionRepository PaymentCollectionRepository() => new PaymentCollectionRepository(new MySqlGenericCommands());
    }
}
