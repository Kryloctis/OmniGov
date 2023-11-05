using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    public class UsersRepository : IUsersRepository
    {
        private readonly string tableName = "users";
        private readonly string tableCollectionsOfficers = "collecting_officers";
        private readonly string tableName3 = "disbursing_officers";
        private readonly string tableName4 = "roles";
        private readonly string viewTableName = "view_users";
        private AccGenericCommands mySqlGenericCommandsLFS;

        public UsersRepository(AccGenericCommands mySqlGenericCommandsLFS)
        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var record = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                    new object[] { "@id", DbType.Int32, Id},
            };

            string query = $"SELECT roles_id, prefix, first_name, mid_initial, last_name, suffix, username, password, is_deleted, created_at, updated_at, office, role_name, permission_name FROM {viewTableName} WHERE id = @id";

            using (var reader = mySqlGenericCommandsLFS.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return record;

                record.Add("roles_id", reader.Rows[0]["roles_id"].ToString());
                record.Add("prefix", reader.Rows[0]["prefix"].ToString());
                record.Add("first_name", reader.Rows[0]["first_name"].ToString());
                record.Add("mid_initial", reader.Rows[0]["mid_initial"].ToString());
                record.Add("last_name", reader.Rows[0]["last_name"].ToString());
                record.Add("suffix", reader.Rows[0]["suffix"].ToString());
                record.Add("username", reader.Rows[0]["username"].ToString());
                record.Add("password", reader.Rows[0]["password"].ToString());
                record.Add("created_at", reader.Rows[0]["created_at"].ToString());
                record.Add("updated_at", reader.Rows[0]["updated_at"].ToString());
                record.Add("office", reader.Rows[0]["office"].ToString());
                record.Add("role_name", reader.Rows[0]["role_name"].ToString());
                record.Add("permission_name", reader.Rows[0]["permission_name"].ToString());
            }

            return record;
        }

        public Dictionary<string, string> GetUserByID(int Id)
        {
            var record = new Dictionary<string, string>();

            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, Id},
                };

                string query = $"SELECT * FROM {tableName} WHERE id = @id";

                using (var reader = mySqlGenericCommandsLFS.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;

                    record.Add("roles_id", reader.Rows[0]["roles_id"].ToString());
                    record.Add("prefix", reader.Rows[0]["prefix"].ToString());
                    record.Add("first_name", reader.Rows[0]["first_name"].ToString());
                    record.Add("mid_initial", reader.Rows[0]["mid_initial"].ToString());
                    record.Add("last_name", reader.Rows[0]["last_name"].ToString());
                    record.Add("suffix", reader.Rows[0]["suffix"].ToString());
                    record.Add("username", reader.Rows[0]["username"].ToString());
                    record.Add("password", reader.Rows[0]["password"].ToString());
                    record.Add("created_at", reader.Rows[0]["created_at"].ToString());
                    record.Add("updated_at", reader.Rows[0]["updated_at"].ToString());
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
                string query = $"SELECT a.id, a.prefix, a.first_name, a.mid_initial, a.last_name, a.suffix, a.username, b.role_name, a.created_at, a.updated_at FROM {tableName} a INNER JOIN roles b on a.roles_id = b.id WHERE b.role_name <> 'System Administrator'";
                var dtUsers = new DataTable();
                return mySqlGenericCommandsLFS.Fill(query, dtUsers);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string GetUserRole(int id)
        {
            string data = string.Empty;
            try
            {
                string query = $"SELECT {tableName4}.role_name FROM {tableName} LEFT JOIN {tableName4} ON {tableName}.roles_id={tableName4}.id WHERE {tableName}.id='{id}'";
                DataTable dt = mySqlGenericCommandsLFS.Fill(query, new DataTable());
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = dt.Rows[i]["role_name"].ToString();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return data;
        }

        public string GetCollectorByUserId(int id)
        {
            string data = string.Empty;
            try
            {
                string query = $"SELECT id FROM {tableCollectionsOfficers} WHERE users_id='{id}'";
                DataTable dt = mySqlGenericCommandsLFS.Fill(query, new DataTable());
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = dt.Rows[i]["id"].ToString();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return data;
        }

        public string GetDisbursingByUserId(int id)
        {
            string data = string.Empty;
            try
            {
                string query = $"SELECT id FROM {tableName3} WHERE users_id='{id}'";
                DataTable dt = mySqlGenericCommandsLFS.Fill(query, new DataTable());
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = dt.Rows[i]["id"].ToString();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return data;
        }

        public DataTable GetLinksCollectingOfficers(string searchText)
        {
            var parameters = new object[][]
            {
                new object[] { "@text_search", DbType.String, $"%{searchText}%"}
            };

            string query = $"SELECT id, roles_id, prefix, first_name, mid_initial, last_name, suffix, CONCAT(first_name, ' ', mid_initial , ' ', last_name) AS user_full_name, username, password, is_deleted, created_at, updated_at, office, role_name, permission_name, permission_office FROM {viewTableName} WHERE role_name LIKE '%collect%' AND last_name LIKE @text_search AND first_name LIKE @text_search AND id NOT IN (SELECT users_id FROM job_orders WHERE is_deleted = 0) AND id NOT IN (SELECT users_id FROM collecting_officers) GROUP BY id";

            var dtUsers = new DataTable();
            return mySqlGenericCommandsLFS.FillBySearch(query, dtUsers, parameters);
        }

        public DataTable GetLinksJOCollectingOfficers()
        {
            string query = $"SELECT " +
                            $"id, " +
                            $"roles_id, " +
                            $"prefix, " +
                            $"first_name, " +
                            $"mid_initial, " +
                            $"last_name, " +
                            $"suffix, " +
                            $"CONCAT(first_name, ' ', mid_initial , ' ', last_name) AS user_full_name, " +
                            $"username, " +
                            $"password, " +
                            $"is_deleted, " +
                            $"created_at, " +
                            $"updated_at, " +
                            $"office, " +
                            $"role_name, " +
                            $"permission_name, " +
                            $"permission_office " +
                            $"FROM view_users " +
                            $"WHERE role_name LIKE '%collect%' " +
                            $"AND id NOT IN (SELECT users_id FROM collecting_officers) " +
                            $"AND id NOT IN (SELECT users_id FROM job_orders WHERE is_deleted = 0) " +
                            $"GROUP BY id";

            var dtUsers = new DataTable();
            return mySqlGenericCommandsLFS.Fill(query, dtUsers);
        }

        public DataTable GetLinksDisbursingOfficers()
        {
            string query = $"SELECT " +
                $"id, " +
                $"roles_id, " +
                $"prefix, " +
                $"first_name, " +
                $"mid_initial, " +
                $"last_name, " +
                $"suffix, " +
                $"CONCAT(first_name, ' ', mid_initial , ' ', last_name) AS user_full_name, " +
                $"username, " +
                $"password, " +
                $"is_deleted, " +
                $"created_at, " +
                $"updated_at, " +
                $"office, " +
                $"role_name, " +
                $"permission_name, " +
                $"permission_office " +
                $"FROM {viewTableName} WHERE role_name LIKE '%disburs%' GROUP BY id";

            var dtUsers = new DataTable();
            return mySqlGenericCommandsLFS.Fill(query, dtUsers);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameters = new object[][]
            {
                new object[] { "@search_text", DbType.String, $"%{searchText}%"},
            };

            var srchtxt = searchText;

            string query = $"SELECT a.id, a.prefix, a.first_name, a.mid_initial, a.last_name, a.suffix, a.username, b.role_name, a.created_at, a.updated_at FROM {tableName} a INNER JOIN roles b on a.roles_id  = b.id WHERE (a.last_name LIKE @search_text OR a.first_name LIKE @search_text OR a.mid_initial LIKE @search_text OR b.role_name LIKE @search_text) AND b.role_name <> 'System Administrator'";

            var dtUsers = new DataTable();
            return mySqlGenericCommandsLFS.FillBySearch(query, dtUsers, parameters);
        }

        public bool Insert(UsersModel entity)
        {
            try
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
                return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
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
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
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
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
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
                        _ = mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
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

                return int.Parse(mySqlGenericCommandsLFS.ExecuteScalar(query));
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
                string queryResult = mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);

                // if query is not null, means found some record, so true
                if (!string.IsNullOrEmpty(queryResult)) return true;
            }
            catch (Exception)
            {
                throw;
            };

            return false;
        }

        public bool LinkedJobOrder(int id)
        {
            var parameters = new object[][]
            {
               new object[] { "@users_id", DbType.Int32, id },
            };

            string query = $"SELECT id FROM job_orders WHERE users_id = @users_id AND is_deleted = 0";
            string queryResult = mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);

            // if query is not null, means found some record, so true
            if (!string.IsNullOrEmpty(queryResult)) return true;

            return false;
        }

        public bool LinkedCollector(int id)
        {
            var parameters = new object[][]
            {
                new object[] { "@users_id", DbType.Int32, id },
            };

            string query = $"SELECT id FROM {tableCollectionsOfficers} WHERE users_id = @users_id";
            string queryResult = mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);

            // if query is not null, means found some record, so true
            if (!string.IsNullOrEmpty(queryResult)) return true;

            return false;
        }

        public bool LinkedDisburser(int id)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@users_id", DbType.Int32, id },
                };

                string query = $"SELECT id FROM {tableName3} WHERE users_id = @users_id";
                string queryResult = mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);

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
            var parameters = new object[][]
            {
                new object[] { "@username", DbType.String, userName }
            };

            string query = $"SELECT username FROM {tableName} WHERE username = @username";
            string queryResult = mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);

            // if query is not null, means found some record, so true
            if (!string.IsNullOrEmpty(queryResult)) return true;
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
                string queryResult = mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);

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

                string query = $"SELECT id FROM {tableName} WHERE BINARY username = @username AND password = sha2(@password, 224)";
                string userId = mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);

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
                string queryResult = mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);

                // if query is not null, means found some record, so true
                if (!string.IsNullOrEmpty(queryResult)) return true;
            }
            catch (Exception)
            {
                throw;
            };

            return false;
        }

        public DataTable GetViewRecords()
        {
            string query = $"SELECT " +
                $"id, " +
                $"roles_id, " +
                $"prefix, " +
                $"first_name, " +
                $"mid_initial, " +
                $"last_name, " +
                $"suffix, " +
                $"username, " +
                $"password, " +
                $"is_deleted, " +
                $"created_at, " +
                $"updated_at, " +
                $"office, " +
                $"role_name, " +
                $"permission_name, " +
                $"permission_office " +
                $"FROM {viewTableName} WHERE office <> 'SysAdmin' GROUP BY id";

            var dataTable = new DataTable();

            return mySqlGenericCommandsLFS.Fill(query, dataTable);
        }

        public string GetCollectorNameByUserId(int userId)
        {
            var parameter = new object[][] {
                new object[]{"@user_id", DbType.Int32, userId}
            };

            string query = $"SELECT CONCAT(first_name, ' ', mid_initial, ' ' ,last_name) AS full_name FROM {tableCollectionsOfficers} WHERE users_id   = @user_id";

            return string.IsNullOrEmpty(mySqlGenericCommandsLFS.ExecuteScalar(query, parameter)) ? string.Empty : mySqlGenericCommandsLFS.ExecuteScalar(query, parameter);
        }

        public DataTable GetViewRecordsByOffice(string office)
        {
            var parameters = new dynamic[][]
            {
                new dynamic[] { "@office", DbType.String, office}
            };

            string Filter()
            {
                if (office == "SysAdmin")
                    return string.Empty;
                else
                    return "AND office = @office";
            }

            string query = $"SELECT id, roles_id, prefix, first_name, mid_initial, last_name, suffix, username, password, is_deleted, created_at, updated_at, office, role_name, permission_name, permission_office FROM {viewTableName} WHERE office <> 'SysAdmin' {Filter()} GROUP BY id";

            var dataTable = new DataTable();

            return mySqlGenericCommandsLFS.FillBySearch(query, dataTable, parameters);
        }

        public DataTable GetViewRecordsBySearch(string office, string searchTxt)
        {
            var parameters = new dynamic[][]
            {
                 new dynamic[] { "@office", DbType.String, office},
                 new dynamic[] { "@searchTxt", DbType.String, $"%{searchTxt}%"}
            };

            string Filter()
            {
                if (office == "SysAdmin")
                    return string.Empty;
                else
                    return "AND office = @office";
            }

            string query = $"SELECT id, roles_id, prefix, first_name, mid_initial, last_name, suffix, username, password, is_deleted, created_at, updated_at, office, role_name, permission_name, permission_office FROM {viewTableName} WHERE office <> 'SysAdmin' {Filter()} AND (last_name LIKE @searchTxt OR first_name LIKE @searchTxt OR mid_initial LIKE @searchTxt OR username LIKE @searchTxt OR office LIKE @searchTxt OR role_name LIKE @searchTxt) GROUP BY id";

            var dataTable = new DataTable();

            return mySqlGenericCommandsLFS.FillBySearch(query, dataTable, parameters);
        }

        public Dictionary<string, dynamic> GetViewRecordById(int Id)
        {
            var record = new Dictionary<string, dynamic>();

            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, Id},
            };

            string query = $"SELECT * FROM {viewTableName} WHERE id = @id";

            using (var reader = mySqlGenericCommandsLFS.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return record;

                record.Add("roles_id", reader.Rows[0]["roles_id"]);
                record.Add("prefix", reader.Rows[0]["prefix"].ToString());
                record.Add("first_name", reader.Rows[0]["first_name"]);
                record.Add("mid_initial", reader.Rows[0]["mid_initial"]);
                record.Add("last_name", reader.Rows[0]["last_name"]);
                record.Add("suffix", reader.Rows[0]["suffix"].ToString());
                record.Add("username", reader.Rows[0]["username"]);
                record.Add("password", reader.Rows[0]["password"]);
                record.Add("created_at", reader.Rows[0]["created_at"]);
                record.Add("updated_at", reader.Rows[0]["updated_at"]);
                record.Add("office", reader.Rows[0]["office"]);
                record.Add("role_name", reader.Rows[0]["role_name"]);
                record.Add("permission_name", reader.Rows[0]["role_name"]);
                record.Add("permission_office", reader.Rows[0]["permission_office"]);
            }
            return record;
        }
    }
}