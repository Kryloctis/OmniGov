using Microsoft.Extensions.DependencyInjection;
using PropertyAssessment.Data.Factories;
using PropertyAssessment.Data.Repositories;
using PropertyAssessment.Domain.Interfaces;
using PropertyAssessment.Domain.Interfaces.Factories;

namespace PropertyAssessment.Data.Services
{
    public static class PropertyAssessmentServiceConfiguration
    {
        public static IServiceCollection AddPropertyAssessmentServices(this IServiceCollection services)
        {
            services.AddScoped<IPropertyAssessmentFactory, PropertyAssessmentFactoryRepository>();
            RegisterPropertyAssessmentRepositories(services);

            return services;
        }

        private static void RegisterPropertyAssessmentRepositories(IServiceCollection services)
        {
            services.AddScoped<IBuildingDetailsRepository, BuildingDetailsRepository>();
            services.AddScoped<ILandAppraisalRepository, LandAppraisalRepository>();
            services.AddScoped<ILandPropertiesRepository, LandPropertiesRepository>();
            services.AddScoped<IPreviousAssessment, PreviousAssessmentRepository>();
            services.AddScoped<IRealPropertiesRepository, RealPropertiesRepository>();
        }
    }
}