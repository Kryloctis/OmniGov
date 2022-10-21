using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    public class ActualUseCodesRepository : IActualUseCodes
    {
        private MySqlGenericCommands _mySqlGenericCommandsLFS;
        private readonly string tableName = "actual_use_codes";

        public ActualUseCodesRepository(MySqlGenericCommands mySqlGenericCommandsLFS)
        {
            _mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<ActualUseCodesModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var model in entityList)
                {
                    var parameters = new object[][]
                    {
                        new object[] { "@id", DbType.Int32, model.Id}
                    };
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
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, Id}
            };

            string query = $"SELECT code, name, is_government FROM {tableName} WHERE id = @id";

            using (var reader = _mySqlGenericCommandsLFS.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return dictionary;

                foreach (DataRow item in reader.Rows)
                {
                    dictionary.Add("code", item["code"].ToString());
                    dictionary.Add("name", item["name"].ToString());
                    dictionary.Add("is_government", item["is_government"].ToString());
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
            var parameters = new object[][]
            {
                new object[] { "@search_text", DbType.String, $"%{searchText}%"}
            };

            string query = $"SELECT * FROM {tableName} WHERE code = @search_text OR name = @search_text";
            var dataTable = new DataTable();
            return _mySqlGenericCommandsLFS.FillBySearch(query, dataTable, parameters);
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(ActualUseCodesModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@code", DbType.String, entity.Code},
                new object[] { "@name", DbType.String, entity.Name},
                new object[] { "@is_government", DbType.Boolean, entity.IsGovernment}
            };

            string query = $"INSERT INTO {tableName} (code, name, is_government) VALUES (code, name, is_government)";
            return _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Update(ActualUseCodesModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.Id},
                new object[] { "@code", DbType.String, entity.Code},
                new object[] { "@name", DbType.String, entity.Name},
                new object[] { "@is_government", DbType.Boolean, entity.IsGovernment}
            };

            string query = $"UPDATE {tableName} SET code = @code, name = @name, is_government = @is_government WHERE id = @id";
            return _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }
    }
}
