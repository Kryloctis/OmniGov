using Budget.Data;
using LFS.Budget.Helpers;
using LFS.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LFS.Budget.Services
{
    public class ObligationService
    {
        public DataTable GetObligationRequests(string searchKey, string status, DateTime dateFrom, DateTime dateTo, int rowLimit, Action<int, int> progressCallback = null)
        {
            // 1. Fetch raw data from the repository
            var dtRaw = BudgetFactory.ObligationRequestRepository().GetRecords(
                searchKey,
                status.ToLower(),
                dateFrom,
                dateTo,
                rowLimit);

            // 2. Prepare the view DataTable with specific columns
            var dtView = new DataTable();
            dtView.Columns.AddRange(new[]
            {
                new DataColumn("id", typeof(int)),
                new DataColumn("transaction_no", typeof(string)),
                new DataColumn("obligation_no", typeof(string)),
                new DataColumn("date_requested", typeof(DateTime)),
                new DataColumn("payee", typeof(string)),
                new DataColumn("created_at", typeof(string)),
                new DataColumn("created_by_id", typeof(string)),
                new DataColumn("created_by_name", typeof(string)),
                new DataColumn("updated_at", typeof(string)),
                new DataColumn("updated_by_id", typeof(string)),
                new DataColumn("updated_by_name", typeof(string)),
            });

            // 3. Optimization: Identify unique user IDs to fetch names in batch (or at least avoid duplicates)
            var userIds = dtRaw.AsEnumerable()
                .SelectMany(r => new[] { r["created_by"], r["updated_by"] })
                .Where(id => id != DBNull.Value)
                .Select(id => Convert.ToInt32(id))
                .Distinct()
                .ToList();

            // 4. Cache user names
            var userCache = new Dictionary<int, string>();
            foreach (var userId in userIds)
            {
                if (!userCache.ContainsKey(userId))
                {
                    // Using the existing Helper to get user data
                    var userData = Helper.GetUserDataById(userId);
                    string fullName = userData.ContainsKey("user_full_name") ? userData["user_full_name"] : string.Empty;
                    userCache[userId] = fullName;
                }
            }

            // Local helper to safely get name from cache
            string GetCachedName(object dbValue)
            {
                if (dbValue == DBNull.Value || dbValue == null) return string.Empty;
                int id = Convert.ToInt32(dbValue);
                return userCache.TryGetValue(id, out var name) ? name : string.Empty;
            }

            int totalRows = dtRaw.Rows.Count;
            int currentRow = 0;

            // 5. Transform and populate the view DataTable
            foreach (DataRow row in dtRaw.Rows)
            {
                var newRow = dtView.NewRow();
                newRow["id"] = row["id"];

                // Format transaction number
                string transactionNo = row["transaction_no"].ToString();
                newRow["transaction_no"] = BudgetHelper.GenTransactionNo(transactionNo);

                newRow["obligation_no"] = row["obligation_no"];
                newRow["date_requested"] = row["date_requested"];
                newRow["payee"] = row["payee"];

                newRow["created_at"] = row["created_at"];
                newRow["created_by_id"] = row["created_by"];
                newRow["created_by_name"] = GetCachedName(row["created_by"]);

                newRow["updated_at"] = row["updated_at"];
                newRow["updated_by_id"] = row["updated_by"];
                newRow["updated_by_name"] = GetCachedName(row["updated_by"]);

                dtView.Rows.Add(newRow);

                currentRow++;
                // Invoke callback if provided
                progressCallback?.Invoke(currentRow, totalRows);
            }

            return dtView;
        }
    }
}
