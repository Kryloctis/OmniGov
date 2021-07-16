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
        private readonly string tableName = "receipts_issued";
        private readonly string tableName2 = "users";
        private readonly string tableName3 = "collecting_officers";
        private readonly string tableName4 = "accountable_forms";
        private readonly string tableName5 = "receipts";
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
            try
            {
                string query = $"SELECT {tableName}.id,CONCAT({tableName3}.last_name,', ',{tableName3}.first_name,' ',{tableName3}.mid_initial) AS collector,CONCAT({tableName4}.acc_form_no,' - ',{tableName4}.acc_form_desc) AS receipt,{tableName}.issuefrom,{tableName}.issueto,{tableName}.date_issued,{tableName}.quantity,{tableName}.last_issued,IF(IFNULL({tableName}.is_returned,0)>0,'YES','NO') AS returned,{tableName}.returned_date,CONCAT({tableName2}.last_name,', ',{tableName2}.first_name,' ',{tableName2}.mid_initial) AS officer FROM {tableName} LEFT JOIN {tableName5} ON {tableName}.receipts_id={tableName5}.id LEFT JOIN {tableName2} ON {tableName5}.users_id={tableName2}.id LEFT JOIN {tableName3} ON {tableName}.collecting_officers_id={tableName3}.id LEFT JOIN {tableName4} ON {tableName5}.accountable_forms_id={tableName4}.id ORDER BY {tableName}.date_issued DESC";

                var dtri = new DataTable();
                return _dbGenericCommands.Fill(query, dtri);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetRecords(int id)
        {
            try
            {
                string query = $"SELECT * FROM {tableName5} LEFT JOIN {tableName4} ON {tableName5}.accountable_forms_id={tableName4}.id WHERE {tableName5}.receiptsto<>IFNULL((SELECT SUM(IF(IFNULL(ri.last_issued,0)>0,ri.issueto-ri.last_issued,0)) FROM {tableName} ri WHERE ri.receipts_id={tableName5}.id),0) AND {tableName5}.id NOT IN (SELECT {tableName}.receipts_id FROM {tableName} WHERE {tableName}.collecting_officers_id='{id}' AND IF(IFNULL({tableName}.is_returned,0)>0,1,0)=0)";

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
                string query = $"SELECT {tableName}.id,CONCAT({tableName4}.acc_form_no,' - ',{tableName4}.acc_form_desc) AS receipt,{tableName}.issuefrom,{tableName}.issueto,{tableName}.date_issued,{tableName}.quantity,{tableName}.last_issued,IF(IFNULL({tableName}.is_returned,0)>0,'YES','NO') AS returned,{tableName}.returned_date FROM {tableName5} LEFT JOIN {tableName} ON {tableName}.receipts_id={tableName5}.id LEFT JOIN {tableName4} ON {tableName5}.accountable_forms_id={tableName4}.id WHERE {tableName}.collecting_officers_id='{coid}' AND {tableName5}.accountable_forms_id='{formid}' AND IF(IFNULL({tableName}.is_returned,0)>0,1,0)=0 AND IF({tableName}.issueto={tableName}.last_issued,true,false)=false";

                var dtri = new DataTable();
                return _dbGenericCommands.Fill(query, dtri);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetRecordsReceipts(string id)
        {
            try
            {
                string query = $"SELECT * FROM {tableName4} WHERE id IN (SELECT {tableName5}.accountable_forms_id FROM {tableName5} LEFT JOIN {tableName} ON {tableName}.receipts_id={tableName5}.id LEFT JOIN {tableName4} ON {tableName5}.accountable_forms_id={tableName4}.id WHERE {tableName}.collecting_officers_id='{id}' AND IF(IFNULL({tableName}.is_returned,0)>0,1,0)=0 AND IF({tableName}.issueto={tableName}.last_issued,true,false)=false)";

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
                string query = $"SELECT {tableName}.id,CONCAT({tableName3}.last_name,', ',{tableName3}.first_name,' ',{tableName3}.mid_initial) AS collector,CONCAT({tableName4}.acc_form_no,' - ',{tableName4}.acc_form_desc) AS receipt,{tableName}.issuefrom,{tableName}.issueto,{tableName}.date_issued,{tableName}.quantity,{tableName}.last_issued,IF(IFNULL({tableName}.is_returned,0)>0,'YES','NO') AS returned,{tableName}.returned_date,CONCAT({tableName2}.last_name,', ',{tableName2}.first_name,' ',{tableName2}.mid_initial) AS officer FROM {tableName} LEFT JOIN {tableName5} ON {tableName}.receipts_id={tableName5}.id LEFT JOIN {tableName2} ON {tableName5}.users_id={tableName2}.id LEFT JOIN {tableName3} ON {tableName}.collecting_officers_id={tableName3}.id LEFT JOIN {tableName4} ON {tableName5}.accountable_forms_id={tableName4}.id WHERE {tableName5}.receiptsfrom LIKE '%{searchText}%' OR {tableName5}.receiptsto LIKE '%{searchText}%' OR CONCAT({tableName3}.last_name,', ',{tableName3}.first_name,' ',{tableName3}.mid_initial) LIKE '%{searchText}%' OR CONCAT({tableName2}.last_name,', ',{tableName2}.first_name,' ',{tableName2}.mid_initial) LIKE '%{searchText}%' OR CONCAT({tableName4}.acc_form_no,' - ',{tableName4}.acc_form_desc) LIKE '%{searchText}%' ORDER BY {tableName}.date_issued DESC";

                var dtri = new DataTable();
                return _dbGenericCommands.Fill(query, dtri);
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
                    new object[] { "@collecting_officers_id", DbType.Int32, entity.CoId },
                    new object[] { "@receipts_id", DbType.Int32, entity.RId },
                    new object[] { "@issuefrom", DbType.Int32, entity.IssuedFrom },
                    new object[] { "@issueto", DbType.Int32, entity.IssuedTo }
                };

                string query = $"SELECT id FROM {tableName} WHERE collecting_officers_id = @collecting_officers_id AND receipts_id=@receipts_id AND issuefrom=@issuefrom AND issueto=@issueto";
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

        public bool IssuedExist(int coid, int id)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@collecting_officers_id", DbType.Int32, coid },
                    new object[] { "@receipts_id", DbType.Int32, id },
                };

                string query = $"SELECT * FROM {tableName} WHERE {tableName}.collecting_officers_id = @collecting_officers_id AND {tableName}.receipts_id=@receipts_id AND IF(IFNULL({tableName}.is_returned,0)<1,true,false)=true";
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

        public bool HasIssued(int id)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@receipts_id", DbType.Int32, id },
                };

                string query = $"SELECT * FROM {tableName} WHERE receipts_id=@receipts_id";
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
                    new object[] { "@receipts_id", DbType.Int32, entity.RId},
                    new object[] { "@collecting_officers_id", DbType.Int32, entity.CoId},
                    new object[] { "@date_issued", DbType.Date, entity.Issued},
                    new object[] { "@issuefrom", DbType.Int32, entity.IssuedFrom},
                    new object[] { "@issueto", DbType.Int32, entity.IssuedTo},
                    new object[] { "@quantity", DbType.Int32, entity.Quantity}
                };

                string query = $"INSERT INTO {tableName} (receipts_id,collecting_officers_id,date_issued,issuefrom,issueto,quantity) VALUES (@receipts_id,@collecting_officers_id,@date_issued,@issuefrom,@issueto,@quantity)";
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
                    new object[] { "@receipts_id", DbType.Int32, entity.RId},
                    new object[] { "@collecting_officers_id", DbType.Int32, entity.CoId},
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

                string query = $"UPDATE {tableName} SET last_issued=@last_issued WHERE id = @id";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
