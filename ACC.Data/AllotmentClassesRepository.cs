using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    public class AllotmentClassesRepository : IAllotmentClassesRepository
    {
        private readonly string tableName = "allotment_classes";
        private AccGenericCommands mySqlGenericCommandsLFS;

        public AllotmentClassesRepository(AccGenericCommands mySqlGenericCommandsLFS)
        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var record = new Dictionary<string, string>();

            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, Id},
                };

                string query = $"SELECT allotment_code, allotment_name, created_at, updated_at FROM {tableName} WHERE id = @id";

                using (var reader = mySqlGenericCommandsLFS.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;

                    record.Add("allotment_code", reader.Rows[0][0].ToString());
                    record.Add("allotment_name", reader.Rows[0][1].ToString());
                    record.Add("created_at", reader.Rows[0][2].ToString());
                    record.Add("updated_at", reader.Rows[0][3].ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }

            return record;
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT id, allotment_code, allotment_name, created_at, updated_at FROM {tableName}";

            DataTable dataTable = new DataTable();
            return mySqlGenericCommandsLFS.Fill(query, dataTable);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            object[][] parameters = new object[][]
            {
                new object[] { "@search_text", DbType.String, $"%{searchText}%"}
            };

            string query = $"SELECT id, allotment_code, allotment_name, created_at, updated_at FROM {tableName} WHERE allotment_code LIKE @search_text OR allotment_name LIKE @search_text";

            DataTable dataTable = new DataTable();
            return mySqlGenericCommandsLFS.FillBySearch(query, dataTable, parameters);
        }

        public bool Insert(AllotmentClassesModel entity)
        {
            object[][] parameters = new object[][]
            {
                new object[] { "@allotment_name", DbType.String, entity.AllotmentName},
                new object[] { "@allotment_code", DbType.String, entity.AllotmentCode}
            };

            string query = $"INSERT INTO {tableName} (allotment_code, allotment_name) VALUES (@allotment_code, @allotment_name)";
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Update(AllotmentClassesModel entity)
        {
            object[][] parameters = new object[][]
            {
                new object[] { "@id", DbType.Int16, entity.Id},
                new object[] { "@allotment_name", DbType.String, entity.AllotmentName},
                new object[] { "@allotment_code", DbType.String, entity.AllotmentCode}
            };

            string query = $"UPDATE {tableName} SET allotment_name = @allotment_name, allotment_code = @allotment_code WHERE id = @id";
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Delete(List<AllotmentClassesModel> entityList)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                foreach (AllotmentClassesModel entity in entityList)
                {
                    object[][] parameters = new object[][]
                    {
                        new object[] { "@id", DbType.Int16, entity.Id},
                    };

                    string query = $"DELETE FROM {tableName} WHERE id = @id";
                    _ = mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
                }

                scope.Complete();
                return true;
            }
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool IdExist(int id)
        {
            object[][] parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, id },
            };

            string query = $"SELECT id FROM {tableName} WHERE id = @id";
            string queryResult = mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);

            // if query is not null, means found some record, so true
            if (!string.IsNullOrEmpty(queryResult)) return true;
            return false;
        }

        public bool CodeExist(string allotmentCode)
        {
            object[][] parameters = new object[][]
            {
                new object[] { "@allotment_code", DbType.String, allotmentCode },
            };

            string query = $"SELECT allotment_code FROM {tableName} WHERE allotment_code = @allotment_code";
            string queryResult = mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);

            // if query is not null, means found some record, so true
            if (!string.IsNullOrEmpty(queryResult)) return true;

            return false;
        }

        public bool CodeExist(string allotmentCode, int allotmentId)
        {
            object[][] parameters = new object[][]
            {
                new object[] { "@id", DbType.Int16, allotmentId },
                new object[] { "@allotment_code", DbType.String, allotmentCode },
            };

            string query = $"SELECT allotment_code FROM {tableName} WHERE id <> @id AND allotment_code = @allotment_code";
            string queryResult = mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);

            // if query is not null, means found some record, so true
            if (!string.IsNullOrEmpty(queryResult)) return true;

            return false;
        }

        public bool NameExist(string allotmentName)
        {
            object[][] parameters = new object[][]
            {
                new object[] { "@allotment_name", DbType.String, allotmentName },
            };

            string query = $"SELECT allotment_name FROM {tableName} WHERE allotment_name = @allotment_name";
            string queryResult = mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);

            // if query is not null, means found some record, so true
            if (!string.IsNullOrEmpty(queryResult)) return true;

            return false;
        }

        public bool NameExist(string allotmentName, int allotmentId)
        {
            object[][] parameters = new object[][]
            {
                new object[] { "@id", DbType.Int16, allotmentId },
                new object[] { "@allotment_name", DbType.String, allotmentName },
            };

            string query = $"SELECT allotment_name FROM {tableName} WHERE id <> @id AND allotment_name = @allotment_name";
            string queryResult = mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);

            // if query is not null, means found some record, so true
            if (!string.IsNullOrEmpty(queryResult)) return true;

            return false;
        }
    }
}