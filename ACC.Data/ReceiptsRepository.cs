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
        private readonly string tableName = "receipts";
        private readonly string tableName2 = "users";
        private readonly string tableName3 = "accountable_forms";
        private readonly string tableName4 = "receipts_issued";
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
            try
            {
                using (var scope = new TransactionScope())
                {
                    foreach (var entity in entityList)
                    {
                        var parameters = new object[][]
                        {
                            new object[] { "@id", DbType.Int16, entity.Id},
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
                string query = $"SELECT {tableName}.id,CONCAT({tableName3}.acc_form_no,' - ',{tableName3}.acc_form_desc) AS receipt,{tableName}.receiptsfrom,{tableName}.receiptsto,{tableName}.received_date,{tableName}.quantity,CONCAT({tableName2}.last_name,', ',{tableName2}.first_name,' ',{tableName2}.mid_initial) AS officer FROM {tableName} LEFT JOIN {tableName2} ON {tableName}.users_id={tableName2}.id LEFT JOIN {tableName3} ON {tableName}.accountable_forms_id={tableName3}.id ORDER BY {tableName}.received_date DESC";

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
                string query = $"SELECT {tableName}.id,CONCAT({tableName3}.acc_form_no,' - ',{tableName3}.acc_form_desc) AS receipt,{tableName}.receiptsfrom,{tableName}.receiptsto,{tableName}.received_date,{tableName}.quantity,CONCAT({tableName2}.last_name,', ',{tableName2}.first_name,' ',{tableName2}.mid_initial) AS officer FROM {tableName} LEFT JOIN {tableName2} ON {tableName}.users_id={tableName2}.id LEFT JOIN {tableName3} ON {tableName}.accountable_forms_id={tableName3}.id WHERE {tableName}.receiptsfrom LIKE '%{searchText}%' OR {tableName}.receiptsto LIKE '%{searchText}%' OR {tableName}.remarks LIKE '%{searchText}%' OR CONCAT({tableName2}.last_name,', ',{tableName2}.first_name,' ',{tableName2}.mid_initial) LIKE '%{searchText}%' OR CONCAT({tableName3}.acc_form_no,' - ',{tableName3}.acc_form_desc) LIKE '%{searchText}%' ORDER BY {tableName}.received_date DESC";

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
                    new object[] { "@id", DbType.Int16, id },
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

        public bool ReceiptExist(int accid,int from,int to)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@accountable_forms_id", DbType.Int16, accid },
                    new object[] { "@receiptsfrom", DbType.Int16, from },
                    new object[] { "@receiptsto", DbType.Int16, to }
                };

                string query = $"SELECT * FROM {tableName} WHERE accountable_forms_id = @accountable_forms_id AND receiptsfrom=@receiptsfrom AND receiptsto=@receiptsto";
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

        public bool ReceiptConsumed(int id)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int16, id },
                };

                string query = $"SELECT * FROM {tableName} WHERE id = @id AND receiptsto=(SELECT SUM(IF(IFNULL(last_issued,0)>0,issueto-last_issued,0)) FROM {tableName4} WHERE receipts_id=id AND IF(IFNULL(is_returned,true),false,true)=false)";
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
                string query = $"SELECT MAX(issueto) AS issuelast FROM {tableName4} WHERE receipts_id='{id}'";

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
                string query = $"SELECT * FROM {tableName} WHERE id='{id}'";

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
                    new object[] { "@users_id", DbType.Int16, entity.UserId},
                    new object[] { "@accountable_forms_id", DbType.Int16, entity.AccId},
                    new object[] { "@receiptsfrom", DbType.Int16, entity.Rfrom},
                    new object[] { "@receiptsto", DbType.Int16, entity.Rto},
                    new object[] { "@received_date", DbType.Date, entity.Rdate},
                    new object[] { "@quantity", DbType.Int16, entity.Quantity},
                    new object[] { "@remarks", DbType.String, entity.Remarks}
                };

                string query = $"INSERT INTO {tableName} (users_id,accountable_forms_id,receiptsfrom,receiptsto,received_date,quantity,remarks) VALUES (@users_id,@accountable_forms_id,@receiptsfrom,@receiptsto,@received_date,@quantity,@remarks)";
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
                    new object[] { "@id", DbType.Int16, entity.Id},
                    new object[] { "@users_id", DbType.Int16, entity.UserId},
                    new object[] { "@accountable_forms_id", DbType.Int16, entity.AccId},
                    new object[] { "@receiptsfrom", DbType.Int16, entity.Rfrom},
                    new object[] { "@receiptsto", DbType.Int16, entity.Rto},
                    new object[] { "@received_date", DbType.Date, entity.Rdate},
                    new object[] { "@quantity", DbType.Int16, entity.Quantity},
                    new object[] { "@remarks", DbType.String, entity.Remarks}
                };

                string query = $"UPDATE {tableName} SET users_id=@users_id,accountable_forms_id=@accountable_forms_id,receiptsfrom=@receiptsfrom,receiptsto=@receiptsto,received_date=@received_date,quantity=@quantity,remarks=@remarks WHERE id = @id";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        
    }
}
