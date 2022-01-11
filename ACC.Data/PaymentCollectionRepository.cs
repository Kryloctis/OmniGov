using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Transactions;
using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using AccountingSystem;

namespace ACC.Data
{
    public class PaymentCollectionRepository:IPaymentCollectionRepository
    {
        private readonly IDbGenericCommands _dbGenericCommands;
        private readonly string tablePaymentCollections = "payment_collections";
        private readonly string tableCollectionOfficers = "collecting_officers";
        private readonly string tableAccountableForms = "accountable_forms";
        private readonly string tableGeneralLedgerAccounts = "general_ledger_accounts";
        private readonly string tableUsers = "users";
        private readonly string tableAccountaGroup = "account_group";
        private readonly string tableMajorAccountGroup = "major_account_group";
        private readonly string tableSubMajorAccountGroup = "sub_major_account_group";
        private readonly string tableSubsidiaryLedgerAccounts = "subsidiary_ledger_accounts";
        private readonly string tableCollectorReportPayments = "collector_report_payments";
        private readonly string tableFunds = "funds";
        private readonly string viewTableName = "view_payment_collections";


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

                string query = $"SELECT * FROM {tablePaymentCollections} WHERE id = @id";

                using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;
                    record.Add("funds_id", reader.Rows[0]["funds_id"].ToString());
                    record.Add("collecting_officers_id", reader.Rows[0]["collecting_officers_id"].ToString());
                    record.Add("accountable_forms_id", reader.Rows[0]["accountable_forms_id"].ToString());
                    record.Add("general_ledger_accounts_id", reader.Rows[0]["general_ledger_accounts_id"].ToString());
                    record.Add("subsidiary_ledger_accounts_id", reader.Rows[0]["subsidiary_ledger_accounts_id"].ToString());
                    record.Add("payee", reader.Rows[0]["payee"].ToString());
                    record.Add("receipt_no", reader.Rows[0]["receipt_no"].ToString());
                    record.Add("quantity", reader.Rows[0]["quantity"].ToString());
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
            string query = $"SELECT * FROM {viewTableName}";
                
            var dtPaymentCollection = new DataTable();
            return _dbGenericCommands.Fill(query, dtPaymentCollection);
        }

        public DataTable GetRecordsByDate(string date)
        {
            var parameter = new object[]
            {
                new object[]{"@date", DbType.DateTime2, date}
            };
            string query  = $"SELECT * FROM {viewTableName} WHERE date = @date";

            var dtPaymentCollection = new DataTable();
            return _dbGenericCommands.FillBySearch(query, dtPaymentCollection, parameter);
        }


        public bool Insert(PaymentCollectionModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@funds_id", DbType.Int16, entity.FundId},
                    new object[] { "@collecting_officers_id", DbType.Int16, entity.CollectingOfficerId},
                    new object[] { "@accountable_forms_id", DbType.Int16, entity.AccountableFormId},
                    new object[] { "@general_ledger_accounts_id", DbType.Int16, entity.GeneralLedgerAccountId},
                    new object[] { "@subsidiary_ledger_accounts_id", DbType.Int16, entity.SlaId},
                    new object[] { "@payee", DbType.String, entity.Payee},
                    new object[] { "@receipt_no", DbType.String, entity.ReceiptNo},
                    new object[] { "@quantity", DbType.String, entity.Quantity},
                    new object[] { "@payment_date", DbType.DateTime, entity.PaymentDate},
                    new object[] { "@amount", DbType.Decimal, entity.Amount},
                    new object[] { "@created_by", DbType.Int16, entity.CreatedBy}                    
                };
                
                string query = $"INSERT INTO {tablePaymentCollections} (funds_id, collecting_officers_id,accountable_forms_id,general_ledger_accounts_id,payee,receipt_no, quantity, payment_date, amount, created_by) VALUES (@funds_id,@collecting_officers_id,@accountable_forms_id,@general_ledger_accounts_id,@payee,@receipt_no, @quantity, @payment_date,@amount,@created_by)";

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
                    new object[] { "@funds_id", DbType.Int16, entity.FundId},
                    new object[] { "@collecting_officers_id", DbType.Int16, entity.CollectingOfficerId},
                    new object[] { "@accountable_forms_id", DbType.Int16, entity.AccountableFormId},
                    new object[] { "@general_ledger_accounts_id", DbType.Int16, entity.GeneralLedgerAccountId},
                    new object[] { "@subsidiary_ledger_accounts_id", DbType.Int16, entity.SlaId},
                    new object[] { "@payee", DbType.String, entity.Payee},
                    new object[] { "@receipt_no", DbType.String, entity.ReceiptNo},
                    new object[] { "@payment_date", DbType.DateTime, entity.PaymentDate},
                    new object[] { "@amount", DbType.Decimal, entity.Amount},
                    new object[] { "@updated_by", DbType.Int16, entity.UpdatedBy}
                };
                string query = string.Empty;
                if (entity.SlaId > 0)
                {
                    query = $"UPDATE {tablePaymentCollections} SET funds_id=@funds_id,collecting_officers_id=@collecting_officers_id,accountable_forms_id=@accountable_forms_id,general_ledger_accounts_id=@general_ledger_accounts_id,subsidiary_ledger_accounts_id=@subsidiary_ledger_accounts_id,payee=@payee,receipt_no=@receipt_no,payment_date=@payment_date,amount=@amount,updated_by=@updated_by WHERE id = @id";
                }
                else
                {
                    query = $"UPDATE {tablePaymentCollections} SET funds_id=@funds_id,collecting_officers_id=@collecting_officers_id,accountable_forms_id=@accountable_forms_id,general_ledger_accounts_id=@general_ledger_accounts_id,subsidiary_ledger_accounts_id=NULL,payee=@payee,receipt_no=@receipt_no,payment_date=@payment_date,amount=@amount,updated_by=@updated_by WHERE id = @id";
                }                    
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

                        string query = $"DELETE FROM {tablePaymentCollections} WHERE id = @id";
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
                string query = $"SELECT COUNT(*) FROM {tablePaymentCollections}";

                return int.Parse(_dbGenericCommands.ExecuteScalar(query));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public decimal SumRecords()
        {
            try
            {
                string query = $"SELECT SUM(amount) FROM {tablePaymentCollections}";

                string result = _dbGenericCommands.ExecuteScalar(query);
                return !string.IsNullOrEmpty(result) ? decimal.Parse(result) : decimal.Parse("0.00");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public decimal SumRecords(int Id,string month)
        {
            try
            {
                string query = $"SELECT SUM(amount) FROM {tablePaymentCollections} WHERE collecting_officers_id='{Id}' AND DATE_FORMAT(payment_date,'%M-%Y')='{month}'";

                string result = _dbGenericCommands.ExecuteScalar(query);
                return !string.IsNullOrEmpty(result) ? decimal.Parse(result) : decimal.Parse("0.00");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public decimal SumRecords(int Id,int fid, string from,string to)
        {
            try
            {
                string query = $"SELECT SUM(amount) FROM {tablePaymentCollections} WHERE collecting_officers_id='{Id}' AND {tablePaymentCollections}.funds_id='{fid}' AND (payment_date BETWEEN CAST('{from}' AS DATE) AND CAST('{to}' AS DATE))";

                string result = _dbGenericCommands.ExecuteScalar(query);
                return !string.IsNullOrEmpty(result) ? decimal.Parse(result) : decimal.Parse("0.00");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public decimal SumRecords(int Id,int fid, string from, string to,string ids)
        {
            try
            {
                string query = $"SELECT SUM(amount) FROM {tablePaymentCollections} WHERE collecting_officers_id='{Id}' AND {tablePaymentCollections}.funds_id='{fid}' AND (payment_date BETWEEN CAST('{from}' AS DATE) AND CAST('{to}' AS DATE)) AND id NOT IN ({ids})";

                string result = _dbGenericCommands.ExecuteScalar(query);
                return !string.IsNullOrEmpty(result) ? decimal.Parse(result) : decimal.Parse("0.00");
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

                string query = $"SELECT id FROM {tablePaymentCollections} WHERE id = @id";
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

        public bool ReceiptExist(string receipt,int formid)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@receipt_no", DbType.String, receipt },
                    new object[] { "@accountable_forms_id", DbType.String, formid },
                };

                string query = $"SELECT id FROM {tablePaymentCollections} WHERE receipt_no=@receipt_no AND accountable_forms_id=@accountable_forms_id";
                string queryResult = _dbGenericCommands.ExecuteScalar(query, parameters);

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
                var parameter = new object[][] {
                    new object[] { "@searchText", DbType.String, $"%{searchText}%" }
                }; 

                string query = $"SELECT * FROM {viewTableName}  WHERE accountable_forms LIKE @searchText OR collecting_officer LIKE @searchText";

                
               
                var dtpc = new DataTable();
                return _dbGenericCommands.FillBySearch(query, dtpc, parameter);
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
                string query = $"SELECT {tablePaymentCollections}.id,CONCAT({tableFunds}.fund_code,' - ',{tableFunds}.fund_name) AS fund,CONCAT({tableAccountaGroup}.account_group_code,'-',{tableMajorAccountGroup}.maj_acc_group_code,'-',{tableSubMajorAccountGroup}.sub_maj_acc_group_code,'-',{tableGeneralLedgerAccounts}.ledger_code) AS account_code,CONCAT({tableAccountableForms}.acc_form_no,'-',{tableAccountableForms}.acc_form_desc) AS accform,{tableGeneralLedgerAccounts}.ledger_name,CONCAT({tableSubsidiaryLedgerAccounts}.sub_code,'-',{tableSubsidiaryLedgerAccounts}.sub_name) AS subsidiary,{tablePaymentCollections}.payee,{tablePaymentCollections}.receipt_no,{tablePaymentCollections}.payment_date,{tablePaymentCollections}.amount,CONCAT({tableCollectionOfficers}.last_name,', ',{tableCollectionOfficers}.first_name,' ',{tableCollectionOfficers}.mid_initial) AS collector,{tablePaymentCollections}.created_at,{tablePaymentCollections}.updated_at,CONCAT(u1.last_name,', ',u1.first_name,' ',u1.mid_initial) AS createdby,CONCAT(u2.last_name,', ',u2.first_name,' ',u2.mid_initial) AS updatedby FROM {tablePaymentCollections} LEFT JOIN {tableCollectionOfficers} ON {tableCollectionOfficers}.id={tablePaymentCollections}.collecting_officers_id LEFT JOIN {tableAccountableForms} ON {tableAccountableForms}.id={tablePaymentCollections}.accountable_forms_id LEFT JOIN {tableGeneralLedgerAccounts} ON {tableGeneralLedgerAccounts}.id={tablePaymentCollections}.general_ledger_accounts_id LEFT JOIN {tableUsers} u1 ON u1.id={tablePaymentCollections}.created_by LEFT JOIN {tableUsers} u2 ON u2.id={tablePaymentCollections}.updated_by LEFT JOIN {tableSubMajorAccountGroup} ON {tableGeneralLedgerAccounts}.sub_major_account_group_id={tableSubMajorAccountGroup}.id LEFT JOIN {tableMajorAccountGroup} ON {tableSubMajorAccountGroup}.major_account_group_id={tableMajorAccountGroup}.id LEFT JOIN {tableAccountaGroup} ON {tableMajorAccountGroup}.account_group_id={tableAccountaGroup}.id LEFT JOIN {tableSubsidiaryLedgerAccounts} ON {tablePaymentCollections}.subsidiary_ledger_accounts_id={tableSubsidiaryLedgerAccounts}.id LEFT JOIN {tableFunds} ON {tablePaymentCollections}.funds_id={tableFunds}.id WHERE DATE_FORMAT({tablePaymentCollections}.payment_date,'%M-%Y')='{month}' ORDER BY {tablePaymentCollections}.id DESC";

                var dtpc = new DataTable();
                return _dbGenericCommands.Fill(query, dtpc);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetRecordByLedger(int Id,string month)
        {
            try
            {
                string query = $"SELECT {tablePaymentCollections}.id,CONCAT({tableFunds}.fund_code,' - ',{tableFunds}.fund_name) AS fund,CONCAT({tableAccountaGroup}.account_group_code,'-',{tableMajorAccountGroup}.maj_acc_group_code,'-',{tableSubMajorAccountGroup}.sub_maj_acc_group_code,'-',{tableGeneralLedgerAccounts}.ledger_code) AS account_code,CONCAT({tableAccountableForms}.acc_form_no,'-',{tableAccountableForms}.acc_form_desc) AS accform,{tableGeneralLedgerAccounts}.ledger_name,CONCAT({tableSubsidiaryLedgerAccounts}.sub_code,'-',{tableSubsidiaryLedgerAccounts}.sub_name) AS subsidiary,{tablePaymentCollections}.payee,{tablePaymentCollections}.receipt_no,{tablePaymentCollections}.payment_date,{tablePaymentCollections}.amount,CONCAT({tableCollectionOfficers}.last_name,', ',{tableCollectionOfficers}.first_name,' ',{tableCollectionOfficers}.mid_initial) AS collector,{tablePaymentCollections}.created_at,{tablePaymentCollections}.updated_at,CONCAT(u1.last_name,', ',u1.first_name,' ',u1.mid_initial) AS createdby,CONCAT(u2.last_name,', ',u2.first_name,' ',u2.mid_initial) AS updatedby FROM {tablePaymentCollections} LEFT JOIN {tableCollectionOfficers} ON {tableCollectionOfficers}.id={tablePaymentCollections}.collecting_officers_id LEFT JOIN {tableAccountableForms} ON {tableAccountableForms}.id={tablePaymentCollections}.accountable_forms_id LEFT JOIN {tableGeneralLedgerAccounts} ON {tableGeneralLedgerAccounts}.id={tablePaymentCollections}.general_ledger_accounts_id LEFT JOIN {tableUsers} u1 ON u1.id={tablePaymentCollections}.created_by LEFT JOIN {tableUsers} u2 ON u2.id={tablePaymentCollections}.updated_by LEFT JOIN {tableSubMajorAccountGroup} ON {tableGeneralLedgerAccounts}.sub_major_account_group_id={tableSubMajorAccountGroup}.id LEFT JOIN {tableMajorAccountGroup} ON {tableSubMajorAccountGroup}.major_account_group_id={tableMajorAccountGroup}.id LEFT JOIN {tableAccountaGroup} ON {tableMajorAccountGroup}.account_group_id={tableAccountaGroup}.id LEFT JOIN {tableSubsidiaryLedgerAccounts} ON {tablePaymentCollections}.subsidiary_ledger_accounts_id={tableSubsidiaryLedgerAccounts}.id LEFT JOIN {tableFunds} ON {tablePaymentCollections}.funds_id={tableFunds}.id WHERE {tableCollectionOfficers}.id='{Id}' AND DATE_FORMAT({tablePaymentCollections}.payment_date,'%M-%Y')='{month}'";

                var dtpc = new DataTable();
                return _dbGenericCommands.Fill(query, dtpc);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetRecordByLedger(int Id,int fid, string from,string to)
        {
            try
            {
                string query = $"SELECT {tablePaymentCollections}.id,CONCAT({tableFunds}.fund_code,' - ',{tableFunds}.fund_name) AS fund,CONCAT({tableAccountaGroup}.account_group_code,'-',{tableMajorAccountGroup}.maj_acc_group_code,'-',{tableSubMajorAccountGroup}.sub_maj_acc_group_code,'-',{tableGeneralLedgerAccounts}.ledger_code) AS account_code,CONCAT({tableAccountableForms}.acc_form_no,'-',{tableAccountableForms}.acc_form_desc) AS accform,{tableGeneralLedgerAccounts}.ledger_name,CONCAT({tableSubsidiaryLedgerAccounts}.sub_code,'-',{tableSubsidiaryLedgerAccounts}.sub_name) AS subsidiary,{tablePaymentCollections}.payee,{tablePaymentCollections}.receipt_no,{tablePaymentCollections}.payment_date,{tablePaymentCollections}.amount,CONCAT({tableCollectionOfficers}.last_name,', ',{tableCollectionOfficers}.first_name,' ',{tableCollectionOfficers}.mid_initial) AS collector,{tablePaymentCollections}.created_at,{tablePaymentCollections}.updated_at,CONCAT(u1.last_name,', ',u1.first_name,' ',u1.mid_initial) AS createdby,CONCAT(u2.last_name,', ',u2.first_name,' ',u2.mid_initial) AS updatedby FROM {tablePaymentCollections} LEFT JOIN {tableCollectionOfficers} ON {tableCollectionOfficers}.id={tablePaymentCollections}.collecting_officers_id LEFT JOIN {tableAccountableForms} ON {tableAccountableForms}.id={tablePaymentCollections}.accountable_forms_id LEFT JOIN {tableGeneralLedgerAccounts} ON {tableGeneralLedgerAccounts}.id={tablePaymentCollections}.general_ledger_accounts_id LEFT JOIN {tableUsers} u1 ON u1.id={tablePaymentCollections}.created_by LEFT JOIN {tableUsers} u2 ON u2.id={tablePaymentCollections}.updated_by LEFT JOIN {tableSubMajorAccountGroup} ON {tableGeneralLedgerAccounts}.sub_major_account_group_id={tableSubMajorAccountGroup}.id LEFT JOIN {tableMajorAccountGroup} ON {tableSubMajorAccountGroup}.major_account_group_id={tableMajorAccountGroup}.id LEFT JOIN {tableAccountaGroup} ON {tableMajorAccountGroup}.account_group_id={tableAccountaGroup}.id LEFT JOIN {tableSubsidiaryLedgerAccounts} ON {tablePaymentCollections}.subsidiary_ledger_accounts_id={tableSubsidiaryLedgerAccounts}.id LEFT JOIN {tableFunds} ON {tablePaymentCollections}.funds_id={tableFunds}.id WHERE {tableCollectionOfficers}.id='{Id}' AND {tableFunds}.id={fid} AND ({tablePaymentCollections}.payment_date BETWEEN CAST('{from}' AS DATE) AND CAST('{to}' AS DATE)) AND {tablePaymentCollections}.id NOT IN (SELECT payment_collections_id FROM {tableCollectorReportPayments})";

                var dtpc = new DataTable();
                return _dbGenericCommands.Fill(query, dtpc);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetRecordByLedger(object[] parameter)
        {
            var parameters = new object[][]
            {
                new object[] { "@collectorId", DbType.UInt16, parameter[0] },
                new object[] { "@collectionFund", DbType.UInt16, parameter[1] },
                new object[] { "@collectionDateFrom", DbType.Date, parameter[2] },
                new object[] { "@collectionDateTo", DbType.Date, parameter[3] }
            };

            string query =  $"SELECT " +
                            $"id AS payment_collections_id, " +
                            $"funds_id, " +
                            $"fund_name, " +
                            $"accountable_form_id," +
                            $"accountable_forms," +
                            $"general_ledger_accounts_id, " +
                            $"account_code, " +
                            $"ledger_name, " +
                            $"payee, " +
                            $"receipt_no, " +
                            $"quantity, " +
                            $"payment_date, " +
                            $"amount " +
                            $"FROM {viewTableName} " +
                            $"WHERE collecting_officer_id = @collectorId AND payment_date " +
                            $"BETWEEN @collectionDateFrom AND @collectionDateTo ";

            var dtPaymentCollection = new DataTable();
            return _dbGenericCommands.FillBySearch(query, dtPaymentCollection, parameters);
        }

        public DataTable GetRecordByExcel(string month)
        {
            try
            {
                string query = $"SELECT {tablePaymentCollections}.id,CONCAT({tableFunds}.fund_code,' - ',{tableFunds}.fund_name) AS fund,CONCAT({tableAccountaGroup}.account_group_code,'-',{tableMajorAccountGroup}.maj_acc_group_code,'-',{tableSubMajorAccountGroup}.sub_maj_acc_group_code,'-',{tableGeneralLedgerAccounts}.ledger_code) AS account_code,CONCAT({tableAccountableForms}.acc_form_no,'-',{tableAccountableForms}.acc_form_desc) AS accform,{tableGeneralLedgerAccounts}.ledger_name,CONCAT({tableSubsidiaryLedgerAccounts}.sub_code,'-',{tableSubsidiaryLedgerAccounts}.sub_name) AS subsidiary,{tablePaymentCollections}.payee,{tablePaymentCollections}.receipt_no,{tablePaymentCollections}.payment_date,{tablePaymentCollections}.amount,CONCAT({tableCollectionOfficers}.last_name,', ',{tableCollectionOfficers}.first_name,' ',{tableCollectionOfficers}.mid_initial) AS collector,{tablePaymentCollections}.created_at,{tablePaymentCollections}.updated_at,CONCAT(u1.last_name,', ',u1.first_name,' ',u1.mid_initial) AS createdby,CONCAT(u2.last_name,', ',u2.first_name,' ',u2.mid_initial) AS updatedby FROM {tablePaymentCollections} LEFT JOIN {tableCollectionOfficers} ON {tableCollectionOfficers}.id={tablePaymentCollections}.collecting_officers_id LEFT JOIN {tableAccountableForms} ON {tableAccountableForms}.id={tablePaymentCollections}.accountable_forms_id LEFT JOIN {tableGeneralLedgerAccounts} ON {tableGeneralLedgerAccounts}.id={tablePaymentCollections}.general_ledger_accounts_id LEFT JOIN {tableUsers} u1 ON u1.id={tablePaymentCollections}.created_by LEFT JOIN {tableUsers} u2 ON u2.id={tablePaymentCollections}.updated_by LEFT JOIN {tableSubMajorAccountGroup} ON {tableGeneralLedgerAccounts}.sub_major_account_group_id={tableSubMajorAccountGroup}.id LEFT JOIN {tableMajorAccountGroup} ON {tableSubMajorAccountGroup}.major_account_group_id={tableMajorAccountGroup}.id LEFT JOIN {tableAccountaGroup} ON {tableMajorAccountGroup}.account_group_id={tableAccountaGroup}.id LEFT JOIN {tableSubsidiaryLedgerAccounts} ON {tablePaymentCollections}.subsidiary_ledger_accounts_id={tableSubsidiaryLedgerAccounts}.id LEFT JOIN {tableFunds} ON {tablePaymentCollections}.funds_id={tableFunds}.id WHERE {tableAccountaGroup}.id='4' AND DATE_FORMAT({tablePaymentCollections}.payment_date,'%M-%Y')='{month}' ORDER BY {tablePaymentCollections}.id DESC";

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
