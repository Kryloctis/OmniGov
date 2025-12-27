using ACC.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFS.Helpers.Budget
{
    public static class BudgetHelper
    {
        public static DataTable GetAccountsByAllotmentClass(string allotmentClassName, string searchKey)
        {
            searchKey ??= string.Empty;

            var repo = AccFactory.GeneralLedgerAccountsRepository();

            return allotmentClassName == "Capital Outlay"
                ? repo.GetViewRecordsByAccountGroupNameSearch("Assets", searchKey)
                : repo.GetViewRecordsByMajorAccGroupNameSearch(allotmentClassName, searchKey);
        }
    }
}