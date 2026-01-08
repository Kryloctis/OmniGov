using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using Org.BouncyCastle.Crypto.Agreement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Transactions;

namespace ACC.Data
{
    public class AllotmentReleaseRepository : IAllotmentReleaseRepository
    {
        private readonly string viewTableName = "view_allotment_release";
        private readonly string tableName = "allotment_release";
        private readonly IAllotmentAccountRepository allotmentAccountRepository;
        private AccGenericCommands mySqlGenericCommandsLFS;

        public AllotmentReleaseRepository(AccGenericCommands mySqlGenericCommandsLFSLFS, IAllotmentAccountRepository allotmentAccountRepository)
        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommandsLFSLFS;
            this.allotmentAccountRepository = allotmentAccountRepository;
        }

        public bool Insert(AllotmentReleaseModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(AllotmentReleaseModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<AllotmentReleaseModel> entityList)
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT id, aro_no, purpose, date_issued, created_at, updated_at FROM {tableName}";
            return mySqlGenericCommandsLFS.Fill(query, new DataTable());
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameters = new object[][]
            {
                new object[] { "@searchTxt", DbType.String, $"%{searchText}%" }
            };

            string query = $"SELECT id, aro_no, purpose, date_issued, created_at, updated_at FROM {tableName} WHERE aro_no LIKE @searchTxt OR purpose LIKE  @searchTxt";

            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                    new object[] { "@id", DbType.Int32, Id}
            };

            string query = $"SELECT id, aro_no, purpose, date_issued, created_at, updated_at FROM {tableName} id = @id";

            DataTable dataTable = mySqlGenericCommandsLFS.ExecuteReader(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                foreach (DataColumn column in dataTable.Columns)
                    recordDictionary[column.ColumnName] = row[column].ToString();

                return recordDictionary;
            }
            return recordDictionary;
        }

        public DataTable GetViewRecordsById(int Id)
        {
            var parameters = new object[][]
            {
                new object[] { "@allotment_release_id", DbType.Int32, Id }
            };

            string query = $"SELECT allotment_release_id, allotment_account_id, aro_no, purpose, date_issued, allotment_release_created_at, allotment_release_updated_at, budget_appropriations_id, funds_id, fund_code, fund_name, function_program_project_id, fpp_code, fpp_name, is_special, others_fpp_id, others_fpp_code, others_fpp_name, allotment_classes_id, allotment_code, allotment_name, general_ledger_accounts_id, account_code, ledger_name, date_entry, year, continuing, remarks, amount FROM {viewTableName} WHERE allotment_release_id = @allotment_release_id";

            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
        }

        private int GetLastInsertedID()
        {
            string query = $"SELECT MAX(id) FROM {tableName}";
            return int.Parse(mySqlGenericCommandsLFS.ExecuteScalar(query));
        }

        public bool Insert(AllotmentReleaseModel entity, List<AllotmentAccountModel> listAllotmentAccount)
        {
            using (var scope = new TransactionScope())
            {
                var parameters = new object[][]
                {
                    new object[] { "@aro_no", DbType.String, entity.ARONumber},
                    new object[] { "@purpose", DbType.String, entity.Purpose},
                    new object[] { "@date_issued", DbType.Date, entity.DateIssued.Date}
                };

                string query = $"INSERT INTO {tableName} (aro_no, purpose, date_issued) VALUES (@aro_no, @purpose, @date_issued)";

                _ = mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);

                foreach (var allotmentAccount in listAllotmentAccount)
                {
                    allotmentAccount.AllotmentReleaseID = GetLastInsertedID();
                    _ = allotmentAccountRepository.Insert(allotmentAccount);
                }

                scope.Complete();
                return true;
            }
        }

        public bool Update(AllotmentReleaseModel entity, List<AllotmentAccountModel> listAllotmentAccount)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                var parameters = new object[][]
                {
                    new object[] { "@id",DbType.Int32, entity.ID},
                    new object[] { "@aro_no", DbType.String, entity.ARONumber},
                    new object[] { "@purpose", DbType.String, entity.Purpose},
                    new object[] { "@date_issued", DbType.Date, entity.DateIssued.Date}
                };

                string query = $"UPDATE {tableName} SET aro_no = @aro_no, purpose = @purpose, date_issued = @date_issued WHERE id = @id";

                _ = mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
                _ = allotmentAccountRepository.DeleteByAllotmentReleaseId(entity.ID);

                foreach (var allotmentAccount in listAllotmentAccount)
                {
                    allotmentAccount.AllotmentReleaseID = entity.ID;
                    _ = allotmentAccountRepository.Insert(allotmentAccount);
                }

                scope.Complete();
                return true;
            }
        }

        public bool Delete(int allotmentReleaseId)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, allotmentReleaseId}
                };

                string query = $"DELETE FROM {tableName} WHERE id = @id";
                _ = allotmentAccountRepository.DeleteByAllotmentReleaseId(allotmentReleaseId);
                _ = mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);

                scope.Complete();
                return true;
            }
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool AllotmentReleaseNoExist(string allotmentReleaseNo, short year)
        {
            var parameters = new object[][]
            {
                new object[] { "@aro_no", DbType.String, allotmentReleaseNo },
                new object[] { "@year", DbType.Int16, year}
            };

            string query = $"SELECT id FROM {tableName} WHERE aro_no = @aro_no AND YEAR(date_issued) = @year";

            return !string.IsNullOrEmpty(mySqlGenericCommandsLFS.ExecuteScalar(query, parameters));
        }

        public bool AllotmentReleaseNoExist(int Id, string allotmentReleaseNo, short year)
        {
            var parameters = new object[][]
            {
                new object[] { "@id",   DbType.Int32, Id },
                new object[] { "@aro_no", DbType.String, allotmentReleaseNo },
                new object[] { "@year", DbType.Int16, year}
            };

            string query = $"SELECT id FROM {tableName} WHERE id <> @id AND aro_no = @aro_no AND YEAR(date_issued) = @year";

            return !string.IsNullOrEmpty(mySqlGenericCommandsLFS.ExecuteScalar(query, parameters));
        }

        public bool AllotmentReleaseExist(int budgetAppropriationId, DateTime dateIssued)
        {
            var parameters = new object[][]
            {
                new object[] { "@budget_appropriations_id", DbType.Int32, budgetAppropriationId },
                new object[] { "@date_issued", DbType.Date, dateIssued.Date }
            };

            string query = $"SELECT allotment_release_id FROM {viewTableName} WHERE budget_appropriations_id = @budget_appropriations_id AND date_issued = @date_issued";

            string queryResult = mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);
            return !string.IsNullOrEmpty(queryResult);
        }

        public bool AllotmentReleaseExist(int Id, int budgetAppropriationId, DateTime dateIssued)
        {
            var parameters = new object[][]
            {
                new object[] { "@allotment_release_id", DbType.Int32, Id },
                new object[] { "@budget_appropriations_id", DbType.Int32, budgetAppropriationId },
                new object[] { "@date_issued", DbType.Date, dateIssued.Date }
            };

            string query = $"SELECT allotment_release_id FROM {viewTableName} WHERE allotment_release_id = @allotment_release_id AND budget_appropriations_id = @budget_appropriations_id AND date_issued = @date_issued";
            string queryResult = mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);

            return !string.IsNullOrEmpty(queryResult);
        }

        public DataTable GetViewRecordsByBudgetAppropriationIdDateIssued(int budgetAppropriationId, DateTime dateIssued)
        {
            var parameters = new object[][]
            {
                new object[] { "@budget_appropriations_id", DbType.Int32, budgetAppropriationId },
                new object[] { "@date_issued", DbType.Date, dateIssued.Date}
            };

            string query = $"SELECT allotment_release_id, allotment_account_id, aro_no, purpose, date_issued, allotment_release_created_at, allotment_release_updated_at, budget_appropriations_id, funds_id, fund_code, fund_name, function_program_project_id, fpp_code, fpp_name, is_special, others_fpp_id, others_fpp_code, others_fpp_name, allotment_classes_id, allotment_code, allotment_name, general_ledger_accounts_id, account_code, ledger_name, date_entry, year, continuing, remarks, amount FROM {viewTableName}  WHERE budget_appropriations_id = @budget_appropriations_id AND date_issued <= @date_issued";

            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
        }

        public DataTable GetViewRecordsByBudgetAppropriationId(int budgetAppropriationId)
        {
            var parameters = new object[][]
            {
                new object[] { "@budget_appropriations_id", DbType.Int32, budgetAppropriationId }
            };

            string query = $"SELECT allotment_release_id, allotment_account_id, aro_no, purpose, date_issued, allotment_release_created_at, allotment_release_updated_at, budget_appropriations_id, funds_id, fund_code, fund_name, function_program_project_id, fpp_code, fpp_name, is_special, others_fpp_id, others_fpp_code, others_fpp_name, allotment_classes_id, allotment_code, allotment_name, general_ledger_accounts_id, account_code, ledger_name, date_entry, year, continuing, remarks, amount FROM {viewTableName} WHERE budget_appropriations_id = @budget_appropriations_id";

            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
        }

        public DataTable GetViewRecords()
        {
            string query = $"SELECT allotment_release_id, allotment_account_id, aro_no, purpose, date_issued, allotment_release_created_at, allotment_release_updated_at, budget_appropriations_id, funds_id, fund_code, fund_name, function_program_project_id, fpp_code, fpp_name, is_special, others_fpp_id, others_fpp_code, others_fpp_name, allotment_classes_id, allotment_code, allotment_name, general_ledger_accounts_id, account_code, ledger_name, date_entry, year, continuing, remarks, amount FROM {viewTableName} ";

            return mySqlGenericCommandsLFS.Fill(query, new DataTable());
        }

        public DataTable GetViewRecordsBySearch(int fundId, int allotmentClassId, DateTime dateIssued, string searchText)
        {
            var parameters = new object[][]
            {
                new object[] { "@funds_id", DbType.Int32, fundId },
                new object[] { "@allotment_classes_id", DbType.Int32, allotmentClassId },
                new object[] { "@date_issued", DbType.Date, dateIssued},
                new object[] { "@searchTxt", DbType.String, $"%{searchText}%"}
            };

            string query = $"SELECT * FROM {viewTableName} WHERE funds_id = @funds_id AND allotment_classes_id = @allotment_classes_id AND date_issued <= @date_issued AND (aro_no LIKE @searchTxt OR purpose LIKE  @searchTxt) GROUP BY allotment_release_id";

            var dataTable = new DataTable();
            return mySqlGenericCommandsLFS.FillBySearch(query, dataTable, parameters);
        }

        public decimal GetTotalAllotmentReleaseById(int allotmentReleaseId)
        {
            var parameters = new object[][]
            {
                new object[] { "@allotment_release_id", DbType.Int32, allotmentReleaseId }
            };

            string query = $"SELECT COALESCE(SUM(amount), 0) AS total_allotment_release FROM {viewTableName} WHERE allotment_release_id = @allotment_release_id";

            return Convert.ToDecimal(mySqlGenericCommandsLFS.ExecuteScalar(query, parameters));
        }

        //SUMMARY
        public decimal GetSumAllotments(string fppId, string subFPPId, int fundId, DateTime dateIssued, int allotmentClassId, byte isContinuing)
        {
            var parameters = new object[][]
            {
                new object[] { "@function_program_project_id", DbType.String, fppId },
                new object[] { "@others_fpp_id",DbType.String, subFPPId},
                new object[] { "@funds_id", DbType.Int32, fundId },
                new object[] { "@date_issued", DbType.Date, dateIssued.Date },
                new object[] { "@allotment_classes_id", DbType.Int32, allotmentClassId},
                new object[] { "@continuing", DbType.Byte, isContinuing},
                new object[] { "@year", DbType.Int16, dateIssued.Year}
            };

            string fppWhereQuery = fppId == "all" ? string.Empty : "function_program_project_id = @function_program_project_id AND";
            string isContinuingQuery = isContinuing == 0 ? "year = @year" : "year <= @year";

            string subFPPQuery = string.Empty;
            if (subFPPId == "all")
                subFPPQuery = "others_fpp_id IS NOT NULL AND";
            else if (fppId == "all")
                subFPPQuery = string.Empty;
            else if (string.IsNullOrEmpty(subFPPId))
                subFPPQuery = "others_fpp_id IS NULL AND";
            else
                subFPPQuery = "others_fpp_id = @others_fpp_id AND";

            string query = $"SELECT COALESCE(SUM(amount), 0) AS amount FROM {viewTableName} WHERE {fppWhereQuery} {subFPPQuery} funds_id = @funds_id AND date_issued <= @date_issued AND allotment_classes_id = @allotment_classes_id AND continuing = @continuing AND {isContinuingQuery}";

            return Convert.ToDecimal(mySqlGenericCommandsLFS.ExecuteScalar(query, parameters));
        }

        //DETAILED
        public decimal GetSumAllotments(int budgetAppropriationId, DateTime dateIssued)
        {
            var parameters = new object[][]
            {
                new object[] { "@budget_appropriations_id", DbType.Int32, budgetAppropriationId },
                new object[] { "@date_issued",DbType.Date, dateIssued.Date }
            };

            string query = $"SELECT COALESCE(SUM(amount), 0) AS amount FROM {viewTableName} WHERE budget_appropriations_id = @budget_appropriations_id AND date_issued <= @date_issued";

            return Convert.ToDecimal(mySqlGenericCommandsLFS.ExecuteScalar(query, parameters));
        }

        public string GetLeastAllotmentReleaseNumber()
        {
            string query = $"SELECT COALESCE(LPAD(MAX(aro_no)+1, 3, '0'),'001') AS aro_no FROM {viewTableName}";
            return mySqlGenericCommandsLFS.ExecuteScalar(query);
        }

        public DataTable GetViewRecords(int fppId, int? othersFppId, int allotmentClssId, string searchKey)
        {
            var parameters = new object[][]
            {
                new object[] { "@function_program_project_id", DbType.Int32, fppId},
                new object[] { "@others_fpp_id", DbType.Int32, othersFppId},
                new object[] { "@allotment_classes_id", DbType.Int32, allotmentClssId},
                new object[] { "@search_key", DbType.String, $"%{searchKey}%"},
            };

            string query = $@"SELECT * FROM {viewTableName}
                            WHERE function_program_project_id = @function_program_project_id
                            AND allotment_classes_id = @allotment_classes_id
                            AND ledger_name LIKE @search_key
                            AND CASE
                                    WHEN @others_fpp_id IS NULL AND others_fpp_id IS NULL THEN 1
                                    WHEN others_fpp_id = @others_fpp_id THEN 1
                                ELSE 0
                                END = 1";

            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
        }

        public DataTable GetViewRecords(int id)
        {
            var parameters = new object[][]
            {
                new object[] { "@allotment_release_id", DbType.Int32, id },
            };

            string query = $"SELECT * FROM {viewTableName} WHERE allotment_release_id = @allotment_release_id";
            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
        }
    }
}