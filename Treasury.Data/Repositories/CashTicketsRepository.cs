using OmniGov.Core.Repositories;
using System.Data;
using System.Transactions;
using Treasury.Domain.Entities;
using Treasury.Domain.Interfaces;

namespace Treasury.Data.Repositories
{
    internal class CashTicketsRepository : ICashTicketsRepository
    {
        private readonly string tableName = "cash_tickets";
        private GenericCommands mySqlGenericCommandsLFS;

        public CashTicketsRepository(GenericCommands mySqlGenericCommandsLFS)
        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommandsLFS ?? throw new ArgumentNullException(nameof(mySqlGenericCommandsLFS));
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {tableName}";
            return mySqlGenericCommandsLFS.Fill(query, new DataTable());
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][] { new object[] { "@id", DbType.Int32, Id } };
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

        public bool Insert(CashTicketsModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@description", DbType.String, entity.Description},
                new object[] { "@quantity", DbType.Int32, entity.Quantity},
                new object[] { "@received_date", DbType.Date, entity.ReceivedDate},
                new object[] { "@remarks", DbType.String, entity.Remarks},
            };

            string query = $"INSERT INTO {tableName} (description, quantity,  received_date, remarks) VALUES(@description, @quantity,  @received_date, @remarks)";

            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Update(CashTicketsModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.Id},
                new object[] { "@description", DbType.String, entity.Description},
                new object[] { "@quantity", DbType.Int32, entity.Quantity},
                new object[] { "@received_date", DbType.Date, entity.ReceivedDate},
                new object[] { "@remarks", DbType.String, entity.Remarks},
            };

            string query = $"UPDATE {tableName} SET  description = @description, quantity = @quantity, received_date = @received_date, remarks = @remarks WHERE id = @id;";
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Delete(List<CashTicketsModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var entity in entityList)
                {
                    var parameters = new object[][]
                    {
                        new object[] { "@id", DbType.Int32, entity.Id},
                    };

                    string query = $"DELETE FROM {tableName} WHERE id = @id";
                    _ = mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
                }

                scope.Complete();
                return true;
            }
        }

        public DataTable GetRecordsBySearch(DateTime dateReceived, string txtSearch, int rowLimit)
        {
            var parameter = new object[][]
            {
                new object[]{"@received_date", DbType.Date, dateReceived.Date},
                new object[]{"@searchTxt", DbType.String, $"%{txtSearch}%"},
                new object[]{"@row_limit", DbType.Int32, rowLimit},
            };

            string query = $"SELECT * FROM {tableName} WHERE DATE(received_date) <= @received_date AND (description LIKE @searchTxt) LIMIT @row_limit";

            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameter);
        }
    }
}