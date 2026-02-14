using Budget.Domain.Interfaces;
using Budget.Domain.Models;
using OmniGov.Core.Repositories;
using System.Data;
using System.Transactions;

namespace Budget.Data.Repositories
{
    public class BudgetAppropriationsRepository : IBudgetAppropriationsRepository
    {
        private ISupplementalAppropriationsRepository ISupplementalAppropriationsRepository;
        private GenericCommands mySqlGenericCommandsLFS;
        private readonly string tableName = "budget_appropriations";
        private readonly string viewTableName = "view_budget_appropriations";

        public BudgetAppropriationsRepository(GenericCommands mySqlGenericCommandsLFS, ISupplementalAppropriationsRepository supplementalAppropriationsRepository)
        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
            ISupplementalAppropriationsRepository = supplementalAppropriationsRepository;
        }

        // bool methods
        public bool BudgetAppropriationContinuing(int fundId, int fppId, int? othersFPPId, int allotmentClassId, int generalLedgerAccountId)
        {
            var parameters = new object[][]
            {
                new object[] { "@funds_id", DbType.Int32, fundId},
                new object[] { "@function_program_project_id", DbType.Int32, fppId},
                new object[] { "@others_fpp_id", DbType.String, othersFPPId },
                new object[] { "@allotment_classes_id", DbType.Int32, allotmentClassId},
                new object[] { "@general_ledger_accounts_id", DbType.Int32, generalLedgerAccountId},
            };

            string query = $"SELECT id FROM {tableName} WHERE funds_id = @funds_id AND function_program_project_id = @function_program_project_id AND others_fpp_id <=> @others_fpp_id AND allotment_classes_id = @allotment_classes_id AND general_ledger_accounts_id = @general_ledger_accounts_id AND continuing = 1";

            // if query is not null, means found some record, so true
            return !string.IsNullOrEmpty(mySqlGenericCommandsLFS.ExecuteScalar(query, parameters));
        }

        public bool BudgetAppropriationContinuing(int id, int fundId, int fppId, int? othersFPPId, int allotmentClassId, int generalLedgerAccountId)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, id},
                new object[] { "@funds_id", DbType.Int32, fundId},
                new object[] { "@function_program_project_id", DbType.Int32, fppId},
                new object[] { "@others_fpp_id", DbType.String, othersFPPId },
                new object[] { "@allotment_classes_id", DbType.Int32, allotmentClassId},
                new object[] { "@general_ledger_accounts_id", DbType.Int32, generalLedgerAccountId},
            };

            string query = $"SELECT id FROM {tableName} WHERE id <> @id AND funds_id = @funds_id AND function_program_project_id = @function_program_project_id AND others_fpp_id <=> @others_fpp_id AND allotment_classes_id = @allotment_classes_id AND general_ledger_accounts_id = @general_ledger_accounts_id AND continuing = 1";

            // if query is not null, means found some record, so true
            return !string.IsNullOrEmpty(mySqlGenericCommandsLFS.ExecuteScalar(query, parameters));
        }

        public bool BudgetAppropriationExist(int fundId, int fppId, int? othersFPPId, int allotmentClassId, int generalLedgerAccountId, short year, string remarks)
        {
            var parameters = new object[][]
            {
                new object[] { "@funds_id", DbType.Int32, fundId},
                new object[] { "@function_program_project_id", DbType.Int32, fppId},
                new object[] { "@others_fpp_id", DbType.String, othersFPPId },
                new object[] { "@allotment_classes_id", DbType.Int32, allotmentClassId},
                new object[] { "@general_ledger_accounts_id", DbType.Int32, generalLedgerAccountId},
                new object[] { "@year",DbType.Int16, year},
                new object[] { "@remarks",DbType.String, remarks}
            };

            string query = $"SELECT id FROM {tableName} WHERE funds_id = @funds_id AND function_program_project_id = @function_program_project_id AND others_fpp_id <=> @others_fpp_id AND allotment_classes_id = @allotment_classes_id AND general_ledger_accounts_id = @general_ledger_accounts_id AND year = @year AND remarks = @remarks";

            // if query is not null, means found some record, so true
            return !string.IsNullOrEmpty(mySqlGenericCommandsLFS.ExecuteScalar(query, parameters));
        }

        public bool BudgetAppropriationExist(int id, int fundId, int FPPId, int? othersFPPId, int allotmentClassId, int generalLedgerAccountId, short year, string remarks)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, id},
                new object[] { "@funds_id", DbType.Int32, fundId},
                new object[] { "@function_program_project_id", DbType.Int32, FPPId},
                new object[] { "@others_fpp_id", DbType.String, othersFPPId },
                new object[] { "@allotment_classes_id", DbType.Int32, allotmentClassId},
                new object[] { "@general_ledger_accounts_id", DbType.Int32, generalLedgerAccountId},
                new object[] { "@year",DbType.Int16, year},
                new object[] { "@remarks",DbType.String, remarks}
            };

            string query = $"SELECT id FROM {tableName} WHERE id <> @id AND funds_id = @funds_id AND function_program_project_id = @function_program_project_id AND others_fpp_id <=> @others_fpp_id AND allotment_classes_id = @allotment_classes_id AND general_ledger_accounts_id = @general_ledger_accounts_id AND year = @year AND remarks = @remarks";

            // if query is not null, means found some record, so true
            return !string.IsNullOrEmpty(mySqlGenericCommandsLFS.ExecuteScalar(query, parameters));
        }

        public bool Delete(List<BudgetAppropriationsModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var entity in entityList)
                {
                    var parameters = new object[][]
                    {
                        new object[] { "@id", DbType.Int32, entity.Id},
                    };

                    string query = $"DELETE FROM {tableName} WHERE id = @id";
                    _ = mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
                }

                scope.Complete();
                return true;
            }
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(BudgetAppropriationsModel budgetAppropriationsModel, List<SupplementalAppropriationsModel> supplementalAppropriationsModelList)
        {
            using (var scope = new TransactionScope())
            {
                _ = Insert(budgetAppropriationsModel);

                int lastInsertedBudgetApppropriationId = GetLastInsertedID();

                ISupplementalAppropriationsRepository.DeleteByBudgerAppropriationId(lastInsertedBudgetApppropriationId);

                foreach (SupplementalAppropriationsModel supplementalAppropriationsModel in supplementalAppropriationsModelList)
                {
                    supplementalAppropriationsModel.BudgetAppropriationID = lastInsertedBudgetApppropriationId;
                    _ = ISupplementalAppropriationsRepository.Insert(supplementalAppropriationsModel);
                }

                scope.Complete();
                return true;
            }
        }

        public bool Insert(BudgetAppropriationsModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@funds_id", DbType.Int32, entity.FundsId},
                new object[] { "@function_program_project_id", DbType.Int32, entity.FunctionProgramProjectId},
                new object[] { "@others_fpp_id", DbType.String, entity.OthersFPPId},
                new object[] { "@allotment_classes_id", DbType.Int32, entity.AllotmentClassesId},
                new object[] { "@general_ledger_accounts_id", DbType.Int32, entity.GeneralLedgerAccountsId},
                new object[] { "@year", DbType.Int16, entity.Year},
                new object[] { "@date_entry", DbType.Date, entity.DateEntry},
                new object[] { "@amount", DbType.Decimal, entity.Amount},
                new object[] { "@continuing", DbType.Boolean, entity.Continuing},
                new object[] { "@remarks", DbType.String, entity.Remarks}
            };

            string query = $"INSERT INTO {tableName} (funds_id, function_program_project_id , others_fpp_id, allotment_classes_id, general_ledger_accounts_id, date_entry, year, amount, continuing, remarks) VALUES (@funds_id, @function_program_project_id, @others_fpp_id, @allotment_classes_id, @general_ledger_accounts_id, @date_entry, @year, @amount, @continuing, @remarks)";

            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Update(BudgetAppropriationsModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.Id},
                new object[] { "@funds_id", DbType.Int32, entity.FundsId},
                new object[] { "@function_program_project_id", DbType.Int32, entity.FunctionProgramProjectId},
                new object[] { "@others_fpp_id", DbType.String, entity.OthersFPPId},
                new object[] { "@allotment_classes_id", DbType.Int32, entity.AllotmentClassesId},
                new object[] { "@general_ledger_accounts_id", DbType.Int32, entity.GeneralLedgerAccountsId},
                new object[] { "@date_entry", DbType.Date, entity.DateEntry},
                new object[] { "@year", DbType.Int16, entity.Year},
                new object[] { "@amount", DbType.Decimal, entity.Amount},
                new object[] { "@continuing", DbType.Boolean, entity.Continuing},
                new object[] { "@remarks", DbType.String, entity.Remarks}
            };

            string query = $"UPDATE {tableName} SET function_program_project_id = @function_program_project_id, funds_id = @funds_id, others_fpp_id = @others_fpp_id, allotment_classes_id = @allotment_classes_id, general_ledger_accounts_id = @general_ledger_accounts_id, date_entry = @date_entry, year = @year, amount = @amount, continuing = @continuing, remarks = @remarks WHERE id = @id";

            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        // DataTable methods
        public DataTable GetGenLdgrAccs(int fppId, int? othersFppId, int allotmentClassId, string searchKey)
        {
            var parameters = new object[][]
            {
                new object[] { "@search_key", DbType.String, $"%{searchKey}%"},
                new object[] { "@allotment_class_id", DbType.Int32, allotmentClassId},
                new object[] { "@fpp_id", DbType.Int32, fppId},
                new object[] { "@others_fpp_id", DbType.Int32, othersFppId}
            };

            string query = $@"SELECT
                                    general_ledger_accounts_id,
                                    account_code,
                                    general_ledger_accounts_name
                                FROM {viewTableName}
                                WHERE fpp_id = @fpp_id
                                    AND CASE
                                        WHEN @others_fpp_id IS NULL AND others_fpp_id IS NULL THEN 1
                                        WHEN others_fpp_id = @others_fpp_id THEN 1
                                        ELSE 0
                                        END = 1
                                    AND allotment_class_id = @allotment_class_id
                                    AND general_ledger_accounts_name LIKE @search_key
                                GROUP BY
                                    general_ledger_accounts_id,
                                    account_code,
                                    general_ledger_accounts_name";

            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
        }

        public DataTable GetHeaderOthersFPP(string fppId, int allotment_classes_id, int funds_id, short year)
        {
            var parameters = new object[][]
            {
                new object[] { "@fpp_id", DbType.String, fppId },
                new object[] { "@allotment_class_id", DbType.Int32, allotment_classes_id },
                new object[] { "@funds_id", DbType.Int32, funds_id },
                new object[] { "@year",DbType.Int16, year },
            };
            string fppWhereQuery = fppId == "all" ? string.Empty : "a.fpp_id = @fpp_id AND";

            string query = $"SELECT distinct a.others_fpp_id, a.others_fpp_name FROM {viewTableName} a INNER JOIN others_fpp b ON a.others_fpp_id = b.id WHERE {fppWhereQuery} a.allotment_class_id = @allotment_class_id AND funds_id = @funds_id AND a.year = @year";
            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
        }

        public DataTable GetHeaderOthersFPP(int fppID, int allotment_classes_id, int funds_id, short year)
        {
            var parameters = new object[][]
            {
                new object[] { "@fpp_id", DbType.Int32, fppID },
                new object[] { "@allotment_class_id", DbType.Int32, allotment_classes_id },
                new object[] { "@funds_id", DbType.Int32, funds_id },
                new object[] { "@year",DbType.Int16, year },
            };

            string query = $"SELECT distinct a.others_fpp_id, a.others_fpp_name  FROM {viewTableName} a INNER JOIN others_fpp b ON a.others_fpp_id = b.id WHERE a.fpp_id = @fpp_id AND a.allotment_class_id = @allotment_class_id AND funds_id = @funds_id AND a.year = @year";

            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {viewTableName}";
            return mySqlGenericCommandsLFS.Fill(query, new DataTable());
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new NotImplementedException();
        }

        public DataTable GetViewRecords(int fundId, DateTime dateEntry, byte isSpecial)
        {
            var parameters = new object[][]
            {
                new object[] { "@funds_id", DbType.Int32, fundId},
                new object[] { "@date_entry", DbType.Date, dateEntry.Date},
                new object[] { "@fpp_is_special", DbType.Byte, isSpecial}
            };

            string query = $"SELECT * FROM {viewTableName} WHERE funds_id = @funds_id AND date_entry <= @date_entry AND fpp_is_special = @fpp_is_special";

            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
        }

        public DataTable GetViewRecords(int fundId, DateTime dateEntry, short year, byte isContinuing, byte isSpecial)
        {
            var parameters = new object[][]
            {
                new object[] { "@funds_id", DbType.Int32, fundId},
                new object[] { "@date_entry", DbType.Date, dateEntry.Date},
                new object[] { "@year", DbType.Int16, year},
                new object[] { "@continuing", DbType.Byte, isContinuing},
                new object[] { "@fpp_is_special", DbType.Byte, isSpecial}
            };

            string query = $"SELECT * FROM {viewTableName} WHERE funds_id = @funds_id AND date_entry <= @date_entry AND year = @year AND continuing = @continuing AND fpp_is_special = @fpp_is_special";
            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
        }

        public DataTable GetViewRecordsByFPPIdAndFundIdAndAllotmentClassIdAndDateEntry(string fppId, int? subFPPId, int funds_id, int allotment_class_id, DateTime date_entry)
        {
            var parameters = new object[][]
            {
                new object[] { "@fpp_id", DbType.String, fppId},
                new object[] { "@others_fpp_id", DbType.String, subFPPId},
                new object[] { "@funds_id", DbType.Int32, funds_id},
                new object[] { "@allotment_class_id", DbType.Int32, allotment_class_id},
                new object[] { "@date_entry", DbType.Date, date_entry.Date},
                new object[] { "@year", DbType.Int16, date_entry.Year}
            };

            string fppWhereQuery = fppId == "all" ? string.Empty : "fpp_id = @fpp_id AND";

            string query = $"SELECT id, funds_id, fund_code, fund_name, fpp_id, fpp_code, fpp_name, fpp_is_special, functional_classification_service_id, functional_classification_service_name, functional_classification_id, functional_classification_sector_code, functional_classification_sector_name, others_fpp_id, others_fpp_code, others_fpp_name, allotment_class_id, allotment_class_code, allotment_class_name, general_ledger_accounts_id, general_ledger_accounts_code, general_ledger_accounts_name, account_code, date_entry, year, SUM(amount) AS amount, continuing, remarks, created_at, updated_at FROM {viewTableName} WHERE {fppWhereQuery} others_fpp_id <=> @others_fpp_id AND allotment_class_id = @allotment_class_id AND date_entry <= @date_entry AND year = @year AND funds_id = @funds_id GROUP BY id";

            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
        }

        public DataTable GetViewRecordsByFPPIdAndFundIdAndAllotmentClassIdAndDateEntryAndBudgetAppropriationId(string fppId, int? subFPPId, int funds_id, int allotment_class_id, DateTime date_entry, int budget_id)
        {
            var parameters = new object[][]
            {
                new object[] { "@fpp_id", DbType.String, fppId},
                new object[] { "@others_fpp_id", DbType.String, subFPPId},
                new object[] { "@funds_id", DbType.Int32, funds_id},
                new object[] { "@allotment_class_id", DbType.Int32, allotment_class_id},
                new object[] { "@date_entry", DbType.Date, date_entry.Date},
                new object[] { "@budget_id", DbType.Int32, budget_id},
                new object[] { "@year", DbType.Int16, date_entry.Year}
            };

            string fppWhereQuery = fppId == "all" ? string.Empty : "fpp_id = @fpp_id AND";

            string query = $"SELECT id, funds_id, fund_code, fund_name, fpp_id, fpp_code, fpp_name, fpp_is_special, functional_classification_service_id, functional_classification_service_name, functional_classification_id, functional_classification_sector_code, functional_classification_sector_name, others_fpp_id, others_fpp_code, others_fpp_name, allotment_class_id, allotment_class_code, allotment_class_name, general_ledger_accounts_id, general_ledger_accounts_code, general_ledger_accounts_name, account_code, date_entry, year, SUM(amount) AS amount, continuing, remarks, created_at, updated_at FROM {viewTableName} WHERE {fppWhereQuery} others_fpp_id <=> @others_fpp_id AND allotment_class_id = @allotment_class_id AND date_entry <= @date_entry AND year = @year AND id <> @budget_id GROUP BY general_ledger_accounts_id";

            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
        }

        public DataTable GetViewRecords(int fppId, int? subFppId, int alltmntClssId, int fundId)
        {
            var parameters = new object[][]
            {
                new object[] { "@fpp_id", DbType.Int32, fppId},
                new object[] { "@others_fpp_id", DbType.String, subFppId},
                new object[] { "@allotment_class_id", DbType.Int32, alltmntClssId},
                new object[] { "@funds_id", DbType.Int32, fundId},
            };

            string query = $"SELECT * FROM {viewTableName} WHERE fpp_id = @fpp_id AND allotment_class_id = @allotment_class_id AND others_fpp_id <=> @others_fpp_id AND funds_id = @funds_id ";

            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
        }

        public DataTable GetViewRecordsByIdsSearch(BudgetAppropriationsModel entity, string searchTxt)
        {
            var parameters = new object[][]
            {
                new object[] { "@fpp_id", DbType.Int32, entity.FunctionProgramProjectId},
                new object[] { "@others_fpp_id", DbType.String, entity.OthersFPPId },
                new object[] { "@allotment_class_id", DbType.Int32, entity.AllotmentClassesId},
                new object[] { "@funds_id", DbType.Int32, entity.FundsId},
                new object[] { "@searchTxt", DbType.String, $"%{searchTxt}%"}
            };

            string query = $"SELECT * FROM {viewTableName} WHERE fpp_id = @fpp_id AND allotment_class_id = @allotment_class_id AND others_fpp_id <=> @others_fpp_id AND funds_id = @funds_id AND (account_code LIKE @searchTxt OR general_ledger_accounts_name LIKE @searchTxt)";

            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
        }

        public DataTable GetViewRecordsByIdsYear(BudgetAppropriationsModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@fpp_id", DbType.Int32, entity.FunctionProgramProjectId},
                new object[] { "@others_fpp_id", DbType.String, entity.OthersFPPId },
                new object[] { "@allotment_class_id", DbType.Int32, entity.AllotmentClassesId},
                new object[] { "@funds_id", DbType.Int32, entity.FundsId},
                new object[] { "@year", DbType.Int16, entity.Year}
            };

            string query = $"SELECT * FROM {viewTableName} WHERE fpp_id = @fpp_id AND allotment_class_id = @allotment_class_id AND others_fpp_id <=> @others_fpp_id AND funds_id = @funds_id AND year = @year ORDER BY general_ledger_accounts_code";

            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
        }

        // decimal methods
        public decimal GetSumBudgetAppropriations(string fppId, string subFPPId, int fundId, DateTime dateEntry, int allotment_classes_id, byte isContinuing)
        {
            var parameters = new object[][]
            {
                new object[] { "@fpp_id", DbType.String, fppId},
                new object[] { "@others_fpp_id", DbType.String, subFPPId },
                new object[] { "@funds_id", DbType.Int32, fundId},
                new object[] { "@date_entry", DbType.Date, dateEntry.Date},
                new object[] { "@allotment_class_id", DbType.Int32, allotment_classes_id },
                new object[] { "@continuing", DbType.Byte, isContinuing},
                new object[] { "@year", DbType.Int16, dateEntry.Year}
            };

            string fppWhereQuery = fppId == "all" ? string.Empty : "fpp_id = @fpp_id AND";
            string isContinuingQuery = isContinuing == 0 ? "year = @year" : "year <= @year";

            string subFPPQuery = string.Empty;

            if (fppId == "all")
                subFPPQuery = string.Empty;
            else
            {
                if (subFPPId == "all")
                    subFPPQuery = "others_fpp_id IS NOT NULL AND";
                else if (string.IsNullOrEmpty(subFPPId))
                    subFPPQuery = "others_fpp_id IS NULL AND";
                else
                    subFPPQuery = "others_fpp_id = @others_fpp_id AND";
            }

            string query = $"SELECT COALESCE(SUM(amount), 0) AS amount FROM {viewTableName} WHERE {fppWhereQuery} {subFPPQuery} funds_id = @funds_id AND date_entry <= @date_entry AND allotment_class_id = @allotment_class_id AND continuing = @continuing AND {isContinuingQuery}";

            return Convert.ToDecimal(mySqlGenericCommandsLFS.ExecuteScalar(query, parameters));
        }

        // Dictionary methods
        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] {"@id", DbType.Int32, Id},
            };
            string query = $"SELECT funds_id, function_program_project_id, others_fpp_id, allotment_classes_id, general_ledger_accounts_id, date_entry, year, amount, continuing, remarks, created_at, updated_at FROM {tableName} WHERE id = @id";

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

        public Dictionary<string, string> GetViewRecordByIdDateEntry(int budgetAppropriationId, DateTime dateEntry)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, budgetAppropriationId},
                new object[] { "@date_entry", DbType.Date, dateEntry.Date}
            };
            string query = $"SELECT * FROM {viewTableName} WHERE id = @id AND date_entry <= @date_entry";

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

        public Dictionary<string, string> GetViewRecordByID(int budgetAppID)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, budgetAppID},
            };
            string query = $"SELECT * FROM {viewTableName} WHERE id = @id ";

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

        // int methods
        public int GetLastInsertedID()
        {
            string query = $"SELECT MAX(id) FROM {tableName}";
            return int.Parse(mySqlGenericCommandsLFS.ExecuteScalar(query));
        }

        // string methods
        public string GetBudgetIdByGeneralLedgerId(string generalLedgerId)
        {
            var parameters = new object[][]
            {
                new object[] { "@general_ledger_id", DbType.Int32, generalLedgerId},
            };

            string query = $"SELECT id FROM {tableName} WHERE general_ledger_accounts_id = @general_ledger_id LIMIT 1";
            return mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);
        }
    }
}