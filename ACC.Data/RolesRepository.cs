using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    public class RolesRepository : IRolesRepository
    {
        private readonly IRoleHasPermissionsRepository roleHasPermissionsRepository;
        private readonly string tableName = "roles";
        private AccGenericCommands mySqlGenericCommandsLFS;

        public RolesRepository(AccGenericCommands mySqlGenericCommandsLFS, IRoleHasPermissionsRepository roleHasPermissionsRepository)
        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
            this.roleHasPermissionsRepository = roleHasPermissionsRepository;
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var record = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                    new object[] { "@id", DbType.Int32, Id},
            };

            string query = $"SELECT office, role_name, created_at, updated_at FROM {tableName} WHERE id = @id";

            using (var reader = mySqlGenericCommandsLFS.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return record;

                record.Add("office", reader.Rows[0]["office"].ToString());
                record.Add("role_name", reader.Rows[0]["role_name"].ToString());
                record.Add("created_at", reader.Rows[0]["created_at"].ToString());
                record.Add("updated_at", reader.Rows[0]["updated_at"].ToString());
            }

            return record;
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {tableName} WHERE role_name <> 'System Administrator'";
            return mySqlGenericCommandsLFS.Fill(query, new DataTable());
        }

        public DataTable GetRecordsByOffice(string office)
        {
            var parameters = new object[][]
            {
                new object[] { "@office", DbType.String, $"%{office}%"}
            };

            string Filter()
            {
                if (office == "SysAdmin")
                    return string.Empty;
                else
                    return "AND office LIKE @office";
            }

            string query = $"SELECT * FROM {tableName} WHERE office <> 'SysAdmin' {Filter()}";
            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameters = new object[][]
            {
                new object[] { "@search_text", DbType.String, $"%{searchText}%"},
            };

            var srchtxt = searchText;

            string query = $"SELECT * FROM {tableName} WHERE role_name <> 'System Administrator' AND role_name  LIKE @search_text";

            var dtUsers = new DataTable();
            return mySqlGenericCommandsLFS.FillBySearch(query, dtUsers, parameters);
        }

        public byte GetLastInsertedID()
        {
            string query = $"SELECT MAX(id) FROM {tableName}";
            return byte.Parse(mySqlGenericCommandsLFS.ExecuteScalar(query));
        }

        public bool Insert(RolesModel entity)
        {
            using (var scope = new TransactionScope())
            {
                var parameters = new object[][]
                {
                    new object[] { "@office", DbType.String, entity.Office},
                    new object[] { "@role_name", DbType.String, entity.RoleName},
                };

                string query = $"INSERT INTO {tableName} (office, role_name) VALUES (@office, @role_name)";
                _ = mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);

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

        public bool Update(RolesModel entity)
        {
            using (var scope = new TransactionScope())
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Byte, entity.Id},
                    new object[] { "@office", DbType.String, entity.Office},
                    new object[] { "@role_name", DbType.String, entity.RoleName},
                };

                string query = $"UPDATE {tableName} SET office = @office, role_name = @role_name WHERE id = @id";
                _ = mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
                roleHasPermissionsRepository.DeleteByRoleId(entity.Id);
                var roleHasPermissionModel = new RoleHasPermissionsModel();
                foreach (var permissionsModel in entity.PermissionsModels)
                {
                    roleHasPermissionModel.RolesId = entity.Id;
                    roleHasPermissionModel.PermissionsId = permissionsModel.Id;
                    roleHasPermissionsRepository.Insert(roleHasPermissionModel);
                }

                scope.Complete();
                return true;
            }
        }

        public bool Delete(List<RolesModel> entityList)
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
                    _ = mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
                }

                scope.Complete();
                return true;
            }
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool IdExist(int id)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, id },
            };

            string query = $"SELECT id FROM {tableName} WHERE id = @id";
            string result = mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);

            return !string.IsNullOrEmpty(result);
        }

        public bool NameExist(string roleName, string office)
        {
            var parameters = new object[][]
            {
                new object[] { "@role_name", DbType.String, roleName },
                new object[] { "@office", DbType.String, office}
            };

            string query = $"SELECT role_name FROM {tableName} WHERE role_name = @role_name AND office = @office";
            string result = mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);

            return !string.IsNullOrEmpty(result);
        }

        public bool NameExist(string roleName, string office, int roleId)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int16, roleId },
                new object[] { "@office", DbType.String, office},
                new object[] { "@role_name", DbType.String, roleName },
            };

            string query = $"SELECT role_name FROM {tableName} WHERE id <> @id AND role_name = @role_name AND office = @office";
            string result = mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);

            return !string.IsNullOrEmpty(result);
        }

        public DataTable GetRecords(int rowLimit, string searchText)
        {
            var parameters = new object[][]
            {
                new object[] { "@row_limit", DbType.Int32, rowLimit},
                new object[] { "@search_key", DbType.String, $"%{searchText}%"}
            };

            string query = $"SELECT * FROM {tableName} WHERE office <> 'SysAdmin' AND (office LIKE @search_key OR role_name LIKE @search_key) LIMIT @row_limit";
            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
        }
    }
}