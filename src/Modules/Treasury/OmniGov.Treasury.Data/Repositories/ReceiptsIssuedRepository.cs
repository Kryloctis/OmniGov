using OmniGov.Core.Entities;
using OmniGov.Core.Interfaces.Services;
using OmniGov.Treasury.Domain.Entities;
using OmniGov.Treasury.Domain.Interfaces;
using System.Data;
using System.Transactions;

namespace OmniGov.Treasury.Data.Repositories
{
    public class ReceiptsIssuedRepository : IReceiptsIssuedRepository
    {
        private readonly string tableName = "receipts_issued";
        private readonly string viewTableName = "view_receipts_issued";
        private readonly IGenericCommands _genericCommands;

        public ReceiptsIssuedRepository(IGenericCommands genericCommands)
        {
            _genericCommands = genericCommands ?? throw new ArgumentNullException(nameof(genericCommands));
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, Id},
            };

            string query = $"SELECT * FROM {viewTableName} WHERE id = @id";
            DataTable dataTable = _genericCommands.ExecuteReader(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                foreach (DataColumn column in dataTable.Columns)
                    recordDictionary[column.ColumnName] = row[column].ToString();

                return recordDictionary;
            }
            return recordDictionary;
        }

        public bool Delete(List<ReceiptsIssuedModel> entityList)
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
                    _ = _genericCommands.ExecuteNonQuery(query, parameters);
                }

                scope.Complete();
                return true;
            }
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT id, collecting_officer_id, collecting_officers_prefix, collecting_officers_first_name, collecting_officers_mid_initial, collecting_officers_last_name, collecting_officers_suffix, job_orders_id, job_orders_prefix, job_orders_first_name, job_orders_mid_initial, job_orders_last_name, job_orders_suffix, acc_form_no, acc_form_desc, accountable_forms, receipt_issued_from, receipt_issued_to, date_issued, quantity, last_issued, is_returned, returned_date, issued_by FROM {viewTableName} ORDER BY date_issued DESC";

            var dataTable = new DataTable();
            return _genericCommands.Fill(query, dataTable);
        }

        public DataTable GetViewRecordsByCollectorId_AccFormId(int collectorId, int accountableFormId)
        {
            var parameter = new object[][] {
                new object[]{"@collector_id", DbType.Int32, collectorId },
                new object[]{"@accountable_form_id", DbType.Int32, accountableFormId }
            };

            string query = $"SELECT id, accountable_forms, receipt_issued_from, receipt_issued_to, date_issued, quantity, last_issued, is_returned, returned_date FROM {viewTableName} WHERE collecting_officer_id = @collector_id AND accountable_form_id = @accountable_form_id AND is_returned = false";

            var dataTable = new DataTable();
            return _genericCommands.FillBySearch(query, dataTable, parameter);
        }

        public DataTable GetViewCollectorsAccountbleForms(int collectingOfficerID, bool collectorIsJO)
        {
            var parameter = new object[][] {
                new object[]{"@collecting_officer_id", DbType.Int32, collectingOfficerID }
            };

            string columnFilter = collectorIsJO ? "job_orders_id" : "ISNULL(job_orders_id) AND collecting_officer_id";

            string query = $"SELECT accountable_form_id, accountable_forms, quantity, receipt_issued_from, receipt_issued_to, last_issued FROM {viewTableName} WHERE is_returned = false AND {columnFilter} = @collecting_officer_id";

            var dataTable = new DataTable();
            return _genericCommands.FillBySearch(query, dataTable, parameter);
        }

        public DataTable GetRecordsBySearch(DateTime dateIssued, string searchText, int rowLimit)
        {
            var parameters = new object[][]
            {
                new object[]{"@searchKey", DbType.String, $"%{searchText}%"},
                new object[]{"@dateIssued", DbType.DateTime, dateIssued.Date},
                new object[]{"@row_limit", DbType.Int32, rowLimit}
            };

            string query = $"SELECT * FROM {viewTableName} WHERE (collecting_officers_first_name LIKE @searchKey OR collecting_officers_last_name LIKE @searchKey OR job_orders_last_name LIKE @searchKey  OR job_orders_first_name LIKE @searchKey OR accountable_forms LIKE @searchKey) AND DATE(date_issued) <= @dateIssued LIMIT @row_limit";

            var dataTable = new DataTable();
            return _genericCommands.FillBySearch(query, dataTable, parameters);
        }

        public bool IdExist(int id)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, id },
            };

            string query = $"SELECT id FROM {tableName} WHERE id = @id";
            string queryResult = _genericCommands.ExecuteScalar(query, parameters);

            if (!string.IsNullOrEmpty(queryResult)) return true;
            return false;
        }

        public bool Insert(ReceiptsIssuedModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@receipts_id", DbType.Int32, entity.ReceiptId},
                new object[] { "@collecting_officers_id", DbType.Int32, entity.CollectorId},
                new object[] { "@job_orders_id", DbType.Int32, entity.JobOrderId},
                new object[] { "@date_issued", DbType.Date, entity.IssuedDate},
                new object[] { "@receipt_issued_from", DbType.Int32, entity.IssuedFrom},
                new object[] { "@receipt_issued_to", DbType.Int32, entity.IssuedTo},
                new object[] { "@quantity", DbType.Int32, entity.Quantity},
                new object[] { "@issued_by", DbType.Int32, entity.IssuedByUserId}
            };

            string query = $"INSERT INTO {tableName} (receipts_id, collecting_officers_id, job_orders_id,  date_issued, receipt_issued_from, receipt_issued_to, quantity, issued_by) VALUES( @receipts_id, @collecting_officers_id, @job_orders_id, @date_issued, @receipt_issued_from, @receipt_issued_to, @quantity, @issued_by)";

            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(ReceiptsIssuedModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.Id},
                new object[] { "@receipts_id", DbType.Int32, entity.ReceiptId},
                new object[] { "@collecting_officers_id", DbType.Int32, entity.CollectorId},
                new object[] { "@date_issued", DbType.Date, entity.IssuedDate},
                new object[] { "@receipt_issued_from", DbType.Int32, entity.IssuedFrom},
                new object[] { "@receipt_issued_to", DbType.Int32, entity.IssuedTo},
                new object[] { "@quantity", DbType.Int32, entity.Quantity}
            };

            string query = $"UPDATE {tableName} SET receipts_id = @receipts_id, collecting_officers_id = @collecting_officers_id, date_issued = @date_issued, receipt_issued_from = @receipt_issued_from, receipt_issued_to = @receipt_issued_to, quantity = @quantity WHERE id = @id";
            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool UpdateReturnedReceipt(ReceiptsIssuedModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.Id},
                new object[] { "@is_returned", DbType.Int32, entity.Is_returned},
                new object[] { "@returned_date", DbType.Date, entity.Returned_date}
            };

            string query = $"UPDATE {tableName} SET is_returned = @is_returned, returned_date = @returned_date WHERE id = @id";
            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool UpdateLastIssued(ReceiptsIssuedModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.Id},
                new object[] { "@last_issued", DbType.Int32, entity.Last_issued}
            };

            string query = $"UPDATE {tableName} SET last_issued = @last_issued WHERE id = @id";
            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public DataTable GettAccFormByCOid(string collectingOfficerId)
        {
            var parameters = new object[][]
            {
                new object[] {"@collecting_officer_id", DbType.String, collectingOfficerId}
            };

            var query = $"SELECT * FROM {viewTableName} WHERE collecting_officer_id = @collecting_officer_id";

            var dataTable = new DataTable();
            return _genericCommands.FillBySearch(query, dataTable, parameters);
        }

        public DataTable GetReturnedReceipts()
        {
            string query = $"SELECT receipts_id, accountable_form_id, accountable_forms, collecting_officer_id, CONCAT(collecting_officers_first_name, ' ', collecting_officers_mid_initial, '. ', collecting_officers_last_name) AS collecting_officer, date_issued, IF(receipt_issued_from = 0 AND receipt_issued_from = 0, NULL, LPAD(receipt_issued_from, 7, 0)) AS receipt_issued_from, IF(receipt_issued_to = 0 AND receipt_issued_to = 0, NULL, LPAD(receipt_issued_to, 7, 0)) AS receipt_issued_to, quantity, last_issued, IF(is_returned = 1, (receipt_issued_to - last_issued), null) AS returned_quantity, returned_date FROM {viewTableName} WHERE is_returned = 1";

            var dataTable = new DataTable();
            return _genericCommands.Fill(query, dataTable);
        }

        public DataTable GetReturnedReceiptsBySearch(string searchKey)
        {
            var parameter = new object[][] {
                new object[]{"@searchKey", DbType.String, $"%{searchKey}%"}
            };

            string query = $"SELECT receipts_id, accountable_form_id, accountable_forms, collecting_officer_id, CONCAT(collecting_officers_first_name, ' ', collecting_officers_mid_initial, '. ', collecting_officers_last_name) AS collecting_officer, date_issued, receipt_issued_from, receipt_issued_to, quantity, last_issued, IF(is_returned = 1, (receipt_issued_to - last_issued), null) AS returned_quantity, returned_date FROM {viewTableName} WHERE is_returned = 1 AND collecting_officers_first_name LIKE @searchKey OR collecting_officers_last_name LIKE @searchKey OR accountable_forms LIKE @searchkey";

            var dataTable = new DataTable();
            return _genericCommands.FillBySearch(query, dataTable, parameter);
        }

        public int GetTotalIssuedReceiptByReceiptId(int receiptId)
        {
            var parameter = new object[][] {
                new object[]{ "@receipt_id", DbType.Int32, receiptId}
            };

            string query = $"SELECT COALESCE(SUM(quantity), 0) AS total_issued FROM {tableName} WHERE receipts_id = @receipt_id";
            return Convert.ToInt32(_genericCommands.ExecuteScalar(query, parameter));
        }

        public bool ReceiptAvailabilityByQuantity(int receiptId, int receiptQuantity)
        {
            var parameters = new object[][] {
                new object[]{ "@receipt_id", DbType.Int32, receiptId},
                new object[]{ "@receipt_quantity", DbType.Int32, receiptQuantity }
            };

            string query = $"SELECT COALESCE(SUM(quantity), 0) FROM view_receipts_issued " +
                           $"WHERE is_returned = false AND receipts_id = @receipt_id";

            int queryResult = int.Parse(_genericCommands.ExecuteScalar(query, parameters));

            return receiptQuantity > queryResult;
        }

        public bool CollectingOfficerHasReceiptAssigned(int id)
        {
            var parameters = new object[][]
            {
                new object[] { "@collecting_officer_id", DbType.Int32, id },
            };

            string query = $"SELECT id FROM {tableName} WHERE collecting_officers_id = @collecting_officer_id OR job_orders_id = @collecting_officer_id";
            string queryResult = _genericCommands.ExecuteScalar(query, parameters);

            if (!string.IsNullOrEmpty(queryResult)) return true;

            return false;
        }

        public bool ReceiptHasIssuance(int receiptId)
        {
            var parameters = new object[][]
            {
                new object[] { "@receipts_id", DbType.Int32, receiptId },
            };

            string query = $"SELECT id FROM {tableName} WHERE receipts_id = @receipts_id";
            string queryResult = _genericCommands.ExecuteScalar(query, parameters);

            if (!string.IsNullOrEmpty(queryResult)) return true;

            return false;
        }

        public DataTable GetAccountabilityForAccountableForms(DateTime date)
        {
            var parameter = new object[][]
            {
                new object[]{"@date_issued", DbType.DateTime2, date}
            };

            string query = $"SELECT * FROM {viewTableName}";

            var dataTable = new DataTable();
            return _genericCommands.FillBySearch(query, dataTable, parameter);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameter = new object[][] {
                new object[]{"@searchKey", DbType.String, $"%{searchText}%" }
            };

            string query = $"SELECT id, collecting_officer_id, collecting_officers_prefix, collecting_officers_first_name, collecting_officers_mid_initial, collecting_officers_last_name, collecting_officers_suffix, job_orders_id, job_orders_prefix, job_orders_first_name, job_orders_mid_initial, job_orders_last_name, job_orders_suffix, acc_form_no, acc_form_desc, accountable_forms, receipt_issued_from, receipt_issued_to, date_issued, quantity, last_issued, is_returned, returned_date, issued_by FROM {viewTableName} WHERE (collecting_officers_last_name LIKE @searchKey OR job_orders_last_name LIKE @searchKey) OR accountable_forms LIKE @searchKey ORDER BY date_issued DESC";

            var dataTable = new DataTable();
            return _genericCommands.FillBySearch(query, dataTable, parameter);
        }

        public bool ReceiptNumberInRange(int receiptId, int receiptNumber)
        {
            var parameters = new object[][]
            {
                new object[] { "@receipt_id", DbType.Int32, receiptId },
                new object[] { "@receipt_number", DbType.Int32, receiptNumber }
            };

            string query = $"SELECT id FROM {tableName} WHERE @receipt_number BETWEEN receipt_issued_from AND receipt_issued_to AND receipts_id = @receipt_id";

            string queryResult = _genericCommands.ExecuteScalar(query, parameters);

            if (string.IsNullOrEmpty(queryResult))
                return true;

            return false;
        }

        public bool ReceiptNumberInRange(int receiptId, int receiptNumber, int receiptIssuedId)
        {
            var parameters = new object[][]
            {
                new object[] { "@receipt_id", DbType.Int32, receiptId },
                new object[] { "@receipt_number", DbType.Int32, receiptNumber },
                new object[] { "@id", DbType.Int32, receiptIssuedId }
            };

            string query = $"SELECT id FROM {tableName} WHERE @receipt_number BETWEEN receipt_issued_from AND receipt_issued_to AND receipts_id = @receipt_id AND id <> @id";

            string queryResult = _genericCommands.ExecuteScalar(query, parameters);

            if (string.IsNullOrEmpty(queryResult))
                return false;

            return true;
        }

        public Dictionary<string, string> GetViewRecordReceiptId(int receiptID)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@receipts_id", DbType.Int32, receiptID},
            };

            string query = $"SELECT * FROM {viewTableName} WHERE receipts_id = @receipts_id";

            DataTable dataTable = _genericCommands.ExecuteReader(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                foreach (DataColumn column in dataTable.Columns)
                    recordDictionary[column.ColumnName] = row[column].ToString();

                return recordDictionary;
            }
            return recordDictionary;
        }

        public Dictionary<string, string> GetViewRcdRecord(AccountableFormsModel accountableFormsModel, UsersModel usersModel)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@accountable_form_id", DbType.Int32, accountableFormsModel.Id },
                new object[] { "@users_id", DbType.Int32, usersModel.Id }
            };

            string query = $"SELECT collecting_officer_id, MIN(receipt_issued_from) AS receipt_issued_from, MAX(receipt_issued_to) AS receipt_issued_to FROM {viewTableName} WHERE accountable_form_id = @accountable_form_id AND co_users_id = @users_id GROUP BY accountable_form_id";

            DataTable dataTable = _genericCommands.ExecuteReader(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                foreach (DataColumn column in dataTable.Columns)
                    recordDictionary[column.ColumnName] = row[column].ToString();

                return recordDictionary;
            }
            return recordDictionary;
        }
    }
}
