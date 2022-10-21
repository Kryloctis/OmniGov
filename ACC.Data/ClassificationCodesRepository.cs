using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    public class ClassificationCodesRepository : IClassificationCodes
    {
        private MySqlGenericCommands _mySqlGenericCommandsLFS;
        private readonly string tableName = "classification_codes";

        public ClassificationCodesRepository(MySqlGenericCommands mySqlGenericCommandsLFS)
        {
            _mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<ClassificationCodesModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var model in entityList)
                {
                    var parameters = new object[][] { new object[] { "@id", DbType.Int32, model.Id } };
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
            string query = $"SELECT code, name, is_special FROM {tableName} WHERE id = @id";

            using (var reader = _mySqlGenericCommandsLFS.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return dictionary;

                foreach (DataRow row in reader.Rows)
                {
                    dictionary.Add("code", row["code"].ToString());
                    dictionary.Add("name", row["name"].ToString());
                    dictionary.Add("is_special", row["is_special"].ToString());
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
            string query = $"SELECT * FROM {tableName} WHERE code LIKE @code OR name LIKE @name";
            var dataTable = new DataTable();
            return _mySqlGenericCommandsLFS.FillBySearch(query, dataTable, parameters);
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(ClassificationCodesModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@code", DbType.String, entity.Code},
                new object[] { "@name", DbType.String, entity.Name},
                new object[] { "@is_special", DbType.Boolean, entity.IsSpecial}
            };

            string query = $"INSERT INTO {tableName} (code, name, is_special) VALUES (@code, @name, @is_special)";
            return _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Update(ClassificationCodesModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.Id },
                new object[] { "@code", DbType.String, entity.Code},
                new object[] { "@name", DbType.String, entity.Name},
                new object[] { "@is_special", DbType.Boolean, entity.IsSpecial}
            };

            string query = $"UPDATE {tableName} SET code = @code, name = @name, is_special = @is_special WHERE id = @id";
            return _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }
    }
}
