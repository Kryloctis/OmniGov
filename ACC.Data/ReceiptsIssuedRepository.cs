using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;
using ACC.Domain.Interfaces;
using ACC.Domain.Models;

namespace ACC.Data
{
    public class ReceiptsIssuedRepository:IReceiptsIssuedRepository
    {
        private readonly IDbGenericCommands _dbGenericCommands;
        private readonly string tableName = "receipts_issued";
        private readonly string viewTableName = "view_receipts_issued";

        public ReceiptsIssuedRepository(IDbGenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
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

                string query = $"SELECT * FROM {tableName} id = @id";

                using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;

                    record.Add("id", reader.Rows[0]["id"].ToString());
                    record.Add("receipts_id", reader.Rows[0]["receipts_id"].ToString());
                    record.Add("quantity", reader.Rows[0]["quantity"].ToString());
                    record.Add("last_issued", reader.Rows[0]["last_issued"].ToString());
                    record.Add("collecting_officers_id", reader.Rows[0]["collecting_officers_id"].ToString());
                    record.Add("is_returned", reader.Rows[0]["is_returned"].ToString());
                    record.Add("returned_date", reader.Rows[0]["returned_date"].ToString());
                    record.Add("date_issued", reader.Rows[0]["date_issued"].ToString());
                    record.Add("issuefrom", reader.Rows[0]["issuefrom"].ToString());
                    record.Add("issueto", reader.Rows[0]["issueto"].ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }

            return record;
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

        public bool Delete(List<ReceiptsIssuedModel> entityList)
        {
            try
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
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetRecords()
        {
            string query =  $"SELECT  " +
                            $"id, " +
                            $"collecting_officer_id, " +
                            $"collecting_officers_prefix, " +
                            $"collecting_officers_first_name, " +
                            $"collecting_officers_mid_initial, " +
                            $"collecting_officers_last_name, " +
                            $"collecting_officers_suffix, " +
                            $"job_orders_id, " +
                            $"job_orders_prefix, " +
                            $"job_orders_first_name, " +
                            $"job_orders_mid_initial, " +
                            $"job_orders_last_name, " +
                            $"job_orders_suffix, " +
                            $"accountable_forms, " +
                            $"receipt_issued_from, " +
                            $"receipt_issued_to, " +
                            $"date_issued,  " +
                            $"quantity,  " +
                            $"last_issued,  " +
                            $"IF(IFNULL(is_returned,0) > 0, 'Yes', 'No') AS returned,  " +
                            $"returned_date,  " +
                            $"issued_by  " +
                            $"FROM {viewTableName} " +
                            $"ORDER BY date_issued DESC";

                
            var dtri = new DataTable();
            return _dbGenericCommands.Fill(query, dtri);
        }

        public DataTable GetIssuedReceiptToCollector(int collectorId, int accountableFormId)
        {
            var parameter = new object[][] {
                new object[]{"@collecting_officer_id", DbType.Int32, collectorId },
                new object[]{"@accountable_form_id", DbType.Int32, accountableFormId }
            };

            string query = $"SELECT " +  
                           $"id, " +
                           $"accountable_forms, " +
                           $"receipt_issued_from, " +
                           $"receipt_issued_to, " +
                           $"date_issued, " +
                           $"quantity, " +
                           $"last_issued, " +
                           $"is_returned, " +
                           $"returned_date " +
                           $"FROM {viewTableName} " +
                           $"WHERE " +
                           $"(collecting_officer_id = @collecting_officer_id OR job_orders_id = @collecting_officer_id) " +
                           $"AND " +
                           $"accountable_form_id = @accountable_form_id AND " +
                           $"IF(receipt_issued_to = last_issued, true, false) = false";

            var dtReceiptIssued = new DataTable();
            return _dbGenericCommands.FillBySearch(query, dtReceiptIssued, parameter);
        }

        public DataTable GetCollectorsAccountbleForms(int collectingOfficerID, bool collectorIsJO)
        {
            var parameter = new object[][] {
                new object[]{"@collecting_officer_id", DbType.Int32, collectingOfficerID }
            };

            string columnFilter = collectorIsJO ? "job_orders_id" : "ISNULL(job_orders_id) AND collecting_officer_id";

            string query = $"SELECT accountable_form_id, accountable_forms, quantity, receipt_issued_from, receipt_issued_to, last_issued FROM {viewTableName} WHERE is_returned = false AND {columnFilter} = @collecting_officer_id";

            var dataTable = new DataTable();
            return _dbGenericCommands.FillBySearch(query, dataTable, parameter);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameter = new object[][] { 
                new object[]{"@searchKey", DbType.String, $"%{searchText}%"},
            };

            string query = $"SELECT  " +
                            $"id, " +
                            $"collecting_officer_id, " +
                            $"collecting_officers_prefix, " +
                            $"collecting_officers_first_name, " +
                            $"collecting_officers_mid_initial, " +
                            $"collecting_officers_last_name, " +
                            $"collecting_officers_suffix, " +
                            $"job_orders_id, " +
                            $"job_orders_prefix, " +
                            $"job_orders_first_name, " +
                            $"job_orders_mid_initial, " +
                            $"job_orders_last_name, " +
                            $"job_orders_suffix, " +
                            $"accountable_forms, " +
                            $"receipt_issued_from, " +
                            $"receipt_issued_to,  " +
                            $"date_issued,  " +
                            $"quantity,  " +
                            $"last_issued,  " +
                            $"IF(IFNULL(is_returned,0) > 0,'Yes','No') AS returned,  " +
                            $"returned_date,  " +
                            $"issued_by  " +
                            $"FROM {viewTableName} " +
                            $"WHERE " +
                            $"collecting_officers_last_name LIKE @searchKey OR " +
                            $"collecting_officers_first_name LIKE @searchKey OR " +
                            $"job_orders_first_name LIKE @searchKey OR " +
                            $"job_orders_last_name LIKE @searchKey OR " +
                            $"accountable_forms LIKE @searchKey " +
                            $"ORDER BY date_issued DESC ";

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

        public bool Insert(ReceiptsIssuedModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@receipts_id", DbType.Int32, entity.ReceiptId},
                    new object[] { "@collecting_officers_id", DbType.Int32, entity.CollectorId},
                    new object[] { "@job_orders_id", DbType.Int32, entity.JobOrderId},
                    new object[] { "@date_issued", DbType.Date, entity.Issued},
                    new object[] { "@receipt_issued_from", DbType.Int32, entity.IssuedFrom},
                    new object[] { "@receipt_issued_to", DbType.Int32, entity.IssuedTo},
                    new object[] { "@quantity", DbType.Int32, entity.Quantity},
                    new object[] { "@issued_by", DbType.Int32, entity.IssuedByUserId}
                };

                string query = $"INSERT INTO {tableName} " +
                               $"(receipts_id, collecting_officers_id, job_orders_id,  date_issued, receipt_issued_from, receipt_issued_to, quantity, issued_by) " +
                               $"VALUES( " +
                               $"@receipts_id, " +
                               $"@collecting_officers_id, " +
                               $"@job_orders_id, " +
                               $"@date_issued, " +
                               $"@receipt_issued_from, " +
                               $"@receipt_issued_to, " +
                               $"@quantity, " +
                               $"@issued_by)";

                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(ReceiptsIssuedModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, entity.Id},
                    new object[] { "@receipts_id", DbType.Int32, entity.ReceiptId},
                    new object[] { "@collecting_officers_id", DbType.Int32, entity.CollectorId},
                    new object[] { "@date_issued", DbType.Date, entity.Issued},
                    new object[] { "@issuefrom", DbType.Int32, entity.IssuedFrom},
                    new object[] { "@issueto", DbType.Int32, entity.IssuedTo},
                    new object[] { "@quantity", DbType.Int32, entity.Quantity}
                };

                string query = $"UPDATE {tableName} SET receipts_id=@receipts_id,collecting_officers_id=@collecting_officers_id,date_issued=@date_issued,issuefrom=@issuefrom,issueto=@issueto,quantity=@quantity WHERE id = @id";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }        

        public bool UpdateReturnedReceipt(ReceiptsIssuedModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.Id},
                new object[] { "@is_returned", DbType.Int32, entity.Is_returned},
                new object[] { "@returned_date", DbType.Date, entity.Returned_date}
            };

            string query = $"UPDATE {tableName} SET is_returned=@is_returned,returned_date=@returned_date WHERE id = @id";
            return _dbGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool UpdateLastIssued(ReceiptsIssuedModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.Id},
                new object[] { "@last_issued", DbType.Int32, entity.Last_issued}
            };

            string query = $"UPDATE {tableName} SET last_issued = @last_issued WHERE id = @id";
            return _dbGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public DataTable GetAccountabilityForAccountableForms(string collectingOfficerId)
        {
            var parameter = new object[][] {
                new object[]{"@collecting_officer_id", DbType.String, collectingOfficerId}
            };
            //string query =  $"SELECT " +
            //                $"accountable_form_id, " +
            //                $"accountable_forms, " +
            //                $"(MAX(receipt_issued_to) - MIN(receipt_issued_from) + 1) quantity, " +
            //                $"LPAD(MIN(receipt_issued_from), 7, 0) receipt_issued_from, " +
            //                $"LPAD(MAX(receipt_issued_to), 7, 0)  receipt_issued_to, " +
            //                $"((receipt_issued_to - receipt_issued_from) + 1) issue_quantity, " +
            //                $"LPAD(receipt_issued_from, 7, 0) , " +
            //                $"LPAD(receipt_issued_to, 7, 0) , " +
            //                $"(receipt_issued_to - last_issued) ending_balance_quantity, " +
            //                $"LPAD((last_issued + 1), 7, 0) ending_balance_serial_from, " +
            //                $"LPAD(receipt_issued_to, 7, 0) ending_balance_serial_to " +
            //                $"FROM {viewTableName} " +
            //                $"WHERE " +
            //                $"collecting_officer_id = @collecting_officer_id " +
            //                $"GROUP BY collecting_officer_id";

            var query = $"SELECT accountable_form_id, accountable_forms, receipt_issued_from, receipt_issued_to, quantity, last_issued FROM {viewTableName} WHERE collecting_officer_id = @collecting_officer_id GROUP BY collecting_officer_id";

            var dt = new DataTable();
            return _dbGenericCommands.FillBySearch(query, dt, parameter);
           
        }

        public DataTable GetReturnedReceipts()
        {
            string query = $"SELECT " +
                           $"receipts_id, " +
                           $"accountable_form_id, " +
                           $"accountable_forms, " +
                           $"collecting_officer_id, " +
                           $"collecting_officer, " +
                           $"date_issued, " +
                           $"IF(receipt_issued_from = 0 AND receipt_issued_from = 0, NULL, LPAD(receipt_issued_from, 7, 0)) AS receipt_issued_from, " +
                           $"IF(receipt_issued_to = 0 AND receipt_issued_to = 0, NULL, LPAD(receipt_issued_to, 7, 0)) AS receipt_issued_to, " +
                           $"quantity, " +
                           $"last_issued, " +
                           $"IF(is_returned = 1, (receipt_issued_to - last_issued), null) AS returned_quantity, " +
                           $"returned_date " +
                           $"FROM " +
                           $"{viewTableName} " +
                           $"WHERE is_returned = 1";

            var dt = new DataTable();
            return _dbGenericCommands.Fill(query, dt);
        }

        public DataTable GetReturnedReceiptsBySearch(string searchKey)
        {
            var parameter = new object[][] {
                new object[]{"@searchKey", DbType.String, $"%{searchKey}%"}
            };

            string query = $"SELECT " +
                  $"receipts_id, " +
                  $"accountable_form_id, " +
                  $"accountable_forms, " +
                  $"collecting_officer_id, " +
                  $"collecting_officer, " +
                  $"date_issued, " +
                  $"receipt_issued_from, " +
                  $"receipt_issued_to, " +
                  $"quantity, " +
                  $"last_issued, " +
                  $"IF(is_returned = 1, (receipt_issued_to - last_issued), null) AS returned_quantity, " +
                  $"returned_date " +
                  $"FROM " +
                  $"{viewTableName} " +
                  $"WHERE is_returned = 1 AND " +
                  $"collecting_officer LIKE @searchKey OR " +
                  $"accountable_forms LIKE @searchkey";

            var dt = new DataTable();
            return _dbGenericCommands.FillBySearch(query, dt, parameter);

        }

        public int GetTotalIssuedReceiptByReceiptId(int receiptId)
        {
            var parameter = new object[][] {
                new object[]{ "@receipt_id", DbType.Int32, receiptId}
            };

            string query = $"SELECT " +
                           $"COALESCE(SUM(quantity), 0) AS total_issued " +
                           $"FROM {tableName} " +
                           $"WHERE receipts_id = @receipt_id";

            return int.Parse(_dbGenericCommands.ExecuteScalar(query, parameter));
        }

        public bool ReceiptAvailabilityByQuantity(int receiptId, int receiptQuantity)
        {
            var parameters = new object[][] {
                new object[]{ "@receipt_id", DbType.Int32, receiptId},
                new object[]{ "@receipt_quantity", DbType.Int32, receiptQuantity }
            };

            string query = $"SELECT COALESCE(SUM(quantity), 0) FROM view_receipts_issued " +
                           $"WHERE is_returned = false AND receipts_id = @receipt_id";

            int queryResult = int.Parse(_dbGenericCommands.ExecuteScalar(query, parameters));

            if (receiptQuantity > queryResult)
                return true;
            else
                return false;
        }

        public bool CollectingOfficerHasReceiptAssigned(int id)
        {
            var parameters = new object[][]
            {
                new object[] { "@collecting_officer_id", DbType.Int32, id },
            };

            string query = $"SELECT id FROM {tableName} WHERE collecting_officers_id = @collecting_officer_id OR job_orders_id = @collecting_officer_id";
            string queryResult = _dbGenericCommands.ExecuteScalar(query, parameters);

            if (!string.IsNullOrEmpty(queryResult)) return true;

            return false;
        }

        public bool ReceiptIsUsed(int receiptId)
        {
            var parameters = new object[][]
           {
                new object[] { "@receipts_id", DbType.Int32, receiptId },
           };

            string query = $"SELECT id FROM {tableName} WHERE receipts_id = @receipts_id";
            string queryResult = _dbGenericCommands.ExecuteScalar(query, parameters);

            if (!string.IsNullOrEmpty(queryResult)) return true;

            return false;
        }
    }
}
