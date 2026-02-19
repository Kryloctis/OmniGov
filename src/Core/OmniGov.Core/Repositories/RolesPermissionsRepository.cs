using OmniGov.Core.Entities;
using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Core.Interfaces.Services;
using System.Data;

namespace OmniGov.Core.Repositories
{
    public class RolesPermissionsRepository : IRolesPermissionsRepository
    {
        private readonly string tableName = "role_has_permissions";
        private readonly string viewTableName = "view_role_has_permissions";
        private IGenericCommands mySqlGenericCommands;

        public RolesPermissionsRepository(IGenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public bool Delete(List<RolesPermissionsModel> entityList)
        {
            throw new NotImplementedException();
        }

        public bool DeleteByRoleId(int roleId)
        {
            var parameters = new object[][]
            {
                new object[] { "@roles_id", DbType.Byte, roleId},
            };

            string query = $"SET FOREIGN_KEY_CHECKS=0; DELETE FROM {tableName} WHERE roles_id = @roles_id; SET FOREIGN_KEY_CHECKS=1;";
            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecords()
        {
            throw new NotImplementedException();
        }

        public DataTable GetViewRecordsByRoleId(int roleId)
        {
            var parameters = new object[][]
            {
                new object[] { "@roles_id", DbType.Byte, roleId},
            };

            string query = $"SELECT * FROM {viewTableName} WHERE roles_id = @roles_id ORDER BY permission_name ASC";
            return mySqlGenericCommands.FillBySearch(query, new DataTable(), parameters);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new NotImplementedException();
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(RolesPermissionsModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@role_id", DbType.Byte, entity.RolesId},
                new object[] { "@permission_id", DbType.Byte, entity.PermissionsId},
            };

            string query = $"INSERT INTO {tableName} (roles_id, permissions_id) VALUES (@role_id, @permission_id)";
            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(RolesPermissionsModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
