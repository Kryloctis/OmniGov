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
        private readonly string tableName = "";
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

        public bool Insert(BudgetRealignmentModel entity)
        {
            throw new System.NotImplementedException();
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
                    $"to_budget," +
                    $"date_entry, " +
                    $"amount " +
                    $"FROM {viewTableName} " +
                    $"WHERE budget_appropriations_id = @budget_appropriations_id";

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
