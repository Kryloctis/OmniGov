using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    public class SubFPPRepository : ISubFPPRepository
    {
        private readonly string tableName = "others_fpp";

        private AccGenericCommands mySqlGenericCommandsLFS;

        public SubFPPRepository(AccGenericCommands mySqlGenericCommandsLFS)
        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
        }

        public bool Delete(List<SubFPPModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var entity in entityList)
                {
                    var parameters = new object[][] { new object[] { "@id", DbType.Int32, entity.Id }, };
                    string query = $"DELETE FROM {tableName} WHERE id = @id";
                    _ = mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
                }

                scope.Complete();
                return true;
            }
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var record = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] {"@id", DbType.Int32, Id},
            };
            string query = $"SELECT others_fpp_code, name FROM {tableName} WHERE id = @id";

            using (var reader = mySqlGenericCommandsLFS.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return record;

                foreach (DataRow item in reader.Rows)
                {
                    record.Add("others_fpp_code", item[0].ToString());
                    record.Add("name", item[1].ToString());
                }
            }

            return record;
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT id, function_program_project_id, others_fpp_code, name, created_at, updated_at FROM {tableName}";
            return mySqlGenericCommandsLFS.Fill(query, new DataTable());
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new NotImplementedException();
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(SubFPPModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@function_program_project_id", DbType.Int32, entity.functionProgramProjectId},
                new object[] { "@others_fpp_code", DbType.String, entity.othersFPPCode},
                new object[] { "@name", DbType.String, entity.othersFPPName}
            };

            string query = $"INSERT INTO {tableName} (function_program_project_id, others_fpp_code, name) VALUES (@function_program_project_id, @others_fpp_code, @name)";
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Update(SubFPPModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.Id},
                new object[] { "@others_fpp_code", DbType.String, entity.othersFPPCode},
                new object[] { "@name", DbType.String, entity.othersFPPName},
            };

            string query = $"UPDATE {tableName} SET others_fpp_code = @others_fpp_code, name = @name WHERE id = @id";
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public DataTable GetRecordsByFppId(int fppId)
        {
            var parameters = new object[][]
            {
                new object[] { "@function_program_project_id", DbType.Int32, fppId }
            };

            string query = $"SELECT * FROM {tableName} WHERE function_program_project_id = @function_program_project_id";
            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
        }

        public DataTable GetRecorsByIDSearchCode(int id, string searchtxt)
        {
            var parameters = new object[][]
            {
                new object[] { "@function_program_project_id", DbType.Int32, id },
                new object[] { "@searchTxt", DbType.String, $"%{searchtxt}%"}
            };

            string query = $"SELECT * FROM {tableName} WHERE function_program_project_id = @function_program_project_id AND (name LIKE @searchTxt OR others_fpp_code LIKE @searchTxt)";

            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
        }

        public bool NameExist(string name)
        {
            var parameters = new object[][]
            {
                new object[] { "@name", DbType.String, name},
            };

            string query = $"SELECT id FROM {tableName} WHERE name = @name";
            string result = mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);
            return !string.IsNullOrEmpty(result);
        }

        public bool NameExist(int id, string name)
        {
            var parameters = new object[][]
            {
                new object[] { "@name", DbType.String, name},
                new object[] { "@id", DbType.Int32, id}
            };

            string query = $"SELECT id FROM {tableName} WHERE id <> @id AND name = @name";
            string result = mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);

            return !string.IsNullOrEmpty(result);
        }

        public bool CodeExist(string otherFPPCode)
        {
            var parameters = new object[][]
            {
                new object[] { "@others_fpp_code", DbType.String, otherFPPCode}
            };

            string query = $"SELECT id FROM {tableName} WHERE others_fpp_code = @others_fpp_code";
            string result = mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);
            return !string.IsNullOrEmpty(result);
        }

        public bool CodeExist(int id, string otherFPPCode)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, id},
                new object[] { "@others_fpp_code",DbType.String, otherFPPCode}
            };

            string query = $"SELECT id FROM {tableName} WHERE id <> @id AND others_fpp_code = @others_fpp_code";
            string result = mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);
            return !string.IsNullOrEmpty(result);
        }

        public DataTable GetRecordsByFPPIdCodeName(int fppId, string searchTxt)
        {
            var parameters = new object[][]
            {
                new object[] { "@function_program_project_id", DbType.Int32, fppId },
                new object[] { "@searchTxt", DbType.String, $"%{searchTxt}%" },
            };

            string query = $"SELECT id, function_program_project_id, others_fpp_code, name, created_at, updated_at FROM {tableName} WHERE function_program_project_id = @function_program_project_id AND (others_fpp_code LIKE @searchTxt OR name LIKE @searchTxt)";

            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
        }
    }
}