using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Transactions;

namespace ACC.Data
{
    public class RptDiscountsRepository : IRptDiscountsRepository
    {
        private MySqlGenericCommands _mySqlGenericCommandsLFS;
        private readonly string tableName = "rpt_discounts";

        public RptDiscountsRepository(MySqlGenericCommands mySqlGenericCommandsLFS)
        {
            _mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<RptDiscountsModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var entity in entityList)
                {
                    var parameters = new object[][]
                    {
                        new object[] { "@id", DbType.Int32, entity.Id}
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
            var dict = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, Id}
            };

            string query = $"SELECT * FROM {tableName} WHERE id = @id";

            using (var reader = _mySqlGenericCommandsLFS.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return dict;

                dict.Add("percentage", reader.Rows[0]["percentage"].ToString()); 
            }

            return dict;
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
                new object[] { "@searchText", DbType.String, $"%{searchText}%"}
            };

            string query = $"SELECT * FROM {tableName} WHERE code LIKE @searchText OR description LIKE @searchText";
            var dataTable = new DataTable();
            return _mySqlGenericCommandsLFS.FillBySearch(query, dataTable, parameters);
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(RptDiscountsModel entity)
        {
            var parameter = new object[][]
            {
                new object[] { "@code", DbType.String, entity.Code},
                new object[] { "@description", DbType.String, entity.Description},
                new object[] { "@rate", DbType.Decimal, entity.Rate}
            };

            string query = $"INSERT INTO {tableName} (code, description, rate) VALUES (@code, @description, @rate)";
            return _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameter);
        }

        public bool Update(RptDiscountsModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.Id},
                new object[] { "@code", DbType.String, entity.Code},
                new object[] { "@description", DbType.String, entity.Description},
                new object[] { "@rate", DbType.Decimal, entity.Rate}
            };

            string query = $"UPDATE {tableName} SET code = @code, description = @description, rate = @rate WHERE id = @id";
            return _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool CodeExist(string code)
        {
            var parameters = new object[][]
            {
                new object[] { "@code", DbType.String, code}
            };

            string query = $"SELECT id FROM {tableName} WHERE code = @code";
            string result = _mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);
            if (!string.IsNullOrEmpty(result))
                return true;
            else
                return false;
        }

        public bool CodeExist(int id, string code)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, id},
                new object[] { "@code", DbType.String, code}
            };

            string query = $"SELECT id FROM {tableName} WHERE id <> @id AND code = @code";
            string result = _mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);
            if (!string.IsNullOrEmpty(result))
                return true;
            else
                return false;
        }

        public bool DescriptionExist(string description)
        {
            var parameters = new object[][]
            {
                new object[] { "@description", DbType.String, description}
            };

            string query = $"SELECT id FROM {tableName} WHERE description = @description";
            string result = _mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);
            if (!string.IsNullOrEmpty(result))
                return true;
            else
                return false;
        }

        public bool DescriptionExist(int id, string description)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, id},
                new object[] { "@description", DbType.String, description}
            };

            string query = $"SELECT id FROM {tableName} WHERE id <> @id AND description = @description";
            string result = _mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);
            if (!string.IsNullOrEmpty(result))
                return true;
            else
                return false;
        }
    }
}
