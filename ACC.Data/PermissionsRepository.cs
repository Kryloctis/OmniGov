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
            throw new NotImplementedException();
        }

        public bool Update(PermissionsModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<PermissionsModel> entityList)
        {
            throw new NotImplementedException();
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

        public DataTable GetRecordsByOffice(string officeName)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@officeName", DbType.String, $"%{officeName}%" },
                };

                string query = $"SELECT * FROM {tableName} WHERE permission_office = 'All' OR permission_office LIKE @officeName";

                var dtGeneralLedgers = new DataTable();
                return _dbGenericCommands.FillBySearch(query, dtGeneralLedgers, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

