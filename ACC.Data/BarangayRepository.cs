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
        private AccGenericCommands _mySqlGenericCommandsLFS;
        private readonly string tableName = "barangays";
        private readonly string viewTableName = "view_barangays";

        public BarangayRepository(AccGenericCommands mySqlGenericCommandsRPT)
        {
            _mySqlGenericCommandsLFS = mySqlGenericCommandsRPT;
        }

        public bool CodeExist(string code)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@code", DbType.String, code },
                };

                string query = $"SELECT code FROM {tableName} WHERE code = @code";
                string queryResult = _mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);

                // if query is not null, means found some record, so true
                if (!string.IsNullOrEmpty(queryResult)) return true;
            }
            catch (Exception)
            {
                throw;
            };

            return false;
        }

        public bool CodeExist(string code, int id)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int16, id },
                    new object[] { "@code", DbType.String, code },
                };

                string query = $"SELECT code FROM {tableName} WHERE id <> @id AND code = @code";
                string queryResult = _mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);

                // if query is not null, means found some record, so true
                if (!string.IsNullOrEmpty(queryResult)) return true;
            }
            catch (Exception)
            {
                throw;
            };

            return false;
        }

        public int CountRecords()
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(List<BarangayModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var entity in entityList)
                {
                    var parameters = new object[][] { new object[] { @"id", DbType.Int32, entity.Id } };

                    string query = $"DELETE FROM {tableName} WHERE id = @id";
                    _ = _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
                }

                scope.Complete();
                return true;
            }
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var dict = new Dictionary<string, string>();

            var parameter = new object[][] {
                new object[]{"@barangay_id", DbType.Int32, Id}
            };
            string query = $"SELECT name, code FROM {tableName} WHERE id = @barangay_id";

            using (var items = _mySqlGenericCommandsLFS.ExecuteReader(query, parameter))
            {
                if (items.Rows.Count < 1)
                    return dict;

                foreach (DataRow item in items.Rows)
                {
                    dict.Add("code", item["code"].ToString());
                    dict.Add("name", item["name"].ToString());
                }

                return dict;
            }
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT id, code, name FROM {tableName}";

            var dtBudgetAppropriation = new DataTable();
            return _mySqlGenericCommandsLFS.Fill(query, dtBudgetAppropriation);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameters = new object[][]
            {
                new object[] { "@search_text", DbType.String, $"%{searchText}%"},
            };

            string query = $"SELECT id, code, name FROM {tableName} WHERE code LIKE @search_text OR name LIKE @search_text";

            var dtBarangay = new DataTable();
            return _mySqlGenericCommandsLFS.FillBySearch(query, dtBarangay, parameters);
        }

        public bool IdExist(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(BarangayModel entity)
        {
            var parameter = new object[][] {
                new object[]{"@barangay_code", DbType.String, entity.Code},
                new object[]{"@barangay_name", DbType.String, entity.Name},
                new object[]{"@municipalities_id", DbType.Int32, entity.MunicipalityID}
            };

            string query = $"INSERT INTO barangays (code, name, municipalities_id) VALUES (@barangay_code, @barangay_name, @municipalities_id)";

            return _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameter);

        }

        public bool Update(BarangayModel entity)
        {
            var parameters = new object[][] {
                new object[]{"@barangay_id", DbType.Int32, entity.Id},
                new object[]{"@code", DbType.String, entity.Code},
                new object[]{"@name", DbType.String, entity.Name }
            };

            string query = $"UPDATE {tableName} SET code = @code, name = @name WHERE id = @barangay_id";
            return _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
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
            return Convert.ToInt32(_mySqlGenericCommandsLFS.ExecuteScalar(query, parameters));
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
            string result = _mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);

            if (!string.IsNullOrEmpty(result)) return true;
            return false;
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
            string result = _mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);

            if (!string.IsNullOrEmpty(result)) return true;
            return false;
        }

        public bool NameExist(string name)
        {
            var parameters = new object[][]
            {
                new object[] { "@barangays_name", DbType.String, name }
            };

            string query = $"SELECT barangays_name FROM {viewTableName} WHERE barangays_name = @barangays_name";
            string result = _mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);

            if (!string.IsNullOrEmpty(result)) return true;
            return false;
        }

        public bool NameExist(string name, int id)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.String, id },
                new object[] { "@name", DbType.String, name }
            };

            string query = $"SELECT name FROM {tableName} WHERE id <> @id AND name = @name";
            string result = _mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);

            if (!string.IsNullOrEmpty(result)) return true;
            return false;
        }

        public Dictionary<string, string> GetViewRecordById(int id)
        {
            var dictionary = new Dictionary<string, string>();
            var parameters = new object[][] { new object[] { "@barangays_id", DbType.Int32, id } };

            string query = $"SELECT barangays_code, barangays_name, municipalities_id, municipalities_code, municipalities_name, provinces_id, provinces_code, provinces_name FROM {viewTableName} WHERE barangays_id = @barangays_id";

            using (var reader = _mySqlGenericCommandsLFS.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return dictionary;

                foreach (DataRow row in reader.Rows)
                {
                    dictionary.Add("barangays_code", row["barangays_code"].ToString());
                    dictionary.Add("barangays_name", row["barangays_name"].ToString());
                    dictionary.Add("municipalities_id", row["municipalities_id"].ToString());
                    dictionary.Add("municipalities_code", row["municipalities_code"].ToString());
                    dictionary.Add("municipalities_name", row["municipalities_name"].ToString());
                    dictionary.Add("provinces_id", row["provinces_id"].ToString());
                    dictionary.Add("provinces_code", row["provinces_code"].ToString());
                    dictionary.Add("provinces_name", row["provinces_name"].ToString());
                }
                return dictionary;
            }
        }

        public int GetLastInsertedId()
        {
            string query = $"SELECT MAX(id) FROM {tableName}";
            return Convert.ToInt32(_mySqlGenericCommandsLFS.ExecuteScalar(query));
        }
    }
}