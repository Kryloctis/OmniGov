using Treasury.Domain.Interfaces;

namespace Treasury.Data.Factories
{
    public class TreasuryFactory
    {
        private static T Resolve<T>() where T : notnull => OmniGov.Core.Services.ServiceLocator.GetRequiredService<T>();

        public static IDisbursingOfficerRepository DisbursingOfficerRepository() => Resolve<IDisbursingOfficerRepository>();

        public static ICollectingOfficerRepository CollectingOfficerRepository() => Resolve<ICollectingOfficerRepository>();

        public static IBanksRepository BanksRepository() => Resolve<IBanksRepository>();

        public static IBankAccountsRepository BankAccountsRepository() => Resolve<IBankAccountsRepository>();

        public static IRciObligationsRepository RCIObligationsRepository() => Resolve<IRciObligationsRepository>();

        public static IRciDeductionsRepository RCIDeductionsRepository() => Resolve<IRciDeductionsRepository>();

        public static IRciRepository RciRepository() => Resolve<IRciRepository>();

        public static IAccountableFormsRepository AccountableFormsRepository() => Resolve<IAccountableFormsRepository>();

        public static IPaymentCollectionsRepository PaymentCollectionsRepository() => Resolve<IPaymentCollectionsRepository>();

        public static IBankDepositsRepository BankDepositsRepository() => Resolve<IBankDepositsRepository>();

        public static IReceiptsRepository ReceiptsRepository() => Resolve<IReceiptsRepository>();

        public static IReceiptsIssuedRepository ReceiptsIssuedRepository() => Resolve<IReceiptsIssuedRepository>();

        public static IJobOrder JobOrderRepository() => Resolve<IJobOrder>();

        public static ICollectingOfficerHasJobOrders CollectingOfficerHasJobOrdersRepository() => Resolve<ICollectingOfficerHasJobOrders>();

        public static IRptDiscountsRepository RptDiscountRepository() => Resolve<IRptDiscountsRepository>();

        public static IRptPenaltiesRepository RptPenaltiesRepository() => Resolve<IRptPenaltiesRepository>();

        public static IRptTaxRatesRepository RptTaxRatesRepository() => Resolve<IRptTaxRatesRepository>();

        public static IRptAssessmentPostsRepository RptAssessmentPostsRepository() => Resolve<IRptAssessmentPostsRepository>();

        public static IRptTaxDuesRepository RptTaxDuesRepository() => Resolve<IRptTaxDuesRepository>();

        public static IRptPaymentRepository RptPaymentepository() => Resolve<IRptPaymentRepository>();

        public static IRealPropertiesRepository RealPropertiesRepository() => Resolve<IRealPropertiesRepository>();

        public static ITaxpayersRepository TaxpayersRepository() => Resolve<ITaxpayersRepository>();

        public static ITaxpayerTypeRepository TaxpayerTypeRepository() => Resolve<ITaxpayerTypeRepository>();

        public static IRptPreviousAssessment RptPreviousAssessmentRepository() => Resolve<IRptPreviousAssessment>();

        public static IBusinessCategoriesRepository BusinessCategoriesRepository() => Resolve<IBusinessCategoriesRepository>();

        public static IBusinessAdOnChargesRepository BusinessAddOnChargesRepository() => Resolve<IBusinessAdOnChargesRepository>();

        public static IBusinessCategoriesHasAddOnCharges BusinessCategoriesHasAddOnCharges() => Resolve<IBusinessCategoriesHasAddOnCharges>();

        public static IChequesRepository ChequesRepository() => Resolve<IChequesRepository>();

        public static IPaymentCollectionHasChequesRepository PaymentCollectionHasChequesRepository() => Resolve<IPaymentCollectionHasChequesRepository>();

        public static IReleasedCheques ReleasedChequesRepository() => Resolve<IReleasedCheques>();

        public static ITaxTypesRepository TaxTypesRepository() => Resolve<ITaxTypesRepository>();

        public static IOtherPaymentRatesRepository OtherPaymentRatesRepository() => Resolve<IOtherPaymentRatesRepository>();

        public static IMarriageLicenseRepository MarriageLicenseRepository() => Resolve<IMarriageLicenseRepository>();

        public static IBurialPermitRepository BurialPermitRepository() => Resolve<IBurialPermitRepository>();

        public static ICattleOwnershipRepository CattleOwnershipRepository() => Resolve<ICattleOwnershipRepository>();

        public static IPaymentFeesCharges PaymentFeesChargesRepository() => Resolve<IPaymentFeesCharges>();

        public static IPrevCattleOwnership PrevCattleOwnershipRepository() => Resolve<IPrevCattleOwnership>();

        public static IRcdRepository RcdRepository() => Resolve<IRcdRepository>();

        public static IRcdCollections RcdCollectionsRepository() => Resolve<IRcdCollections>();

        public static IRcdDeposits RcdDepositsRepository() => Resolve<IRcdDeposits>();

        public static IDelinquentNotice DelinquentNoticeRepository() => Resolve<IDelinquentNotice>();

        public static IRptLevy RptLevyRepository() => Resolve<IRptLevy>();

        public static IAuctionRepository AuctionRepository() => Resolve<IAuctionRepository>();

        public static IRptAuctionRepository RptAuctionRepository() => Resolve<IRptAuctionRepository>();

        public static IBiddersRepository BiddersRepository() => Resolve<IBiddersRepository>();

        public static IBidRepository BidRepository() => Resolve<IBidRepository>();

        public static ICommunityTaxCertificateRepository CommunityTaxCertificateRepository() => Resolve<ICommunityTaxCertificateRepository>();

        public static ICashTicketsRepository CashTicketsRepository() => Resolve<ICashTicketsRepository>();

        public static ICashTicketsIssuedRepository CashTicketsIssuedRepository() => Resolve<ICashTicketsIssuedRepository>();
    }
}