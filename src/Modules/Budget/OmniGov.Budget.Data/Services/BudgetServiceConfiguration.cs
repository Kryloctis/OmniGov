using Microsoft.Extensions.DependencyInjection;
using OmniGov.Budget.Data.Factories;
using OmniGov.Budget.Data.Repositories;
using OmniGov.Budget.Domain.Interfaces;
using OmniGov.Budget.Domain.Interfaces.Factories;

namespace OmniGov.Budget.Data.Services
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
