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
        private MySqlGenericCommands mySqlGenericCommands;
        private readonly string tableName = "budget_appropriations";
        private readonly string viewTableName = "view_budget_realignment";


        public BudgetRealignmentRepository(MySqlGenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
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

        public DataTable FilterRecords(string searchTxt, short month, short year)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@searchTxt", DbType.String, $"%{searchTxt}%"},
                    new object[] { "@month", DbType.Int16, month},
                    new object[] { "@year", DbType.Int16, year}
                };

                //string query = $"SELECT " +
                //    $"id, " +
                //    $"account, " +
                //    $"amount, " +
                //    $"date realigned, " +
                //    $"remarks " +
                //    $"FROM {viewTableName} ";

                string query = $"SELECT g.ledger_name, t.amount, f.date_entry, f.remarks FROM realignment_from AS f  INNER JOIN realignment_to AS t ON f.id = t.realignment_from_id INNER JOIN general_ledger_accounts AS g ON f.from_budget_appropriations_id = g.id";

                var dtGeneralLedgers = new DataTable();
                return mySqlGenericCommands.FillBySearch(query, dtGeneralLedgers, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
