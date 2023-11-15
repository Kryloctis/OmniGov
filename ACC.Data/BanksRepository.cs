using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    public class BanksRepository : IBanksRepository
    {
        private readonly IAccGenericCommands _dbGenericCommands;
        private readonly string tableName = "banks";

        public BanksRepository(IAccGenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var record = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, Id},
            };

            string query = $"SELECT bank_code, bank_name, bank_branch FROM {tableName} WHERE id = @id";

            using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return record;

                record.Add("bank_code", reader.Rows[0]["bank_code"].ToString());
                record.Add("bank_name", reader.Rows[0]["bank_name"].ToString());
                record.Add("bank_branch", reader.Rows[0]["bank_branch"].ToString());
            }

            return record;
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {tableName}";

            var dtBanks = new DataTable();
            return _dbGenericCommands.Fill(query, dtBanks);

        }

        public bool Insert(BanksModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@bank_code", DbType.String, entity.BankCode},
                new object[] { "@bank_name", DbType.String, entity.BankName},
                new object[] { "@bank_branch", DbType.String, entity.BankBranch}
            };

            string query = $"INSERT INTO {tableName} (bank_code, bank_name, bank_branch) VALUES (@bank_code, @bank_name, @bank_branch)";
            return _dbGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(BanksModel entity)
        {
            var parameters = new object[][]
            {
                new object[] {"@id", DbType.Int16, entity.Id},
                new object[] {"@bank_code", DbType.String, entity.BankCode},
                new object[] {"@bank_name", DbType.String, entity.BankName},
                new object[] {"@bank_branch", DbType.String, entity.BankBranch},
            };

            string query = $"UPDATE {tableName} SET bank_code = @bank_code, bank_name = @bank_name, bank_branch = @bank_branch WHERE id = @id";
            return _dbGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Delete(List<BanksModel> entityList)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    foreach (var entity in entityList)
                    {
                        var parameters = new object[][]
                        {
                            new object[] { "@id", DbType.Int16, entity.Id},
                        };

                        string query = $"DELETE FROM {tableName} WHERE id = @id";
                        _ = _dbGenericCommands.ExecuteNonQuery(query, parameters);
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
            try
            {
                string query = $"SELECT COUNT(*) FROM {tableName}";

                return int.Parse(_dbGenericCommands.ExecuteScalar(query));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IdExist(int id)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, id },
                };

                string query = $"SELECT id FROM {tableName} WHERE id = @id";
                string queryResult = _dbGenericCommands.ExecuteScalar(query, parameters);

                // if query is not null, means found some record, so true
                if (!string.IsNullOrEmpty(queryResult)) return true;
            }
            catch (Exception)
            {
                throw;
            };

            return false;
        }

        public bool CodeExist(string accountCode)
        {
            var parameters = new object[][]
            {
                new object[] { "@account_no", DbType.String, accountCode },
            };

            string query = $"SELECT account_no FROM {tableName} WHERE account_no = @account_no";
            string queryResult = _dbGenericCommands.ExecuteScalar(query, parameters);

            // if query is not null, means found some record, so true
            if (!string.IsNullOrEmpty(queryResult)) return true;
            return false;
        }

        public bool CodeExist(string accountCode, int bankId)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int16, bankId },
                new object[] { "@account_no", DbType.String, accountCode },
            };

            string query = $"SELECT account_no FROM {tableName} WHERE id <> @id AND account_no = @account_no";
            string queryResult = _dbGenericCommands.ExecuteScalar(query, parameters);

            // if query is not null, means found some record, so true
            if (!string.IsNullOrEmpty(queryResult)) return true;
            return false;
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameters = new object[][] { new object[] { "@search_text", DbType.String, $"%{searchText}%" } };

            string query = $"SELECT * FROM {tableName} WHERE bank_code LIKE @search_text OR bank_name LIKE @search_text OR bank_branch LIKE @search_text";

            var dtBanks = new DataTable();
            return _dbGenericCommands.FillBySearch(query, dtBanks, parameters);
        }

        public int GetLastInsertedId()
        {
            string query = $"SELECT MAX(id) FROM {tableName}";
            return Convert.ToInt32(_dbGenericCommands.ExecuteScalar(query));
        }

        public bool BankExistByNameBranch(string name, string branch)
        {
            var parameters = new object[][]
            {
                new object[] { "@bank_name", DbType.String, name.ToLower().Trim()},
                new object[] { "@bank_branch", DbType.String, branch.ToLower().Trim()}
            };

            string query = $"SELECT id FROM {tableName} WHERE @bank_name = bank_name AND @bank_branch = bank_branch";
            string result = _dbGenericCommands.ExecuteScalar(query, parameters);
            if (!string.IsNullOrEmpty(result)) return true;
            return false;
        }

        public int GetIdByNameBranch(string name, string branch)
        {
            var parameters = new object[][]
            {
                new object[] { "@bank_name", DbType.String, name},
                new object[] { "@bank_branch", DbType.String, branch}
            };

            string query = $"SELECT id FROM {tableName} WHERE bank_name = @bank_name AND bank_branch = @bank_branch";
            return Convert.ToInt32(_dbGenericCommands.ExecuteScalar(query, parameters));
        }
    }
}