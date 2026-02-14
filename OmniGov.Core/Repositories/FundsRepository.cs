using OmniGov.Core.Entities;
using OmniGov.Core.Interfaces;
using System.Data;
using System.Transactions;

namespace OmniGov.Core.Repositories
{
    public class FundsRepository : IFundsRepository
    {
        private readonly string tableName = "funds";
        private readonly string tableNamePaymentCollections = "payment_collections";
        private readonly string tableNameBankDeposits = "bank_deposits";
        private GenericCommands mySqlGenericCommandsLFS;

        public FundsRepository(GenericCommands mySqlGenericCommandsLFS)
        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, Id},
            };

            string query = $"SELECT * FROM {tableName} WHERE id = @id";

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
            string query = $"SELECT * FROM {tableName}";
            return mySqlGenericCommandsLFS.Fill(query, new DataTable());
        }

        public DataTable GetRecordsPrintCashposition(DateTime date)
        {
            var parameters = new object[][]
            {
                new object[] { "@date", DbType.DateTime, date}
            };

            string query = $"SELECT {tableName}.id, funds.fund_name, CONCAT({tableName}.fund_name,'(',{tableName}.fund_code,')') AS fund,(SELECT IFNULL(SUM(amount),0) FROM {tableNameBankDeposits} WHERE funds_id={tableName}.id AND date < CAST('@date' AS DATE)) AS beginning,(SELECT IFNULL(SUM(amount),0) FROM {tableNamePaymentCollections} WHERE funds_id={tableName}.id AND payment_date=CAST('@date' AS DATE)) AS collection,(SELECT IFNULL(SUM(amount),0) FROM {tableNameBankDeposits} WHERE funds_id={tableName}.id AND date = CAST('@date' AS DATE)) AS deposited FROM {tableName}";

            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameters = new object[][]
            {
                new object[]{"@search_key", DbType.String, $"%{searchText}%"},
            };

            string query = $"SELECT * FROM {tableName} WHERE fund_code LIKE @search_key OR fund_name LIKE @search_key";

            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
        }

        public bool Insert(FundsModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@fund_name", DbType.String, entity.FundName},
                new object[] { "@fund_code", DbType.String, entity.FundCode},
            };

            string query = $"INSERT INTO {tableName} (fund_code,fund_name) VALUES (@fund_code,@fund_name)";
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Update(FundsModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int16, entity.Id},
                new object[] { "@fund_name", DbType.String, entity.FundName},
                new object[] { "@fund_code", DbType.String, entity.FundCode},
            };

            string query = $"UPDATE {tableName} SET fund_code = @fund_code, fund_name = @fund_name WHERE id = @id";
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Delete(List<FundsModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var entity in entityList)
                {
                    var parameters = new object[][] { new object[] { "@id", DbType.Int16, entity.Id }, };

                    string query = $"DELETE FROM {tableName} WHERE id = @id";
                    _ = mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
                }

                scope.Complete();
                return true;
            }
        }

        public bool IdExist(int id)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, id },
            };

            string query = $"SELECT id FROM {tableName} WHERE id = @id";
            string queryResult = mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);

            return !string.IsNullOrEmpty(queryResult);
        }

        public bool NameExist(string fundName)
        {
            var parameters = new object[][]
            {
                new object[] { "@fund_name", DbType.String, fundName },
            };

            string query = $"SELECT fund_name FROM {tableName} WHERE fund_name = @fund_name";
            string queryResult = mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);

            return !string.IsNullOrEmpty(queryResult);
        }

        public bool NameExist(string fundName, int fundId)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int16, fundId },
                new object[] { "@fund_name", DbType.String, fundName },
            };

            string query = $"SELECT id FROM {tableName} WHERE id <> @id AND fund_name = @fund_name";
            string queryResult = mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);

            return !string.IsNullOrEmpty(queryResult);
        }

        public bool CodeExist(string fundCode)
        {
            var parameters = new object[][]
            {
                new object[] { "@fund_code", DbType.String, fundCode },
            };

            string query = $"SELECT fund_code FROM {tableName} WHERE fund_code = @fund_code";
            string queryResult = mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);

            return string.IsNullOrEmpty(queryResult);
        }

        public bool CodeExist(string fundCode, int fundId)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int16, fundId },
                new object[] { "@fund_code", DbType.String, fundCode },
            };

            string query = $"SELECT fund_code FROM {tableName} WHERE id <> @id AND fund_code = @fund_code";
            string queryResult = mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);

            return !string.IsNullOrEmpty(queryResult);
        }

        public DataTable GetRecords(string searchText, int rowLimit)
        {
            var parameters = new object[][]
            {
                new object[] { "@search_key", DbType.String, $"%{searchText}%"},
                new object[] { "@row_limit", DbType.Int32, rowLimit},
            };

            string query = $"SELECT * FROM {tableName} WHERE (fund_code LIKE @search_key OR fund_name LIKE @search_key) LIMIT @row_limit";
            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
        }
    }
}