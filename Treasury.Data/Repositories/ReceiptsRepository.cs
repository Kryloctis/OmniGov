using OmniGov.Core.Repositories;
using OmniGov.Core.Services;
using System.Data;
using System.Transactions;
using Treasury.Domain.Entities;
using Treasury.Domain.Interfaces;

namespace Treasury.Data.Repositories
{
    public class ReceiptsRepository : IReceiptsRepository
    {
        private readonly string tableName = "receipts";
        private readonly string viewTableName = "view_receipts";
        private GenericCommands mySqlGenericCommands;

        public ReceiptsRepository(GenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public bool Delete(List<ReceiptsModel> entityList)
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
                    _ = mySqlGenericCommands.ExecuteNonQuery(query, parameters);
                }

                scope.Complete();
                return true;
            }
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, Id},
            };

            string query = $"SELECT * FROM {tableName} WHERE {tableName}.id = @id";

            DataTable dataTable = mySqlGenericCommands.ExecuteReader(query, parameters);

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
            string query = $"SELECT id, accountable_forms_id, acc_form_no, acc_form_desc, receipt_number_from, receipt_number_to, received_date, quantity, user AS officer FROM {viewTableName} ORDER BY accountable_forms_id ";

            return mySqlGenericCommands.Fill(query, new DataTable());
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameter = new object[][]
            {
                new object[]{"@searchText", DbType.String, $"%{searchText}%"},
            };

            string query = $"SELECT id, CONCAT(acc_form_no, ' ', acc_form_desc) AS accountable_forms, receipt_number_from, receipt_number_to, received_date, quantity, user AS officer, FROM {viewTableName} WHERE acc_form_no like @searchText OR acc_form_desc LIKE @searchText OR user LIKE @searchText ORDER BY received_date DESC";

            return mySqlGenericCommands.FillBySearch(query, new DataTable(), parameter);
        }

        public bool IdExist(int id)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, id },
            };

            string query = $"SELECT id FROM {tableName} WHERE id = @id";

            // if query is not null, means found some record, so true
            return !string.IsNullOrEmpty(mySqlGenericCommands.ExecuteScalar(query, parameters));
        }

        public int GetMaxReceiptNumberByAccountableFormId(int accountableFormId)
        {
            int value = 0;

            string query = $"SELECT IFNULL(MAX(receipt_number_to), 0) AS receiptno " +
                           $"FROM {tableName} " +
                           $"WHERE accountable_forms_id = {accountableFormId}";

            DataTable dt = mySqlGenericCommands.Fill(query, new DataTable());
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                    value = int.Parse(dt.Rows[i]["receiptno"].ToString());
            }

            return value;
        }

        public int GetMinReceiptNumberByAccountableFormId(int accountableFormId)
        {
            int value = 0;

            string query = $"SELECT IFNULL(MAX(receipt_number_from), 0) AS receiptno " +
                            $"FROM {tableName} " +
                            $"WHERE accountable_forms_id = {accountableFormId}";
            DataTable dt = mySqlGenericCommands.Fill(query, new DataTable());
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                    value = int.Parse(dt.Rows[i]["receiptno"].ToString());
            }

            return value;
        }

        public bool Insert(ReceiptsModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@accountable_forms_id", DbType.Int32, entity.AccountableFormId},
                new object[] { "@receipt_number_from", DbType.Int32, entity.SerialNoFrom},
                new object[] { "@receipt_number_to", DbType.Int32, entity.SerialNoTo},
                new object[] { "@received_date", DbType.Date, entity.ReceiptDate},
                new object[] { "@quantity", DbType.Int32, entity.Quantity},
                new object[] { "@users_id", DbType.Int32, entity.UserId},
                new object[] { "@remarks", DbType.String, entity.Remarks}
            };

            string query = $"INSERT INTO {tableName} (accountable_forms_id, receipt_number_from, receipt_number_to, received_date, quantity, users_id, remarks) VALUES (@accountable_forms_id, @receipt_number_from, @receipt_number_to, @received_date, @quantity, @users_id, @remarks)";
            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(ReceiptsModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.Id},
                new object[] { "@users_id", DbType.Int32, entity.UserId},
                new object[] { "@accountable_forms_id", DbType.Int32, entity.AccountableFormId},
                new object[] { "@receipt_number_from", DbType.Int32, entity.SerialNoFrom},
                new object[] { "@receipt_number_to", DbType.Int32, entity.SerialNoTo},
                new object[] { "@received_date", DbType.Date, entity.ReceiptDate},
                new object[] { "@quantity", DbType.Int32, entity.Quantity},
                new object[] { "@remarks", DbType.String, entity.Remarks}
            };

            string query = $"UPDATE {tableName} SET users_id = @users_id, accountable_forms_id = @accountable_forms_id, receipt_number_from = @receipt_number_from, receipt_number_to = @receipt_number_to, received_date = @received_date, quantity = @quantity, remarks = @remarks WHERE id = @id";

            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool ReceiptNumberInRange(int receiptId, int receiptNumber)
        {
            var parameters = new object[][]
            {
                new object[] { "@receipt_id", DbType.Int32, receiptId },
                new object[] { "@receipt_number", DbType.Int32, receiptNumber }
            };
            string query = $"SELECT id FROM {tableName} WHERE @receipt_number BETWEEN receipt_number_from AND receipt_number_to AND id = @receipt_id";

            string queryResult = mySqlGenericCommands.ExecuteScalar(query, parameters);

            if (string.IsNullOrEmpty(queryResult))
                return false;

            return true;
        }

        public DataTable GetRecordsByDateAndText(DateTime dateReceived, string txtSearch, int rowLimit)
        {
            var parameter = new object[][]
            {
                new object[]{"@received_date", DbType.Date, dateReceived.Date},
                new object[]{"@txt_search", DbType.String, $"%{txtSearch}%"},
                new object[]{"@row_limit", DbType.Int32, rowLimit},
            };

            string query = $"SELECT * FROM {viewTableName} WHERE DATE(received_date) <= @received_date AND (acc_form_desc LIKE @txt_search OR acc_form_no LIKE @txt_search) LIMIT @row_limit";
            return mySqlGenericCommands.FillBySearch(query, new DataTable(), parameter);
        }

        public bool ReceiptNumberExist(int accountableFormID, int receiptNumber)
        {
            var parameters = new object[][]
            {
                new object[] { "@accountable_forms_id", DbType.Int32, accountableFormID },
                new object[] { "@receipt_number", DbType.Int32, receiptNumber },
            };

            string query = $"SELECT id FROM {tableName} WHERE @receipt_number BETWEEN receipt_number_from AND receipt_number_to AND accountable_forms_id = @accountable_forms_id";

            string queryResult = mySqlGenericCommands.ExecuteScalar(query, parameters);

            if (string.IsNullOrEmpty(queryResult))
                return false;

            return true;
        }

        public bool ReceiptNumberExist(int accountableFormID, int receiptNumber, int receiptID)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, receiptID },
                new object[] { "@accountable_forms_id", DbType.Int32, accountableFormID },
                new object[] { "@receipt_number", DbType.Int32, receiptNumber },
            };

            string query = $"SELECT id FROM {tableName} WHERE @receipt_number BETWEEN receipt_number_from AND receipt_number_to AND accountable_forms_id = @accountable_forms_id AND id <> @id ";

            return !string.IsNullOrEmpty(mySqlGenericCommands.ExecuteScalar(query, parameters));
        }

        public DataTable GetViewRecords()
        {
            string query = $"SELECT * FROM {viewTableName}";

            return mySqlGenericCommands.Fill(query, new DataTable());
        }
    }
}

