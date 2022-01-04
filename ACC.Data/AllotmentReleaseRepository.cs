using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    public class AllotmentReleaseRepository : IAllotmentReleaseRepository
    {

        private MySqlGenericCommands _mySqlGenericCommands;
        private readonly string viewTableName = "view_allotment_release";
        private readonly string tableName = "allotment_release";
        private readonly IAllotmentAccountRepository _allotmentAccountRepository;

        public AllotmentReleaseRepository(MySqlGenericCommands mySqlGenericCommands, IAllotmentAccountRepository allotmentAccountRepository)
        {
            _mySqlGenericCommands = mySqlGenericCommands;
            _allotmentAccountRepository = allotmentAccountRepository;
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
            try
            {
                string query = $"SELECT id, aro_no, purpose, date_issued, created_at, updated_at FROM {tableName}";
                var dataTable = new DataTable();

                return _mySqlGenericCommands.Fill(query, dataTable);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@searchTxt", DbType.String, $"%{searchText}%" }
                };

                string query = $"SELECT id, aro_no, purpose, date_issued, created_at, updated_at FROM {tableName} WHERE aro_no LIKE @searchTxt OR purpose LIKE  @searchTxt";

                var dataTable = new DataTable();

                return _mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
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

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            try
            {
                var record = new Dictionary<string, string>();

                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, Id}
                };

                string query = $"SELECT id, aro_no, purpose, date_issued, created_at, updated_at FROM {tableName} id = @id";

                using (var reader = _mySqlGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;

                    foreach (DataRow item in reader.Rows)
                    {
                        record.Add("id", item[0].ToString());
                        record.Add("aro_no", item[1].ToString());
                        record.Add("purpose", item[2].ToString());
                        record.Add("date_issued", item[3].ToString());
                        record.Add("created_at", item[4].ToString());
                        record.Add("updated_at", item[5].ToString());
                    }
                }
                return record;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetViewRecordsById(int Id)
        {
            try
            {
                var record = new Dictionary<string, string>();

                var parameters = new object[][]
                {
                    new object[] { "@allotment_release_id", DbType.Int32, Id }
                };

                string query = $"SELECT " +
                    $"allotment_release_id, " +
                    $"allotment_account_id, " +
                    $"aro_no, " +
                    $"purpose, " +
                    $"date_issued, " +
                    $"allotment_release_created_at, " +
                    $"allotment_release_updated_at, " +
                    $"budget_appropriations_id, " +
                    $"funds_id, " +
                    $"fund_code, " +
                    $"fund_name, " +
                    $"function_program_project_id, " +
                    $"fpp_code, " +
                    $"fpp_name, " +
                    $"is_special, " +
                    $"others_fpp_id, " +
                    $"others_fpp_code, " +
                    $"others_fpp_name, " +
                    $"allotment_classes_id, " +
                    $"allotment_code, " +
                    $"allotment_name, " +
                    $"general_ledger_accounts_id, " +
                    $"account_code, " +
                    $"ledger_name, " +
                    $"date_entry, " +
                    $"year, " +
                    $"continuing, " +
                    $"remarks, " +
                    $"amount " +
                    $"FROM {viewTableName} " +
                    $"WHERE " +
                    $"allotment_release_id = @allotment_release_id";

                var dataTable = new DataTable();
                return _mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
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

        private int GetLastInsertedID()
        {
            try
            {
                string query = $"SELECT MAX(id) FROM {tableName}";
                return int.Parse(_mySqlGenericCommands.ExecuteScalar(query));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Insert(AllotmentReleaseModel entity, List<AllotmentAccountModel> listAllotmentAccount)
        {
            try
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

                    _ = _mySqlGenericCommands.ExecuteNonQuery(query, parameters);

                    foreach (var allotmentAccount in listAllotmentAccount)
                    {
                        allotmentAccount.AllotmentReleaseID = GetLastInsertedID();
                        _ = _allotmentAccountRepository.Insert(allotmentAccount);
                    }

                    scope.Complete();
                    return true;
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(AllotmentReleaseModel entity, List<AllotmentAccountModel> listAllotmentAccount)
        {
            try
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

                    string query = $"UPDATE {tableName} " +
                        $"SET " +
                        $"aro_no = @aro_no, " +
                        $"purpose = @purpose, " +
                        $"date_issued = @date_issued " +
                        $"WHERE id = @id";

                    _ = _mySqlGenericCommands.ExecuteNonQuery(query, parameters);

                    _ = _allotmentAccountRepository.DeleteByAllotmentReleaseId(entity.ID);

                    foreach (var allotmentAccount in listAllotmentAccount)
                    {
                        allotmentAccount.AllotmentReleaseID = entity.ID;
                        _ = _allotmentAccountRepository.Insert(allotmentAccount);
                    }


                    scope.Complete();
                    return true;
                };

            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(int allotmentReleaseId)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    var parameters = new object[][]
                    {
                        new object[] { "@id", DbType.Int32, allotmentReleaseId}
                    };

                    string query = $"DELETE FROM {tableName} WHERE id = @id";
                    _ = _allotmentAccountRepository.DeleteByAllotmentReleaseId(allotmentReleaseId);
                    _ = _mySqlGenericCommands.ExecuteNonQuery(query, parameters);


                    scope.Complete();
                    return true;
                };

            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool AllotmentReleaseNoExist(string allotmentReleaseNo)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@aro_no", DbType.String, allotmentReleaseNo }
                };

                string query = $"SELECT id FROM {tableName} WHERE aro_no = @aro_no";
                string queryResult = _mySqlGenericCommands.ExecuteScalar(query, parameters);

                if (!string.IsNullOrEmpty(queryResult)) return true;
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        public bool AllotmentReleaseNoExist(int Id, string allotmentReleaseNo)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id",   DbType.Int32, Id },
                    new object[] { "@aro_no", DbType.String, allotmentReleaseNo }
                };

                string query = $"SELECT id FROM {tableName} WHERE id <> @id AND aro_no = @aro_no";
                string queryResult = _mySqlGenericCommands.ExecuteScalar(query, parameters);

                if (!string.IsNullOrEmpty(queryResult)) return true;
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        public bool AllotmentReleaseExist(int budgetAppropriationId, DateTime dateIssued)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@budget_appropriations_id", DbType.Int32, budgetAppropriationId },
                    new object[] { "@date_issued", DbType.Date, dateIssued.Date }
                };

                string query = $"SELECT allotment_release_id FROM {viewTableName} WHERE budget_appropriations_id = @budget_appropriations_id AND date_issued = @date_issued";
                string queryResult = _mySqlGenericCommands.ExecuteScalar(query, parameters);

                if (!string.IsNullOrEmpty(queryResult)) return true;

            }
            catch (Exception)
            {
                throw;
            }

            return false;
        }

        public bool AllotmentReleaseExist(int Id, int budgetAppropriationId, DateTime dateIssued)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@allotment_release_id", DbType.Int32, Id },
                    new object[] { "@budget_appropriations_id", DbType.Int32, budgetAppropriationId },
                    new object[] { "@date_issued", DbType.Date, dateIssued.Date }
                };

                string query = $"SELECT allotment_release_id FROM {viewTableName} WHERE allotment_release_id = @allotment_release_id AND budget_appropriations_id = @budget_appropriations_id AND date_issued = @date_issued";
                string queryResult = _mySqlGenericCommands.ExecuteScalar(query, parameters);

                if (!string.IsNullOrEmpty(queryResult)) return true;

            }
            catch (Exception)
            {
                throw;
            }

            return false;
        }

        public DataTable GetViewRecordsByBudgetAppropriationIdDateIssued(int budgetAppropriationId, DateTime dateIssued)
        {
            var parameters = new object[][]
            {
                new object[] { "@budget_appropriations_id", DbType.Int32, budgetAppropriationId },
                new object[] { "@date_issued", DbType.Date, dateIssued.Date}
            };


            string query = $"SELECT " +
                $"allotment_release_id, " +
                $"allotment_account_id, " +
                $"aro_no, " +
                $"purpose, " +
                $"date_issued, " +
                $"allotment_release_created_at, " +
                $"allotment_release_updated_at, " +
                $"budget_appropriations_id, " +
                $"funds_id, " +
                $"fund_code, " +
                $"fund_name, " +
                $"function_program_project_id, " +
                $"fpp_code, " +
                $"fpp_name, " +
                $"is_special, " +
                $"others_fpp_id, " +
                $"others_fpp_code, " +
                $"others_fpp_name, " +
                $"allotment_classes_id, " +
                $"allotment_code, " +
                $"allotment_name, " +
                $"general_ledger_accounts_id, " +
                $"account_code, " +
                $"ledger_name, " +
                $"date_entry, " +
                $"year, " +
                $"continuing, " +
                $"remarks, " +
                $"amount " +
                $"FROM {viewTableName} " +
                $"WHERE budget_appropriations_id = @budget_appropriations_id " +
                $"AND date_issued <= @date_issued";

            var dataTable = new DataTable();
            return _mySqlGenericCommands.FillBySearch(query, dataTable, parameters);

        }

        public DataTable GetViewRecordsByBudgetAppropriationId(int budgetAppropriationId)
        {
            var parameters = new object[][]
            {
                new object[] { "@budget_appropriations_id", DbType.Int32, budgetAppropriationId }
            };


            string query = $"SELECT " +
                $"allotment_release_id, " +
                $"allotment_account_id, " +
                $"aro_no, " +
                $"purpose, " +
                $"date_issued, " +
                $"allotment_release_created_at, " +
                $"allotment_release_updated_at, " +
                $"budget_appropriations_id, " +
                $"funds_id, " +
                $"fund_code, " +
                $"fund_name, " +
                $"function_program_project_id, " +
                $"fpp_code, " +
                $"fpp_name, " +
                $"is_special, " +
                $"others_fpp_id, " +
                $"others_fpp_code, " +
                $"others_fpp_name, " +
                $"allotment_classes_id, " +
                $"allotment_code, " +
                $"allotment_name, " +
                $"general_ledger_accounts_id, " +
                $"account_code, " +
                $"ledger_name, " +
                $"date_entry, " +
                $"year, " +
                $"continuing, " +
                $"remarks, " +
                $"amount " +
                $"FROM {viewTableName} " +
                $"WHERE budget_appropriations_id = @budget_appropriations_id";

            var dataTable = new DataTable();
            return _mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }

        public DataTable GetViewRecords()
        {
            try
            {
                string query = $"SELECT " +
                    $"allotment_release_id, " +
                    $"allotment_account_id, " +
                    $"aro_no, " +
                    $"purpose, " +
                    $"date_issued, " +
                    $"allotment_release_created_at, " +
                    $"allotment_release_updated_at, " +
                    $"budget_appropriations_id, " +
                    $"funds_id, " +
                    $"fund_code, " +
                    $"fund_name, " +
                    $"function_program_project_id, " +
                    $"fpp_code, " +
                    $"fpp_name, " +
                    $"is_special, " +
                    $"others_fpp_id, " +
                    $"others_fpp_code, " +
                    $"others_fpp_name, " +
                    $"allotment_classes_id, " +
                    $"allotment_code, " +
                    $"allotment_name, " +
                    $"general_ledger_accounts_id, " +
                    $"account_code, " +
                    $"ledger_name, " +
                    $"date_entry, " +
                    $"year, " +
                    $"continuing, " +
                    $"remarks, " +
                    $"amount " +
                    $"FROM {viewTableName} ";

                var dataTable = new DataTable();
                return _mySqlGenericCommands.Fill(query, dataTable);
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

        #region BUDGET DASHBOARD METHODS
        //SUMMARY
        public decimal GetSumAllotments(string fppId, string subFPPId, int fundId, DateTime dateIssued, int allotmentClassId, byte isContinuing)
        {
            try
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


                string query = $"SELECT COALESCE(SUM(amount), 0) AS amount " +
                    $"FROM {viewTableName} " +
                    $"WHERE {fppWhereQuery} " +
                    $"{subFPPQuery} " +
                    $"funds_id = @funds_id " +
                    $"AND date_issued <= @date_issued " +
                    $"AND allotment_classes_id = @allotment_classes_id " +
                    $"AND continuing = @continuing " +
                    $"AND {isContinuingQuery}";

                decimal allotments = Convert.ToDecimal(_mySqlGenericCommands.ExecuteScalar(query, parameters));
                return allotments;
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

        //DETAILED  
        public decimal GetSumAllotments(int budgetAppropriationId, DateTime dateIssued)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@budget_appropriations_id", DbType.Int32, budgetAppropriationId },
                    new object[] { "@date_issued",DbType.Date, dateIssued.Date }
                };

                string query = $"SELECT COALESCE(SUM(amount), 0) AS amount FROM {viewTableName} " +
                    $"WHERE budget_appropriations_id = @budget_appropriations_id " +
                    $"AND date_issued <= @date_issued";

                decimal allotments = Convert.ToDecimal(_mySqlGenericCommands.ExecuteScalar(query, parameters));
                return allotments;
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
        #endregion
    }
}
