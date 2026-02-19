using Microsoft.Extensions.DependencyInjection;
using OmniGov.Core.Interfaces.Services;
using OmniGov.Core.Services;
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
            // Create a factory method for GenericCommands targeted at RPT
            services.AddScoped<IBuildingDetailsRepository>(sp => 
                new BuildingDetailsRepository(new GenericCommands(sp.GetRequiredService<IConnectionProvider>(), DatabaseTarget.Rpt)));
            
            services.AddScoped<ILandAppraisalRepository>(sp => 
                new LandAppraisalRepository(new GenericCommands(sp.GetRequiredService<IConnectionProvider>(), DatabaseTarget.Rpt)));
            
            services.AddScoped<ILandPropertiesRepository>(sp => 
                new LandPropertiesRepository(new GenericCommands(sp.GetRequiredService<IConnectionProvider>(), DatabaseTarget.Rpt)));
            
            services.AddScoped<IPreviousAssessment>(sp => 
                new PreviousAssessmentRepository(new GenericCommands(sp.GetRequiredService<IConnectionProvider>(), DatabaseTarget.Rpt)));
            
            services.AddScoped<IRealPropertiesRepository>(sp => 
                new RealPropertiesRepository(new GenericCommands(sp.GetRequiredService<IConnectionProvider>(), DatabaseTarget.Rpt)));
        }
    }
}