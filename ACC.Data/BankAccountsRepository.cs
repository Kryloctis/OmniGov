using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

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
            using (var scope = new TransactionScope())
            {
                foreach (var entity in entityList)
                {
                    var parameters = new object[][] { new object[] { @"id", DbType.Int32, entity.ID } };

                    string query = $"DELETE FROM {tableName} WHERE id = @id";
                    _ = _dbGenericCommands.ExecuteNonQuery(query, parameters);
                }

                scope.Complete();
                return true;
            }
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var record = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, Id},
            };

            string query = $"SELECT * FROM {tableName} WHERE id = @id";

            using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return record;

                record.Add("id", reader.Rows[0]["id"].ToString());
                record.Add("banks_id", reader.Rows[0]["banks_id"].ToString());
                record.Add("account_no", reader.Rows[0]["account_no"].ToString());
                record.Add("created_at", reader.Rows[0]["created_at"].ToString());
                record.Add("updated_at", reader.Rows[0]["updated_at"].ToString());
            }

            return record;
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
            var parameters = new object[][] {
                new object[]{"@id", DbType.Int32, entity.ID},
                new object[]{"@banks_id", DbType.Int32, entity.BankID},
                new object[]{"@account_no", DbType.String, entity.AccountNumber},
            };

            string query = $"UPDATE {tableName} SET banks_id = @banks_id, account_no = @account_no WHERE id = @id";
            return _dbGenericCommands.ExecuteNonQuery(query, parameters);
        }
    }
}