using Microsoft.Extensions.DependencyInjection;
using OmniGov.Treasury.Data.Factories;
using OmniGov.Treasury.Data.Repositories;
using OmniGov.Treasury.Domain.Interfaces;
using OmniGov.Treasury.Domain.Interfaces.Factories;

namespace OmniGov.Treasury.Data.Services
{
    public static class TreasuryServiceConfiguration
    {
        public static IServiceCollection AddTreasuryServices(this IServiceCollection services)
        {
            services.AddScoped<ITreasuryFactory, TreasuryFactoryRepository>();
            RegisterTreasuryRepositories(services);

            return services;
        }

        private static void RegisterTreasuryRepositories(IServiceCollection services)
        {
            services.AddScoped<IAccountableFormsRepository, AccountableFormsRepository>();
            services.AddScoped<IAuctionRepository, AuctionRepository>();
            services.AddScoped<IBankAccountsRepository, BankAccountsRepository>();
            services.AddScoped<IBankDepositsRepository, BankDepositsRepository>();
            services.AddScoped<IBanksRepository, BanksRepository>();
            services.AddScoped<IBidRepository, BidRepository>();
            services.AddScoped<IBiddersRepository, BiddersRepository>();
            services.AddScoped<IBurialPermitRepository, BurialPermitRepository>();
            services.AddScoped<IBusinessAdOnChargesRepository, BusinessAddOnChargesRepository>();
            services.AddScoped<IBusinessCategoriesHasAddOnCharges, BusinessCategoriesHasAddOnChargesRepository>();
            services.AddScoped<IBusinessCategoriesRepository, BusinessCategoriesRepository>();
            services.AddScoped<ICashTicketsIssuedRepository, CashTicketsIssuedRepository>();
            services.AddScoped<ICashTicketsRepository, CashTicketsRepository>();
            services.AddScoped<ICattleOwnershipRepository, CattleOwnershipRepository>();
            services.AddScoped<IChequesRepository, ChequesRepository>();
            services.AddScoped<ICollectingOfficerHasJobOrders, CollectingOfficerHasJobOrdersRepository>();
            services.AddScoped<ICollectingOfficerRepository, CollectingOfficerRepository>();
            services.AddScoped<ICommunityTaxCertificateRepository, CommunityTaxCertificateRepository>();
            services.AddScoped<IDelinquentNotice, DelinquentNoticeRepository>();
            services.AddScoped<IDisbursingOfficerRepository, DisbursingOfficerRepository>();
            services.AddScoped<IJobOrder, JobOrderRepository>();
            services.AddScoped<IMarriageLicenseRepository, MarriageLicenseRepository>();
            services.AddScoped<IOtherPaymentRatesRepository, OtherPaymentRatesRepository>();
            services.AddScoped<IPaymentCollectionHasChequesRepository, PaymentCollectionHasChequesRepository>();
            services.AddScoped<IPaymentCollectionsRepository, PaymentCollectionsRepository>();
            services.AddScoped<IPaymentFeesCharges, PaymentFeesChargesRepository>();
            services.AddScoped<IPrevCattleOwnership, PrevCattleOwnershipRepository>();
            services.AddScoped<IRcdCollections, RcdCollectionRepository>();
            services.AddScoped<IRcdDeposits, RcdDepositsRepository>();
            services.AddScoped<IRcdRepository, RcdRepository>();
            services.AddScoped<IRciDeductionsRepository, RCIDeductionsRepository>();
            services.AddScoped<IRciObligationsRepository, RCIObligationsRepository>();
            services.AddScoped<IRciRepository, RciRepository>();
            services.AddScoped<IRealPropertiesRepository, RealPropertiesRepository>();
            services.AddScoped<IReceiptsIssuedRepository, ReceiptsIssuedRepository>();
            services.AddScoped<IReceiptsRepository, ReceiptsRepository>();
            services.AddScoped<IReleasedCheques, ReleasedChequesRepository>();
            services.AddScoped<IRptAssessmentPostsRepository, RptAssessmentPostsRepository>();
            services.AddScoped<IRptAuctionRepository, RptAuctionRepository>();
            services.AddScoped<IRptDiscountsRepository, RptDiscountsRepository>();
            services.AddScoped<IRptLevy, RptLevyRepository>();
            services.AddScoped<IRptPaymentRepository, RptPaymentsRepository>();
            services.AddScoped<IRptPenaltiesRepository, RptPenaltiesRepository>();
            services.AddScoped<IRptPreviousAssessment, RptPreviousAssessmentRepository>();
            services.AddScoped<IRptTaxDuesRepository, RptTaxDuesRepository>();
            services.AddScoped<IRptTaxRatesRepository, RptTaxRatesRepository>();
            services.AddScoped<ITaxTypesRepository, TaxTypesRepository>();
            services.AddScoped<ITaxpayerTypeRepository, TaxpayerTypeRepository>();
            services.AddScoped<ITaxpayersRepository, TaxpayerRepository>();
        }
    }
}
