using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Transactions;
using ACC.Domain.Interfaces;
using ACC.Domain.Models;

namespace ACC.Data
{
    public class PaymentCollectionRepository:IPaymentCollectionRepository
    {
        private readonly IDbGenericCommands _dbGenericCommands;
        private readonly string tableName = "payment_collections";
        private readonly string tableName2 = "collecting_officers";
        private readonly string tableName3 = "accountable_forms";
        private readonly string tableName4 = "general_ledger_accounts";
        private readonly string tableName5 = "users";
        private readonly string tableName6 = "account_group";
        private readonly string tableName7 = "major_account_group";
        private readonly string tableName8 = "sub_major_account_group";
        private readonly string tableName9 = "subsidiary_ledger_accounts";
        public PaymentCollectionRepository(IDbGenericCommands dbGenericCommands)
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

                string query = $"SELECT * FROM {tableName} LEFT JOIN {tableName2} ON {tableName2}.id={tableName}.collecting_officers_id LEFT JOIN {tableName3} ON {tableName3}.id={tableName}.accountable_forms_id LEFT JOIN {tableName4} ON {tableName4}.id={tableName}.general_ledger_accounts_id LEFT JOIN {tableName5} u1 ON u1.id={tableName}.created_by LEFT JOIN {tableName5} u2 ON u2.id={tableName}.updated_by LEFT JOIN {tableName9} ON {tableName}.subsidiary_ledger_accounts_id={tableName9}.id WHERE {tableName}.id = @id";

                using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;

                    record.Add("collecting_officers_id", reader.Rows[0]["collecting_officers_id"].ToString());
                    record.Add("accountable_forms_id", reader.Rows[0]["accountable_forms_id"].ToString());
                    record.Add("general_ledger_accounts_id", reader.Rows[0]["general_ledger_accounts_id"].ToString());
                    record.Add("subsidiary_ledger_accounts_id", reader.Rows[0]["subsidiary_ledger_accounts_id"].ToString());
                    record.Add("payee", reader.Rows[0]["payee"].ToString());
                    record.Add("receipt_no", reader.Rows[0]["receipt_no"].ToString());
                    record.Add("payment_date", reader.Rows[0]["payment_date"].ToString());
                    record.Add("amount", reader.Rows[0]["amount"].ToString());                    
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
                string query = $"SELECT {tableName}.id,CONCAT(DATE_FORMAT({tableName}.payment_date,'%y'),'-',DATE_FORMAT({tableName}.payment_date,'%m'),'-',LPAD({tableName}.id, 3, 0)) AS rcdno,CONCAT({tableName6}.account_group_code,'-',{tableName7}.maj_acc_group_code,'-',{tableName8}.sub_maj_acc_group_code,'-',{tableName4}.ledger_code) AS account_code,CONCAT({tableName3}.acc_form_no,'-',{tableName3}.acc_form_desc) AS accform,{tableName4}.ledger_name,CONCAT({tableName9}.sub_code,'-',{tableName9}.sub_name) AS subsidiary,{tableName}.payee,{tableName}.receipt_no,{tableName}.payment_date,{tableName}.amount,CONCAT({tableName2}.last_name,', ',{tableName2}.first_name,' ',{tableName2}.mid_initial) AS collector,{tableName}.created_at,{tableName}.updated_at,CONCAT(u1.last_name,', ',u1.first_name,' ',u1.mid_initial) AS createdby,CONCAT(u2.last_name,', ',u2.first_name,' ',u2.mid_initial) AS updatedby FROM {tableName} LEFT JOIN {tableName2} ON {tableName2}.id={tableName}.collecting_officers_id LEFT JOIN {tableName3} ON {tableName3}.id={tableName}.accountable_forms_id LEFT JOIN {tableName4} ON {tableName4}.id={tableName}.general_ledger_accounts_id LEFT JOIN {tableName5} u1 ON u1.id={tableName}.created_by LEFT JOIN {tableName5} u2 ON u2.id={tableName}.updated_by LEFT JOIN {tableName8} ON {tableName4}.sub_major_account_group_id={tableName8}.id LEFT JOIN {tableName7} ON {tableName8}.major_account_group_id={tableName7}.id LEFT JOIN {tableName6} ON {tableName7}.account_group_id={tableName6}.id LEFT JOIN {tableName9} ON {tableName}.subsidiary_ledger_accounts_id={tableName9}.id ORDER BY {tableName}.id DESC";

                var dtRCI = new DataTable();
                return _dbGenericCommands.Fill(query, dtRCI);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Insert(PaymentCollectionModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@collecting_officers_id", DbType.Int16, entity.CoId},
                    new object[] { "@accountable_forms_id", DbType.Int16, entity.AccId},
                    new object[] { "@general_ledger_accounts_id", DbType.Int16, entity.GlaId},
                    new object[] { "@subsidiary_ledger_accounts_id", DbType.Int16, entity.SlaId},
                    new object[] { "@payee", DbType.String, entity.Payee},
                    new object[] { "@receipt_no", DbType.String, entity.ReceiptNo},
                    new object[] { "@payment_date", DbType.DateTime, entity.PaymentDate},
                    new object[] { "@amount", DbType.Decimal, entity.Amount},
                    new object[] { "@created_by", DbType.Int16, entity.CreatedBy}                    
                };

                string query = $"INSERT INTO {tableName} (collecting_officers_id,accountable_forms_id,general_ledger_accounts_id,subsidiary_ledger_accounts_id,payee,receipt_no,payment_date,amount,created_by) VALUES (@collecting_officers_id,@accountable_forms_id,@general_ledger_accounts_id,@subsidiary_ledger_accounts_id,@payee,@receipt_no,@payment_date,@amount,@created_by)";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(PaymentCollectionModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int16, entity.Id},
                    new object[] { "@collecting_officers_id", DbType.Int16, entity.CoId},
                    new object[] { "@accountable_forms_id", DbType.Int16, entity.AccId},
                    new object[] { "@general_ledger_accounts_id", DbType.Int16, entity.GlaId},
                    new object[] { "@subsidiary_ledger_accounts_id", DbType.Int16, entity.SlaId},
                    new object[] { "@payee", DbType.String, entity.Payee},
                    new object[] { "@receipt_no", DbType.String, entity.ReceiptNo},
                    new object[] { "@payment_date", DbType.DateTime, entity.PaymentDate},
                    new object[] { "@amount", DbType.Decimal, entity.Amount},
                    new object[] { "@updated_by", DbType.Int16, entity.UpdatedBy}
                };

                string query = $"UPDATE {tableName} SET collecting_officers_id=@collecting_officers_id,accountable_forms_id=@accountable_forms_id,general_ledger_accounts_id=@general_ledger_accounts_id,subsidiary_ledger_accounts_id=@subsidiary_ledger_accounts_id,payee=@payee,receipt_no=@receipt_no,payment_date=@payment_date,amount=@amount,updated_by=@updated_by WHERE id = @id";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Delete(List<PaymentCollectionModel> entityList)
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

        public DataTable GetRecordsBySearch(string searchText)
        {
            try
            {
                var srchtxt = searchText;

                string query = $"SELECT {tableName}.id,CONCAT(DATE_FORMAT({tableName}.payment_date,'%y'),'-',DATE_FORMAT({tableName}.payment_date,'%m'),'-',LPAD({tableName}.id, 3, 0)) AS rcdno,CONCAT({tableName6}.account_group_code,'-',{tableName7}.maj_acc_group_code,'-',{tableName8}.sub_maj_acc_group_code,'-',{tableName4}.ledger_code) AS account_code,CONCAT({tableName3}.acc_form_no,'-',{tableName3}.acc_form_desc) AS accform,{tableName4}.ledger_name,CONCAT({tableName9}.sub_code,'-',{tableName9}.sub_name) AS subsidiary,{tableName}.payee,{tableName}.receipt_no,{tableName}.payment_date,{tableName}.amount,CONCAT({tableName2}.last_name,', ',{tableName2}.first_name,' ',{tableName2}.mid_initial) AS collector,{tableName}.created_at,{tableName}.updated_at,CONCAT(u1.last_name,', ',u1.first_name,' ',u1.mid_initial) AS createdby,CONCAT(u2.last_name,', ',u2.first_name,' ',u2.mid_initial) AS updatedby FROM {tableName} LEFT JOIN {tableName2} ON {tableName2}.id={tableName}.collecting_officers_id LEFT JOIN {tableName3} ON {tableName3}.id={tableName}.accountable_forms_id LEFT JOIN {tableName4} ON {tableName4}.id={tableName}.general_ledger_accounts_id LEFT JOIN {tableName5} u1 ON u1.id={tableName}.created_by LEFT JOIN {tableName5} u2 ON u2.id={tableName}.updated_by LEFT JOIN {tableName8} ON {tableName4}.sub_major_account_group_id={tableName8}.id LEFT JOIN {tableName7} ON {tableName8}.major_account_group_id={tableName7}.id LEFT JOIN {tableName6} ON {tableName7}.account_group_id={tableName6}.id LEFT JOIN {tableName9} ON {tableName}.subsidiary_ledger_accounts_id={tableName9}.id WHERE {tableName}.payee  LIKE'%{srchtxt}%' OR {tableName}.receipt_no  LIKE'%{srchtxt}%' OR {tableName}.payment_date  LIKE'%{srchtxt}%' OR {tableName}.amount  LIKE'%{srchtxt}%' OR CONCAT({tableName2}.last_name,', ',{tableName2}.first_name,' ',{tableName2}.mid_initial) LIKE'%{srchtxt}%' OR {tableName3}.acc_form_no  LIKE'%{srchtxt}%' OR {tableName3}.acc_form_desc LIKE'%{srchtxt}%' OR CONCAT(DATE_FORMAT({tableName}.payment_date,'%y'),'-',DATE_FORMAT({tableName}.payment_date,'%m'),'-',LPAD({tableName}.id, 3, 0)) LIKE'%{srchtxt}%' OR CONCAT({tableName6}.account_group_code,'-',{tableName7}.maj_acc_group_code,'-',{tableName8}.sub_maj_acc_group_code,'-',{tableName4}.ledger_code) LIKE'%{srchtxt}%' OR {tableName4}.ledger_name LIKE'%{srchtxt}%' OR CONCAT(u1.last_name,', ',u1.first_name,' ',u1.mid_initial) LIKE'%{srchtxt}%' OR CONCAT(u2.last_name,', ',u2.first_name,' ',u2.mid_initial) LIKE'%{srchtxt}%' ORDER BY {tableName}.id DESC";

                var dtpc = new DataTable();
                return _dbGenericCommands.Fill(query, dtpc);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetRecordByLedger(string month)
        {
            try
            {
                string query = $"SELECT {tableName}.id,CONCAT(DATE_FORMAT({tableName}.payment_date,'%y'),'-',DATE_FORMAT({tableName}.payment_date,'%m'),'-',LPAD({tableName}.id, 3, 0)) AS rcdno,CONCAT({tableName6}.account_group_code,'-',{tableName7}.maj_acc_group_code,'-',{tableName8}.sub_maj_acc_group_code,'-',{tableName4}.ledger_code) AS account_code,CONCAT({tableName3}.acc_form_no,'-',{tableName3}.acc_form_desc) AS accform,{tableName4}.ledger_name,CONCAT({tableName9}.sub_code,'-',{tableName9}.sub_name) AS subsidiary,{tableName}.payee,{tableName}.receipt_no,{tableName}.payment_date,{tableName}.amount,CONCAT({tableName2}.last_name,', ',{tableName2}.first_name,' ',{tableName2}.mid_initial) AS collector,{tableName}.created_at,{tableName}.updated_at,CONCAT(u1.last_name,', ',u1.first_name,' ',u1.mid_initial) AS createdby,CONCAT(u2.last_name,', ',u2.first_name,' ',u2.mid_initial) AS updatedby FROM {tableName} LEFT JOIN {tableName2} ON {tableName2}.id={tableName}.collecting_officers_id LEFT JOIN {tableName3} ON {tableName3}.id={tableName}.accountable_forms_id LEFT JOIN {tableName4} ON {tableName4}.id={tableName}.general_ledger_accounts_id LEFT JOIN {tableName5} u1 ON u1.id={tableName}.created_by LEFT JOIN {tableName5} u2 ON u2.id={tableName}.updated_by LEFT JOIN {tableName8} ON {tableName4}.sub_major_account_group_id={tableName8}.id LEFT JOIN {tableName7} ON {tableName8}.major_account_group_id={tableName7}.id LEFT JOIN {tableName6} ON {tableName7}.account_group_id={tableName6}.id LEFT JOIN {tableName9} ON {tableName}.subsidiary_ledger_accounts_id={tableName9}.id WHERE DATE_FORMAT({tableName}.payment_date,'%M-%Y')='{month}' ORDER BY {tableName}.id DESC";

                var dtpc = new DataTable();
                return _dbGenericCommands.Fill(query, dtpc);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
