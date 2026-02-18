using Accounting.Data.Repositories;
using Accounting.Domain.Interfaces;
using Accounting.Domain.Interfaces.Factories;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddScoped<IADADisbursementsJournalRepository, ADADisbursementsJournalRepository>();
            services.AddScoped<IAmortizationRepository, AmortizationRepository>();
            services.AddScoped<IAmortizationScheduleRepository, AmortizationScheduleRepository>();
            services.AddScoped<IBeginningBalancesRepository, BeginningBalancesRepository>();
            services.AddScoped<ICashDisbursementsJournalRepository, CashDisbursementsJournalRepository>();
            services.AddScoped<ICashReceiptsJournalRepository, CashReceiptsJournalRepository>();
            services.AddScoped<IGeneralLedgerAccountsRepository, GeneralLedgerAccountsRepository>();
            services.AddScoped<ICheckDisbursementsJournalRepository, CheckDisbursementsJournalRepository>();
            services.AddScoped<IGeneralJournalRepository, GeneralJournalRepository>();
            services.AddScoped<IJEVAccountsRepository, JEVAccountsRepository>();
            services.AddScoped<IJEVRepository, JEVRepository>();
            services.AddScoped<ISubsidiaryLedgerAccountsRepository, SubsidiaryLedgerAccountsRepository>();
        }
    }
}