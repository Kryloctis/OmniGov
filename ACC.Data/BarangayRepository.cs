using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    public class BarangayRepository : IBarangayRepository
    {
        private AccGenericCommands mySqlGenericCommandsLFS;
        private readonly string tableName = "barangays";
        private readonly string viewTableName = "view_barangays";

        public BarangayRepository(AccGenericCommands mySqlGenericCommandsRPT)
        {
            mySqlGenericCommandsLFS = mySqlGenericCommandsRPT;
        }

        public bool CodeExist(string code)
        {
            var parameters = new object[][]
            {
                new object[] { "@code", DbType.String, code },
            };

            string query = $"SELECT code FROM {tableName} WHERE code = @code";
            string result = mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);
            return !string.IsNullOrEmpty(result);
        }

        public bool CodeExist(string code, int id)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int16, id },
                new object[] { "@code", DbType.String, code },
            };

            string query = $"SELECT code FROM {tableName} WHERE id <> @id AND code = @code";
            string result = mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);
            return !string.IsNullOrEmpty(result);
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<BarangayModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var entity in entityList)
                {
                    var parameters = new object[][] { new object[] { @"id", DbType.Int32, entity.Id } };

                    string query = $"DELETE FROM {tableName} WHERE id = @id";
                    _ = mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
                }

                scope.Complete();
                return true;
            }
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var recordDictionary = new Dictionary<string, string>();
            var parameters = new object[][]
            {
                new object[]{"@barangay_id", DbType.Int32, Id}
            };

            string query = $"SELECT * FROM {tableName} WHERE id = @barangay_id";

            DataTable dataTable = mySqlGenericCommandsLFS.ExecuteReader(query, parameters);

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
            string query = $"SELECT id, code, name FROM {tableName}";
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

        public bool Insert(BarangayModel entity)
        {
            var parameter = new object[][] {
                new object[]{"@barangay_code", DbType.String, entity.Code},
                new object[]{"@barangay_name", DbType.String, entity.Name},
                new object[]{"@municipalities_id", DbType.Int32, entity.MunicipalityId}
            };

            string query = $"INSERT INTO barangays (code, name, municipalities_id) VALUES (@barangay_code, @barangay_name, @municipalities_id)";
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameter);
        }

        public bool Update(BarangayModel entity)
        {
            var parameters = new object[][]
            {
                new object[]{"@barangay_id", DbType.Int32, entity.Id},
                new object[]{"@code", DbType.String, entity.Code},
                new object[]{"@name", DbType.String, entity.Name }
            };

            string query = $"UPDATE {tableName} SET code = @code, name = @name WHERE id = @barangay_id";
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public int GetIdByName_MunicipalitiesName_ProvincesName(string name, string municipalityName, string provinceName)
        {
            var parameters = new object[][]
            {
                new object[] { "@barangays_name", DbType.String, name },
                new object[] { "@municipalities_name", DbType.String, municipalityName},
                new object[] { "@provinces_name", DbType.String, provinceName}
            };
            string query = $"SELECT barangays_id FROM {viewTableName} WHERE barangays_name = @barangays_name AND municipalities_name = @municipalities_name AND provinces_name = @provinces_name";
            return Convert.ToInt32(mySqlGenericCommandsLFS.ExecuteScalar(query, parameters));
        }

        public bool NameExistByMunicipalitiesName_ProvincesName(string name, string municipalityName, string provinceName)
        {
            var parameters = new object[][]
            {
                new object[] { "@barangays_name", DbType.String, name },
                new object[] { "@municipalities_name", DbType.String, municipalityName },
                new object[] { "@provinces_name", DbType.String, provinceName}
            };

            string query = $"SELECT barangays_name FROM {viewTableName} WHERE barangays_name = @barangays_name AND municipalities_name = @municipalities_name AND provinces_name = @provinces_name";
            string result = mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);
            return !string.IsNullOrEmpty(result);
        }

        public bool NameExistByMunicipalitiesName_ProvincesName(string name, string municipalityName, string provinceName, int id)
        {
            var parameters = new object[][]
            {
                new object[] { "@barangays_id", DbType.String, id },
                new object[] { "@barangays_name", DbType.String, name },
                new object[] { "@municipalities_name", DbType.String, municipalityName },
                new object[] { "@provinces_name", DbType.String, provinceName }
            };

            string query = $"SELECT barangays_name FROM {viewTableName} WHERE barangays_id <> @barangays_id AND barangays_name = @barangays_name AND municipalities_name = @municipalities_name AND provinces_name = @provinces_name";
            string result = mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);
            return !string.IsNullOrEmpty(result);
        }

        public bool NameExist(string name)
        {
            var parameters = new object[][]
            {
                new object[] { "@barangays_name", DbType.String, name }
            };

            string query = $"SELECT barangays_name FROM {viewTableName} WHERE barangays_name = @barangays_name";
            string result = mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);
            return !string.IsNullOrEmpty(result);
        }

        public bool NameExist(string name, int id)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.String, id },
                new object[] { "@name", DbType.String, name }
            };

            string query = $"SELECT name FROM {tableName} WHERE id <> @id AND name = @name";
            string result = mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);
            return !string.IsNullOrEmpty(result);
        }

        public Dictionary<string, string> GetViewRecordById(int id)
        {
            var recordDictionary = new Dictionary<string, string>();
            var parameters = new object[][]
            {
                new object[] { "@barangays_id", DbType.Int32, id }
            };

            string query = $"SELECT * FROM {viewTableName} WHERE barangays_id = @barangays_id";

            DataTable dataTable = mySqlGenericCommandsLFS.ExecuteReader(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                foreach (DataColumn column in dataTable.Columns)
                    recordDictionary[column.ColumnName] = row[column].ToString();

                return recordDictionary;
            }
            return recordDictionary;
        }

        public int GetLastInsertedId()
        {
            string query = $"SELECT MAX(id) FROM {tableName}";
            return Convert.ToInt32(mySqlGenericCommandsLFS.ExecuteScalar(query));
        }

        public DataTable GetRecordsBySearch(int rowLimit, string searchText, int municipalityId)
        {
            var parameters = new object[][]
            {
                new object[] { "@row_limit", DbType.Int32, rowLimit},
                new object[] { "@search_text", DbType.String, $"%{searchText}%"},
                new object[] { "@municipalities_id", DbType.Int32, municipalityId}
            };

            string query = $"SELECT * FROM {tableName} WHERE (code LIKE @search_text OR name LIKE @search_text) AND municipalities_id = @municipalities_id LIMIT @row_limit";
            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
        }
    }
}