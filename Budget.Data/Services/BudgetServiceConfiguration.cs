using ACC.Domain.Interfaces;
using Budget.Data.Factories;
using Budget.Data.Repositories;
using Budget.Domain.Interfaces;
using Budget.Domain.Interfaces.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace Budget.Data.Services
{
    public static class BudgetServiceConfiguration
    {
        public static IServiceCollection AddBudgetServices(this IServiceCollection services)
        {
            services.AddScoped<IBudgetFactory, BudgetFactoryRepository>();
            RegisterBudgetRepositories(services);

            return services;
        }

        private static void RegisterBudgetRepositories(IServiceCollection services)
        {
            services.AddScoped<IAllotmentAccountRepository, AllotmentAccountRepository>();
            services.AddScoped<IAllotmentReleaseRepository, AllotmentReleaseRepository>();
            services.AddScoped<IAugmentations, AugmentationsRepository>();
            services.AddScoped<IBudgetAppropriationHasAugmentations, BudgetAppropriationHasAugmentationsRepository>();
            services.AddScoped<IBudgetAppropriationsHasRealignments, BudgetAppropriationsHasRealignmentsRepository>();
            services.AddScoped<IBudgetAppropriationsRepository, BudgetAppropriationsRepository>();
            services.AddScoped<IObligationAccountRepository, ObligationAccountRepository>();
            services.AddScoped<IObligationRequestRepository, ObligationRequestRepository>();
            services.AddScoped<IRealignments, RealignmentsRepository>();
            services.AddScoped<ISupplementalAppropriationsRepository, SupplementalAppropriationsRepository>();
        }
    }
}