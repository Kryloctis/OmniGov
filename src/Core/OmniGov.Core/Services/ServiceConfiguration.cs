using Microsoft.Extensions.DependencyInjection;
using OmniGov.Core.Factories;
using OmniGov.Core.Interfaces.Factories;
using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Core.Interfaces.Services;
using OmniGov.Core.Repositories;

namespace OmniGov.Core.Services
{
    /// <summary>
    /// Extension methods for configuring Core services in the DI container
    /// </summary>
    public static class ServiceConfiguration
    {
        /// <summary>
        /// Registers all Core services and repositories
        /// </summary>
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            // Register connection provider as singleton (shared across the app)
            services.AddSingleton<IConnectionProvider, ConnectionProvider>();

            // Register GenericCommands as scoped (new instance per scope/request)
            services.AddScoped<IGenericCommands>(sp =>
            {
                var connectionProvider = sp.GetRequiredService<IConnectionProvider>();
                return new GenericCommands(connectionProvider);
            });

            // Register the Repository Factory
            services.AddScoped<IRepositoryFactory, RepositoryFactory>();

            // Register individual repositories (optional - can use factory instead)
            RegisterCoreRepositories(services);

            return services;
        }

        private static void RegisterCoreRepositories(IServiceCollection services)
        {
            services.AddScoped<ISubMajorAccountGroupRepository>(sp =>
            {
                var commands = sp.GetRequiredService<IGenericCommands>();
                return new SubMajorAccountGroupRepository(commands);
            });

            services.AddScoped<IMajorAccountGroupRepository>(sp =>
            {
                var commands = sp.GetRequiredService<IGenericCommands>();
                return new MajorAccountGroupRepository(commands);
            });

            services.AddScoped<IAccountGroupRepository>(sp =>
            {
                var commands = sp.GetRequiredService<IGenericCommands>();
                return new AccountGroupRepository(commands);
            });

            services.AddScoped<IJournalsRepository>(sp =>
            {
                var commands = sp.GetRequiredService<IGenericCommands>();
                return new JournalsRepository(commands);
            });

            services.AddScoped<IFundsRepository>(sp =>
            {
                var commands = sp.GetRequiredService<IGenericCommands>();
                return new FundsRepository(commands);
            });

            services.AddScoped<IAllotmentClassesRepository>(sp =>
            {
                var commands = sp.GetRequiredService<IGenericCommands>();
                return new AllotmentClassesRepository(commands);
            });

            services.AddScoped<IFunctionalClassificationRepository>(sp =>
            {
                var commands = sp.GetRequiredService<IGenericCommands>();
                return new FunctionalClassificationRepository(commands);
            });

            services.AddScoped<IFunctionalClassificationServiceRepository>(sp =>
            {
                var commands = sp.GetRequiredService<IGenericCommands>();
                return new FunctionalClassificationServiceRepository(commands);
            });

            services.AddScoped<IFunctionProgramProjectRepository>(sp =>
            {
                var commands = sp.GetRequiredService<IGenericCommands>();
                return new FunctionProgramProjectRepository(commands);
            });

            services.AddScoped<IRolesPermissionsRepository>(sp =>
            {
                var commands = sp.GetRequiredService<IGenericCommands>();
                return new RolesPermissionsRepository(commands);
            });

            services.AddScoped<IRolesRepository>(sp =>
            {
                var commands = sp.GetRequiredService<IGenericCommands>();
                var rolesPermissionsRepo = sp.GetRequiredService<IRolesPermissionsRepository>();
                return new RolesRepository(commands, rolesPermissionsRepo);
            });

            services.AddScoped<IUsersRepository>(sp =>
            {
                var commands = sp.GetRequiredService<IGenericCommands>();
                return new UsersRepository(commands);
            });

            services.AddScoped<IPermissionsRepository>(sp =>
            {
                var commands = sp.GetRequiredService<IGenericCommands>();
                return new PermissionsRepository(commands);
            });

            services.AddScoped<ISubFPPRepository>(sp =>
            {
                var commands = sp.GetRequiredService<IGenericCommands>();
                return new SubFPPRepository(commands);
            });

            services.AddScoped<IJournalsDefaultAccountsRepository>(sp =>
            {
                var commands = sp.GetRequiredService<IGenericCommands>();
                return new JournalsDefaultAccountsRepository(commands);
            });

            services.AddScoped<IFaceValueRepository>(sp =>
            {
                var commands = sp.GetRequiredService<IGenericCommands>();
                return new FaceValueRepository(commands);
            });

            services.AddScoped<ISignatoriesHasReferences>(sp =>
            {
                var commands = sp.GetRequiredService<IGenericCommands>();
                return new SignatoriesHasReferencesRepository(commands);
            });

            services.AddScoped<ISignatories>(sp =>
            {
                var commands = sp.GetRequiredService<IGenericCommands>();
                var sigHasRef = sp.GetRequiredService<ISignatoriesHasReferences>();
                return new SignatoriesRepository(commands, sigHasRef);
            });

            services.AddScoped<IDocumentReferences>(sp =>
            {
                var commands = sp.GetRequiredService<IGenericCommands>();
                return new DocumentReferencesRepository(commands);
            });

            services.AddScoped<IDocuments>(sp =>
            {
                var commands = sp.GetRequiredService<IGenericCommands>();
                return new DocumentsRepository(commands);
            });

            services.AddScoped<IBarangayRepository>(sp =>
            {
                var commands = sp.GetRequiredService<IGenericCommands>();
                return new BarangayRepository(commands);
            });

            services.AddScoped<IProvinces>(sp =>
            {
                var commands = sp.GetRequiredService<IGenericCommands>();
                return new ProvincesRepository(commands);
            });

            services.AddScoped<IMunicipalities>(sp =>
            {
                var commands = sp.GetRequiredService<IGenericCommands>();
                return new MunicipalitiesRepository(commands);
            });

            services.AddScoped<IActualUseCodes>(sp =>
            {
                var commands = sp.GetRequiredService<IGenericCommands>();
                return new ActualUseCodesRepository(commands);
            });

            services.AddScoped<IClassificationCodes>(sp =>
            {
                var commands = sp.GetRequiredService<IGenericCommands>();
                return new ClassificationCodesRepository(commands);
            });

            services.AddScoped<IServer>(sp =>
            {
                var commands = sp.GetRequiredService<IGenericCommands>();
                var provider = sp.GetRequiredService<IConnectionProvider>();
                return new ServerRepository(commands, provider);
            });

            services.AddScoped<IRegistry>(sp =>
            {
                var commands = sp.GetRequiredService<IGenericCommands>();
                return new RegistryRepository(commands);
            });
        }
    }
}