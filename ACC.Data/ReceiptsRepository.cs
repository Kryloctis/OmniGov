using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    public class ReceiptsRepository : IReceiptsRepository
    {
        private readonly IAccGenericCommands _dbGenericCommands;
        private readonly string tableName = "receipts";
        private readonly string viewTableName = "view_receipts";

        public ReceiptsRepository(IAccGenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
        }

        public int CountRecords()
        {
            string query = $"SELECT COUNT(*) FROM {tableName}";

            return int.Parse(_dbGenericCommands.ExecuteScalar(query));

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
                    _ = _dbGenericCommands.ExecuteNonQuery(query, parameters);
                }

                scope.Complete();
                return true;
            }
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var record = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                    new object[] { "@id", DbType.Int32, Id},
            };

            string query = $"SELECT * FROM {tableName} WHERE {tableName}.id = @id";

            using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return record;

                record.Add("id", reader.Rows[0]["id"].ToString());
                record.Add("receipt_number_from", reader.Rows[0]["receipt_number_from"].ToString());
                record.Add("receipt_number_to", reader.Rows[0]["receipt_number_to"].ToString());
                record.Add("received_date", reader.Rows[0]["received_date"].ToString());
                record.Add("quantity", reader.Rows[0]["quantity"].ToString());
                record.Add("remarks", reader.Rows[0]["remarks"].ToString());
                record.Add("users_id", reader.Rows[0]["users_id"].ToString());
                record.Add("accountable_forms_id", reader.Rows[0]["accountable_forms_id"].ToString());
            }

            return record;
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT id, accountable_forms_id, acc_form_no, acc_form_desc, receipt_number_from, receipt_number_to, received_date, quantity, user AS officer FROM {viewTableName} ORDER BY accountable_forms_id ";

            var dtri = new DataTable();
            return _dbGenericCommands.Fill(query, dtri);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameter = new object[][] {
                new object[]{"@searchText", DbType.String, $"%{searchText}%"},
            };

            string query = $"SELECT id, CONCAT(acc_form_no, ' ', acc_form_desc) AS accountable_forms, receipt_number_from, receipt_number_to, received_date, quantity, user AS officer, FROM {viewTableName} WHERE acc_form_no like @searchText OR acc_form_desc LIKE @searchText OR user LIKE @searchText ORDER BY received_date DESC";

            var dtri = new DataTable();
            return _dbGenericCommands.FillBySearch(query, dtri, parameter);
        }

        public bool IdExist(int id)
        {
            var parameters = new object[][]
            {
                    new object[] { "@id", DbType.Int32, id },
            };

            string query = $"SELECT id FROM {tableName} WHERE id = @id";
            string queryResult = _dbGenericCommands.ExecuteScalar(query, parameters);

            // if query is not null, means found some record, so true
            if (!string.IsNullOrEmpty(queryResult)) return true;

            return false;
        }

        public int GetMaxReceiptNumberByAccountableFormId(int accountableFormId)
        {
            int value = 0;

            string query = $"SELECT IFNULL(MAX(receipt_number_to), 0) AS receiptno " +
                           $"FROM {tableName} " +
                           $"WHERE accountable_forms_id = {accountableFormId}";

            DataTable dt = _dbGenericCommands.Fill(query, new DataTable());
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
            DataTable dt = _dbGenericCommands.Fill(query, new DataTable());
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
            return _dbGenericCommands.ExecuteNonQuery(query, parameters);
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

            string query = $"UPDATE {tableName} SET " +
                            $"users_id = @users_id, " +
                            $"accountable_forms_id = @accountable_forms_id, " +
                            $"receipt_number_from = @receipt_number_from, " +
                            $"receipt_number_to = @receipt_number_to, " +
                            $"received_date = @received_date, " +
                            $"quantity = @quantity, " +
                            $"remarks = @remarks " +
                            $"WHERE id = @id";

            return _dbGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool ReceiptInRange(int receiptId, int receiptNumberFrom, int receiptNumberTo)
        {
            var parameters = new object[][]
            {
                new object[] { "@receipt_number_from", DbType.Int32, receiptNumberFrom },
                new object[] { "@receipt_number_to", DbType.Int32, receiptNumberTo },
                new object[] { "@receipt_id", DbType.Int32, receiptId }
            };
            string query = $"SELECT id FROM {tableName} WHERE receipt_number_from <= @receipt_number_from AND receipt_number_to >= @receipt_number_to AND id = @receipt_id";

            string queryResult = _dbGenericCommands.ExecuteScalar(query, parameters);

            if (string.IsNullOrEmpty(queryResult))
                return false;

            return true;
        }

        public DataTable GetRecordsByDateAndText(DateTime dateReceived, string txtSearch)
        {
            var parameter = new object[][] {
                new object[]{"@received_date", DbType.Date, dateReceived},
                new object[]{"@received_date_month", DbType.Byte, dateReceived.Month},
                new object[]{"@received_date_year", DbType.Int16, dateReceived.Year},
                new object[]{"@txt_search", DbType.String, $"%{txtSearch}%"},
            };

            string query = $"SELECT id, accountable_forms_id, acc_form_no, acc_form_desc, receipt_number_from, receipt_number_to, received_date, quantity, user AS officer FROM {viewTableName} WHERE (received_date = @received_date OR MONTH(received_date) = @received_date_month) AND YEAR(received_date) = @received_date_year AND acc_form_desc LIKE @txt_search";

            var dtReceipts = new DataTable();
            return _dbGenericCommands.FillBySearch(query, dtReceipts, parameter);
        }

        public bool ReceiptNumberExist(int accountableFormID, int receiptNumber)
        {
            var parameters = new object[][]
            {
                new object[] { "@accountable_forms_id", DbType.Int32, accountableFormID },
                new object[] { "@receipt_number", DbType.Int32, receiptNumber },
            };

            string query = $"SELECT id FROM {tableName} WHERE @receipt_number BETWEEN receipt_number_from AND receipt_number_to AND accountable_forms_id = @accountable_forms_id";

            string queryResult = _dbGenericCommands.ExecuteScalar(query, parameters);

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

            string queryResult = _dbGenericCommands.ExecuteScalar(query, parameters);

            if (string.IsNullOrEmpty(queryResult))
                return false;

            return true;
        }
    }
}