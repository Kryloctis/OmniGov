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
        
        internal static IJournalsRepository JournalsRepository() => new JournalsRepository(new MySqlGenericCommands());
        internal static IAllotmentClassesRepository AllotmentClassesRepository() => new AllotmentClassesRepository(new MySqlGenericCommands());

        internal static IError CreateErrors(Array errors) => new Error(errors);
    }
}
