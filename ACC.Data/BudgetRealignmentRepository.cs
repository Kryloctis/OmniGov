using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using MySql.Data.MySqlClient;
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
                    new object[] { "@realignment_from_id", DbType.Int32, entity.FromBudgetAppropriationId},
                    new object[] { "@realignment_to_id", DbType.Int32, entity.BudgetAppropriationId},
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
            throw new System.NotImplementedException();
        }

        public bool Delete(List<BudgetRealignmentModel> entityList)
        {
            throw new System.NotImplementedException();
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

        public DataTable GetRealignmentFromByAppropriationId(int budgetAppropriationsId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@budget_appropriations_id",DbType.Int32, budgetAppropriationsId }
                };

                string query = $"SELECT " +
                    $"from_id," +
                    $"from_fpp_name," +
                    $"from_allotment_name," +
                    $"from_budget," +
                    $"date_entry, " +
                    $"amount " +
                    $"FROM {viewTableName} " +
                    $"WHERE to_budget_appropriations_id = @budget_appropriations_id";

                var dtSupplementalApprorpriation = new DataTable();

                return _mySqlGenericCommands.FillBySearch(query, dtSupplementalApprorpriation, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetRealignmentToByAppropriationId(int budgetAppropriationsId)
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
    }
}
