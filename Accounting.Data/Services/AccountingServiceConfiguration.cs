using Accounting.Data.Repositories;
using Accounting.Domain.Interfaces;
using Accounting.Domain.Interfaces.Factories;
using Microsoft.Extensions.DependencyInjection;
using OmniGov.Core.Interfaces.Services;
using OmniGov.Core.Services;

namespace Accounting.Data.Services
{
    public static class AccountingServiceConfiguration
    {
        public static IServiceCollection AddAccountingServices(this IServiceCollection services)
        {  // Register connection provider as singleton (shared across the app)
            services.AddSingleton<IConnectionProvider, ConnectionProvider>();

            // Register GenericCommands as scoped (new instance per scope/request)
            services.AddScoped<IGenericCommands>(sp =>
            {
                var connectionProvider = sp.GetRequiredService<IConnectionProvider>();
                return new GenericCommands(connectionProvider);
            });

            // Register the Repository Factory
            //services.AddScoped<IRepositoryFactory, RepositoryFactory>();

            // Register the Accounting Repository Factory
            services.AddScoped<IAccountingFactory, AccountingFactoryRepository>();

            // Register individual repositories (optional - can use factory instead)
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