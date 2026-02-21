using Microsoft.Extensions.DependencyInjection;
using OmniGov.Accounting.Data.Factories;
using OmniGov.Accounting.Data.Repositories;
using OmniGov.Accounting.Domain.Interfaces;
using OmniGov.Accounting.Domain.Interfaces.Factories;

namespace Accounting.Data.Services
{
    public static class AccountingServiceConfiguration
    {
        public static IServiceCollection AddAccountingServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountingFactory, AccountingFactoryRepository>();
            RegisterAccountingRepositories(services);

            return services;
        }

        private static void RegisterAccountingRepositories(IServiceCollection services)
        {
            services.AddScoped<IAdaDisbursementsJournalRepository, AdaDisbursementsJournalRepository>();
            services.AddScoped<IAmortizationRepository, AmortizationRepository>();
            services.AddScoped<IAmortizationScheduleRepository, AmortizationScheduleRepository>();
            services.AddScoped<IBeginningBalancesRepository, BeginningBalancesRepository>();
            services.AddScoped<ICashDisbursementsJournalRepository, CashDisbursementsJournalRepository>();
            services.AddScoped<ICashReceiptsJournalRepository, CashReceiptsJournalRepository>();
            services.AddScoped<IGeneralLedgerAccountsRepository, GeneralLedgerAccountsRepository>();
            services.AddScoped<ICheckDisbursementsJournalRepository, CheckDisbursementsJournalRepository>();
            services.AddScoped<IGeneralJournalRepository, GeneralJournalRepository>();
            services.AddScoped<IJevAccountsRepository, JevAccountsRepository>();
            services.AddScoped<IJevRepository, JevRepository>();
            services.AddScoped<ISubsidiaryLedgerAccountsRepository, SubsidiaryLedgerAccountsRepository>();
        }
    }
}