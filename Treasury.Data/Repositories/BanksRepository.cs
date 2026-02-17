using OmniGov.Core.Repositories;
using OmniGov.Core.Services;
using System.Data;
using System.Transactions;
using Treasury.Domain.Entities;
using Treasury.Domain.Interfaces;

namespace Treasury.Data.Repositories
{
    public class BanksRepository : IBanksRepository
    {
        private readonly string tableName = "banks";
        private GenericCommands mySqlGenericCommands;

        public BanksRepository(GenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, Id},
            };

            string query = $"SELECT * FROM {tableName} WHERE id = @id";

            DataTable dataTable = mySqlGenericCommands.ExecuteReader(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                foreach (DataColumn column in dataTable.Columns)
                    recordDictionary[column.ColumnName] = row[column].ToString();

                return recordDictionary;
            }
            return recordDictionary;
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {tableName}";
            return mySqlGenericCommands.Fill(query, new DataTable());
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
            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
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
            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Delete(List<BanksModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var entity in entityList)
                {
                    var parameters = new object[][] { new object[] { "@id", DbType.Int16, entity.Id }, };
                    string query = $"DELETE FROM {tableName} WHERE id = @id";
                    _ = mySqlGenericCommands.ExecuteNonQuery(query, parameters);
                }

                scope.Complete();
                return true;
            }
        }

        public bool IdExist(int id)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, id },
            };

            string query = $"SELECT id FROM {tableName} WHERE id = @id";
            string queryResult = mySqlGenericCommands.ExecuteScalar(query, parameters);
            return !string.IsNullOrEmpty(queryResult);
        }

        public bool CodeExist(string accountCode)
        {
            var parameters = new object[][]
            {
                new object[] { "@account_no", DbType.String, accountCode },
            };

            string query = $"SELECT account_no FROM {tableName} WHERE account_no = @account_no";
            string queryResult = mySqlGenericCommands.ExecuteScalar(query, parameters);
            return !string.IsNullOrEmpty(queryResult);
        }

        public bool CodeExist(string accountCode, int bankId)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int16, bankId },
                new object[] { "@account_no", DbType.String, accountCode },
            };

            string query = $"SELECT account_no FROM {tableName} WHERE id <> @id AND account_no = @account_no";
            string queryResult = mySqlGenericCommands.ExecuteScalar(query, parameters);
            return !string.IsNullOrEmpty(queryResult);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameters = new object[][]
            {
                new object[] { "@search_text", DbType.String, $"%{searchText}%" }
            };

            string query = $"SELECT * FROM {tableName} WHERE bank_code LIKE @search_text OR bank_name LIKE @search_text OR bank_branch LIKE @search_text";
            return mySqlGenericCommands.FillBySearch(query, new DataTable(), parameters);
        }

        public int GetLastInsertedId()
        {
            string query = $"SELECT MAX(id) FROM {tableName}";
            return Convert.ToInt32(mySqlGenericCommands.ExecuteScalar(query));
        }

        public bool BankExistByNameBranch(string name, string branch)
        {
            var parameters = new object[][]
            {
                new object[] { "@bank_name", DbType.String, name.ToLower().Trim()},
                new object[] { "@bank_branch", DbType.String, branch.ToLower().Trim()}
            };

            string query = $"SELECT id FROM {tableName} WHERE @bank_name = bank_name AND @bank_branch = bank_branch";
            string result = mySqlGenericCommands.ExecuteScalar(query, parameters);
            return !string.IsNullOrEmpty(result);
        }

        public int GetIdByNameBranch(string name, string branch)
        {
            var parameters = new object[][]
            {
                new object[] { "@bank_name", DbType.String, name},
                new object[] { "@bank_branch", DbType.String, branch}
            };

            string query = $"SELECT id FROM {tableName} WHERE bank_name = @bank_name AND bank_branch = @bank_branch";
            return Convert.ToInt32(mySqlGenericCommands.ExecuteScalar(query, parameters));
        }

        public DataTable GetRecords(int rowLimit, string searchKey)
        {
            var parameters = new object[][]
            {
                new object[] { "@row_limit", DbType.Int32, rowLimit},
                new object[] { "@search_key", DbType.String, $"%{searchKey}%"},
            };

            string query = $"SELECT * FROM {tableName} WHERE (bank_code LIKE @search_key OR bank_name LIKE @search_key OR bank_branch LIKE @search_key) LIMIT @row_limit";
            return mySqlGenericCommands.FillBySearch(query, new DataTable(), parameters);
        }
    }
}

