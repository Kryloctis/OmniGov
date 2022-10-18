using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    public class ProvincesRepository : IProvinces
    {
        private MySqlGenericCommands _mySqlGenericCommandsLFS;
        private readonly string tableName = "provinces";

        public ProvincesRepository(MySqlGenericCommands mySqlGenericCommandsLFS)
        {
            _mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<ProvincesModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var provincesModel in entityList)
                {
                    var parameters = new object[][] { new object[] { "@id", DbType.Int32, provincesModel.Id } };
                    string query = $"DELETE FROM {tableName} WHERE id = @id";
                    _ = _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
                }

                scope.Complete();
                return true;
            }
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var dictionary = new Dictionary<string, string>();
            var parameters = new object[][] { new object[] { "@id", DbType.Int32, Id } };
            string query = $"SELECT code, name FROM {tableName} WHERE id = @id";

            using (var reader = _mySqlGenericCommandsLFS.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return dictionary;

                foreach (DataRow row in reader.Rows)
                {
                    dictionary.Add("code", row["code"].ToString());
                    dictionary.Add("name", row["name"].ToString());
                }
                return dictionary;
            }
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {tableName}";
            var dataTable = new DataTable();
            return _mySqlGenericCommandsLFS.Fill(query, dataTable);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameters = new object[][] { new object[] { "@search_text", DbType.String, $"%{searchText}%" } };
            string query = $"SELECT * FROM {tableName} WHERE code LIKE @search_text OR name LIKE @search_text";
            var dataTable = new DataTable();
            return _mySqlGenericCommandsLFS.FillBySearch(query, dataTable, parameters);
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(ProvincesModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@code", DbType.String, entity.Code},
                new object[] { "@name", DbType.String, entity.Name}
            };

            string query = $"INSERT INTO {tableName} (code, name) VALUES (@code, @name)";
            return _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Update(ProvincesModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.Id},
                new object[] { "@code", DbType.String, entity.Code},
                new object[] { "@name", DbType.String, entity.Name}
            };

            string query = $"UPDATE {tableName} SET code = @code, name = @name WHERE id = @id";
            return _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool NameExist(string name)
        {
            var parameters = new object[][] { new object[] { "@name", DbType.String, name } };
            string query = $"SELECT id FROM {tableName} WHERE name = @name";

            string result = _mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);
            if (!string.IsNullOrEmpty(result))
                return true;
            return false;
        }

        public bool NameExist(int id, string name)
        {
            var parameters = new object[][]
            {
                new object[] { "@name", DbType.String, name },
                new object[] { "@id", DbType.Int32, id}
            };
            string query = $"SELECT id FROM {tableName} WHERE name = @name AND id <> @id";

            string result = _mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);
            if (!string.IsNullOrEmpty(result))
                return true;
            return false;
        }

        public int GetLastInsertedId()
        {
            string query = $"SELECT COALESCE(MAX(id),0) AS id FROM {tableName}";
            return Convert.ToInt32(_mySqlGenericCommandsLFS.ExecuteScalar(query));
        }

        public int GetIdByName(string name)
        {
            var parameters = new object[][] { new object[] { "@name", DbType.String, name } };
            string query = $"SELECT id FROM {tableName} WHERE name = @name";
            return Convert.ToInt32(_mySqlGenericCommandsLFS.ExecuteScalar(query, parameters));
        }
    }
}
