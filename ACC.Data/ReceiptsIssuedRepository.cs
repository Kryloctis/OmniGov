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

        private readonly string tableAccountableForms = "accountable_forms";
        private readonly string tableReceipts = "receipts";



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
                            $"collecting_officer, " +
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
                            $"ORDER BY date_issued DESC";

                
            var dtri = new DataTable();
            return _dbGenericCommands.Fill(query, dtri);
        }

        public DataTable GetRecordsByCollectorId(int collectorId)
        {
            var parameter = new object[][] {
                new object[]{"@collecting_officer_id", DbType.String, collectorId }
            };

            string query = $"SELECT * FROM {tableReceipts} " +
                $"LEFT JOIN {tableAccountableForms} ON {tableReceipts}.accountable_forms_id={tableAccountableForms}.id " +
                $"WHERE ({tableReceipts}.receipt_number_to <> IFNULL((SELECT SUM(IF(IFNULL(ri.last_issued,0)>0,ri.receipt_issued_to-ri.last_issued,0)) FROM {tableName} ri WHERE ri.receipts_id={tableReceipts}.id),0) OR {tableReceipts}.quantity<>IFNULL((SELECT SUM(ri.quantity) FROM {tableName} ri LEFT JOIN {tableReceipts} r ON ri.receipts_id=r.id LEFT JOIN {tableAccountableForms} af ON r.accountable_forms_id=af.id WHERE r.id=receipts.id),0))" +
                $"AND {tableReceipts}.id NOT IN (SELECT {tableName}.receipts_id FROM {tableName} WHERE {tableName}.collecting_officers_id='{collectorId}' AND IF(IFNULL({tableName}.is_returned,0)>0,1,0)=0)";

            //string query = $"SELECT * FROM {viewTableName} WHERE collecting_officer_id = @collecting_officer_id AND is_returned = false ";
            var dtReceiptsIssued = new DataTable();

            return _dbGenericCommands.FillBySearch(query, dtReceiptsIssued, parameter);
        }

        public DataTable GetRecords(string coid, string formid)
        {
            try
            {
                string query = $"SELECT {tableName}.id," +
                    $"CONCAT({tableAccountableForms}.acc_form_no,' - ',{tableAccountableForms}.acc_form_desc) AS receipt," +
                    $"{tableName}.receipt_issued_from," +
                    $"{tableName}.receipt_issued_to," +
                    $"{tableName}.date_issued," +
                    $"{tableName}.quantity," +
                    $"{tableName}.last_issued," +
                    $"IF(IFNULL({tableName}.is_returned,0)>0,'YES','NO') AS returned," +
                    $"{tableName}.returned_date " +
                    $"FROM {tableReceipts} LEFT JOIN {tableName} ON {tableName}.receipts_id={tableReceipts}.id " +
                    $"LEFT JOIN {tableAccountableForms} ON {tableReceipts}.accountable_forms_id={tableAccountableForms}.id " +
                    $"WHERE {tableName}.collecting_officers_id='{coid}' AND {tableReceipts}.accountable_forms_id='{formid}' AND IF(IFNULL({tableName}.is_returned,0)>0,1,0)=0 AND IF({tableName}.receipt_issued_to={tableName}.last_issued,true,false)=false";

                var dtri = new DataTable();
                return _dbGenericCommands.Fill(query, dtri);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetRecordsReceipts(string collectorId)
        {
            var parameter = new object[][] {
                new object[]{"@collectingOfficerId", DbType.String, collectorId }
            };

            string query =  $"SELECT " +
                            $"accountable_forms.id, " +
                            $"accountable_forms.acc_form_no, " +
                            $"accountable_forms.acc_form_desc, " +
                            $"receipts_issued.quantity " +
                            $"FROM accountable_forms AS accountable_forms " +
                            $"INNER JOIN receipts AS receipts " +
                            $"ON receipts.accountable_forms_id = accountable_forms.id " +
                            $"INNER JOIN receipts_issued AS receipts_issued " +
                            $"ON receipts_issued.receipts_id = receipts.id " +
                            $"WHERE receipts_issued.collecting_officers_id = @collectingOfficerId";


            var dtri = new DataTable();
            return _dbGenericCommands.FillBySearch(query, dtri, parameter);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameter = new object[][] { 
                new object[]{"@searchKey", DbType.String, $"%{searchText}%"},
            };

            string query = $"SELECT  " +
                            $"id, " +
                            $"collecting_officer, " +
                            $"accountable_forms, " +
                            $"issuefrom, " +
                            $"issueto,  " +
                            $"date_issued,  " +
                            $"quantity,  " +
                            $"last_issued,  " +
                            $"IF(IFNULL(is_returned,0) > 0,'Yes','No') AS returned,  " +
                            $"returned_date,  " +
                            $"user  " +
                            $"FROM {viewTableName} " +
                            $"WHERE " +
                            $"collecting_officer LIKE @searchKey OR " +
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

        public bool IssuedExist(ReceiptsIssuedModel entity)
        {
            try
            {
              
                var parameters = new object[][]
                {
                    new object[] { "@receipts_id", DbType.Int32, entity.ReceiptId },
                    new object[] { "@issuefrom", DbType.Int32, entity.IssuedFrom },
                    new object[] { "@issueto", DbType.Int32, entity.IssuedTo }
                };

               string query = $"SELECT id FROM {tableName} WHERE receipts_id=@receipts_id AND issuefrom=@issuefrom AND issueto=@issueto AND IF(IFNULL(is_returned,0)<1,false,true)=false";



                string queryResult = _dbGenericCommands.ExecuteScalar(query, parameters);

                if (!string.IsNullOrEmpty(queryResult)) return true;
            }
            catch (Exception)
            {
                throw;
            };

            return false;
        }

        public bool IssuedExist(int coid, int id)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@collecting_officers_id", DbType.Int32, coid },
                    new object[] { "@receipts_id", DbType.Int32, id },
                };

                string query = $"SELECT * FROM {tableName} WHERE {tableName}.collecting_officers_id = @collecting_officers_id AND {tableName}.receipts_id=@receipts_id AND IF(IFNULL({tableName}.is_returned,0)<1,false,true)=true";
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

        public bool HasIssued(int accountableFormId, int collectorId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@accountable_form_id", DbType.Int32, accountableFormId },
                    new object[] { "@collecting_officer_id", DbType.Int32, collectorId },
                };

                string query = $"SELECT * " +
                               $"FROM {viewTableName} " +
                               $"WHERE " +
                               $"accountable_form_id = @accountable_form_id " +
                               $"AND " +
                               $"collecting_officer_id = @collecting_officer_id " +
                               $"AND is_returned IS NULL"; 

                string queryResult = _dbGenericCommands.ExecuteScalar(query, parameters);

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
                    new object[] { "@date_issued", DbType.Date, entity.Issued},
                    new object[] { "@receipt_issued_from", DbType.Int32, entity.IssuedFrom},
                    new object[] { "@receipt_issued_to", DbType.Int32, entity.IssuedTo},
                    new object[] { "@quantity", DbType.Int32, entity.Quantity},
                    new object[] { "@issued_by", DbType.Int32, entity.IssuedByUserId}
                };

                string query = $"INSERT INTO {tableName} " +
                               $"(receipts_id, collecting_officers_id, date_issued, receipt_issued_from, receipt_issued_to, quantity, issued_by) " +
                               $"VALUES( " +
                               $"@receipts_id, " +
                               $"@collecting_officers_id, " +
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
            try
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
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateCurrentIssued(ReceiptsIssuedModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, entity.Id},
                    new object[] { "@last_issued", DbType.Int32, entity.Last_issued}
                };

                string query = $"UPDATE {tableName} SET last_issued = @last_issued WHERE id = @id";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetAccountabilityForAccountableForms(string collectingOfficerId)
        {
            var parameter = new object[][] {
                new object[]{"@collecting_officer_id", DbType.String, collectingOfficerId}
            };

            string query =  $"SELECT " +
                            $"accountable_forms, " +
                            $"(MAX(issueto) - MIN(issuefrom) + 1) quantity, " +
                            $"MIN(issuefrom) serial_no_from, " +
                            $"MAX(issueto) serial_no_to, " +
                            $"((issueto - issuefrom) + 1) issue_quantity, " +
                            $"issuefrom, " +
                            $"issueto, " +
                            $"(issueto - last_issued) ending_balance_quantity, " +
                            $"(last_issued + 1) ending_balance_serial_from, " +
                            $"(issueto) ending_balance_serial_to " +
                            $"FROM {viewTableName} " +
                            $"WHERE " +
                            $"collecting_officer_id = @collecting_officer_id " +
                            $"GROUP BY collecting_officer_id ";

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
                           $"issuefrom, " +
                           $"issueto, " +
                           $"quantity, " +
                           $"last_issued, " +
                           $"IF(is_returned = 1, (issueto - last_issued), null) AS returned_quantity, " +
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
                  $"issuefrom, " +
                  $"issueto, " +
                  $"quantity, " +
                  $"last_issued, " +
                  $"IF(is_returned = 1, (issueto - last_issued), null) AS returned_quantity, " +
                  $"returned_date " +
                  $"FROM " +
                  $"{viewTableName} " +
                  $"WHERE is_returned = 1 AND " +
                  $"collecting_officer LIKE @searchKey OR " +
                  $"accountable_forms LIKE @searchkey";

            var dt = new DataTable();
            return _dbGenericCommands.FillBySearch(query, dt, parameter);

        }

        public int GetReceiptNumberFromByReceiptId(int receiptId)
        {
            var parameter = new object[][] {
                new object[]{ "@receipt_id", DbType.Int32, receiptId}
            };

            string query = $"SELECT " +
                           $"COALESCE(MAX(receipt_issued_to), 0) AS receipt_issued_from " +
                           $"FROM {tableName} " +
                           $"WHERE receipts_id = @receipt_id";

            return int.Parse(_dbGenericCommands.ExecuteScalar(query, parameter));
        }

        public bool ReceiptAvailability(int receiptId, int receiptQuantity)
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

    }
}
