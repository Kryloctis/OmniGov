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

                string query = $"SELECT roles_id, first_name, mid_initial, last_name, username, password, is_deleted, created_at, updated_at FROM {tableName} WHERE id = @id";

                using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;

                    record.Add("roles_id", reader.Rows[0][0].ToString());
                    record.Add("first_name", reader.Rows[0][1].ToString());
                    record.Add("mid_initial", reader.Rows[0][2].ToString());
                    record.Add("last_name", reader.Rows[0][3].ToString());
                    record.Add("username", reader.Rows[0][4].ToString());
                    record.Add("password", reader.Rows[0][5].ToString());
                    record.Add("created_at", reader.Rows[0][6].ToString());
                    record.Add("updated_at", reader.Rows[0][7].ToString());
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
                string query = $"SELECT {tableName}.id, {tableName}.first_name, {tableName}.mid_initial, {tableName}.last_name, {tableName}.username, roles.role_name, {tableName}.created_at, {tableName}.updated_at FROM {tableName} inner join roles on {tableName}.roles_id  = roles.id";
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
            throw new NotImplementedException();
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

                string query = $"INSERT INTO {tableName} ( roles_id, first_name, mid_initial, last_name, username, password) VALUES (@roles_id, @first_name, @mid_initial, @last_name, @username, @password)";
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
                    new object[] { "@password", DbType.String, entity.Password},

                };

                string query = $"UPDATE {tableName} SET roles_id = @roles_id, first_name = @first_name, mid_initial = @mid_initial, last_name = @last_name, username = @username, password = @password WHERE id = @id";
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
    }
}
