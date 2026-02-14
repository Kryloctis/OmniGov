using OmniGov.Core.Repositories;
using System.Data;
using System.Transactions;
using Treasury.Domain.Entities;
using Treasury.Domain.Interfaces;

namespace Treasury.Data.Repositories
{
    public class RptTaxRatesRepository : IRptTaxRatesRepository
    {
        private GenericCommands mySqlGenericCommandsLFS;
        private readonly string tableName = "rpt_tax_rates";

        public RptTaxRatesRepository(GenericCommands mySqlGenericCommandsLFS)
        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<RptTaxRatesModel> entityList)
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
                    _ = mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
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

            using (var items = mySqlGenericCommandsLFS.ExecuteReader(query, parameters))
            {
                if (items.Rows.Count < 1)
                    return dict;

                foreach (DataRow item in items.Rows)
                {
                    dict.Add("code", item["code"].ToString());
                    dict.Add("description", item["description"].ToString());
                    dict.Add("rate", item["rate"].ToString());
                }

                return dict;
            }
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {tableName}";
            var dataTable = new DataTable();
            return mySqlGenericCommandsLFS.Fill(query, dataTable);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameters = new object[][]
            {
                new object[] {"@searchText", DbType.String, $"%{searchText}%"}
            };

            string query = $"SELECT * FROM {tableName} WHERE code LIKE @searchText OR description LIKE @searchText";
            var dataTable = new DataTable();
            return mySqlGenericCommandsLFS.FillBySearch(query, dataTable, parameters);
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(RptTaxRatesModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@code", DbType.String, entity.Code},
                new object[] { "@description",DbType.String, entity.Description},
                new object[] { "@rate", DbType.Decimal, entity.Rate / 100 }
            };

            string query = $"INSERT INTO {tableName} (code, description, rate) VALUES (@code, @description, @rate)";
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Update(RptTaxRatesModel entity)
        {
            var parameters = new object[][]
             {
                new object[] { "@id",DbType.Int32, entity.Id},
                new object[] { "@code", DbType.String, entity.Code},
                new object[] { "@description", DbType.String, entity.Description},
                new object[] { "@rate", DbType.Decimal, entity.Rate / 100 }
             };

            string query = $"UPDATE {tableName} SET code = @code, description = @description, rate = @rate WHERE id = @id";
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public decimal GetTaxRateByDescription(string description)
        {
            var parameters = new object[][]
            {
                new object[] { "@description", DbType.String, description}
            };

            string query = $"SELECT rate FROM {tableName} WHERE description = @description";
            string result = mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);
            return string.IsNullOrWhiteSpace(result) ? 0 : Convert.ToDecimal(result);
        }
    }
}