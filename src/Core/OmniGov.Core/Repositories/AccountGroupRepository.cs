using OmniGov.Core.Entities;
using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Core.Interfaces.Services;
using System.Data;
using System.Transactions;

namespace OmniGov.Core.Repositories
{
    public class AccountGroupRepository : IAccountGroupRepository
    {
        private readonly IGenericCommands _dbGenericCommands;
        private readonly string tableName = "account_group";

        public AccountGroupRepository(IGenericCommands dbGenericCommands)
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

            string query = $"SELECT account_group_code, account_group_name, created_at, updated_at FROM {tableName} WHERE id = @id";

            using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return record;

                record.Add("account_group_code", reader.Rows[0][0].ToString());
                record.Add("account_group_name", reader.Rows[0][1].ToString());
                record.Add("created_at", reader.Rows[0][2].ToString());
                record.Add("updated_at", reader.Rows[0][3].ToString());
            }

            return record;
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {tableName}";

            var dtJournals = new DataTable();
            return _dbGenericCommands.Fill(query, dtJournals);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new NotImplementedException();
        }

        public bool Insert(AccountGroupModel entity)
        {
            var parameters = new object[][]
            {
                    new object[] { "@account_group_code", DbType.String, entity.AccountGroupCode},
                    new object[] { "@account_group_name", DbType.String, entity.AccountGroupName},
            };

            string query = $"INSERT INTO {tableName} (account_group_code, account_group_name) VALUES (@account_group_code, @account_group_name)";
            return _dbGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(AccountGroupModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Byte, entity.Id},
                new object[] { "@account_group_code", DbType.String, entity.AccountGroupCode},
                new object[] { "@account_group_name", DbType.String, entity.AccountGroupName},
            };

            string query = $"UPDATE {tableName} SET account_group_code = @account_group_code, account_group_name = @account_group_name WHERE id = @id";
            return _dbGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Delete(List<AccountGroupModel> entityList)
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

        public bool IdExist(int id)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Byte, id },
            };

            string query = $"SELECT id FROM {tableName} WHERE id = @id";

            return !string.IsNullOrEmpty(_dbGenericCommands.ExecuteScalar(query, parameters));
        }

        public bool CodeExist(string code)
        {
            var parameters = new object[][]
            {
                new object[] { "@account_group_code", DbType.String, code },
            };

            string query = $"SELECT account_group_code FROM {tableName} WHERE account_group_code = @account_group_code";

            return !string.IsNullOrEmpty(_dbGenericCommands.ExecuteScalar(query, parameters));
        }

        public bool CodeExist(string code, int id)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.String, id },
                new object[] { "@account_group_code", DbType.String, code },
            };

            string query = $"SELECT account_group_code FROM {tableName} WHERE id <> @id AND account_group_code = @account_group_code";

            return !string.IsNullOrEmpty(_dbGenericCommands.ExecuteScalar(query, parameters));
        }

        public bool NameExist(string name)
        {
            var parameters = new object[][]
            {
                new object[] { "@account_group_name", DbType.String, name },
            };

            string query = $"SELECT account_group_name FROM {tableName} WHERE account_group_name = @account_group_name";

            return !string.IsNullOrEmpty(_dbGenericCommands.ExecuteScalar(query, parameters));
        }

        public bool NameExist(string name, int id)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.String, id },
                new object[] { "@account_group_name", DbType.String, name },
            };

            string query = $"SELECT account_group_name FROM {tableName} WHERE id <> @id AND account_group_name = @account_group_name";

            return !string.IsNullOrEmpty(_dbGenericCommands.ExecuteScalar(query, parameters));
        }
    }
}