using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;
using ACC.Domain.Interfaces;
using ACC.Domain.Models;

namespace ACC.Data
{
    public class RolesRepository : IRolesRepository
    {
        private readonly IDbGenericCommands _dbGenericCommands;
        private readonly IRoleHasPermissionsRepository roleHasPermissionsRepository;
        private readonly string tableName = "roles";
        

        public RolesRepository(
            IDbGenericCommands dbGenericCommands,
            IRoleHasPermissionsRepository _roleHasPermissionsRepository
            )
        {
            _dbGenericCommands = dbGenericCommands;
            roleHasPermissionsRepository = _roleHasPermissionsRepository;
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

                string query = $"SELECT role_name, created_at, updated_at FROM {tableName} WHERE id = @id";

                using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;

                    record.Add("role_name", reader.Rows[0][0].ToString());
                    record.Add("created_at", reader.Rows[0][1].ToString());
                    record.Add("updated_at", reader.Rows[0][2].ToString());
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

                var dtRoles = new DataTable();
                return _dbGenericCommands.Fill(query, dtRoles);
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

                string query = $"SELECT * FROM {tableName} WHERE role_name  LIKE'%" + srchtxt + "%'";

                var dtUsers = new DataTable();
                return _dbGenericCommands.Fill(query, dtUsers);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public byte GetLastInsertedID()
        {
            try
            {
                string query = $"SELECT MAX(id) FROM {tableName}";
                return byte.Parse(_dbGenericCommands.ExecuteScalar(query));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Insert(RolesModel entity)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    var parameters = new object[][]
                    {
                        new object[] { "@office", DbType.String, entity.Office},
                        new object[] { "@role_name", DbType.String, entity.RoleName},
                    };

                    string query = $"INSERT INTO {tableName} (office, role_name) VALUES (@office, @role_name)";
                    _ = _dbGenericCommands.ExecuteNonQuery(query, parameters);

                    var roleHasPermissionModel = new RoleHasPermissionsModel();
                    foreach (var permissionsModel in entity.PermissionsModels)
                    {
                        roleHasPermissionModel.RolesId = GetLastInsertedID();
                        roleHasPermissionModel.PermissionsId = permissionsModel.Id;
                        roleHasPermissionsRepository.Insert(roleHasPermissionModel);
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

        public bool Update(RolesModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int16, entity.Id},
                    new object[] { "@office", DbType.String, entity.Office},
                    new object[] { "@role_name", DbType.String, entity.RoleName},
                };

                string query = $"UPDATE {tableName} SET office = @office, role_name = @role_name WHERE id = @id";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(List<RolesModel> entityList)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    foreach (var entity in entityList)
                    {
                        var parameters = new object[][]
                        {
                            new object[] { "@id", DbType.Int32, entity.Id},
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

        public bool NameExist(string roleName)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@role_name", DbType.String, roleName },
                };

                string query = $"SELECT role_name FROM {tableName} WHERE role_name = @role_name";
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

        public bool NameExist(string roleName, int roleId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int16, roleId },
                    new object[] { "@role_name", DbType.String, roleName },
                };

                string query = $"SELECT role_name FROM {tableName} WHERE id <> @id AND role_name = @role_name";
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
