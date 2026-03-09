using OmniGov.Core.Entities;
using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Core.Interfaces.Services;
using System.Data;
using System.Transactions;

namespace OmniGov.Core.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly string tableName = "users";
        private readonly string viewTableName = "view_users";
        private IGenericCommands _genericCommands;

        public UsersRepository(IGenericCommands genericCommands)
        {
            _genericCommands = genericCommands;
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, Id},
            };

            string query = $"SELECT * FROM {tableName} WHERE id = @id";

            DataTable dataTable = _genericCommands.ExecuteReader(query, parameters);

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
            throw new NotImplementedException();
        }

        public DataTable GetLinksCollectingOfficers(string searchText)
        {
            var parameters = new object[][]
            {
                new object[] { "@text_search", DbType.String, $"%{searchText}%"}
            };

            string query = $"SELECT id, roles_id, prefix, first_name, mid_initial, last_name, suffix, CONCAT(first_name, ' ', mid_initial , ' ', last_name) AS user_full_name, username, password, is_deleted, created_at, updated_at, role_name, permission_name, permission_office FROM {viewTableName} WHERE role_name LIKE '%collect%' AND last_name LIKE @text_search AND first_name LIKE @text_search AND id NOT IN (SELECT users_id FROM job_orders WHERE is_deleted = 0) AND id NOT IN (SELECT users_id FROM collecting_officers) GROUP BY id";

            return _genericCommands.FillBySearch(query, new DataTable(), parameters);
        }

        public DataTable GetLinksJOCollectingOfficers()
        {
            string query = $"SELECT id, roles_id, prefix, first_name, mid_initial, last_name, suffix, CONCAT(first_name, ' ', mid_initial, ' ', last_name) AS user_full_name, username, password, is_deleted, created_at, updated_at, role_name, permission_name, FROM view_users WHERE role_name LIKE '%collect%' AND id NOT IN(SELECT users_id FROM collecting_officers) AND id NOT IN(SELECT users_id FROM job_orders WHERE is_deleted = 0) GROUP BY id";

            return _genericCommands.Fill(query, new DataTable());
        }

        public DataTable GetLinksDisbursingOfficers()
        {
            string query = $@"SELECT
                            id,
                            roles_id,
                            prefix,
                            first_name,
                            mid_initial,
                            last_name,
                            suffix,
                            CONCAT(first_name, ' ', mid_initial , ' ', last_name) AS user_full_name,
                            username,
                            password,
                            is_deleted,
                            created_at,
                            updated_at,
                            role_name,
                            permission_name,
                            FROM {viewTableName} WHERE role_name LIKE '%disburs%' GROUP BY id";

            return _genericCommands.Fill(query, new DataTable());
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameters = new object[][]
            {
                new object[] { "@search_text", DbType.String, $"%{searchText}%"},
            };

            string query = $"SELECT a.id, a.prefix, a.first_name, a.mid_initial, a.last_name, a.suffix, a.username, b.role_name, a.created_at, a.updated_at FROM {tableName} a INNER JOIN roles b on a.roles_id  = b.id WHERE (a.last_name LIKE @search_text OR a.first_name LIKE @search_text OR a.mid_initial LIKE @search_text OR b.role_name LIKE @search_text)";

            return _genericCommands.FillBySearch(query, new DataTable(), parameters);
        }

        public bool Insert(UsersModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@roles_id", DbType.Byte, entity.RoleId},
                new object[] { "@prefix", DbType.String, entity.Prefix},
                new object[] { "@first_name", DbType.String  , entity.FirstName},
                new object[] { "@mid_initial", DbType.String, entity.MidInitial},
                new object[] { "@last_name", DbType.String, entity.LastName},
                new object[] { "@suffix", DbType.String, entity.Suffix},
                new object[] { "@username", DbType.String, entity.UserName},
                new object[] { "@password", DbType.String, entity.Password},
            };

            string query = $"INSERT INTO {tableName} ( roles_id, prefix, first_name, mid_initial, last_name, suffix, username, password) VALUES (@roles_id, @prefix, @first_name, @mid_initial, @last_name, @suffix, @username, sha2(@password, 224))";

            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(UsersModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int16, entity.Id},
                new object[] { "@roles_id", DbType.Byte, entity.RoleId},
                new object[] { "@prefix", DbType.String, entity.Prefix},
                new object[] { "@first_name", DbType.String, entity.FirstName},
                new object[] { "@mid_initial", DbType.String, entity.MidInitial},
                new object[] { "@last_name", DbType.String, entity.LastName},
                new object[] { "@suffix", DbType.String, entity.Suffix},
                new object[] { "@username", DbType.String, entity.UserName},
            };

            string query = $"UPDATE {tableName} SET roles_id = @roles_id, prefix = @prefix, first_name = @first_name, mid_initial = @mid_initial, last_name = @last_name, suffix = @suffix, username = @username WHERE id = @id";

            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool UpdateWithPassword(UsersModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int16, entity.Id},
                new object[] { "@roles_id", DbType.Byte, entity.RoleId},
                new object[] { "@prefix", DbType.String, entity.Prefix},
                new object[] { "@first_name", DbType.String  , entity.FirstName},
                new object[] { "@mid_initial", DbType.String, entity.MidInitial},
                new object[] { "@last_name", DbType.String, entity.LastName},
                new object[] { "@suffix", DbType.String, entity.Suffix},
                new object[] { "@username", DbType.String, entity.UserName},
                new object[] { "@password", DbType.String, entity.Password},
            };

            string query = $"UPDATE {tableName} SET roles_id = @roles_id, prefix = @prefix, first_name = @first_name, mid_initial = @mid_initial, last_name = @last_name, suffix = @suffix, username = @username, password = sha2(@password, 224) WHERE id = @id";

            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Delete(List<UsersModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var entity in entityList)
                {
                    var parameters = new object[][] { new object[] { "@id", DbType.Int16, entity.Id }, };
                    string query = $"DELETE FROM {tableName} WHERE id = @id";
                    _ = _genericCommands.ExecuteNonQuery(query, parameters);
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

            return !string.IsNullOrEmpty(_genericCommands.ExecuteScalar(query, parameters));
        }

        public bool NameExist(string userName)
        {
            var parameters = new object[][]
            {
                new object[] { "@username", DbType.String, userName }
            };

            string query = $"SELECT username FROM {tableName} WHERE username = @username";

            return !string.IsNullOrEmpty(_genericCommands.ExecuteScalar(query, parameters));
        }

        public bool NameExist(string userName, int userId)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int16, userId },
                new object[] { "@username", DbType.String, userName },
            };

            string query = $"SELECT username FROM {tableName} WHERE id <> @id AND username = @username";

            return !string.IsNullOrEmpty(_genericCommands.ExecuteScalar(query, parameters));
        }

        public Dictionary<string, string> GetUserRecordByAcc(string username, string password)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@username", DbType.String, username },
                new object[] { "@password", DbType.String, password },
            };

            string query = $"SELECT * FROM {viewTableName} WHERE is_deleted = 0 AND username = @username AND password = sha2(@password, 224)";

            DataTable dataTable = _genericCommands.ExecuteReader(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                foreach (DataColumn column in dataTable.Columns)
                    recordDictionary[column.ColumnName] = row[column].ToString();

                return recordDictionary;
            }
            return recordDictionary;
        }

        public DataTable GetViewRecordsBySearch(int rowLimit, string searchTxt)
        {
            var parameters = new object[][]
            {
                new object[] { "@searchTxt", DbType.String, $"%{searchTxt}%"},
                new object[] { "@row_limit", DbType.Int32, rowLimit}
            };

            string query = $"SELECT * FROM {viewTableName} WHERE (last_name LIKE @searchTxt OR first_name LIKE @searchTxt OR mid_initial LIKE @searchTxt OR username LIKE @searchTxt OR role_name LIKE @searchTxt) AND is_super = 0 GROUP BY id LIMIT @row_limit";

            return _genericCommands.FillBySearch(query, new DataTable(), parameters);
        }

        public bool AccIsValidated(string username, string password)
        {
            var parameters = new object[][]
            {
                new object[] { "@username", DbType.String, username },
                new object[] { "@password", DbType.String, password },
            };

            string query = $"SELECT id FROM {tableName} WHERE is_deleted = 0 AND username = @username AND password = sha2(@password, 224)";
            return !string.IsNullOrEmpty(_genericCommands.ExecuteScalar(query, parameters));
        }

        public Dictionary<string, dynamic> GetViewRecordById(int Id)
        {
            var recordDictionary = new Dictionary<string, dynamic>();

            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, Id},
            };

            string query = $"SELECT * FROM {viewTableName} WHERE id = @id";

            DataTable dataTable = _genericCommands.ExecuteReader(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                foreach (DataColumn column in dataTable.Columns)
                    recordDictionary[column.ColumnName] = row[column].ToString();

                return recordDictionary;
            }
            return recordDictionary;
        }

        public DataTable GetViewRecords()
        {
            string query = $"SELECT * FROM {viewTableName}";
            return _genericCommands.Fill(query, new DataTable());
        }
    }
}