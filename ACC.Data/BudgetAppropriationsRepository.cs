using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
                    new object[] { "@continuing", DbType.Boolean, entity.Continuing},
                    new object[] { "@remarks", DbType.String, entity.Remarks}
               };

                string query = $"INSERT INTO {tableName} " +
                    $"(funds_id, " +
                    $"function_program_project_id , " +
                    $"others_fpp_id, " +
                    $"allotment_classes_id, " +
                    $"general_ledger_accounts_id, " +
                    $"date_entry, " +
                    $"year, " +
                    $"amount, " +
                    $"continuing, " +
                    $"remarks) " +
                    $"VALUES " +
                    $"(@funds_id, " +
                    $"@function_program_project_id, " +
                    $"@others_fpp_id, " +
                    $"@allotment_classes_id, " +
                    $"@general_ledger_accounts_id, " +
                    $"@date_entry, " +
                    $"@year, " +
                    $"@amount, " +
                    $"@continuing, " +
                    $"@remarks)";

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
                    new object[] { "@continuing", DbType.Boolean, entity.Continuing},
                    new object[] { "@remarks", DbType.String, entity.Remarks}
                };

                string query = $"UPDATE {tableName} SET " +
                    $"function_program_project_id = @function_program_project_id, " +
                    $"funds_id = @funds_id, " +
                    $"others_fpp_id = @others_fpp_id, " +
                    $"allotment_classes_id = @allotment_classes_id, " +
                    $"general_ledger_accounts_id = @general_ledger_accounts_id, " +
                    $"date_entry = @date_entry, " +
                    $"year = @year, " +
                    $"amount = @amount, " +
                    $"continuing = @continuing, " +
                    $"remarks = @remarks " +
                    $"WHERE id = @id";

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
                string query = $"SELECT " +
                    $"funds_id, " +
                    $"function_program_project_id, " +
                    $"others_fpp_id, " +
                    $"allotment_classes_id, " +
                    $"general_ledger_accounts_id, " +
                    $"date_entry, " +
                    $"year, " +
                    $"amount, " +
                    $"continuing, " +
                    $"remarks, " +
                    $"created_at, " +
                    $"updated_at " +
                    $"FROM {tableName} " +
                    $"WHERE id = @id";

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
                        record.Add("remarks", item[9].ToString());
                        record.Add("created_at", item[10].ToString());
                        record.Add("updated_at", item[11].ToString());
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
            try
            {
                string query = $"SELECT * FROM {viewTableName}";

                var dtBudgetAppropriation = new DataTable();
                return mySqlGenericCommands.Fill(query, dtBudgetAppropriation);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new NotImplementedException();
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }


        //SAAOBB
        public DataTable GetViewRecords(int fundId, DateTime dateEntry, byte isSpecial)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@funds_id", DbType.Int32, fundId},
                    new object[] { "@date_entry", DbType.Date, dateEntry.Date},
                    new object[] { "@fpp_is_special", DbType.Byte, isSpecial}
                };


                string query = $"SELECT " +
                     $"id, " +
                     $"funds_id, " +
                     $"fund_code, " +
                     $"fund_name, " +
                     $"fpp_id, " +
                     $"fpp_code, " +
                     $"fpp_name, " +
                     $"fpp_is_special, " +
                     $"functional_classification_service_id, " +
                     $"functional_classification_service_name, " +
                     $"functional_classification_id, " +
                     $"functional_classification_sector_code, " +
                     $"functional_classification_sector_name, " +
                     $"others_fpp_id, " +
                     $"others_fpp_code, " +
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
                     $"remarks, " +
                     $"created_at, " +
                     $"updated_at " +
                     $"FROM {viewTableName} " +
                     $"WHERE " +
                     $"funds_id = @funds_id " +
                     $"AND date_entry <= @date_entry " +
                     $"AND fpp_is_special = @fpp_is_special";

                var dataTable = new DataTable();
                return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
            }
            catch (MySqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //SAAOB
        public DataTable GetViewRecords(int fundId, DateTime dateEntry, short year, byte isContinuing, byte isSpecial)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@funds_id", DbType.Int32, fundId},
                    new object[] { "@date_entry", DbType.Date, dateEntry.Date},
                    new object[] { "@year", DbType.Int16, year},
                    new object[] { "@continuing", DbType.Byte, isContinuing},
                    new object[] { "@fpp_is_special", DbType.Byte, isSpecial}
                };


                string query = $"SELECT " +
                     $"id, " +
                     $"funds_id, " +
                     $"fund_code, " +
                     $"fund_name, " +
                     $"fpp_id, " +
                     $"fpp_code, " +
                     $"fpp_name, " +
                     $"fpp_is_special, " +
                     $"functional_classification_service_id, " +
                     $"functional_classification_service_name, " +
                     $"functional_classification_id, " +
                     $"functional_classification_sector_code, " +
                     $"functional_classification_sector_name, " +
                     $"others_fpp_id, " +
                     $"others_fpp_code, " +
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
                     $"remarks, " +
                     $"created_at, " +
                     $"updated_at " +
                     $"FROM {viewTableName} " +
                     $"WHERE " +
                     $"funds_id = @funds_id " +
                     $"AND date_entry <= @date_entry " +
                     $"AND year = @year " +
                     $"AND continuing = @continuing " +
                     $"AND fpp_is_special = @fpp_is_special";

                var dataTable = new DataTable();
                return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
            }
            catch (MySqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //DASHBOARD

        #region BUDGET DASHBOARD

        //DETAILED
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


            string query = $"SELECT " +
                   $"id, " +
                   $"funds_id, " +
                   $"fund_code, " +
                   $"fund_name, " +
                   $"fpp_id, " +
                   $"fpp_code, " +
                   $"fpp_name, " +
                   $"fpp_is_special, " +
                   $"functional_classification_service_id, " +
                   $"functional_classification_service_name, " +
                   $"functional_classification_id, " +
                   $"functional_classification_sector_code, " +
                   $"functional_classification_sector_name, " +
                   $"others_fpp_id, " +
                   $"others_fpp_code, " +
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
                   $"SUM(amount) AS amount, " +
                   $"continuing, " +
                   $"remarks, " +
                   $"created_at, " +
                   $"updated_at " +
                   $"FROM {viewTableName} " +
                   $"WHERE {fppWhereQuery} " +
                   $"others_fpp_id <=> @others_fpp_id AND " +
                   $"allotment_class_id = @allotment_class_id " +
                   $"AND date_entry <= @date_entry " +
                   $"AND year = @year AND funds_id = @funds_id " +
                   $"GROUP BY id";

            var dataTable = new DataTable();
            return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);

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

            string query = $"SELECT distinct a.others_fpp_id, a.others_fpp_name " +
                $"FROM {viewTableName} a INNER JOIN others_fpp b ON a.others_fpp_id = b.id " +
                $"WHERE " +
                $"{fppWhereQuery} " +
                $"a.allotment_class_id = @allotment_class_id " +
                $"AND funds_id = @funds_id " +
                $"AND a.year = @year";

            var dataTable = new DataTable();
            return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);

        }

        //SUMMARY
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

            string query = $"SELECT COALESCE(SUM(amount), 0) AS amount " +
                    $"FROM {viewTableName} " +
                    $"WHERE " +
                    $"{fppWhereQuery} " +
                    $"{subFPPQuery} " +
                    $"funds_id = @funds_id " +
                    $"AND date_entry <= @date_entry " +
                    $"AND allotment_class_id = @allotment_class_id " +
                    $"AND continuing = @continuing " +
                    $"AND {isContinuingQuery}";


            decimal budgetAppropriations = Convert.ToDecimal(mySqlGenericCommands.ExecuteScalar(query, parameters));

            return budgetAppropriations;
        }

        #endregion

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
                };

                string query = $"SELECT " +
                    $"id, " +
                    $"funds_id, " +
                    $"fund_code, " +
                    $"fund_name, " +
                    $"fpp_id, " +
                    $"fpp_code, " +
                    $"fpp_name, " +
                    $"fpp_is_special, " +
                    $"functional_classification_service_id, " +
                    $"functional_classification_service_name, " +
                    $"functional_classification_id, " +
                    $"functional_classification_sector_code, " +
                    $"functional_classification_sector_name, " +
                    $"others_fpp_id, " +
                    $"others_fpp_code, " +
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
                    $"remarks, " +
                    $"created_at, " +
                    $"updated_at " +
                    $"FROM {viewTableName} " +
                    $"WHERE fpp_id = @fpp_id " +
                    $"AND allotment_class_id = @allotment_class_id " +
                    $"AND others_fpp_id <=> @others_fpp_id " +
                    $"AND funds_id = @funds_id ";

                var dataTable = new DataTable();
                return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetViewRecordsByIdsSearch(BudgetAppropriationsModel entity, string searchTxt)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@fpp_id", DbType.Int32, entity.FunctionProgramProjectId},
                    new object[] { "@others_fpp_id", DbType.String, entity.OthersFPPId },
                    new object[] { "@allotment_class_id", DbType.Int32, entity.AllotmentClassesId},
                    new object[] { "@funds_id", DbType.Int32, entity.FundsId},
                    new object[] { "@searchTxt", DbType.String, $"%{searchTxt}%"}
                };

                string query = $"SELECT " +
                    $"id, " +
                    $"funds_id, " +
                    $"fund_code, " +
                    $"fund_name, " +
                    $"fpp_id, " +
                    $"fpp_code, " +
                    $"fpp_name, " +
                    $"fpp_is_special, " +
                    $"functional_classification_service_id, " +
                    $"functional_classification_service_name, " +
                    $"functional_classification_id, " +
                    $"functional_classification_sector_code, " +
                    $"functional_classification_sector_name, " +
                    $"others_fpp_id, " +
                    $"others_fpp_code, " +
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
                    $"remarks, " +
                    $"created_at, " +
                    $"updated_at " +
                    $"FROM {viewTableName} " +
                    $"WHERE fpp_id = @fpp_id " +
                    $"AND allotment_class_id = @allotment_class_id " +
                    $"AND others_fpp_id <=> @others_fpp_id " +
                    $"AND funds_id = @funds_id " +
                    $"AND (account_code LIKE @searchTxt OR general_ledger_accounts_name LIKE @searchTxt)";

                var dataTable = new DataTable();
                return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
            }
            catch (Exception)
            {
                throw;
            }
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

            string query = $"SELECT " +
                $"id, " +
                $"funds_id, " +
                $"fund_code, " +
                $"fund_name, " +
                $"fpp_id, " +
                $"fpp_code, " +
                $"fpp_name, " +
                $"fpp_is_special, " +
                $"functional_classification_service_id, " +
                $"functional_classification_service_name, " +
                $"functional_classification_id, " +
                $"functional_classification_sector_code, " +
                $"functional_classification_sector_name, " +
                $"others_fpp_id, " +
                $"others_fpp_code, " +
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
                $"remarks, " +
                $"created_at, " +
                $"updated_at " +
                $"FROM {viewTableName} " +
                $"WHERE fpp_id = @fpp_id " +
                $"AND allotment_class_id = @allotment_class_id " +
                $"AND others_fpp_id <=> @others_fpp_id " +
                $"AND funds_id = @funds_id " +
                $"AND year = @year";

            var dataTable = new DataTable();
            return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
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

            var dataTable = new DataTable();
            return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }

        //change//
        public Dictionary<string, string> GetViewRecordByID(int budgetAppID)
        {
            var record = new Dictionary<string, string>();

            try
            {
                var parameters = new object[][]
                {
                   new object[] { "@id", DbType.Int32, budgetAppID},
                };
                string query = $"SELECT " +
                    $"id, " +
                    $"funds_id, " +
                    $"fund_code, " +
                    $"fund_name, " +
                    $"fpp_id, " +
                    $"fpp_code, " +
                    $"fpp_name, " +
                    $"functional_classification_service_id, " +
                    $"functional_classification_service_name, " +
                    $"functional_classification_id, " +
                    $"functional_classification_sector_code, " +
                    $"functional_classification_sector_name, " +
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
                    $"remarks, " +
                    $"created_at, " +
                    $"updated_at " +
                    $"FROM {viewTableName} " +
                    $"WHERE " +
                    $"id = @id ";

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
                        record.Add("functional_classification_service_id", item[7].ToString());
                        record.Add("functional_classification_service_name", item[8].ToString());
                        record.Add("functional_classification_id", item[9].ToString());
                        record.Add("functional_classification_sector_code", item[10].ToString());
                        record.Add("functional_classification_sector_name", item[11].ToString());
                        record.Add("others_fpp_id", item[12].ToString());
                        record.Add("others_fpp_name", item[13].ToString());
                        record.Add("allotment_class_id", item[14].ToString());
                        record.Add("allotment_class_code", item[15].ToString());
                        record.Add("allotment_class_name", item[16].ToString());
                        record.Add("general_ledger_accounts_id", item[17].ToString());
                        record.Add("general_ledger_accounts_code", item[18].ToString());
                        record.Add("general_ledger_accounts_name", item[19].ToString());
                        record.Add("account_code", item[20].ToString());
                        record.Add("date_entry", item[21].ToString());
                        record.Add("year", item[22].ToString());
                        record.Add("amount", item[23].ToString());
                        record.Add("continuing", item[24].ToString());
                        record.Add("remarks", item[25].ToString());
                        record.Add("created_at", item[26].ToString());
                        record.Add("updated_at", item[27].ToString());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return record;
        }

        public Dictionary<string, string> GetViewRecordByIdDateEntry(int budgetAppropriationId, DateTime dateEntry)
        {
            var record = new Dictionary<string, string>();
            var parameters = new object[][]
            {
                    new object[] { "@id", DbType.Int32, budgetAppropriationId},
                    new object[] { "@date_entry", DbType.Date, dateEntry.Date}
            };
            string query = $"SELECT " +
                $"id, " +
                $"funds_id, " +
                $"fund_code, " +
                $"fund_name, " +
                $"fpp_id, " +
                $"fpp_code, " +
                $"fpp_name, " +
                $"functional_classification_service_id, " +
                $"functional_classification_service_name, " +
                $"functional_classification_id, " +
                $"functional_classification_sector_code, " +
                $"functional_classification_sector_name, " +
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
                $"remarks, " +
                $"created_at, " +
                $"updated_at " +
                $"FROM {viewTableName} " +
                $"WHERE " +
                $"id = @id " +
                $"AND date_entry <= @date_entry";

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
                    record.Add("functional_classification_service_id", item[7].ToString());
                    record.Add("functional_classification_service_name", item[8].ToString());
                    record.Add("functional_classification_id", item[9].ToString());
                    record.Add("functional_classification_sector_code", item[10].ToString());
                    record.Add("functional_classification_sector_name", item[11].ToString());
                    record.Add("others_fpp_id", item[12].ToString());
                    record.Add("others_fpp_name", item[13].ToString());
                    record.Add("allotment_class_id", item[14].ToString());
                    record.Add("allotment_class_code", item[15].ToString());
                    record.Add("allotment_class_name", item[16].ToString());
                    record.Add("general_ledger_accounts_id", item[17].ToString());
                    record.Add("general_ledger_accounts_code", item[18].ToString());
                    record.Add("general_ledger_accounts_name", item[19].ToString());
                    record.Add("account_code", item[20].ToString());
                    record.Add("date_entry", item[21].ToString());
                    record.Add("year", item[22].ToString());
                    record.Add("amount", item[23].ToString());
                    record.Add("continuing", item[24].ToString());
                    record.Add("remarks", item[25].ToString());
                    record.Add("created_at", item[26].ToString());
                    record.Add("updated_at", item[27].ToString());
                }
            }
            return record;
        }


        #region Validations

        public bool BudgetAppropriationExist(int fundId, int fppId, int? othersFPPId, int allotmentClassId, int generalLedgerAccountId, short year, string remarks)
        {
            try
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

                string query = $"SELECT id FROM {tableName} " +
                    $"WHERE " +
                    $"funds_id = @funds_id " +
                    $"AND function_program_project_id = @function_program_project_id " +
                    $"AND others_fpp_id <=> @others_fpp_id " +
                    $"AND allotment_classes_id = @allotment_classes_id " +
                    $"AND general_ledger_accounts_id = @general_ledger_accounts_id " +
                    $"AND year = @year " +
                    $"AND remarks = @remarks";

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

        public bool BudgetAppropriationExist(int id, int fundId, int FPPId, int? othersFPPId, int allotmentClassId, int generalLedgerAccountId, short year, string remarks)
        {
            try
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

                string query = $"SELECT id FROM {tableName} " +
                    $"WHERE id <> @id " +
                    $"AND funds_id = @funds_id " +
                    $"AND function_program_project_id = @function_program_project_id " +
                    $"AND others_fpp_id <=> @others_fpp_id " +
                    $"AND allotment_classes_id = @allotment_classes_id " +
                    $"AND general_ledger_accounts_id = @general_ledger_accounts_id " +
                    $"AND year = @year " +
                    $"AND remarks = @remarks";

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

        public bool BudgetAppropriationContinuing(int fundId, int fppId, int? othersFPPId, int allotmentClassId, int generalLedgerAccountId)
        {
            try
            {
                var parameters = new object[][]
                {
                new object[] { "@funds_id", DbType.Int32, fundId},
                new object[] { "@function_program_project_id", DbType.Int32, fppId},
                new object[] { "@others_fpp_id", DbType.String, othersFPPId },
                new object[] { "@allotment_classes_id", DbType.Int32, allotmentClassId},
                new object[] { "@general_ledger_accounts_id", DbType.Int32, generalLedgerAccountId},
                };

                string query = $"SELECT " +
                    $"id " +
                    $"FROM {tableName} " +
                    $"WHERE funds_id = @funds_id " +
                    $"AND function_program_project_id = @function_program_project_id " +
                    $"AND others_fpp_id <=> @others_fpp_id " +
                    $"AND allotment_classes_id = @allotment_classes_id " +
                    $"AND general_ledger_accounts_id = @general_ledger_accounts_id " +
                    $"AND continuing = 1";

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

        public bool BudgetAppropriationContinuing(int id, int fundId, int fppId, int? othersFPPId, int allotmentClassId, int generalLedgerAccountId)
        {
            try
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

                string query = $"SELECT " +
                    $"id " +
                    $"FROM {tableName} " +
                    $"WHERE id <> @id " +
                    $"AND funds_id = @funds_id " +
                    $"AND function_program_project_id = @function_program_project_id " +
                    $"AND others_fpp_id <=> @others_fpp_id " +
                    $"AND allotment_classes_id = @allotment_classes_id " +
                    $"AND general_ledger_accounts_id = @general_ledger_accounts_id " +
                    $"AND continuing = 1";

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

        public string GetBudgetIdByGeneralLedgerId(string generalLedgerId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@general_ledger_id", DbType.Int32, generalLedgerId},
                };

                string query = $"SELECT id FROM {tableName} WHERE general_ledger_accounts_id = @general_ledger_id LIMIT 1";
                return mySqlGenericCommands.ExecuteScalar(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }



        #endregion Validations


        public DataTable GetViewRecordsByFPPIdAndFundIdAndAllotmentClassIdAndDateEntryAndBudgetAppropriationId(string fppId, int? subFPPId, int funds_id, int allotment_class_id, DateTime date_entry, int budget_id)
        {
            try
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


                string query = $"SELECT " +
                       $"id, " +
                       $"funds_id, " +
                       $"fund_code, " +
                       $"fund_name, " +
                       $"fpp_id, " +
                       $"fpp_code, " +
                       $"fpp_name, " +
                       $"fpp_is_special, " +
                       $"functional_classification_service_id, " +
                       $"functional_classification_service_name, " +
                       $"functional_classification_id, " +
                       $"functional_classification_sector_code, " +
                       $"functional_classification_sector_name, " +
                       $"others_fpp_id, " +
                       $"others_fpp_code, " +
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
                       $"SUM(amount) AS amount, " +
                       $"continuing, " +
                       $"remarks, " +
                       $"created_at, " +
                       $"updated_at " +
                       $"FROM {viewTableName} " +
                       $"WHERE {fppWhereQuery} " +
                       $"others_fpp_id <=> @others_fpp_id AND " +
                       $"allotment_class_id = @allotment_class_id " +
                       $"AND date_entry <= @date_entry " +
                       $"AND year = @year " +
                       $"AND id <> @budget_id " +
                       $"GROUP BY general_ledger_accounts_id";

                var dataTable = new DataTable();
                return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
            }
            catch (MySqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
