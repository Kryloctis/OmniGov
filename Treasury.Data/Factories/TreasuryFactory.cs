using OmniGov.Core.Repositories;
using OmniGov.Core.Factories;
using OmniGov.Core.Services;
using Treasury.Data.Repositories;
using Treasury.Domain.Interfaces;

namespace Treasury.Data.Factories
{
    public class TreasuryFactory
    {
        private static GenericCommands genericCommands;

        public static IDisbursingOfficerRepository DisbursingOfficerRepository() => new DisbursingOfficerRepository(genericCommands);

        public static ICollectingOfficerRepository CollectingOfficerRepository() => new CollectingOfficerRepository(genericCommands);

        public static IBanksRepository BanksRepository() => new BanksRepository(genericCommands);

        public static IBankAccountsRepository BankAccountsRepository() => new BankAccountsRepository(genericCommands);

        public static IRCIObligationsRepository RCIObligationsRepository() => new RCIObligationsRepository(genericCommands);

        public static IRCIDeductionsRepository RCIDeductionsRepository() => new RCIDeductionsRepository(genericCommands);

        public static IRciRepository RciRepository() => new RciRepository(genericCommands);

        public static IAccountableRepository AccountableFormsRepository() => new AccountableFormsRepository(genericCommands);

        public static IPaymentCollectionsRepository PaymentCollectionsRepository() => new PaymentCollectionsRepository(genericCommands, RptPaymentepository(), MarriageLicenseRepository(), CattleOwnershipRepository(), PrevCattleOwnershipRepository(), BurialPermitRepository(), PaymentCollectionHasChequesRepository(), PaymentFeesChargesRepository(), RcdCollectionsRepository(), RcdDepositsRepository(), BidRepository(), BiddersRepository(), CommunityTaxCertificateRepository());

        public static IBankDepositsRepository BankDepositsRepository() => new BankDepositsRepository(genericCommands, RcdDepositsRepository());

        public static IReceiptsRepository ReceiptsRepository() => new ReceiptsRepository(genericCommands);

        public static IReceiptsIssuedRepository ReceiptsIssuedRepository() => new ReceiptsIssuedRepository(genericCommands);

        public static IJobOrder JobOrderRepository() => new JobOrderRepository(genericCommands);

        public static ICollectingOfficerHasJobOrders CollectingOfficerHasJobOrdersRepository() => new CollectingOfficerHasJobOrdersRepository(genericCommands);

        public static IRptDiscountsRepository RptDiscountRepository() => new RptDiscountsRepository(genericCommands);

        public static IRptPenaltiesRepository RptPenaltiesRepository() => new RptPenaltiesRepository(genericCommands);

        public static IRptTaxRatesRepository RptTaxRatesRepository() => new RptTaxRatesRepository(genericCommands);

        public static IRptAssessmentPostsRepository RptAssessmentPostsRepository() => new RptAssessmentPostsRepository(genericCommands);

        public static IRptTaxDuesRepository RptTaxDuesRepository() => new RptTaxDuesRepository(genericCommands);

        public static IRptPaymentRepository RptPaymentepository() => new RptPaymentsRepository(genericCommands, RptTaxDuesRepository());

        public static IRealPropertiesRepository RealPropertiesRepository() => new RealPropertiesRepository(genericCommands,
                                                                                                            Factory.ProvincesRepository(),
                                                                                                            Factory.MunicipalitiesRepository(),
                                                                                                            Factory.BarangayRepository(),
                                                                                                            Factory.ActualUseCodesRepository(),
                                                                                                            Factory.ClassificationCodesRepository(),
                                                                                                            TaxpayerTypeRepository(),
                                                                                                            TaxpayersRepository(),
                                                                                                            RptPreviousAssessmentRepository());

        public static ITaxpayersRepository TaxpayersRepository() => new TaxpayerRepository(genericCommands);

        public static ITaxpayerTypeRepository TaxpayerTypeRepository() => new TaxpayerTypeRepository(genericCommands);

        public static IRptPreviousAssessment RptPreviousAssessmentRepository() => new RptPreviousAssessmentRepository(genericCommands);

        public static IBusinessCategoriesRepository BusinessCategoriesRepository() => new BusinessCategoriesRepository(genericCommands);

        public static IBusinessAdOnChargesRepository BusinessAddOnChargesRepository() => new BusinessAddOnChargesRepository(genericCommands);

        public static IBusinessCategoriesHasAddOnCharges BusinessCategoriesHasAddOnCharges() => new BusinessCategoriesHasAddOnChargesRepository(genericCommands);

        public static IChequesRepository ChequesRepository() => new ChequesRepository(genericCommands);

        public static IPaymentCollectionHasChequesRepository PaymentCollectionHasChequesRepository() => new PaymentCollectionHasChequesRepository(genericCommands, ChequesRepository());

        public static IReleasedCheques ReleasedChequesRepository() => new ReleasedChequesRepository(genericCommands);

        public static ITaxTypesRepository TaxTypesRepository() => new TaxTypesRepository(genericCommands);

        public static IOtherPaymentRatesRepository OtherPaymentRatesRepository() => new OtherPaymentRatesRepository(genericCommands);

        public static IMarriageLicenseRepository MarriageLicenseRepository() => new MarriageLicenseRepository(genericCommands);

        public static IBurialPermitRepository BurialPermitRepository() => new BurialPermitRepository(genericCommands);

        public static ICattleOwnershipRepository CattleOwnershipRepository() => new CattleOwnershipRepository(genericCommands);

        public static IPaymentFeesCharges PaymentFeesChargesRepository() => new PaymentFeesChargesRepository(genericCommands);

        public static IPrevCattleOwnership PrevCattleOwnershipRepository() => new PrevCattleOwnershipRepository(genericCommands);

        public static IRcd RcdRepository() => new RcdRepository(genericCommands, RcdCollectionsRepository(), RcdDepositsRepository());

        public static IRcdCollections RcdCollectionsRepository() => new RcdCollectionRepository(genericCommands);

        public static IRcdDeposits RcdDepositsRepository() => new RcdDepositsRepository(genericCommands);

        public static IDelinquentNotice DelinquentNoticeRepository() => new DelinquentNoticeRepository(genericCommands);

        public static IRptLevy RptLevyRepository() => new RptLevyRepository(genericCommands);

        public static IAuctionRepository AuctionRepository() => new AuctionRepository(genericCommands);

        public static IRptAuctionRepository RptAuctionRepository() => new RptAuctionRepository(genericCommands);

        public static IBiddersRepository BiddersRepository() => new BiddersRepository(genericCommands);

        public static IBidRepository BidRepository() => new BidRepository(genericCommands);

        public static ICommunityTaxCertificateRepository CommunityTaxCertificateRepository() => new CommunityTaxCertificateRepository(genericCommands);

        public static ICashTicketsRepository CashTicketsRepository() => new CashTicketsRepository(genericCommands);

        public static ICashTicketsIssuedRepository CashTicketsIssuedRepository() => new CashTicketsIssuedRepository(genericCommands);
    }
}