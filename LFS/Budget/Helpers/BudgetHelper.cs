using Accounting.Data;
using System.Data;
using System.Text.RegularExpressions;

namespace LFS.Budget.Helpers
{
    public static class BudgetHelper
    {
        /// <summary>
        /// Retrieves General Ledger Accounts based on the selected Allotment Class.
        ///
        /// LGU Business Rule:
        /// - If the selected Allotment Class is "Capital Outlay",
        ///   General Ledger Accounts must be sourced using the Account Group Name "Assets".
        ///   This follows LGU accounting standards where Capital Outlay expenditures
        ///   are always tied to Asset accounts.
        ///
        /// - For all other Allotment Classes,
        ///   General Ledger Accounts are retrieved using the Major Account Group Name
        ///   that matches the name of the selected Allotment Class.
        ///
        /// A search key may be provided to filter account results.
        /// </summary>
        /// <param name="allotmentClassName">
        /// Name of the selected allotment class (e.g., Capital Outlay, MOOE, PS).
        /// </param>
        /// <param name="searchKey">
        /// Optional search keyword for filtering General Ledger Accounts.
        /// </param>
        /// <returns>
        /// A DataTable containing the filtered General Ledger Accounts.
        /// </returns>
        public static DataTable GetAccountsByAllotmentClass(string allotmentClassName, string searchKey)
        {
            // Ensure searchKey is not null to prevent repository errors
            searchKey ??= string.Empty;

            // Get a single instance of the repository for better performance and readability
            var repo = AccountingFactory.GeneralLedgerAccountsRepository();

            // LGU Rule Enforcement:
            // Capital Outlay → use Account Group Name = "Assets"
            // Other classes → use Major Account Group Name = Allotment Class Name
            return allotmentClassName == "Capital Outlay"
                ? repo.GetViewRecordsByAccountGroupNameSearch("Assets", searchKey)
                : repo.GetViewRecordsByMajorAccGroupNameSearch(allotmentClassName, searchKey);
        }

        internal static string GenTransactionNo(string transactionNo)
        {
            var match = Regex.Match(transactionNo, @"(\d{2})-(\d+)");
            string x = $"{match.Groups[1].Value}-{match.Groups[2].Value}";

            return x;
        }
    }
}