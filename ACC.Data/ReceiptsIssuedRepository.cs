using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Transactions;
using ACC.Domain.Interfaces;
using ACC.Domain.Models;

namespace ACC.Data
{
    public class ReceiptsIssuedRepository:IReceiptsIssuedRepository
    {
        private readonly IDbGenericCommands _dbGenericCommands;
        private readonly string tableReceiptsIssued = "receipts_issued";
        private readonly string tableUsers = "users";
        private readonly string tableCollectingOfficers = "collecting_officers";
        private readonly string tableAccountableForms = "accountable_forms";
        private readonly string tableReceipts = "receipts";

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

                string query = $"SELECT * FROM {tableReceiptsIssued} id = @id";

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
                string query = $"SELECT COUNT(*) FROM {tableReceiptsIssued}";

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

                        string query = $"DELETE FROM {tableReceiptsIssued} WHERE id = @id";
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
                            $"issuefrom, " +
                            $"issueto,  " +
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

        public DataTable GetRecords(int id)
        {
            try
            {
                string query = $"SELECT * FROM {tableReceipts} " +
                    $"LEFT JOIN {tableAccountableForms} ON {tableReceipts}.accountable_forms_id={tableAccountableForms}.id " +
                    $"WHERE ({tableReceipts}.receiptsto<>IFNULL((SELECT SUM(IF(IFNULL(ri.last_issued,0)>0,ri.issueto-ri.last_issued,0)) FROM {tableReceiptsIssued} ri WHERE ri.receipts_id={tableReceipts}.id),0) OR {tableReceipts}.quantity<>IFNULL((SELECT SUM(ri.quantity) FROM {tableReceiptsIssued} ri LEFT JOIN {tableReceipts} r ON ri.receipts_id=r.id LEFT JOIN {tableAccountableForms} af ON r.accountable_forms_id=af.id WHERE r.id=receipts.id),0))" +
                    $"AND {tableReceipts}.id NOT IN (SELECT {tableReceiptsIssued}.receipts_id FROM {tableReceiptsIssued} WHERE {tableReceiptsIssued}.collecting_officers_id='{id}' AND IF(IFNULL({tableReceiptsIssued}.is_returned,0)>0,1,0)=0)";

                var dtri = new DataTable();
                return _dbGenericCommands.Fill(query, dtri);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetRecords(string coid, string formid)
        {
            try
            {
                string query = $"SELECT {tableReceiptsIssued}.id," +
                    $"CONCAT({tableAccountableForms}.acc_form_no,' - ',{tableAccountableForms}.acc_form_desc) AS receipt," +
                    $"{tableReceiptsIssued}.issuefrom," +
                    $"{tableReceiptsIssued}.issueto," +
                    $"{tableReceiptsIssued}.date_issued," +
                    $"{tableReceiptsIssued}.quantity," +
                    $"{tableReceiptsIssued}.last_issued," +
                    $"IF(IFNULL({tableReceiptsIssued}.is_returned,0)>0,'YES','NO') AS returned," +
                    $"{tableReceiptsIssued}.returned_date " +
                    $"FROM {tableReceipts} LEFT JOIN {tableReceiptsIssued} ON {tableReceiptsIssued}.receipts_id={tableReceipts}.id " +
                    $"LEFT JOIN {tableAccountableForms} ON {tableReceipts}.accountable_forms_id={tableAccountableForms}.id " +
                    $"WHERE {tableReceiptsIssued}.collecting_officers_id='{coid}' AND {tableReceipts}.accountable_forms_id='{formid}' AND IF(IFNULL({tableReceiptsIssued}.is_returned,0)>0,1,0)=0 AND IF({tableReceiptsIssued}.issueto={tableReceiptsIssued}.last_issued,true,false)=false";

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
                            $"af.id, " +
                            $"af.acc_form_no, " +
                            $"af.acc_form_desc, " +
                            $"ri.quantity " +
                            $"FROM accountable_forms af " +
                            $"INNER JOIN receipts r " +
                            $"ON r.accountable_forms_id = af.id " +
                            $"INNER JOIN receipts_issued ri " +
                            $"ON ri.receipts_id = r.id " +
                            $"WHERE ri.collecting_officers_id = @collectingOfficerId";


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

                string query = $"SELECT id FROM {tableReceiptsIssued} WHERE id = @id";
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

               string query = $"SELECT id FROM {tableReceiptsIssued} WHERE receipts_id=@receipts_id AND issuefrom=@issuefrom AND issueto=@issueto AND IF(IFNULL(is_returned,0)<1,false,true)=false";



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

                string query = $"SELECT * FROM {tableReceiptsIssued} WHERE {tableReceiptsIssued}.collecting_officers_id = @collecting_officers_id AND {tableReceiptsIssued}.receipts_id=@receipts_id AND IF(IFNULL({tableReceiptsIssued}.is_returned,0)<1,false,true)=true";
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
                    new object[] { "@issuefrom", DbType.Int32, entity.IssuedFrom},
                    new object[] { "@issueto", DbType.Int32, entity.IssuedTo},
                    new object[] { "@quantity", DbType.Int32, entity.Quantity},
                    new object[] { "@issuedBy", DbType.Int32, entity.IssuedByUserId}
                };

                string query = $"INSERT INTO {tableReceiptsIssued} " +
                               $"(receipts_id, collecting_officers_id, date_issued, issuefrom, issueto, quantity, issued_by) VALUES" +
                              $"(@receipts_id, @collecting_officers_id, @date_issued, @issuefrom, @issueto, @quantity, @issuedBy)";
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

                string query = $"UPDATE {tableReceiptsIssued} SET receipts_id=@receipts_id,collecting_officers_id=@collecting_officers_id,date_issued=@date_issued,issuefrom=@issuefrom,issueto=@issueto,quantity=@quantity WHERE id = @id";
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

                string query = $"UPDATE {tableReceiptsIssued} SET is_returned=@is_returned,returned_date=@returned_date WHERE id = @id";
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

                string query = $"UPDATE {tableReceiptsIssued} SET last_issued = @last_issued WHERE id = @id";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetAccountabilityForAccountableForms()
        {
            try
            {
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
                                $"GROUP BY collecting_officer_id ";

                var dt = new DataTable();
                return _dbGenericCommands.Fill(query, dt);
            }
            catch (Exception)
            {

                throw;
            }
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
    }
}
