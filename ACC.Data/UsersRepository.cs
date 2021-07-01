using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;
using ACC.Domain.Interfaces;
using ACC.Domain.Models;

namespace ACC.Data
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IDbGenericCommands _dbGenericCommands;
        private readonly string tableName = "users";
        private readonly string viewTableName = "view_users";

        public UsersRepository(IDbGenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var record = new Dictionary<string, string>();

            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, Id},
                };

                string query = $"SELECT roles_id, first_name, mid_initial, last_name, username, password, is_deleted, created_at, updated_at, office, role_name, permission_name FROM {viewTableName} WHERE id = @id";

                using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;

                    record.Add("roles_id", reader.Rows[0]["roles_id"].ToString());
                    record.Add("first_name", reader.Rows[0]["first_name"].ToString());
                    record.Add("mid_initial", reader.Rows[0]["mid_initial"].ToString());
                    record.Add("last_name", reader.Rows[0]["last_name"].ToString());
                    record.Add("username", reader.Rows[0]["username"].ToString());
                    record.Add("password", reader.Rows[0]["password"].ToString());
                    record.Add("created_at", reader.Rows[0]["created_at"].ToString());
                    record.Add("updated_at", reader.Rows[0]["updated_at"].ToString());
                    record.Add("office", reader.Rows[0]["office"].ToString());
                    record.Add("role_name", reader.Rows[0]["role_name"].ToString());
                    record.Add("permission_name", reader.Rows[0]["permission_name"].ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }

            return record;
        }

        public DataTable GetRecords()
        {
            try
            {
                string query = $"SELECT a.id, a.first_name, a.mid_initial, a.last_name, a.username, b.role_name, a.created_at, a.updated_at FROM {tableName} a INNER JOIN roles b on a.roles_id  = b.id WHERE b.role_name <> 'System Administrator'";
                var dtUsers = new DataTable();
                return _dbGenericCommands.Fill(query, dtUsers);
            }
            catch (Exception)
            {
                throw;
            }
        }
      
        public DataTable GetRecordsBySearch(string searchText)
        {
            try
            {
                var srchtxt = searchText;
               
                string query = $"SELECT {tableName}.id, {tableName}.first_name, {tableName}.mid_initial, {tableName}.last_name, {tableName}.username, roles.role_name, {tableName}.created_at, {tableName}.updated_at FROM {tableName} inner join roles on {tableName}.roles_id  = roles.id WHERE last_name  LIKE'%" + srchtxt + "%' OR first_name  LIKE'%" + srchtxt + "%' OR mid_initial  LIKE'%" + srchtxt + "%' OR role_name  LIKE'%" + srchtxt + "%'";

                var dtUsers = new DataTable();
                return _dbGenericCommands.Fill(query, dtUsers);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Insert(UsersModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@roles_id", DbType.Byte  , entity.RoleId},
                    new object[] { "@first_name", DbType.String  , entity.FirstName},
                    new object[] { "@mid_initial", DbType.String, entity.MidInitial},
                    new object[] { "@last_name", DbType.String, entity.LastName},
                    new object[] { "@username", DbType.String, entity.UserName},
                    new object[] { "@password", DbType.String, entity.Password},

                };

                string query = $"INSERT INTO {tableName} ( roles_id, first_name, mid_initial, last_name, username, password) VALUES (@roles_id, @first_name, @mid_initial, @last_name, @username, sha2(@password, 224))";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(UsersModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int16, entity.Id},
                    new object[] { "@roles_id", DbType.Byte  , entity.RoleId},
                    new object[] { "@first_name", DbType.String  , entity.FirstName},
                    new object[] { "@mid_initial", DbType.String, entity.MidInitial},
                    new object[] { "@last_name", DbType.String, entity.LastName},
                    new object[] { "@username", DbType.String, entity.UserName},

                };

                string query = $"UPDATE {tableName} SET roles_id = @roles_id, first_name = @first_name, mid_initial = @mid_initial, last_name = @last_name, username = @username WHERE id = @id";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateWithPassword(UsersModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int16, entity.Id},
                    new object[] { "@roles_id", DbType.Byte  , entity.RoleId},
                    new object[] { "@first_name", DbType.String  , entity.FirstName},
                    new object[] { "@mid_initial", DbType.String, entity.MidInitial},
                    new object[] { "@last_name", DbType.String, entity.LastName},
                    new object[] { "@username", DbType.String, entity.UserName},
                    new object[] { "@password", DbType.String, entity.Password},

                };

                string query = $"UPDATE {tableName} SET roles_id = @roles_id, first_name = @first_name, mid_initial = @mid_initial, last_name = @last_name, username = @username, password = sha2(@password, 224) WHERE id = @id";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(List<UsersModel> entityList)
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

        public bool NameExist(string userName)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@username", DbType.String, userName },
                };

                string query = $"SELECT username FROM {tableName} WHERE username = @username";
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

        public bool NameExist(string userName, int userId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int16, userId },
                    new object[] { "@username", DbType.String, userName },
                };

                string query = $"SELECT username FROM {tableName} WHERE id <> @id AND username = @username";
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

        public byte ValidateLogin(string username, string password)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@username", DbType.String, username },
                    new object[] { "@password", DbType.String, password },
                };

                string query = $"SELECT id FROM {tableName} WHERE username = @username AND password = sha2(@password, 224)";
                string userId = _dbGenericCommands.ExecuteScalar(query, parameters);

                // if query is not null, means found some record, so true
                if (!string.IsNullOrEmpty(userId)) return Convert.ToByte(userId);
            }
            catch (Exception)
            {
                throw;
            };

            return 0;
        }

        public bool HasPermission(byte userId, string permissionName)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Byte, userId },
                    new object[] { "@permission_name", DbType.String, permissionName},
                };

                string query = $"SELECT id FROM {viewTableName} WHERE id = @id AND permission_name = @permission_name";
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
    }
}
