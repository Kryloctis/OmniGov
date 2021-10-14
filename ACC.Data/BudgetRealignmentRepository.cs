using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    public class BudgetRealignmentRepository : IBudgetRealignmentRepository
    {

        private MySqlGenericCommands _mySqlGenericCommands;
        private readonly string tableName = "realignment_from";
        private readonly string tableName2 = "realignment_to";
        private readonly string viewTableName1 = "view_realignment_from";
        private readonly string viewTableName2 = "view_realignment_to";
        private readonly string viewTableName = "view_realignment";


        public BudgetRealignmentRepository(MySqlGenericCommands mySqlGenericCommands)
        {
            _mySqlGenericCommands = mySqlGenericCommands;
        }

        public bool IdExist(int id)
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetRecords()
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new System.NotImplementedException();
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new System.NotImplementedException();
        }

        public int CountRecords()
        {
            throw new System.NotImplementedException();
        }
        public bool InsertRealignment(BudgetRealignmentModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@realignment_from_id", DbType.Int32, entity.RealignmentId},
                    new object[] { "@realignment_to_id", DbType.Int32, entity.ToBudgetAppropriationId},
                    new object[] { "@amount", DbType.Decimal, entity.Amount},
                };

                string query = $"INSERT INTO {tableName2} (realignment_from_id, to_budget_appropriations_id, amount) VALUES (@realignment_from_id, @realignment_to_id, @amount)";
                return _mySqlGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Insert(BudgetRealignmentModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@budget_appropriations_id", DbType.Int32, entity.BudgetAppropriationId},
                    new object[] { "@date_entry", DbType.Date, entity.DateEntry.Date},
                    new object[] { "@remarks", DbType.String, entity.Remarks},
                };

                string query = $"INSERT INTO {tableName} (from_budget_appropriations_id, date_entry, remarks) VALUES (@budget_appropriations_id, @date_entry, @remarks)";
                return _mySqlGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(BudgetRealignmentModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int16, entity.RealignmentId},
                    new object[] { "@date_entry", DbType.DateTime, entity.DateEntry},
                    new object[] { "@remarks", DbType.String, entity.Remarks},
                };

                string query = $"UPDATE {tableName} SET date_entry=@date_entry, remarks=@remarks WHERE id = @id";
                return _mySqlGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(List<BudgetRealignmentModel> entityList)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    foreach (var entity in entityList)
                    {
                        var parameters = new object[][]
                        {
                            new object[] { "@id", DbType.Int32, entity.ToBudgetAppropriationId},
                        };

                        string query = $"DELETE FROM {tableName2} WHERE id = @id";
                        _ = _mySqlGenericCommands.ExecuteNonQuery(query, parameters);
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


        public DataTable GetRecordsByBudgetAppropriationId(int budgetAppropriationsId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@budget_appropriations_id",DbType.Int32, budgetAppropriationsId }
                };

                string query = $"SELECT " +
                    $"to_id," +
                    $"to_fpp_name," +
                    $"to_allotment_name," +
                    $"to_budget," +
                    $"date_entry, " +
                    $"amount " +
                    $"FROM {viewTableName} " +
                    $"WHERE from_budget_appropriations_id = @budget_appropriations_id";

                var dtSupplementalApprorpriation = new DataTable();

                return _mySqlGenericCommands.FillBySearch(query, dtSupplementalApprorpriation, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ushort GetLastInsertedID()
        {
            try
            {
                string query = $"SELECT MAX(id) FROM {tableName}";
                return (ushort)int.Parse(_mySqlGenericCommands.ExecuteScalar(query));
            }
            catch (Exception)
            {
                throw;
            }
        }


        public decimal GetAmountOfBudgetRealignedToByBudgetId(int budgetId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@budget_appropriations_id", DbType.Int32, budgetId},
                };

                string query = $"SELECT COALESCE(SUM(amount), 0) AS amount FROM view_realignment WHERE to_budget_appropriations_id=@budget_appropriations_id";
                decimal amount = Convert.ToDecimal(_mySqlGenericCommands.ExecuteScalar(query, parameters));
                return amount;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public decimal GetAmountOfBudgetRealignedFromByBudgetId(int budgetId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@budget_appropriations_id", DbType.Int32, budgetId},
                };

                string query = $"SELECT COALESCE(SUM(amount), 0) AS amount FROM view_realignment WHERE from_budget_appropriations_id=@budget_appropriations_id";
                decimal amount = Convert.ToDecimal(_mySqlGenericCommands.ExecuteScalar(query, parameters));
                return amount;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool BudgetHasRealignment(int budgetId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@budget_appropriations_id",DbType.Int64, budgetId },
                };

                string query = $"SELECT id FROM {tableName} WHERE from_budget_appropriations_id = @budget_appropriations_id";
                string queryResult = _mySqlGenericCommands.ExecuteScalar(query, parameters);

                if (!string.IsNullOrEmpty(queryResult)) return true;
            }
            catch (Exception)
            {
                throw;
            };

            return false;
        }

        public DataTable GetBudgetRealignmentByAppropriationId(int budgetAppropriationsId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@budget_appropriations_id",DbType.Int32, budgetAppropriationsId }
                };

                string query = $"SELECT " +
                    $"id, " +
                    $"fpp_name, " +
                    $"allotment_name, " +
                    $"ledger_name, " +
                    $"date_entry, " +
                    $"total_amount, " +
                    $"remarks " +
                    $"FROM {viewTableName1}  " +
                    $"WHERE budget_appropriations_id=@budget_appropriations_id ";


                var dtSupplementalApprorpriation = new DataTable();

                return _mySqlGenericCommands.FillBySearch(query, dtSupplementalApprorpriation, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetRecordsByRealignmentId(int realignmentId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@realignment_id",DbType.Int32, realignmentId }  
                };

                string query = $"SELECT " +
                    $"from_id, " +
                    $"from_fpp_code, " +
                    $"from_fpp_name, " +
                    $"from_allotment_name, " +
                    $"from_budget, " +
                    $"amount " +
                    $"FROM {viewTableName}  " +
                    $"WHERE from_id=@realignment_id ";


                var dtSupplementalApprorpriation = new DataTable();

                return _mySqlGenericCommands.FillBySearch(query, dtSupplementalApprorpriation, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
       
        public DataTable GetRealignedAccountsByBudgetAppropriationId(int budgetAppropriationsId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@budget_appropriations_id", DbType.Int32, budgetAppropriationsId }
                };

                string query = $"SELECT " +
                    $"to_ledger_id, " +
                    $"to_budget, " +
                    $"amount " +
                    $"FROM {viewTableName}  " +
                    $"WHERE from_budget_appropriations_id=@budget_appropriations_id";


                var dtSupplementalApprorpriation = new DataTable();

                return _mySqlGenericCommands.FillBySearch(query, dtSupplementalApprorpriation, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Dictionary<string, string> GetRecordByRealignmentId(int realignmentId)
        {
            var record = new Dictionary<string, string>();

            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@realignmentId", DbType.Int32, realignmentId},
                };

                string query = $"SELECT * FROM {tableName} WHERE id=@realignmentId";

                using (var reader = _mySqlGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;

                    record.Add("id", reader.Rows[0]["id"].ToString());
                    record.Add("from_budget_appropriations_id", reader.Rows[0]["from_budget_appropriations_id"].ToString());
                    record.Add("date_entry", reader.Rows[0]["date_entry"].ToString());
                    record.Add("remarks", reader.Rows[0]["remarks"].ToString());
                    record.Add("created_at", reader.Rows[0]["created_at"].ToString());
                    record.Add("updated_at", reader.Rows[0]["updated_at"].ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }

            return record;
        }

        public DataTable GetRealignedAccountsByRealignmentId(int realignmentId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@realignmentId", DbType.Int32, realignmentId }
                };

                string query = $"SELECT " +
                    $"to_ledger_id, " +
                    $"to_budget_appropriations_id, " +
                    $"to_budget, " +
                    $"amount " +
                    $"FROM {viewTableName}  " +
                    $"WHERE from_id=@realignmentId";


                var dtSupplementalApprorpriation = new DataTable();

                return _mySqlGenericCommands.FillBySearch(query, dtSupplementalApprorpriation, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool RemoveRealignmentAccounts(int realignmentId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@realignmentId", DbType.Int32, realignmentId},
                };

                string query = $"DELETE FROM {tableName2} WHERE realignment_from_id = @realignmentId";
                return _mySqlGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
