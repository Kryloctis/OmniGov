using OmniGov.Core.Interfaces;

namespace OmniGov.Core.Repositories
{
    public static class Factory
    {
        internal static GenericCommands mySqlGenericCommandsLFS;

        public static ISubMajorAccountGroupRepository SubMajorAccountGroupRepository() => new SubMajorAccountGroupRepository(mySqlGenericCommandsLFS);

        public static IMajorAccountGroupRepository MajorAccountGroupRepository() => new MajorAccountGroupRepository(mySqlGenericCommandsLFS);

        public static IAccountGroupRepository AccountGroupRepository() => new AccountGroupRepository(mySqlGenericCommandsLFS);

        public static IJournalsRepository JournalsRepository() => new JournalsRepository(mySqlGenericCommandsLFS);

        public static IFundsRepository FundsRepository() => new FundsRepository(mySqlGenericCommandsLFS);

        public static IAllotmentClassesRepository AllotmentClassesRepository() => new AllotmentClassesRepository(mySqlGenericCommandsLFS);

        public static IFunctionalClassificationRepository FunctionalClassificationRepository() => new FunctionalClassificationRepository(mySqlGenericCommandsLFS);

        public static IFunctionalClassificationServiceRepository FunctionalClassificationServiceRepository() => new FunctionalClassificationServiceRepository(mySqlGenericCommandsLFS);

        public static IFunctionProgramProjectRepository FunctionProgramProjectRepository() => new FunctionProgramProjectRepository(mySqlGenericCommandsLFS);

        public static IRolesPermissionsRepository RolesPermissionsRepository() => new RolesPermissionsRepository(mySqlGenericCommandsLFS);

        public static IRolesRepository RolesRepository() => new RolesRepository(mySqlGenericCommandsLFS, RolesPermissionsRepository());

        public static IUsersRepository UsersRepository() => new UsersRepository(mySqlGenericCommandsLFS);

        public static IPermissionsRepository PermissionsRepository() => new PermissionsRepository(mySqlGenericCommandsLFS);

        public static ISubFPPRepository SubFPPRepository() => new SubFPPRepository(mySqlGenericCommandsLFS);

        public static IError CreateErrors(Array errors) => new Error(errors);

        public static IJournalsDefaultAccountsRepository JournalsDefaultAccountsRepository() => new JournalsDefaultAccountsRepository(mySqlGenericCommandsLFS);

        public static IFaceValueRepository FaceValueRepository() => new FaceValueRepository(mySqlGenericCommandsLFS);

        public static ISignatories SignatoriesRepository() => new SignatoriesRepository(mySqlGenericCommandsLFS, SignatoriesHasReferencesRepository());

        public static ISignatoriesHasReferences SignatoriesHasReferencesRepository() => new SignatoriesHasReferencesRepository(mySqlGenericCommandsLFS);

        public static IDocumentReferences DocumentReferencesRepository() => new DocumentReferencesRepository(mySqlGenericCommandsLFS);

        public static IDocuments DocumentsRepository() => new DocumentsRepository(mySqlGenericCommandsLFS);

        public static IBarangayRepository BarangayRepository() => new BarangayRepository(mySqlGenericCommandsLFS);

        public static IProvinces ProvincesRepository() => new ProvincesRepository(mySqlGenericCommandsLFS);

        public static IMunicipalities MunicipalitiesRepository() => new MunicipalitiesRepository(mySqlGenericCommandsLFS);

        public static IActualUseCodes ActualUseCodesRepository() => new ActualUseCodesRepository(mySqlGenericCommandsLFS);

        public static IClassificationCodes ClassificationCodesRepository() => new ClassificationCodesRepository(mySqlGenericCommandsLFS);

        public static IServer ServerRepository() => new AccServerRepository(mySqlGenericCommandsLFS);

        public static IRegistry RegistryRepository() => new RegistryRepository(mySqlGenericCommandsLFS);
    }
}