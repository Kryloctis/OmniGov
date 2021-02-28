using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACC.Domain.Interfaces;
using ACC.Data;

namespace AccountingSystem
{
    static class Factory
    {
        internal static IGeneralLedgerAccountsRepository GeneralLedgerAccountsRepository() => new GeneralLedgerAccountsRepository(new MySqlGenericCommands());

        internal static ISubMajorAccountGroupRepository SubMajorAccountGroupRepository() => new SubMajorAccountGroupRepository(new MySqlGenericCommands());

        internal static IMajorAccountGroupRepository MajorAccountGroupRepository() => new MajorAccountGroupRepository(new MySqlGenericCommands());

        internal static IAccountGroupRepository AccountGroupRepository() => new AccountGroupRepository(new MySqlGenericCommands());

        internal static IJournalsRepository JournalsRepository() => new JournalsRepository(new MySqlGenericCommands());
        internal static IFundsRepository FundsRepository() => new FundsRepository(new MySqlGenericCommands());
        internal static IAllotmentClassesRepository AllotmentClassesRepository() => new AllotmentClassesRepository(new MySqlGenericCommands());
        internal static IFunctionalClassificationRepository FunctionalClassificationRepository() => new FunctionalClassificationRepository(new MySqlGenericCommands());
        internal static IFunctionalClassificationServiceRepository FunctionalClassificationServiceRepository() => new FunctionalClassificationServiceRepository(new MySqlGenericCommands());
        internal static IFunctionProgramProjectRepository FunctionProgramProjectRepository() => new FunctionProgramProjectRepository(new MySqlGenericCommands());
        internal static IError CreateErrors(Array errors) => new Error(errors);
    }
}
