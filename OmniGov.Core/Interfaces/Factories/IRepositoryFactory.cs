using System;
using OmniGov.Core.Interfaces.Repositories;

namespace OmniGov.Core.Interfaces.Factories
{
    /// <summary>
    /// Factory interface for creating Core repository instances
    /// </summary>
    public interface IRepositoryFactory
    {
        ISubMajorAccountGroupRepository SubMajorAccountGroupRepository();
        IMajorAccountGroupRepository MajorAccountGroupRepository();
        IAccountGroupRepository AccountGroupRepository();
        IJournalsRepository JournalsRepository();
        IFundsRepository FundsRepository();
        IAllotmentClassesRepository AllotmentClassesRepository();
        IFunctionalClassificationRepository FunctionalClassificationRepository();
        IFunctionalClassificationServiceRepository FunctionalClassificationServiceRepository();
        IFunctionProgramProjectRepository FunctionProgramProjectRepository();
        IRolesPermissionsRepository RolesPermissionsRepository();
        IRolesRepository RolesRepository();
        IUsersRepository UsersRepository();
        IPermissionsRepository PermissionsRepository();
        ISubFPPRepository SubFPPRepository();
        IError CreateErrors(Array errors);
        IJournalsDefaultAccountsRepository JournalsDefaultAccountsRepository();
        IFaceValueRepository FaceValueRepository();
        ISignatories SignatoriesRepository();
        ISignatoriesHasReferences SignatoriesHasReferencesRepository();
        IDocumentReferences DocumentReferencesRepository();
        IDocuments DocumentsRepository();
        IBarangayRepository BarangayRepository();
        IProvinces ProvincesRepository();
        IMunicipalities MunicipalitiesRepository();
        IActualUseCodes ActualUseCodesRepository();
        IClassificationCodes ClassificationCodesRepository();
        IServer ServerRepository();
        IRegistry RegistryRepository();
    }
}
