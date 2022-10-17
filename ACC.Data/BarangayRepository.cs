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
        private MySqlGenericCommands _mySqlGenericCommandsLFS;
        private readonly string tableName = "barangays";

        public BarangayRepository(MySqlGenericCommands mySqlGenericCommandsRPT)
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

        public bool NameExist(string name)
        {
            var parameters = new object[][]
            {
                new object[] { "@name", DbType.String, name }
            };

            string query = $"SELECT name FROM {tableName} WHERE name = @name";
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

        public bool Update(BarangayModel entity)
        {
            var parameters = new object[][] {
                new object[]{"@barangay_id", DbType.Int32, entity.Id},
                new object[]{"@barangay_code", DbType.String, entity.Code},
                new object[]{"@barangay_name", DbType.String, entity.Name }
            };

            string query = $"UPDATE {tableName} SET code = @barangay_code, name = @barangay_name WHERE id = @barangay_id";
            return _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }
    }
}