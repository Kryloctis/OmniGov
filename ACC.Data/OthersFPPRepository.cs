using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ACC.Data
{
    public class OthersFPPRepository : IOthersFPPRepository
    {

        private readonly string tableName = "others_fpp";

        private MySqlGenericCommands mySqlGenericCommands;

        public OthersFPPRepository(MySqlGenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<OthersFPPModel> entityList)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecords()
        {
            try
            {
                string query = $"SELECT id, function_program_project_id, name, created_at, updated_at FROM {tableName}";

                var dtPermissions = new DataTable();
                return mySqlGenericCommands.Fill(query, dtPermissions);
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

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(OthersFPPModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@name", DbType.String, entity.Name},
                    new object[] { "@function_program_project_id", DbType.Int32, entity.functionProgramProjectId}
                };

                string query = $"INSERT INTO {tableName} (name , function_program_project_id) VALUES (@name, @function_program_project_id)";
                return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(OthersFPPModel entity)
        {
            throw new NotImplementedException();
        }

        #region Validations

        public bool NameExist(string name)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@name", DbType.String, name},
                };

                string query = $"SELECT id FROM {tableName} WHERE name = @name";
                string queryResult = mySqlGenericCommands.ExecuteScalar(query, parameters);

                // if query is not null, means found some record, so true
                if (!string.IsNullOrEmpty(queryResult)) return true;
            }
            catch (Exception)
            {
                throw;
            };

            return false;
        }

        public bool NameExist(int id, string name)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@name", DbType.String, name},
                    new object[] { "@id", DbType.Int32, id}
                };

                string query = $"SELECT id FROM {tableName} WHERE id <> @id AND name = @name";
                string queryResult = mySqlGenericCommands.ExecuteScalar(query, parameters);

                // if query is not null, means found some record, so true
                if (!string.IsNullOrEmpty(queryResult)) return true;
            }
            catch (Exception)
            {
                throw;
            };

            return false;
        }

        #endregion Validations
    }
}
