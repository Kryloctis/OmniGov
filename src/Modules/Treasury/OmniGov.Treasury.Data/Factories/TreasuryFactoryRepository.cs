using OmniGov.Core.Interfaces.Services;
using Treasury.Data.Repositories;
using Treasury.Domain.Interfaces;
using Treasury.Domain.Interfaces.Factories;

namespace Treasury.Data.Factories
{
    public class TreasuryFactoryRepository : ITreasuryFactory
    {
        private readonly IGenericCommands _genericCommands;

        public TreasuryFactoryRepository(IGenericCommands genericCommands)
        {
            _genericCommands = genericCommands ?? throw new ArgumentNullException(nameof(genericCommands));
        }

        public IAccountableFormsRepository AccountableRepository()
            => new AccountableFormsRepository(_genericCommands);

        public IAuctionRepository AuctionRepository()
            => new AuctionRepository(_genericCommands);

        public IBankAccountsRepository BankAccountsRepository()
            => new BankAccountsRepository(_genericCommands);

        public IBankDepositsRepository BankDepositsRepository()
            => new BankDepositsRepository(_genericCommands, RcdDeposits());

        public IBanksRepository BanksRepository()
            => new BanksRepository(_genericCommands);

        public IBidRepository BidRepository()
            => new BidRepository(_genericCommands);

        public IBiddersRepository BiddersRepository()
            => new BiddersRepository(_genericCommands);

        public IBurialPermitRepository BurialPermitRepository()
            => new BurialPermitRepository(_genericCommands);

        public IBusinessAdOnChargesRepository BusinessAdOnChargesRepository()
            => new BusinessAddOnChargesRepository(_genericCommands);

        public IBusinessCategoriesHasAddOnCharges BusinessCategoriesHasAddOnCharges()
            => new BusinessCategoriesHasAddOnChargesRepository(_genericCommands);

        public IBusinessCategoriesRepository BusinessCategoriesRepository()
            => new BusinessCategoriesRepository(_genericCommands);

        public ICashTicketsIssuedRepository CashTicketsIssuedRepository()
            => new CashTicketsIssuedRepository(_genericCommands);

        public ICashTicketsRepository CashTicketsRepository()
            => new CashTicketsRepository(_genericCommands);

        public ICattleOwnershipRepository CattleOwnershipRepository()
            => new CattleOwnershipRepository(_genericCommands);

        public IChequesRepository ChequesRepository()
            => new ChequesRepository(_genericCommands);

        public ICollectingOfficerHasJobOrders CollectingOfficerHasJobOrders()
            => new CollectingOfficerHasJobOrdersRepository(_genericCommands);

        public ICollectingOfficerRepository CollectingOfficerRepository()
            => new CollectingOfficerRepository(_genericCommands);

        public ICommunityTaxCertificateRepository CommunityTaxCertificateRepository()
            => new CommunityTaxCertificateRepository(_genericCommands);

        public IDelinquentNotice DelinquentNotice()
            => new DelinquentNoticeRepository(_genericCommands);

        public IDisbursingOfficerRepository DisbursingOfficerRepository()
            => new DisbursingOfficerRepository(_genericCommands);

        public IJobOrder JobOrder()
            => new JobOrderRepository(_genericCommands);

        public IMarriageLicenseRepository MarriageLicenseRepository()
            => new MarriageLicenseRepository(_genericCommands);

        public IOtherPaymentRatesRepository OtherPaymentRatesRepository()
            => new OtherPaymentRatesRepository(_genericCommands);

        public IPaymentCollectionHasChequesRepository PaymentCollectionHasChequesRepository()
            => new PaymentCollectionHasChequesRepository(_genericCommands, ChequesRepository());

        public IPaymentCollectionsRepository PaymentCollectionsRepository()
            => new PaymentCollectionsRepository(
                _genericCommands,
                RptPaymentRepository(),
                MarriageLicenseRepository(),
                CattleOwnershipRepository(),
                PrevCattleOwnership(),
                BurialPermitRepository(),
                PaymentCollectionHasChequesRepository(),
                PaymentFeesCharges(),
                RcdCollections(),
                RcdDeposits(),
                BidRepository(),
                BiddersRepository(),
                CommunityTaxCertificateRepository());

        public IPaymentFeesCharges PaymentFeesCharges()
            => new PaymentFeesChargesRepository(_genericCommands);

        public IPrevCattleOwnership PrevCattleOwnership()
            => new PrevCattleOwnershipRepository(_genericCommands);

        public IRcdCollections RcdCollections()
            => new RcdCollectionRepository(_genericCommands);

        public IRcdDeposits RcdDeposits()
            => new RcdDepositsRepository(_genericCommands);

        public IRcdRepository RcdRepository()
            => new RcdRepository(_genericCommands, RcdCollections(), RcdDeposits());

        public IRciDeductionsRepository RciDeductionsRepository()
            => new RCIDeductionsRepository(_genericCommands);

        public IRciObligationsRepository RciObligationsRepository()
            => new RCIObligationsRepository(_genericCommands);

        public IRciRepository RciRepository()
            => new RciRepository(_genericCommands);

        public IRealPropertiesRepository RealPropertiesRepository()
            => new RealPropertiesRepository(
                _genericCommands,
                OmniGov.Core.Factories.Factory.ProvincesRepository(),
                OmniGov.Core.Factories.Factory.MunicipalitiesRepository(),
                OmniGov.Core.Factories.Factory.BarangayRepository(),
                OmniGov.Core.Factories.Factory.ActualUseCodesRepository(),
                OmniGov.Core.Factories.Factory.ClassificationCodesRepository(),
                TaxpayerTypeRepository(),
                TaxpayersRepository(),
                RptPreviousAssessment());

        public IReceiptsIssuedRepository ReceiptsIssuedRepository()
            => new ReceiptsIssuedRepository(_genericCommands);

        public IReceiptsRepository ReceiptsRepository()
            => new ReceiptsRepository(_genericCommands);

        public IReleasedCheques ReleasedCheques()
            => new ReleasedChequesRepository(_genericCommands);

        public IRptAssessmentPostsRepository RptAssessmentPostsRepository()
            => new RptAssessmentPostsRepository(_genericCommands);

        public IRptAuctionRepository RptAuctionRepository()
            => new RptAuctionRepository(_genericCommands);

        public IRptDiscountsRepository RptDiscountsRepository()
            => new RptDiscountsRepository(_genericCommands);

        public IRptLevy RptLevy()
            => new RptLevyRepository(_genericCommands);

        public IRptPaymentRepository RptPaymentRepository()
            => new RptPaymentsRepository(_genericCommands, RptTaxDuesRepository());

        public IRptPenaltiesRepository RptPenaltiesRepository()
            => new RptPenaltiesRepository(_genericCommands);

        public IRptPreviousAssessment RptPreviousAssessment()
            => new RptPreviousAssessmentRepository(_genericCommands);

        public IRptTaxDuesRepository RptTaxDuesRepository()
            => new RptTaxDuesRepository(_genericCommands);

        public IRptTaxRatesRepository RptTaxRatesRepository()
            => new RptTaxRatesRepository(_genericCommands);

        public ITaxpayersRepository TaxpayersRepository()
            => new TaxpayerRepository(_genericCommands);

        public ITaxpayerTypeRepository TaxpayerTypeRepository()
            => new TaxpayerTypeRepository(_genericCommands);

        public ITaxTypesRepository TaxTypesRepository()
            => new TaxTypesRepository(_genericCommands);
    }
}