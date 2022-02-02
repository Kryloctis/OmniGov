using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Transactions;
using ACC.Domain.Interfaces;
using ACC.Domain.Models;

namespace ACC.Data
{
    public class ReceiptsRepository : IReceiptsRepository
    {
        private readonly IDbGenericCommands _dbGenericCommands;
        private readonly string tableReceipts = "receipts";
        private readonly string tableReceiptsIssued = "receipts_issued";


        private readonly string viewTableName = "view_receipts";

        public ReceiptsRepository(IDbGenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
        }

        public int CountRecords()
        {
            try
            {
                string query = $"SELECT COUNT(*) FROM {tableReceipts}";

                return int.Parse(_dbGenericCommands.ExecuteScalar(query));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(List<ReceiptsModel> entityList)
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

                        string query = $"DELETE FROM {tableReceipts} WHERE id = @id";
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

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var record = new Dictionary<string, string>();

            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, Id},
                };

                string query = $"SELECT * FROM {tableReceipts} WHERE {tableReceipts}.id = @id";

                using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;

                    record.Add("id", reader.Rows[0]["id"].ToString());
                    record.Add("receiptsfrom", reader.Rows[0]["receiptsfrom"].ToString());
                    record.Add("receiptsto", reader.Rows[0]["receiptsto"].ToString());
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
            try
            {
                string query = $"SELECT " +
                    $"id, " +
                    $"CONCAT(acc_form_no, ' - ', acc_form_desc) receipt, " +
                    $"if(receiptsfrom = 0, null, receiptsfrom), " +
                    $"if(receiptsto = 0, null, receiptsto), " +
                    $"received_date, " +
                    $"quantity, " +
                    $"user officer " +
                    $"FROM {viewTableName} " +
                    $"ORDER BY accountable_forms_id ";

                var dtri = new DataTable();
                return _dbGenericCommands.Fill(query, dtri);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            try
            {
                var parameter = new object[][] {
                    new object[]{"@searchText", DbType.String, $"%{searchText}%"},
                };

                string query =    $"SELECT " +
                                  $"id, " +
                                  $"CONCAT(acc_form_no, ' - ', acc_form_desc) receipt, " +
                                  $"receiptsfrom, " +
                                  $"receiptsto, " +
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
            catch (Exception)
            {
                throw;
            }
        }

        public bool IdExist(int id)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, id },
                };

                string query = $"SELECT id FROM {tableReceipts} WHERE id = @id";
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

        public bool ReceiptsIssued(int id)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, id },
                };

                string query = $"SELECT id FROM {tableReceiptsIssued} WHERE receipts_id = @id";
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

        public bool AllowEdit(int id)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, id },
                };

                string query = $"SELECT {tableReceipts}.id FROM {tableReceipts} LEFT JOIN {tableReceiptsIssued} ON {tableReceipts}.id={tableReceiptsIssued}.receipts_id WHERE ({tableReceiptsIssued}.issuefrom AND {tableReceiptsIssued}.issueto BETWEEN {tableReceipts}.receiptsfrom AND {tableReceipts}.receiptsto) AND {tableReceipts}.id=@id";
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

        public bool ReceiptExist(int accid,int from,int to)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@accountable_forms_id", DbType.Int32, accid },
                    new object[] { "@receiptsfrom", DbType.Int32, from },
                    new object[] { "@receiptsto", DbType.Int32, to }
                };

                string query = $"SELECT * FROM {tableReceipts} WHERE accountable_forms_id = @accountable_forms_id AND ((receiptsfrom BETWEEN @receiptsfrom AND @receiptsto) OR (receiptsto BETWEEN @receiptsfrom AND @receiptsto))";
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

        public int RMAX(int accid)
        {
            int value = 0;
            try
            {               
                string query = $"SELECT IFNULL(MAX(receiptsto),0) AS receiptno FROM {tableReceipts} WHERE accountable_forms_id = {accid}";
                DataTable dt = _dbGenericCommands.Fill(query,new DataTable());
                if(dt.Rows.Count > 0)
                {
                    for(int i=0;i < dt.Rows.Count; i++)
                    {
                        value = int.Parse(dt.Rows[i]["receiptno"].ToString());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            };

            return value;
        }

        public int RMIN(int accid)
        {
            int value = 0;
            try
            {
                string query = $"SELECT IFNULL(MAX(receiptsfrom), 0) AS receiptno FROM {tableReceipts} WHERE accountable_forms_id = {accid}";
                DataTable dt = _dbGenericCommands.Fill(query, new DataTable());
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        value = int.Parse(dt.Rows[i]["receiptno"].ToString());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            };

            return value;
        }

        public bool ReceiptConsumed(int id)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, id },
                };

                string query = $"SELECT * FROM {tableReceipts} WHERE id = @id AND receiptsto=(SELECT SUM(IF(IFNULL(last_issued,0)>0,issueto-last_issued,0)) FROM {tableReceiptsIssued} WHERE receipts_id=id AND IF(IFNULL(is_returned,true),false,true)=false)";
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

        public DataTable NextReceipt(int id)
        {
            try
            {
                string query = $"SELECT IFNULL(last_issued,issueto) AS issuelast,issueto,is_returned FROM {tableReceiptsIssued} WHERE receipts_id='{id}' AND issueto<>IFNULL(last_issued,0) ORDER BY issuelast DESC";

                var dtri = new DataTable();
                return _dbGenericCommands.Fill(query, dtri);
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        public DataTable NextTicket(int id)
        {
            try
            {
                string query = $"SELECT IFNULL(SUM({tableReceiptsIssued}.quantity), 0) AS issuelast, {tableReceipts}.quantity FROM " +
                    $"{tableReceiptsIssued} LEFT JOIN {tableReceipts} ON {tableReceiptsIssued}.receipts_id={tableReceipts}.id " +
                    $"WHERE {tableReceiptsIssued}.receipts_id='{id}'";

                var dtri = new DataTable();
                return _dbGenericCommands.Fill(query, dtri);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public DataTable FirstReceipt(int id)
        {
            try
            {
                string query = $"SELECT * FROM {tableReceipts} WHERE id='{id}'";

                var dtri = new DataTable();
                return _dbGenericCommands.Fill(query, dtri);
            }
            catch (Exception)
            {
                throw;
            }

        }



        public bool Insert(ReceiptsModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@users_id", DbType.Int32, entity.UserId},
                    new object[] { "@accountable_forms_id", DbType.Int32, entity.AccId},
                    new object[] { "@receiptsfrom", DbType.Int32, entity.SerialNoFrom},
                    new object[] { "@receiptsto", DbType.Int32, entity.SerialNoTo},
                    new object[] { "@received_date", DbType.Date, entity.ReceiptDate},
                    new object[] { "@quantity", DbType.Int32, entity.Quantity},
                    new object[] { "@remarks", DbType.String, entity.Remarks}
                };

                string query =  $"INSERT INTO {tableReceipts} " +
                                $"(users_id, " +
                                $"accountable_forms_id, " +
                                $"receiptsfrom, " +
                                $"receiptsto, " +
                                $"received_date, " +
                                $"quantity, " +
                                $"remarks) " +
                                $"VALUES " +
                                $"(@users_id, " +
                                $"@accountable_forms_id, " +
                                $"@receiptsfrom, " +
                                $"@receiptsto, " +
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
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, entity.Id},
                    new object[] { "@users_id", DbType.Int32, entity.UserId},
                    new object[] { "@accountable_forms_id", DbType.Int32, entity.AccId},
                    new object[] { "@receiptsfrom", DbType.Int32, entity.SerialNoFrom},
                    new object[] { "@receiptsto", DbType.Int32, entity.SerialNoTo},
                    new object[] { "@received_date", DbType.Date, entity.ReceiptDate},
                    new object[] { "@quantity", DbType.Int32, entity.Quantity},
                    new object[] { "@remarks", DbType.String, entity.Remarks}
                };

                string query = $"UPDATE {tableReceipts} SET users_id=@users_id,accountable_forms_id=@accountable_forms_id,receiptsfrom=@receiptsfrom,receiptsto=@receiptsto,received_date=@received_date,quantity=@quantity,remarks=@remarks WHERE id = @id";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        
    }
}
