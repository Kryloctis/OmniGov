using OmniGov.Core.Interfaces.Factories;
using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Core.Interfaces.Services;

namespace OmniGov.Core.Factories
{
    /// <summary>
    /// Instance-based factory for creating Core repository instances with dependency injection
    /// </summary>
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly IGenericCommands _genericCommands;
        private readonly IConnectionProvider _connectionProvider;

        public RepositoryFactory(IGenericCommands genericCommands, IConnectionProvider connectionProvider)
        {
            _genericCommands = genericCommands ?? throw new ArgumentNullException(nameof(genericCommands));
            _connectionProvider = connectionProvider ?? throw new ArgumentNullException(nameof(connectionProvider));
        }

        public ISubMajorAccountGroupRepository SubMajorAccountGroupRepository()
            => new Repositories.SubMajorAccountGroupRepository(_genericCommands);

        public IMajorAccountGroupRepository MajorAccountGroupRepository()
            => new Repositories.MajorAccountGroupRepository(_genericCommands);

        public IAccountGroupRepository AccountGroupRepository()
            => new Repositories.AccountGroupRepository(_genericCommands);

        public IJournalsRepository JournalsRepository()
            => new Repositories.JournalsRepository(_genericCommands);

        public IFundsRepository FundsRepository()
            => new Repositories.FundsRepository(_genericCommands);

        public IAllotmentClassesRepository AllotmentClassesRepository()
            => new Repositories.AllotmentClassesRepository(_genericCommands);

        public IFunctionalClassificationRepository FunctionalClassificationRepository()
            => new Repositories.FunctionalClassificationRepository(_genericCommands);

        public IFunctionalClassificationServiceRepository FunctionalClassificationServiceRepository()
            => new Repositories.FunctionalClassificationServiceRepository(_genericCommands);

        public IFunctionProgramProjectRepository FunctionProgramProjectRepository()
            => new Repositories.FunctionProgramProjectRepository(_genericCommands);

        public IRolesPermissionsRepository RolesPermissionsRepository()
            => new Repositories.RolesPermissionsRepository(_genericCommands);

        public IRolesRepository RolesRepository()
            => new Repositories.RolesRepository(_genericCommands, RolesPermissionsRepository());

        public IUsersRepository UsersRepository()
            => new Repositories.UsersRepository(_genericCommands);

        public IPermissionsRepository PermissionsRepository()
            => new Repositories.PermissionsRepository(_genericCommands);

        public ISubFPPRepository SubFPPRepository()
            => new Repositories.SubFPPRepository(_genericCommands);

        public IError CreateErrors(Array errors)
            => new Repositories.Error(errors);

        public IJournalsDefaultAccountsRepository JournalsDefaultAccountsRepository()
            => new Repositories.JournalsDefaultAccountsRepository(_genericCommands);

        public IFaceValueRepository FaceValueRepository()
            => new Repositories.FaceValueRepository(_genericCommands);

        public ISignatories SignatoriesRepository()
            => new Repositories.SignatoriesRepository(_genericCommands, SignatoriesHasReferencesRepository());

        public ISignatoriesHasReferences SignatoriesHasReferencesRepository()
            => new Repositories.SignatoriesHasReferencesRepository(_genericCommands);

        public IDocumentReferences DocumentReferencesRepository()
            => new Repositories.DocumentReferencesRepository(_genericCommands);

        public IDocuments DocumentsRepository()
            => new Repositories.DocumentsRepository(_genericCommands);

        public IBarangayRepository BarangayRepository()
            => new Repositories.BarangayRepository(_genericCommands);

        public IProvinces ProvincesRepository()
            => new Repositories.ProvincesRepository(_genericCommands);

        public IMunicipalities MunicipalitiesRepository()
            => new Repositories.MunicipalitiesRepository(_genericCommands);

        public IActualUseCodes ActualUseCodesRepository()
            => new Repositories.ActualUseCodesRepository(_genericCommands);

        public IClassificationCodes ClassificationCodesRepository()
            => new Repositories.ClassificationCodesRepository(_genericCommands);

        public IServer ServerRepository()
            => new Repositories.ServerRepository(_genericCommands, _connectionProvider);

        public IRegistry RegistryRepository()
            => new Repositories.RegistryRepository(_genericCommands);
    }
}