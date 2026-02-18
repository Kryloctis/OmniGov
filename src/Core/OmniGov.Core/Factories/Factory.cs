using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Core.Repositories;

namespace OmniGov.Core.Factories
{
    public static class Factory
    {
        private static T Resolve<T>() where T : notnull => OmniGov.Core.Services.ServiceLocator.GetRequiredService<T>();

        public static ISubMajorAccountGroupRepository SubMajorAccountGroupRepository() => Resolve<ISubMajorAccountGroupRepository>();

        public static IMajorAccountGroupRepository MajorAccountGroupRepository() => Resolve<IMajorAccountGroupRepository>();

        public static IAccountGroupRepository AccountGroupRepository() => Resolve<IAccountGroupRepository>();

        public static IJournalsRepository JournalsRepository() => Resolve<IJournalsRepository>();

        public static IFundsRepository FundsRepository() => Resolve<IFundsRepository>();

        public static IAllotmentClassesRepository AllotmentClassesRepository() => Resolve<IAllotmentClassesRepository>();

        public static IFunctionalClassificationRepository FunctionalClassificationRepository() => Resolve<IFunctionalClassificationRepository>();

        public static IFunctionalClassificationServiceRepository FunctionalClassificationServiceRepository() => Resolve<IFunctionalClassificationServiceRepository>();

        public static IFunctionProgramProjectRepository FunctionProgramProjectRepository() => Resolve<IFunctionProgramProjectRepository>();

        public static IRolesPermissionsRepository RolesPermissionsRepository() => Resolve<IRolesPermissionsRepository>();

        public static IRolesRepository RolesRepository() => Resolve<IRolesRepository>();

        public static IUsersRepository UsersRepository() => Resolve<IUsersRepository>();

        public static IPermissionsRepository PermissionsRepository() => Resolve<IPermissionsRepository>();

        public static ISubFPPRepository SubFPPRepository() => Resolve<ISubFPPRepository>();

        public static IError CreateErrors(Array errors) => new Error(errors);

        public static IJournalsDefaultAccountsRepository JournalsDefaultAccountsRepository() => Resolve<IJournalsDefaultAccountsRepository>();

        public static IFaceValueRepository FaceValueRepository() => Resolve<IFaceValueRepository>();

        public static ISignatories SignatoriesRepository() => Resolve<ISignatories>();

        public static ISignatoriesHasReferences SignatoriesHasReferencesRepository() => Resolve<ISignatoriesHasReferences>();

        public static IDocumentReferences DocumentReferencesRepository() => Resolve<IDocumentReferences>();

        public static IDocuments DocumentsRepository() => Resolve<IDocuments>();

        public static IBarangayRepository BarangayRepository() => Resolve<IBarangayRepository>();

        public static IProvinces ProvincesRepository() => Resolve<IProvinces>();

        public static IMunicipalities MunicipalitiesRepository() => Resolve<IMunicipalities>();

        public static IActualUseCodes ActualUseCodesRepository() => Resolve<IActualUseCodes>();

        public static IClassificationCodes ClassificationCodesRepository() => Resolve<IClassificationCodes>();

        public static IServer ServerRepository() => Resolve<IServer>();

        public static IRegistry RegistryRepository() => Resolve<IRegistry>();
    }
}