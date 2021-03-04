using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;
using ACC.Domain.Interfaces;
using ACC.Domain.Models;

namespace ACC.Data
{
    public class PermissionsRepository : IPermissionsRepository
    {
        private readonly IDbGenericCommands _dbGenericCommands;
        private readonly string tableName = "permissions";


        public PermissionsRepository(IDbGenericCommands dbGenericCommands)
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

                string query = $"SELECT permission_name FROM {tableName} WHERE id = @id";

                using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;

                    record.Add("permission_name", reader.Rows[0][0].ToString());

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
                string query = $"SELECT * FROM {tableName}";

                var dtPermissions = new DataTable();
                return _dbGenericCommands.Fill(query, dtPermissions);
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

                string query = $"SELECT * FROM {tableName} WHERE permission_name  LIKE'%" + srchtxt + "%'";

                var dtUsers = new DataTable();
                return _dbGenericCommands.Fill(query, dtUsers);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Insert(PermissionsModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@permission_name", DbType.String, entity.PermissionName},
                    new object[] { "@permission_id", DbType.Byte, entity.Id},
                    new object[] { "@role_id", DbType.Byte, entity.currentRole},

                };

                string query = $"INSERT INTO role_has_permissions (roles_id, permissions_id) VALUES (@role_id, @permission_id)";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(PermissionsModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int16, entity.Id},
                    new object[] { "@permission_name", DbType.String, entity.PermissionName},

                };

                string query = $"UPDATE {tableName} SET permission_name = @permission_name WHERE id = @id";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(List<PermissionsModel> entityList)
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
        public bool PermissionExists(int id, int roleid)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, id },
                    new object[] { "@roleid", DbType.Int32, roleid },
                };

                string query = $"SELECT * FROM role_has_permissions WHERE roles_id = @roleid and permissions_id = @id";
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

        public bool NameExist(string permissionName)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@permission_name", DbType.String, permissionName },
                };

                string query = $"SELECT permission_name FROM {tableName} WHERE permission_name = @permission_name";
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

        public bool NameExist(string permissionName, int permissionId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int16, permissionId },
                    new object[] { "@permission_name", DbType.String, permissionName },
                };

                string query = $"SELECT permission_name FROM {tableName} WHERE id <> @id AND permission_name = @permission_name";
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

        public bool idExist(int id)
        {
            throw new NotImplementedException();
        }
    }
}

