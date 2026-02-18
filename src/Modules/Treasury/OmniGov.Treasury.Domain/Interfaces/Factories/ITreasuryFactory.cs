namespace Treasury.Domain.Interfaces.Factories
{
    public interface ITreasuryFactory
    {
        public IAccountableFormsRepository AccountableRepository();

        public IAuctionRepository AuctionRepository();

        public IBankAccountsRepository BankAccountsRepository();

        public IBankDepositsRepository BankDepositsRepository();

        public IBanksRepository BanksRepository();

        public IBidRepository BidRepository();

        public IBiddersRepository BiddersRepository();

        public IBurialPermitRepository BurialPermitRepository();

        public IBusinessAdOnChargesRepository BusinessAdOnChargesRepository();

        public IBusinessCategoriesHasAddOnCharges BusinessCategoriesHasAddOnCharges();

        public IBusinessCategoriesRepository BusinessCategoriesRepository();

        public ICashTicketsIssuedRepository CashTicketsIssuedRepository();

        public ICashTicketsRepository CashTicketsRepository();

        public ICattleOwnershipRepository CattleOwnershipRepository();

        public IChequesRepository ChequesRepository();

        public ICollectingOfficerHasJobOrders CollectingOfficerHasJobOrders();

        public ICollectingOfficerRepository CollectingOfficerRepository();

        public ICommunityTaxCertificateRepository CommunityTaxCertificateRepository();

        public IDelinquentNotice DelinquentNotice();

        public IDisbursingOfficerRepository DisbursingOfficerRepository();

        public IJobOrder JobOrder();

        public IMarriageLicenseRepository MarriageLicenseRepository();

        public IOtherPaymentRatesRepository OtherPaymentRatesRepository();

        public IPaymentCollectionHasChequesRepository PaymentCollectionHasChequesRepository();

        public IPaymentCollectionsRepository PaymentCollectionsRepository();

        public IPaymentFeesCharges PaymentFeesCharges();

        public IPrevCattleOwnership PrevCattleOwnership();

        public IRciDeductionsRepository RciDeductionsRepository();

        public IRciObligationsRepository RciObligationsRepository();

        public IRciRepository RciRepository();

        public IRcdRepository RcdRepository();

        public IRcdCollections RcdCollections();

        public IRcdDeposits RcdDeposits();

        public IRealPropertiesRepository RealPropertiesRepository();

        public IReceiptsIssuedRepository ReceiptsIssuedRepository();

        public IReceiptsRepository ReceiptsRepository();

        public IReleasedCheques ReleasedCheques();

        public IRptAssessmentPostsRepository RptAssessmentPostsRepository();

        public IRptAuctionRepository RptAuctionRepository();

        public IRptDiscountsRepository RptDiscountsRepository();

        public IRptLevy RptLevy();

        public IRptPaymentRepository RptPaymentRepository();

        public IRptPenaltiesRepository RptPenaltiesRepository();

        public IRptPreviousAssessment RptPreviousAssessment();

        public IRptTaxDuesRepository RptTaxDuesRepository();

        public IRptTaxRatesRepository RptTaxRatesRepository();

        public ITaxTypesRepository TaxTypesRepository();

        public ITaxpayerTypeRepository TaxpayerTypeRepository();

        public ITaxpayersRepository TaxpayersRepository();
    }
}