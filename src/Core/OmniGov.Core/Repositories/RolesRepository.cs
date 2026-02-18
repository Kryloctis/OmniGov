using OmniGov.Core.Entities;
using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Core.Interfaces.Services;
using System.Data;
using System.Transactions;

namespace OmniGov.Core.Repositories
{
    public class RolesRepository : IRolesRepository
    {
        private readonly IRolesPermissionsRepository roleHasPermissionsRepository;
        private readonly string tableName = "roles";
        private IGenericCommands mySqlGenericCommands;

        public RolesRepository(IGenericCommands mySqlGenericCommands, IRolesPermissionsRepository roleHasPermissionsRepository)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
            this.roleHasPermissionsRepository = roleHasPermissionsRepository;
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, Id},
            };

            string query = $"SELECT role_name, created_at, updated_at FROM {tableName} WHERE id = @id";

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
            string query = $"SELECT * FROM {tableName} WHERE role_name <> 'System Administrator'";
            return mySqlGenericCommands.Fill(query, new DataTable());
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
            return mySqlGenericCommands.FillBySearch(query, dtUsers, parameters);
        }

        public byte GetLastInsertedID()
        {
            string query = $"SELECT MAX(id) FROM {tableName}";
            return byte.Parse(mySqlGenericCommands.ExecuteScalar(query));
        }

        public bool Insert(RolesModel entity)
        {
            using (var scope = new TransactionScope())
            {
                var parameters = new object[][]
                {
                    new object[] { "@role_name", DbType.String, entity.RoleName},
                };

                string query = $"INSERT INTO {tableName} (role_name) VALUES (@role_name)";
                _ = mySqlGenericCommands.ExecuteNonQuery(query, parameters);

                var roleHasPermissionModel = new RolesPermissionsModel();
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
                    new object[] { "@id", DbType.Int32, entity.Id},
                    new object[] { "@role_name", DbType.String, entity.RoleName},
                };

                string query = $"UPDATE {tableName} SET role_name = @role_name WHERE id = @id";
                _ = mySqlGenericCommands.ExecuteNonQuery(query, parameters);
                roleHasPermissionsRepository.DeleteByRoleId(entity.Id);
                var roleHasPermissionModel = new RolesPermissionsModel();
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
                    var parameters = new object[][] { new object[] { "@id", DbType.Int32, entity.Id }, };

                    string query = $"DELETE FROM {tableName} WHERE id = @id";
                    _ = roleHasPermissionsRepository.DeleteByRoleId(entity.Id);
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
            string result = mySqlGenericCommands.ExecuteScalar(query, parameters);

            return !string.IsNullOrEmpty(result);
        }

        public bool NameExist(string roleName)
        {
            var parameters = new object[][]
            {
                new object[] { "@role_name", DbType.String, roleName },
            };

            string query = $"SELECT role_name FROM {tableName} WHERE role_name = @role_name";
            string result = mySqlGenericCommands.ExecuteScalar(query, parameters);

            return !string.IsNullOrEmpty(result);
        }

        public bool NameExist(string roleName, int roleId)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int16, roleId },
                new object[] { "@role_name", DbType.String, roleName },
            };

            string query = $"SELECT role_name FROM {tableName} WHERE id <> @id AND role_name = @role_name";
            string result = mySqlGenericCommands.ExecuteScalar(query, parameters);

            return !string.IsNullOrEmpty(result);
        }

        public DataTable GetRecords(int rowLimit, string searchText)
        {
            var parameters = new object[][]
            {
                new object[] { "@row_limit", DbType.Int32, rowLimit},
                new object[] { "@search_key", DbType.String, $"%{searchText}%"}
            };

            string query = $"SELECT * FROM {tableName} WHERE (role_name LIKE @search_key) LIMIT @row_limit";
            return mySqlGenericCommands.FillBySearch(query, new DataTable(), parameters);
        }
    }
}
