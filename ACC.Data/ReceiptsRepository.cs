using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;
using ACC.Domain.Interfaces;
using ACC.Domain.Models;

namespace ACC.Data
{
    public class ReceiptsRepository : IReceiptsRepository
    {
        private readonly IDbGenericCommands _dbGenericCommands;
        private readonly string tableName = "receipts";
        private readonly string viewTableName = "view_receipts";
        private readonly string tableReceiptsIssued = "receipts_issued";

        public ReceiptsRepository(IDbGenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
        }

        public int CountRecords()
        {
            try
            {
                string query = $"SELECT COUNT(*) FROM {tableName}";

                return int.Parse(_dbGenericCommands.ExecuteScalar(query));
            }
            catch (Exception)
            {
                throw;
            }
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

            try
            {
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
            }
            catch (Exception)
            {
                throw;
            }

            return record;
        }

        public DataTable GetRecords()
        {
            string query  = $"SELECT " +
                            $"id, " +
                            $"CONCAT(acc_form_no, ' - ', acc_form_desc) receipt, " +
                            $"LPAD(receipt_number_from, 7, 0) AS receipt_number_from, " +
                            $"LPAD(receipt_number_to, 7, 0) AS receipt_number_to, " +
                            $"received_date, " +
                            $"quantity, " +
                            $"user officer " +
                            $"FROM {viewTableName} " +
                            $"ORDER BY accountable_forms_id ";

            var dtri = new DataTable();
            return _dbGenericCommands.Fill(query, dtri);
        }

        public DataTable GetReceipts()
        {
            string query = $"SELECT " +
                           $"id, " +
                           $"CONCAT(acc_form_no, ' - ', acc_form_desc, ' (' , receipt_number_from , '-' , receipt_number_to , ')') receipt, " +
                           $"receipt_number_from, " +
                           $"receipt_number_to, " +
                           $"received_date, " +
                           $"quantity, " +
                           $"user officer " +
                           $"FROM {viewTableName} " +
                           $"ORDER BY accountable_forms_id";

            var dtri = new DataTable();
            return _dbGenericCommands.Fill(query, dtri);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameter = new object[][] {
                new object[]{"@searchText", DbType.String, $"%{searchText}%"},
            };

            string query =      $"SELECT " +
                                $"id, " +
                                $"CONCAT(acc_form_no, ' - ', acc_form_desc) receipt, " +
                                $"receipt_number_from, " +
                                $"receipt_number_to, " +
                                $"received_date, " +
                                $"quantity, " +
                                $"user officer " +
                                $"FROM {viewTableName} " +
                                $"WHERE acc_form_desc LIKE @searchText " +
                                $"OR acc_form_no LIKE @searchText " +
                                $"OR user LIKE @searchText " +
                                $"ORDER BY received_date DESC";

            var dtri = new DataTable();
            return _dbGenericCommands.FillBySearch(query, dtri, parameter);
       
        }

        public bool IdExist(int id)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, id },
                };

                string query = $"SELECT id FROM {tableName} WHERE id = @id";
                string queryResult = _dbGenericCommands.ExecuteScalar(query, parameters);

                // if query is not null, means found some record, so true
                if (!string.IsNullOrEmpty(queryResult)) return true;
            }
            catch (Exception)
            {
                throw;
            };

            return false;
        }


        //TRANSFER THIS METHOD TO RECEIPT ISSUED REPO.
        public bool ReceiptsIssued(int id)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, id },
            };

            string query = $"SELECT id FROM {tableReceiptsIssued} WHERE receipts_id = @id";
            string queryResult = _dbGenericCommands.ExecuteScalar(query, parameters);

            if (!string.IsNullOrEmpty(queryResult)) return true;
        
            return false;
        }

        public bool AllowEdit(int id)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, id },
                };

                string query = $"SELECT {tableName}.id " +
                               $"FROM {tableName} LEFT JOIN {tableReceiptsIssued} ON {tableName}.id={tableReceiptsIssued}.receipts_id " +
                               $"WHERE ({tableReceiptsIssued}.receipt_issued_from AND {tableReceiptsIssued}.receipt_issued_to BETWEEN {tableName}.receipt_number_from AND {tableName}.receipt_number_to) AND {tableName}.id=@id";
                string queryResult = _dbGenericCommands.ExecuteScalar(query, parameters);

                // if query is not null, means found some record, so true
                if (!string.IsNullOrEmpty(queryResult)) return true;
            }
            catch (Exception)
            {
                throw;
            };

            return false;
        }

        public int GetMaxReceiptNumberByAccountableFormId(int accountableFormId)
        {
            int value = 0;          

            string query = $"SELECT IFNULL(MAX(receipt_number_to), 0) AS receiptno " +
                           $"FROM {tableName} " +
                           $"WHERE accountable_forms_id = {accountableFormId}";

            DataTable dt = _dbGenericCommands.Fill(query,new DataTable());
            if(dt.Rows.Count > 0)
            {
                for(int i=0;i < dt.Rows.Count; i++)
                    value = int.Parse(dt.Rows[i]["receiptno"].ToString());
            }
         
            return value;
        }

        public int GetMinReceiptNumberByAccountableFormId(int accountableFormId)
        {
            int value = 0;
           
            string query  = $"SELECT IFNULL(MAX(receipt_number_from), 0) AS receiptno " +
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

        public bool ReceiptConsumed(int id)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, id },
            };

            string query =  $"SELECT * FROM {tableName} " +
                            $"WHERE " +
                            $"id = @id AND receipt_number_to = (SELECT SUM(IF(IFNULL(last_issued,0) > 0, " +
                            $"receipt_issued_to - last_issued,0)) " +
                            $"FROM {tableReceiptsIssued} " +
                            $"WHERE receipts_id = id AND IF(IFNULL(is_returned, true), false, true) = false)";

            string queryResult = _dbGenericCommands.ExecuteScalar(query, parameters);

            if (!string.IsNullOrEmpty(queryResult)) 
                return true;

            return false;
        }

        public bool Insert(ReceiptsModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@users_id", DbType.Int32, entity.UserId},
                    new object[] { "@accountable_forms_id", DbType.Int32, entity.AccId},
                    new object[] { "@receipt_number_from", DbType.Int32, entity.SerialNoFrom},
                    new object[] { "@receipt_number_to", DbType.Int32, entity.SerialNoTo},
                    new object[] { "@received_date", DbType.Date, entity.ReceiptDate},
                    new object[] { "@quantity", DbType.Int32, entity.Quantity},
                    new object[] { "@remarks", DbType.String, entity.Remarks}
                };

                string query =  $"INSERT INTO {tableName} " +
                                $"(users_id, " +
                                $"accountable_forms_id, " +
                                $"receipt_number_from, " +
                                $"receipt_number_to, " +
                                $"received_date, " +
                                $"quantity, " +
                                $"remarks) " +
                                $"VALUES " +
                                $"(@users_id, " +
                                $"@accountable_forms_id, " +
                                $"@receipt_number_from, " +
                                $"@receipt_number_to, " +
                                $"@received_date, " +
                                $"@quantity, " +
                                $"@remarks)";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(ReceiptsModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.Id},
                new object[] { "@users_id", DbType.Int32, entity.UserId},
                new object[] { "@accountable_forms_id", DbType.Int32, entity.AccId},
                new object[] { "@receipt_number_from", DbType.Int32, entity.SerialNoFrom},
                new object[] { "@receipt_number_to", DbType.Int32, entity.SerialNoTo},
                new object[] { "@received_date", DbType.Date, entity.ReceiptDate},
                new object[] { "@quantity", DbType.Int32, entity.Quantity},
                new object[] { "@remarks", DbType.String, entity.Remarks}
            };

            string query =  $"UPDATE {tableName} SET " +
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

        public int GetReceiptNumberFromByReceiptId(int receiptId)
        {
            var parameter = new object[][] {
                new object[]{ "@receipt_id", DbType.Int32, receiptId}
            };

            string query = $"SELECT " +
                           $"receipt_number_from " +
                           $"FROM {tableName} " +
                           $"WHERE id = @receipt_id";

            return int.Parse(_dbGenericCommands.ExecuteScalar(query, parameter));
        }

        public bool IsReceiptBetweenFromAndTo(int receiptId, int receiptNumberFrom, int receiptNumberTo)
        {
            var parameters = new object[][]
            {
                new object[] { "@receipt_number_from", DbType.Int32, receiptNumberFrom },
                new object[] { "@receipt_number_to", DbType.Int32, receiptNumberTo },
                new object[] { "@receipt_id", DbType.Int32, receiptId }
            };
            string query = $"SELECT id " +
                           $"FROM {tableName} " +
                           $"WHERE receipt_number_from <= @receipt_number_from AND receipt_number_to >= @receipt_number_to AND id = @receipt_id";

            string queryResult = _dbGenericCommands.ExecuteScalar(query, parameters);

            if (string.IsNullOrEmpty(queryResult)) 
                return false;

            return true;
        }
    }
}
