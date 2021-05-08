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

        public bool Insert(BudgetAppropriationsModel entity)
        {
            try
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
                    new object[] { "@continuing", DbType.Boolean, entity.Continuing}
               };

                string query = $"INSERT INTO {tableName} (funds_id, function_program_project_id , others_fpp_id, allotment_classes_id, general_ledger_accounts_id, date_entry, year, amount, continuing) VALUES (@funds_id ,@function_program_project_id , @others_fpp_id, @allotment_classes_id, @general_ledger_accounts_id, @date_entry, @year, @amount, @continuing)";
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
                    new object[] { "@id", DbType.Int32, entity.Id},
                    new object[] { "@funds_id", DbType.Int32, entity.FundsId},
                    new object[] { "@function_program_project_id", DbType.Int32, entity.FunctionProgramProjectId},
                    new object[] { "@others_fpp_id", DbType.String, entity.OthersFPPId},
                    new object[] { "@allotment_classes_id", DbType.Int32, entity.AllotmentClassesId},
                    new object[] { "@general_ledger_accounts_id", DbType.Int32, entity.GeneralLedgerAccountsId},
                    new object[] { "@date_entry", DbType.Date, entity.DateEntry},
                    new object[] { "@year", DbType.Int16, entity.Year},
                    new object[] { "@amount", DbType.Decimal, entity.Amount},
                    new object[] { "@continuing", DbType.Boolean, entity.Continuing}
                };

                string query = $"UPDATE {tableName} SET function_program_project_id = @function_program_project_id, funds_id =@funds_id, others_fpp_id = @others_fpp_id, allotment_classes_id = @allotment_classes_id, general_ledger_accounts_id = @general_ledger_accounts_id, date_entry = @date_entry, year = @year, amount = @amount, continuing = @continuing WHERE id = @id";
                return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
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
                            new object[] { "@id", DbType.Int32, entity.Id},
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

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var record = new Dictionary<string, string>();
            try
            {
                var parameters = new object[][]
               {
                   new object[] {"@id", DbType.Int32, Id},
               };
                string query = $"SELECT funds_id, function_program_project_id, others_fpp_id, allotment_classes_id, general_ledger_accounts_id, date_entry, year, amount, continuing, created_at, updated_at FROM {tableName} WHERE id = @id";

                using (var reader = mySqlGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;

                    foreach (DataRow item in reader.Rows)
                    {
                        record.Add("funds_id", item[0].ToString());
                        record.Add("function_program_project_id", item[1].ToString());
                        record.Add("others_fpp_id", item[2].ToString());
                        record.Add("allotment_classes_id", item[3].ToString());
                        record.Add("general_ledger_accounts_id", item[4].ToString());
                        record.Add("date_entry", item[5].ToString());
                        record.Add("year", item[6].ToString());
                        record.Add("amount", item[7].ToString());
                        record.Add("continuing", item[8].ToString());
                        record.Add("created_at", item[9].ToString());
                        record.Add("updated_at", item[10].ToString());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return record;
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

        #region Validations

        public bool BudgetAllotmentExist(int fundID, int FPPId, int? othersFPPId, int allotmentClassID, int generalLedgerAccountId, short year)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@funds_id", DbType.Int32, fundID},
                    new object[] { "@function_program_project_id", DbType.Int32, FPPId},
                    new object[] { "@others_fpp_id", DbType.String, othersFPPId },
                    new object[] { "@allotment_classes_id", DbType.Int32, allotmentClassID},
                    new object[] { "@general_ledger_accounts_id", DbType.Int32, generalLedgerAccountId},
                    new object[] { "@year",DbType.Int16, year}
                };

                string query = $"SELECT id FROM {tableName} WHERE funds_id = @funds_id AND function_program_project_id = @function_program_project_id AND others_fpp_id <=> @others_fpp_id AND allotment_classes_id = @allotment_classes_id AND general_ledger_accounts_id = @general_ledger_accounts_id AND year = @year";
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
         
        public bool BudgetAllotmentExist(int id, int fundID, int FPPId, int? othersFPPId, int allotmentClassID, int generalLedgerAccountId, short year)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, id},
                    new object[] { "@funds_id", DbType.Int32, fundID},
                    new object[] { "@function_program_project_id", DbType.Int32, FPPId},
                    new object[] { "@others_fpp_id", DbType.String, othersFPPId },
                    new object[] { "@allotment_classes_id", DbType.Int32, allotmentClassID},
                    new object[] { "@general_ledger_accounts_id", DbType.Int32, generalLedgerAccountId},
                    new object[] { "@year",DbType.Int16, year}
                };

                string query = $"SELECT id FROM {tableName} WHERE id <> @id AND funds_id = @funds_id AND function_program_project_id = @function_program_project_id AND others_fpp_id <=> @others_fpp_id AND allotment_classes_id = @allotment_classes_id AND general_ledger_accounts_id = @general_ledger_accounts_id AND year = @year";
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

        #endregion Validations

        public Dictionary<string, string> GetViewRecordByIDs(int budgetAppID, int fppID, int? othersFPPID, int allotmentClassID, int genLedgerAccID)
        {
            var record = new Dictionary<string, string>();

            try
            {
                var parameters = new object[][]
                {
                   new object[] { "@id", DbType.Int32, budgetAppID},
                   new object[] { "@fpp_id", DbType.Int32, fppID},
                   new object[] { "@others_fpp_id", DbType.String, othersFPPID},
                   new object[] { "@allotment_class_id", DbType.Int32, allotmentClassID},
                   new object[] { "@general_ledger_accounts_id", DbType.Int32, genLedgerAccID}
                };
                string query = $"SELECT " +
                    $"id, " +
                    $"funds_id, " +
                    $"fund_code, " +
                    $"fund_name, " +
                    $"fpp_id, " +
                    $"fpp_code, " +
                    $"fpp_name, " +
                    $"others_fpp_id, " +
                    $"others_fpp_name, " +
                    $"allotment_class_id, " +
                    $"allotment_class_code, " +
                    $"allotment_class_name, " +
                    $"general_ledger_accounts_id, " +
                    $"general_ledger_accounts_code, " +
                    $"general_ledger_accounts_name, " +
                    $"account_code, " +
                    $"date_entry, " +
                    $"year, " +
                    $"amount, " +
                    $"continuing, " +
                    $"created_at, " +
                    $"updated_at " +
                    $"FROM {viewTableName} " +
                    $"WHERE " +
                    $"id = @id " +
                    $"AND fpp_id = @fpp_id " +
                    $"AND others_fpp_id <=> @others_fpp_id " +
                    $"AND allotment_class_id = @allotment_class_id " +
                    $"AND general_ledger_accounts_id = @general_ledger_accounts_id";

                using (var reader = mySqlGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;

                    foreach (DataRow item in reader.Rows)
                    {
                        record.Add("id", item[0].ToString());
                        record.Add("funds_id", item[1].ToString());
                        record.Add("fund_code", item[2].ToString());
                        record.Add("fund_name", item[3].ToString());
                        record.Add("fpp_id", item[4].ToString());
                        record.Add("fpp_code", item[5].ToString());
                        record.Add("fpp_name", item[6].ToString());
                        record.Add("others_fpp_id", item[7].ToString());
                        record.Add("others_fpp_name", item[8].ToString());
                        record.Add("allotment_class_id", item[9].ToString());
                        record.Add("allotment_class_code", item[10].ToString());
                        record.Add("allotment_class_name", item[11].ToString());
                        record.Add("general_ledger_accounts_id", item[12].ToString());
                        record.Add("general_ledger_accounts_code", item[13].ToString());
                        record.Add("account_code", item[14].ToString());
                        record.Add("general_ledger_accounts_name", item[15].ToString());
                        record.Add("date_entry", item[16].ToString());
                        record.Add("year", item[17].ToString());
                        record.Add("amount", item[18].ToString());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return record;
        }

        public DataTable GetViewRecordsByIds(int fppID, int allotmentClassID, int? othersFPPID, int typeOfFund, DateTime dateEntry)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@fpp_id", DbType.Int32, fppID},
                    new object[] { "@allotment_classes_id", DbType.Int32, allotmentClassID},
                    new object[] { "@others_fpp_id", DbType.String, othersFPPID },
                    new object[] { "@funds_id", DbType.Int32, typeOfFund},
                    new object[] { "@date_entry", DbType.Date, dateEntry.Date}
                };

                string query = $"SELECT " +
                    $"budget_appropriations_id, " +
                    $"funds_id, " +
                    $"fund_code, " +
                    $"fund_name, " +
                    $"fpp_id, " +
                    $"fpp_name, " +
                    $"others_fpp_id, " +
                    $"others_fpp_name, " +
                    $"allotment_classes_id, " +
                    $"allotment_code, " +
                    $"allotment_name, " +
                    $"general_ledger_acc_id, " +
                    $"account_code, " +
                    $"ledger_code, " +
                    $"ledger_name, " +
                    $"date_entry, " +
                    $"year, " +
                    $"appropriation," +
                    $"total_allotment_release, " +
                    $"appropriation_balance, " +
                    $"created_at, " +
                    $"updated_at " +
                    $"FROM {viewTableName} " +
                    $"WHERE fpp_id = @fpp_id " +
                    $"AND allotment_classes_id = @allotment_classes_id " +
                    $"AND others_fpp_id <=> @others_fpp_id " +
                    $"AND funds_id = @funds_id " +
                    $"AND date_entry <= @date_entry";

                var dtPermissions = new DataTable();
                return mySqlGenericCommands.FillBySearch(query, dtPermissions, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetYearsBudgetAppropriations() 
        {
            try
            {
                string query = $"SELECT year FROM {viewTableName} group by year;";

                var dtPermissions = new DataTable();
                return mySqlGenericCommands.Fill(query, dtPermissions);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetViewRecordsSAAOB(int fppID, short year)
        {
            try
            {
                var parameters = new object[][]
           {
                    new object[] { "@fpp_id", DbType.Int32, fppID},
                    new object[] { "@year", DbType.Int16, year}
           };

                string query = $"SELECT * FROM lfsdb.view_budget_appropriations " +
                    $"WHERE fpp_id = @fpp_id " +
                    $"AND year = @year ";

                var dtPermissions = new DataTable();
                return mySqlGenericCommands.FillBySearch(query, dtPermissions, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }


        //Budget Appropriations Display

        public DataTable GetViewRecordsByIds(BudgetAppropriationsModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@fpp_id", DbType.Int32, entity.FunctionProgramProjectId},
                    new object[] { "@others_fpp_id", DbType.String, entity.OthersFPPId },
                    new object[] { "@allotment_class_id", DbType.Int32, entity.AllotmentClassesId},
                    new object[] { "@funds_id", DbType.Int32, entity.FundsId},
                    new object[] { "@year", DbType.Int16, entity.Year}
                };

                string query = $"SELECT " +
                    $"id, " +
                    $"funds_id, " +
                    $"fund_code, " +
                    $"fund_name, " +
                    $"fpp_id, " +
                    $"fpp_code, " +
                    $"fpp_name, " +
                    $"others_fpp_id, " +
                    $"others_fpp_name, " +
                    $"allotment_class_id, " +
                    $"allotment_class_code, " +
                    $"allotment_class_name, " +
                    $"general_ledger_accounts_id, " +
                    $"general_ledger_accounts_code, " +
                    $"general_ledger_accounts_name, " +
                    $"account_code, " +
                    $"date_entry, " +
                    $"year, " +
                    $"amount, " +
                    $"continuing, " +
                    $"created_at, " +
                    $"updated_at " +
                    $"FROM {viewTableName} " +
                    $"WHERE fpp_id = @fpp_id " +
                    $"AND allotment_class_id = @allotment_class_id " +
                    $"AND others_fpp_id <=> @others_fpp_id " +
                    $"AND funds_id = @funds_id " +
                    $"AND year = @year";

                var dtPermissions = new DataTable();
                return mySqlGenericCommands.FillBySearch(query, dtPermissions, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetHeaderOthersFPP(int fppID, int allotment_classes_id, int funds_id, short year)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@fpp_id", DbType.Int32, fppID },
                    new object[] { "@allotment_class_id", DbType.Int32, allotment_classes_id },
                    new object[] { "@funds_id", DbType.Int32, funds_id },
                    new object[] { "@year",DbType.Int16, year },
                };

                string query = $"SELECT distinct a.others_fpp_id, a.others_fpp_name  FROM {viewTableName} a INNER JOIN others_fpp b ON a.others_fpp_id = b.id WHERE a.fpp_id = @fpp_id AND a.allotment_class_id = @allotment_class_id AND funds_id = @funds_id AND a.year = @year";

                var dtPermissions = new DataTable();
                return mySqlGenericCommands.FillBySearch(query, dtPermissions, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
