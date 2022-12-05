using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace AccountingSystem
{
    internal class BankAccountsRepository : IBankAccountsRepository
    {
        private readonly IAccGenericCommands _dbGenericCommands;
        private readonly string tableName = "bank_accounts";
        private readonly string viewTableName = "view_bank_accounts";

        public BankAccountsRepository(IAccGenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
        }

        public int CountRecords()
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(List<BankAccountsModel> entityList)
        {
            throw new System.NotImplementedException();
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {tableName}";

            var dt = new DataTable();
            return _dbGenericCommands.Fill(query, dt);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            string query = $"SELECT * FROM {tableName}";

            var dt = new DataTable();
            return _dbGenericCommands.Fill(query, dt);
        }

        public DataTable GetViewRecords()
        {
            string query = $"SELECT * FROM {tableName}";

            var dt = new DataTable();
            return _dbGenericCommands.Fill(query, dt);
        }

        public DataTable GetViewRecordsBySearch(string searchKey)
        {
            var parameters = new object[][]
            {
                new object[]{"@searchText", DbType.String, $"%{searchKey}%"},
            };

            string query = $"SELECT * FROM {tableName} WHERE account_no LIKE @searchText";

            var dt = new DataTable();
            return _dbGenericCommands.FillBySearch(query, dt, parameters);
        }

        public bool IdExist(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(BankAccountsModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] {"@banks_id", DbType.String, entity.BankID},
                    new object[] {"@account_no", DbType.String, entity.AccountNumber},
                };

                string query = $"INSERT INTO {tableName} (banks_id,account_no) VALUES (@banks_id, @account_no)";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(BankAccountsModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}