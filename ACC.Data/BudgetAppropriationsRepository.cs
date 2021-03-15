using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Transactions;

namespace ACC.Data
{
    public class BudgetAppropriationsRepository : IBudgetAppropriationsRepository
    {
        private MySqlGenericCommands mySqlGenericCommands;
        private readonly string tableName = "budget_appropriations";
        private readonly string viewTableName = "view_budget_appropriations";

        public BudgetAppropriationsRepository(MySqlGenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<BudgetAppropriationsModel> entityList)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    foreach (var entity in entityList)
                    {
                        var parameters = new object[][]
                        {
                            new object[] { "@id", DbType.Int32, entity.ID},
                        };

                        string query = $"DELETE FROM {tableName} WHERE id = @id";
                        _ = mySqlGenericCommands.ExecuteNonQuery(query, parameters);
                    }

                    scope.Complete();
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecords()
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new NotImplementedException();
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(BudgetAppropriationsModel entity)
        {
            try
            {
                var parameters = new object[][]
               {
                    new object[] { "@function_program_project_id", DbType.Int32, entity.FunctionProgramProjectId},
                    new object[] { "@others_fpp_id", DbType.String, entity.OthersFPPId},
                    new object[] { "@allotment_classes_id", DbType.Int32, entity.AllotmentClassesId},
                    new object[] { "@general_ledger_accounts_id", DbType.Int32, entity.GeneralLedgerAccountsId},
                    new object[] { "@date_entry", DbType.Date, entity.DateEntry},
                    new object[] { "@amount", DbType.Decimal, entity.amount}
               };

                string query = $"INSERT INTO {tableName} (function_program_project_id , others_fpp_id, allotment_classes_id, general_ledger_accounts_id, date_entry, amount) VALUES (@function_program_project_id , @others_fpp_id, @allotment_classes_id, @general_ledger_accounts_id, @date_entry, @amount)";
                return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
 
        }

        public bool Update(BudgetAppropriationsModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, entity.ID},
                    new object[] { "@function_program_project_id", DbType.Int32, entity.FunctionProgramProjectId},
                    new object[] { "@others_fpp_id", DbType.String, entity.OthersFPPId},
                    new object[] { "@allotment_classes_id", DbType.Int32, entity.AllotmentClassesId},
                    new object[] { "@general_ledger_accounts_id", DbType.Int32, entity.GeneralLedgerAccountsId},
                    new object[] { "@date_entry", DbType.Date, entity.DateEntry},
                    new object[] { "@amount", DbType.Decimal, entity.amount}
                };

                string query = $"UPDATE {tableName} SET function_program_project_id = @function_program_project_id, others_fpp_id = @others_fpp_id, allotment_classes_id = @allotment_classes_id, general_ledger_accounts_id = @general_ledger_accounts_id, date_entry = @date_entry, amount = @amount WHERE id = @id";
                return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region Validations

        public bool BudgetAllotmentExist(int FPPId, int? othersFPPId, int allotmentClassID, int generalLedgerAccountId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@function_program_project_id", DbType.Int32, FPPId},
                    new object[] { "@others_fpp_id", DbType.String, othersFPPId },
                    new object[] { "@allotment_classes_id", DbType.Int32, allotmentClassID},
                    new object[] { "@general_ledger_accounts_id", DbType.Int32, generalLedgerAccountId},
                };

                string query = $"SELECT id FROM {tableName} WHERE function_program_project_id = @function_program_project_id AND others_fpp_id <=> @others_fpp_id AND allotment_classes_id = @allotment_classes_id AND general_ledger_accounts_id = @general_ledger_accounts_id";
                string queryResult = mySqlGenericCommands.ExecuteScalar(query, parameters);

                // if query is not null, means found some record, so true
                if (!string.IsNullOrEmpty(queryResult)) return true;

            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        public bool BudgetAllotmentExist(int id, int FPPId, int? othersFPPId, int allotmentClassID, int generalLedgerAccountId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "id", DbType.Int32, id},
                    new object[] { "@function_program_project_id", DbType.Int32, FPPId},
                    new object[] { "@others_fpp_id", DbType.String, othersFPPId },
                    new object[] { "@allotment_classes_id", DbType.Int32, allotmentClassID},
                    new object[] { "@general_ledger_accounts_id", DbType.Int32, generalLedgerAccountId},
                };

                string query = $"SELECT id FROM {tableName} WHERE id <> @id AND function_program_project_id = @function_program_project_id AND others_fpp_id <=> @others_fpp_id AND allotment_classes_id = @allotment_classes_id AND general_ledger_accounts_id = @general_ledger_accounts_id";
                string queryResult = mySqlGenericCommands.ExecuteScalar(query, parameters);

                // if query is not null, means found some record, so true
                if (!string.IsNullOrEmpty(queryResult)) return true;

            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        public DataTable GetViewRecords()
        {
            try
            {
                string query = $"SELECT budget_approrations_id, fpp_id, fpp_code, fpp_name, others_fpp_id, others_fpp_name, allotment_classes_id, allotment_code, allotment_name, general_ledger_acc_id, ledger_code, ledger_name, is_contra_account, amount, created_at, updated_at FROM {viewTableName}";

                var dtPermissions = new DataTable();
                return mySqlGenericCommands.Fill(query, dtPermissions);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetViewRecordsBySearch(string searchTxt)
        {
            try
            {
                string query = $"SELECT budget_approrations_id, fpp_id, fpp_code, fpp_name, others_fpp_id, others_fpp_name, allotment_classes_id, allotment_code, allotment_name, general_ledger_acc_id, ledger_code, ledger_name, is_contra_account, amount, created_at, updated_at FROM {viewTableName}";

                var dtPermissions = new DataTable();
                return mySqlGenericCommands.Fill(query, dtPermissions);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Dictionary<string, string> GetRecordByIDs(int budgetAppID, int fppID, int? othersFPPID, int allotmentClassID, int genLedgerAccID)
        {
            var record = new Dictionary<string, string>();

            try
            {
                var parameters = new object[][]
                {
                   new object[] {"@id", DbType.Int32, budgetAppID},
                   new object[] {"@function_program_project_id", DbType.Int32, fppID},
                   new object[] {"@others_fpp_id", DbType.String, othersFPPID},
                   new object[] {"@allotment_classes_id", DbType.Int32, allotmentClassID},
                   new object[] {"@general_ledger_accounts_id", DbType.Int32, genLedgerAccID }
                };
                string query = $"SELECT function_program_project_id, others_fpp_id, allotment_classes_id, general_ledger_accounts_id, amount FROM {tableName} WHERE id = @id AND function_program_project_id = @function_program_project_id AND others_fpp_id <=> @others_fpp_id AND allotment_classes_id = @allotment_classes_id AND general_ledger_accounts_id = @general_ledger_accounts_id";

                using (var reader = mySqlGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;

                    foreach (DataRow item in reader.Rows)
                    {
                        record.Add("function_program_project_id", item[0].ToString());
                        record.Add("others_fpp_id", item[1].ToString());
                        record.Add("allotment_classes_id", item[2].ToString());
                        record.Add("general_ledger_accounts_id", item[3].ToString());
                        record.Add("amount", item[4].ToString());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return record;
        }

        #endregion Validations
    }
}
