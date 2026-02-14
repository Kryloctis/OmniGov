using OmniGov.Core.Repositories;
using System.Data;
using System.Transactions;
using Treasury.Domain.Entities;
using Treasury.Domain.Interfaces;

namespace Treasury.Data.Repositories
{
    public class RptDiscountsRepository : IRptDiscountsRepository
    {
        private GenericCommands _mySqlGenericCommandsLFS;
        private readonly string tableName = "rpt_discounts";

        public RptDiscountsRepository(GenericCommands mySqlGenericCommandsLFS)
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

                foreach (DataRow item in reader.Rows)
                {
                    dict.Add("month", item["month"].ToString());
                    dict.Add("description", item["description"].ToString());
                    dict.Add("rate", item["rate"].ToString());
                    dict.Add("is_advance", item["is_advance"].ToString());
                }
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

            string query = $"SELECT * FROM {tableName} WHERE description LIKE @searchText";
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
                new object[] { "@month", DbType.Int32, entity.Month},
                new object[] { "@description", DbType.String, entity.Description},
                new object[] { "@rate", DbType.Decimal, entity.Rate / 100},
                new object[] { "@is_advance", DbType.Boolean, entity.IsAdvance}
            };

            string query = $"INSERT INTO {tableName} (month, description, rate, is_advance) VALUES (@month, @description, @rate, @is_advance)";
            return _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameter);
        }

        public bool Update(RptDiscountsModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.Id},
                new object[] { "@month", DbType.Int32, entity.Month},
                new object[] { "@description", DbType.String, entity.Description},
                new object[] { "@rate", DbType.Decimal, entity.Rate / 100},
                new object[] { "@is_advance", DbType.Boolean, entity.IsAdvance}
            };

            string query = $"UPDATE {tableName} SET month = @month, description = @description, rate = @rate, is_advance = @is_advance  WHERE id = @id";
            return _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
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

        public Dictionary<string, string> GetRecordByMonth(int month, bool isAdvance)
        {
            var dict = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@month", DbType.Int32, month},
                new object[] { "@is_advance", DbType.Boolean, isAdvance}
            };

            string query = $"SELECT * FROM {tableName} WHERE month = @month AND is_advance = @is_advance";

            using (var reader = _mySqlGenericCommandsLFS.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count == 0)
                    return dict;

                foreach (DataRow row in reader.Rows)
                {
                    dict.Add("month", row["month"].ToString());
                    dict.Add("description", row["description"].ToString());
                    dict.Add("rate", row["rate"].ToString());
                    dict.Add("is_advance", row["is_advance"].ToString());
                }
            }

            return dict;
        }
    }
}