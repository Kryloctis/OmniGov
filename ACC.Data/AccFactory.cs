using ACC.Data;
using ACC.Domain.Interfaces;
using RPT.Domain.Interfaces;
using System;
using System.Net.Http.Headers;

namespace AccountingSystem
{
    public static class AccFactory
    {
        public static AccGenericCommands mySqlGenericCommandsLFS;

        public static byte UserId = 1;

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

        #region Budget Approprations

        public static IBudgetAppropriationsRepository BudgetAppropriationsRepository() => new BudgetAppropriationsRepository(mySqlGenericCommandsLFS, SupplementalAppropriationsRepository());

        public static IRealignments RealignmentsRepository() => new RealignmentsRepository(mySqlGenericCommandsLFS);

        public static IBudgetAppropriationsHasRealignments BudgetAppropriationsHasRealignments() => new BudgetAppropriationsHasRealignmentsRepository(mySqlGenericCommandsLFS);

        public static ISupplementalAppropriationsRepository SupplementalAppropriationsRepository() => new SupplementalAppropriationsRepository(mySqlGenericCommandsLFS);

        public static IAugmentations AugmentationsRepository() => new AugmentationsRepository(mySqlGenericCommandsLFS);

        public static IBudgetAppropriationHasAugmentations BudgetAppropriationHasAugmentationsRepository() => new BudgetAppropriationHasAugmentationsRepository(mySqlGenericCommandsLFS);

        #endregion Budget Approprations

        public static IAllotmentReleaseRepository AllotmentReleaseRepository() => new AllotmentReleaseRepository(mySqlGenericCommandsLFS, AllotmentAccountRepository());

        public static IAllotmentAccountRepository AllotmentAccountRepository() => new AllotmentAccountRepository(mySqlGenericCommandsLFS);

        public static IObligationRequestRepository ObligationRequestRepository() => new ObligationRequestRepository(mySqlGenericCommandsLFS, ObligationAccountRepository());

        public static IObligationAccountRepository ObligationAccountRepository() => new ObligationAccountRepository(mySqlGenericCommandsLFS);

        public static IError CreateErrors(Array errors) => new Error(errors);

        public static IBanksRepository BanksRepository() => new BanksRepository(mySqlGenericCommandsLFS);

        public static IBankAccountsRepository BankAccountsRepository() => new BankAccountsRepository(mySqlGenericCommandsLFS, BanksRepository());

        public static IRCIObligationsRepository RCIObligationsRepository() => new RCIObligationsRepository(mySqlGenericCommandsLFS);

        public static IRCIDeductionsRepository RCIDeductionsRepository() => new RCIDeductionsRepository(mySqlGenericCommandsLFS);

        public static IRCIRepository RCIRepository() => new RCIRepository(mySqlGenericCommandsLFS);

        public static IAccountableRepository AccountableFormsRepository() => new AccountableFormsRepository(mySqlGenericCommandsLFS);

        public static IPaymentCollectionsRepository PaymentCollectionsRepository() => new PaymentCollectionsRepository(mySqlGenericCommandsLFS, GeneralPaymentRepository(), RptPaymentepository(), MarriageLicenseRepository(), CattleOwnershipRepository(), CattleTransferOfOwnershipRepository(), BurialPermitRepository(), PaymentCollectionHasChequesRepository());

        public static IBankDepositsRepository BankDepositsRepository() => new BankDepositsRepository(mySqlGenericCommandsLFS);

        public static ICollectorReportRepository CollectorReportRepository() => new CollectorReportRepository(mySqlGenericCommandsLFS, CollectorReportPaymentsRepository());

        public static ICollectorReportPaymentsRepository CollectorReportPaymentsRepository() => new CollectorReportPaymentsRepository(mySqlGenericCommandsLFS);

        public static IGeneralCollectionsRepository GeneralCollectionsRepository() => new GeneralCollectionsRepository(mySqlGenericCommandsLFS);

        public static IGeneralCollectionsPaymentsRepository GeneralCollectionsPaymentsRepository() => new GeneralCollectionsPaymentsRepository(mySqlGenericCommandsLFS);

        public static IGeneralCollectionsDepositsRepository GeneralCollectionsDepositsRepository() => new GeneralCollectionsDepositsRepository(mySqlGenericCommandsLFS);

        public static IReceiptsRepository ReceiptsRepository() => new ReceiptsRepository(mySqlGenericCommandsLFS);

        public static IReceiptsIssuedRepository ReceiptsIssuedRepository() => new ReceiptsIssuedRepository(mySqlGenericCommandsLFS);

        public static IJournalsDefaultAccountsRepository JournalsDefaultAccountsRepository() => new JournalsDefaultAccountsRepository(mySqlGenericCommandsLFS);

        public static IAmortizationRepository AmortizationRepository() => new AmortizationRepository(mySqlGenericCommandsLFS);

        public static IAmortizationScheduleRepository AmortizationScheduleRepository() => new AmortizationScheduleRepository(mySqlGenericCommandsLFS);

        public static IFaceValueRepository FaceValueRepository() => new FaceValueRepository(mySqlGenericCommandsLFS);

        public static ISignatories SignatoriesRepository() => new SignatoriesRepository(mySqlGenericCommandsLFS, SignatoriesHasReferencesRepository());

        public static ISignatoriesHasReferences SignatoriesHasReferencesRepository() => new SignatoriesHasReferencesRepository(mySqlGenericCommandsLFS);

        public static IDocumentReferences DocumentReferencesRepository() => new DocumentReferencesRepository(mySqlGenericCommandsLFS);

        public static IDocuments DocumentsRepository() => new DocumentsRepository(mySqlGenericCommandsLFS);

        public static IJobOrder JobOrderRepository() => new JobOrderRepository(mySqlGenericCommandsLFS);

        public static ICollectingOfficerHasJobOrders CollectingOfficerHasJobOrdersRepository() => new CollectingOfficerHasJobOrdersRepository(mySqlGenericCommandsLFS);

        public static IRptDiscountsRepository RptDiscountRepository() => new RptDiscountsRepository(mySqlGenericCommandsLFS);

        public static IRptPenaltiesRepository RptPenaltiesRepository() => new RptPenaltiesRepository(mySqlGenericCommandsLFS);

        public static IRptTaxRatesRepository RptTaxRatesRepository() => new RptTaxRatesRepository(mySqlGenericCommandsLFS);

        public static IRptAssessmentPostingRepository RptAssessmentPostsRepository() => new RptAssessmentPostsRepository(mySqlGenericCommandsLFS);

        public static IGeneralPaymentsRepository GeneralPaymentRepository() => new GeneralPaymentsRepository(mySqlGenericCommandsLFS);

        public static IRptTaxDuesRepository RptTaxDuesRepository() => new RptTaxDuesRepository(mySqlGenericCommandsLFS);

        public static IRptPaymentRepository RptPaymentepository() => new RptPaymentsRepository(mySqlGenericCommandsLFS, RptTaxDuesRepository());

        public static IRealPropertiesRepository RealPropertiesRepository() => new RealPropertiesRepository(mySqlGenericCommandsLFS,
                                                                                                            ProvincesRepository(),
                                                                                                            MunicipalitiesRepository(),
                                                                                                            BarangayRepository(),
                                                                                                            ActualUseCodesRepository(),
                                                                                                            ClassificationCodesRepository(),
                                                                                                            TaxpayerTypeRepository(),
                                                                                                            TaxpayersRepository(),
                                                                                                            RptPreviousAssessmentRepository());

        public static ITaxpayersRepository TaxpayersRepository() => new TaxpayerRepository(mySqlGenericCommandsLFS);

        public static ITaxpayerTypeRepository TaxpayerTypeRepository() => new TaxpayerTypeRepository(mySqlGenericCommandsLFS);

        public static IBarangayRepository BarangayRepository() => new BarangayRepository(mySqlGenericCommandsLFS);

        public static IProvinces ProvincesRepository() => new ProvincesRepository(mySqlGenericCommandsLFS);

        public static IMunicipalities MunicipalitiesRepository() => new MunicipalitiesRepository(mySqlGenericCommandsLFS);

        public static IActualUseCodes ActualUseCodesRepository() => new ActualUseCodesRepository(mySqlGenericCommandsLFS);

        public static IClassificationCodes ClassificationCodesRepository() => new ClassificationCodesRepository(mySqlGenericCommandsLFS);

        public static IRptPreviousAssessment RptPreviousAssessmentRepository() => new RptPreviousAssessmentRepository(mySqlGenericCommandsLFS);

        public static IBusinessCategoriesRepository BusinessCategoriesRepository() => new BusinessCategoriesRepository(mySqlGenericCommandsLFS);

        public static IBusinessAdOnChargesRepository BusinessAddOnChargesRepository() => new BusinessAddOnChargesRepository(mySqlGenericCommandsLFS);

        public static IBusinessCategoriesHasAddOnCharges BusinessCategoriesHasAddOnCharges() => new BusinessCategoriesHasAddOnChargesRepository(mySqlGenericCommandsLFS);

        public static IChequesRepository ChequesRepository() => new ChequesRepository(mySqlGenericCommandsLFS);

        public static IPaymentCollectionHasChequesRepository PaymentCollectionHasChequesRepository() => new PaymentCollectionHasChequesRepository(mySqlGenericCommandsLFS, ChequesRepository());

        public static IReleasedCheques ReleasedChequesRepository() => new ReleasedChequesRepository(mySqlGenericCommandsLFS);

        public static ITaxTypesRepository TaxTypesRepository() => new TaxTypesRepository(mySqlGenericCommandsLFS);

        public static IOtherPaymentRatesRepository OtherPaymentRatesRepository() => new OtherPaymentRatesRepository(mySqlGenericCommandsLFS);

        public static IMarriageLicenseRepository MarriageLicenseRepository() => new MarriageLicenseRepository(mySqlGenericCommandsLFS);

        public static IBurialPermitRepository BurialPermitRepository() => new BurialPermitRepository(mySqlGenericCommandsLFS);

        public static ICattleOwnershipRepository CattleOwnershipRepository() => new CattleOwnershipRepository(mySqlGenericCommandsLFS);

        public static ICattleTransferOfOwnershipRepository CattleTransferOfOwnershipRepository() => new CattleTransferOfOwnershipRepository(mySqlGenericCommandsLFS);
    }
}