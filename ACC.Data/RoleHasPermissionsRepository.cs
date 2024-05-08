using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACC.Data
{
    public class RoleHasPermissionsRepository : IRoleHasPermissionsRepository
    {
        private readonly string tableName = "role_has_permissions";
        private readonly string viewTableName = "view_role_has_permissions";
        private AccGenericCommands mySqlGenericCommandsLFS;

        public RoleHasPermissionsRepository(AccGenericCommands mySqlGenericCommandsLFS)
        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<RoleHasPermissionsModel> entityList)
        {
            throw new NotImplementedException();
        }

        public bool DeleteByRoleId(byte roleId)
        {
            var parameters = new object[][]
            {
                new object[] { "@roles_id", DbType.Byte, roleId},
            };

            string query = $"SET FOREIGN_KEY_CHECKS=0; DELETE FROM {tableName} WHERE roles_id = @roles_id; SET FOREIGN_KEY_CHECKS=1;";
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecords()
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecordsByRoleId(byte roleId)
        {
            var parameters = new object[][]
            {
                new object[] { "@roles_id", DbType.Byte, roleId},
            };
            string query = $"SELECT * FROM {viewTableName} WHERE roles_id = @roles_id ORDER BY permission_name ASC";
            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new NotImplementedException();
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(RoleHasPermissionsModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@role_id", DbType.Byte, entity.RolesId},
                new object[] { "@permission_id", DbType.Byte, entity.PermissionsId},
            };

            string query = $"INSERT INTO {tableName} (roles_id, permissions_id) VALUES (@role_id, @permission_id)";
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Update(RoleHasPermissionsModel entity)
        {
            throw new NotImplementedException();
        }
    }
}