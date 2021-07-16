using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Transactions;

namespace ACC.Data
{
    class GeneralCollectionsRepository:IGeneralCollectionsRepository
    {
        private readonly IDbGenericCommands _dbGenericCommands;
        private readonly string tableName = "general_collections";
        private readonly string tableName2 = "users";
        private readonly string tableName3 = "general_collections_payment";
        private readonly string tableName4 = "collector_report_payments";
        private readonly string tableName5 = "payment_collections";
        private readonly string tableName6 = "general_collections_deposits";
        private readonly string tableName7 = "bank_deposits";
        private readonly string tableName8 = "collecting_officers";
        private readonly string tableName9 = "accountable_forms";
        private readonly string tableName10 = "general_ledger_accounts";
        private readonly string tableName11 = "account_group";
        private readonly string tableName12 = "major_account_group";
        private readonly string tableName13 = "sub_major_account_group";
        private readonly string tableName14 = "subsidiary_ledger_accounts";
        private readonly string tableName15 = "collector_report";
        private readonly string tableName16 = "general_collections_deposits";
        private readonly string tableName17 = "banks";
        private readonly string tableName18 = "funds";
        private readonly string tableName19 = "receipts";
        private readonly string tableName20 = "receipts_issued";
        public GeneralCollectionsRepository(IDbGenericCommands dbGenericCommands)
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

                string query = $"SELECT * FROM {tableName} WHERE id = @id";

                using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;
                    record.Add("id", reader.Rows[0]["id"].ToString());
                    record.Add("rcd_no", reader.Rows[0]["rcd_no"].ToString());
                    record.Add("rcd_date", reader.Rows[0]["rcd_date"].ToString());
                    record.Add("users_id", reader.Rows[0]["users_id"].ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }

            return record;
        }

        public Dictionary<string, string> GetRecordByID(string Id)
        {
            var record = new Dictionary<string, string>();

            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@rcd_no", DbType.String, Id},
                };

                string query = $"SELECT * FROM {tableName} WHERE  rcd_no= @rcd_no";

                using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;
                    record.Add("id", reader.Rows[0]["id"].ToString());
                    record.Add("rcd_no", reader.Rows[0]["rcd_no"].ToString());
                    record.Add("rcd_date", reader.Rows[0]["rcd_date"].ToString());
                    record.Add("users_id", reader.Rows[0]["users_id"].ToString());
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
                string query = $"SELECT {tableName}.id,{tableName}.rcd_no,{tableName}.rcd_date,CONCAT({tableName2}.last_name,', ',{tableName2}.first_name,' ',{tableName2}.mid_initial) AS officer,(SELECT SUM({tableName5}.amount) FROM {tableName5} LEFT JOIN {tableName4} ON {tableName4}.payment_collections_id={tableName5}.id LEFT JOIN {tableName3} ON {tableName3}.collector_report_id={tableName4}.collector_report_id WHERE {tableName3}.general_collections_id={tableName}.id) AS colamount,(SELECT IF(COUNT({tableName6}.id)>0,true,false) FROM {tableName6} WHERE {tableName6}.general_collections_id={tableName}.id) AS deposited FROM {tableName} LEFT JOIN {tableName2} ON {tableName2}.id={tableName}.users_id ORDER BY {tableName}.id DESC";

                var dtcr = new DataTable();
                return _dbGenericCommands.Fill(query, dtcr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Insert(GeneralCollectionsModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@rcd_no", DbType.String, entity.Rcdno},
                    new object[] { "@rcd_date", DbType.Date, entity.Rcddate},
                    new object[] { "@users_id", DbType.Int16, entity.Userid},
                };

                string query = $"INSERT INTO {tableName} (rcd_no,rcd_date,users_id) VALUES (@rcd_no,@rcd_date,@users_id)";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(GeneralCollectionsModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int16, entity.Id},
                    new object[] { "@rcd_no", DbType.String, entity.Rcdno},
                    new object[] { "@rcd_date", DbType.Date, entity.Rcddate},
                };

                string query = $"UPDATE {tableName} SET rcd_no=@rcd_no,rcd_date=@rcd_date WHERE id=@id";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(List<GeneralCollectionsModel> entityList)
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

        public bool CodeExist(string id)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@rcd_no", DbType.String, id },
                };

                string query = $"SELECT rcd_no FROM {tableName} WHERE rcd_no = @rcd_no";
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
                string query = $"SELECT {tableName}.id,{tableName}.rcd_no,{tableName}.rcd_date,CONCAT({tableName2}.last_name,', ',{tableName2}.first_name,' ',{tableName2}.mid_initial) AS officer,(SELECT SUM({tableName5}.amount) FROM {tableName5} LEFT JOIN {tableName4} ON {tableName4}.payment_collections_id={tableName5}.id LEFT JOIN {tableName3} ON {tableName3}.collector_report_id={tableName4}.collector_report_id WHERE {tableName3}.general_collections_id={tableName}.id) AS colamount,(SELECT IF(COUNT({tableName6}.id)>0,true,false) FROM {tableName6} WHERE {tableName6}.general_collections_id={tableName}.id) AS deposited FROM {tableName} LEFT JOIN {tableName2} ON {tableName2}.id={tableName}.users_id WHERE {tableName}.rcd_no LIKE '%{searchText}%' OR CONCAT({tableName2}.last_name,', ',{tableName2}.first_name,' ',{tableName2}.mid_initial) LIKE '%{searchText}%' ORDER BY {tableName}.id DESC";

                var dtpc = new DataTable();
                return _dbGenericCommands.Fill(query, dtpc);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public decimal SumRecords(int id)
        {
            try
            {
                string query = $"SELECT SUM({tableName5}.amount) FROM {tableName5} LEFT JOIN {tableName4} ON {tableName4}.payment_collections_id={tableName5}.id LEFT JOIN {tableName3} ON {tableName3}.collector_report_id={tableName4}.collector_report_id WHERE {tableName3}.general_collections_id='{id}'";
                string result = _dbGenericCommands.ExecuteScalar(query);
                return !string.IsNullOrEmpty(result) ? decimal.Parse(result) : decimal.Parse("0.00");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetRecordByGC(string Id)
        {
            try
            {
                string query = $"SELECT {tableName}.id,{tableName}.rcd_no,{tableName15}.report_no,CONCAT({tableName11}.account_group_code,'-',{tableName12}.maj_acc_group_code,'-',{tableName13}.sub_maj_acc_group_code,'-',{tableName10}.ledger_code) AS account_code,CONCAT({tableName9}.acc_form_no,'-',{tableName9}.acc_form_desc) AS accform,{tableName10}.ledger_name,CONCAT({tableName14}.sub_code,'-',{tableName14}.sub_name) AS subsidiary,{tableName5}.payee,{tableName5}.receipt_no,{tableName5}.payment_date,{tableName5}.amount,CONCAT({tableName8}.last_name,', ',{tableName8}.first_name,' ',{tableName8}.mid_initial) AS collector,{tableName5}.created_at,{tableName5}.updated_at,CONCAT(u1.last_name,', ',u1.first_name,' ',u1.mid_initial) AS createdby,CONCAT(u2.last_name,', ',u2.first_name,' ',u2.mid_initial) AS updatedby,CONCAT(u3.last_name,', ',u3.first_name,' ',u3.mid_initial) AS officer FROM {tableName} LEFT JOIN {tableName3} ON {tableName3}.general_collections_id={tableName}.id LEFT JOIN {tableName4} ON {tableName4}.collector_report_id={tableName3}.collector_report_id LEFT JOIN {tableName5} ON {tableName5}.id={tableName4}.payment_collections_id LEFT JOIN {tableName15} ON {tableName4}.collector_report_id={tableName15}.id LEFT JOIN {tableName9} ON {tableName5}.accountable_forms_id={tableName9}.id LEFT JOIN {tableName10} ON {tableName5}.general_ledger_accounts_id={tableName10}.id LEFT JOIN {tableName2} u1 ON u1.id={tableName5}.created_by LEFT JOIN {tableName2} u2 ON u2.id={tableName5}.updated_by LEFT JOIN {tableName2} u3 ON u3.id={tableName}.users_id LEFT JOIN {tableName13} ON {tableName13}.id={tableName10}.sub_major_account_group_id LEFT JOIN {tableName12} ON {tableName13}.major_account_group_id={tableName12}.id LEFT JOIN {tableName11} ON {tableName12}.account_group_id={tableName11}.id LEFT JOIN {tableName14} ON {tableName5}.subsidiary_ledger_accounts_id={tableName14}.id LEFT JOIN {tableName8} ON {tableName8}.id={tableName5}.collecting_officers_id WHERE {tableName}.id IN ({Id})";

                var dtpc = new DataTable();
                return _dbGenericCommands.Fill(query, dtpc);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetRecordByGC(string from,string to)
        {
            try
            {
                string query = $"SELECT {tableName}.id,{tableName}.rcd_no,{tableName15}.report_no,CONCAT({tableName11}.account_group_code,'-',{tableName12}.maj_acc_group_code,'-',{tableName13}.sub_maj_acc_group_code,'-',{tableName10}.ledger_code) AS account_code,CONCAT({tableName9}.acc_form_no,'-',{tableName9}.acc_form_desc) AS accform,{tableName10}.ledger_name,CONCAT({tableName14}.sub_code,'-',{tableName14}.sub_name) AS subsidiary,{tableName5}.payee,{tableName5}.receipt_no,{tableName5}.payment_date,{tableName5}.amount,CONCAT({tableName8}.last_name,', ',{tableName8}.first_name,' ',{tableName8}.mid_initial) AS collector,{tableName5}.created_at,{tableName5}.updated_at,CONCAT(u1.last_name,', ',u1.first_name,' ',u1.mid_initial) AS createdby,CONCAT(u2.last_name,', ',u2.first_name,' ',u2.mid_initial) AS updatedby,CONCAT(u3.last_name,', ',u3.first_name,' ',u3.mid_initial) AS officer FROM {tableName} LEFT JOIN {tableName3} ON {tableName3}.general_collections_id={tableName}.id LEFT JOIN {tableName4} ON {tableName4}.collector_report_id={tableName3}.collector_report_id LEFT JOIN {tableName5} ON {tableName5}.id={tableName4}.payment_collections_id LEFT JOIN {tableName15} ON {tableName4}.collector_report_id={tableName15}.id LEFT JOIN {tableName9} ON {tableName5}.accountable_forms_id={tableName9}.id LEFT JOIN {tableName10} ON {tableName5}.general_ledger_accounts_id={tableName10}.id LEFT JOIN {tableName2} u1 ON u1.id={tableName5}.created_by LEFT JOIN {tableName2} u2 ON u2.id={tableName5}.updated_by LEFT JOIN {tableName2} u3 ON u3.id={tableName}.users_id LEFT JOIN {tableName13} ON {tableName13}.id={tableName10}.sub_major_account_group_id LEFT JOIN {tableName12} ON {tableName13}.major_account_group_id={tableName12}.id LEFT JOIN {tableName11} ON {tableName12}.account_group_id={tableName11}.id LEFT JOIN {tableName14} ON {tableName5}.subsidiary_ledger_accounts_id={tableName14}.id LEFT JOIN {tableName8} ON {tableName8}.id={tableName5}.collecting_officers_id WHERE ({tableName}.rcd_date BETWEEN CAST('{from}' AS DATE) AND CAST('{to}' AS DATE))";

                var dtpc = new DataTable();
                return _dbGenericCommands.Fill(query, dtpc);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetRecordByData(string Id)
        {
            try
            {
                string query = $"SELECT {tableName}.id,{tableName}.rcd_no,{tableName}.rcd_date,CONCAT({tableName2}.last_name,', ',{tableName2}.first_name,' ',{tableName2}.mid_initial) AS officer,(SELECT SUM({tableName5}.amount) FROM {tableName5} LEFT JOIN {tableName4} ON {tableName4}.payment_collections_id={tableName5}.id LEFT JOIN {tableName3} ON {tableName3}.collector_report_id={tableName4}.collector_report_id WHERE {tableName3}.general_collections_id={tableName}.id) AS colamount,(SELECT IF(COUNT({tableName6}.id)>0,true,false) FROM {tableName6} WHERE {tableName6}.general_collections_id={tableName}.id) AS deposited,CONCAT({tableName18}.fund_code,'-',{tableName18}.fund_name) AS fund FROM {tableName} LEFT JOIN {tableName2} ON {tableName2}.id={tableName}.users_id LEFT JOIN {tableName3} ON {tableName}.id={tableName3}.general_collections_id LEFT JOIN {tableName15} ON {tableName3}.collector_report_id={tableName15}.id LEFT JOIN {tableName18} ON {tableName15}.funds_id={tableName18}.id WHERE {tableName}.id IN ({Id})";

                var dtcr = new DataTable();
                return _dbGenericCommands.Fill(query, dtcr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetRecordByForms(int Id)
        {
            try
            {
                string query = $"SELECT {tableName}.id,{tableName9}.id AS formid,{tableName9}.acc_form_no,{tableName9}.acc_form_desc,(SELECT pc.receipt_no FROM {tableName3} gcp LEFT JOIN {tableName4} crp ON gcp.collector_report_id=crp.collector_report_id LEFT JOIN {tableName5} pc ON pc.id=crp.payment_collections_id LEFT JOIN {tableName9} af ON af.id=pc.accountable_forms_id WHERE gcp.general_collections_id={tableName}.id AND af.id={tableName9}.id ORDER BY pc.receipt_no ASC LIMIT 1) AS orfrom,(SELECT pc.receipt_no FROM {tableName3} gcp LEFT JOIN {tableName4} crp ON gcp.collector_report_id=crp.collector_report_id LEFT JOIN {tableName5} pc ON pc.id=crp.payment_collections_id LEFT JOIN {tableName9} af ON af.id=pc.accountable_forms_id WHERE gcp.general_collections_id={tableName}.id AND af.id={tableName9}.id ORDER BY pc.receipt_no DESC LIMIT 1) AS orto,(SELECT SUM(pc.amount) FROM {tableName3} gcp LEFT JOIN {tableName4} crp ON gcp.collector_report_id=crp.collector_report_id LEFT JOIN {tableName5} pc ON pc.id=crp.payment_collections_id LEFT JOIN {tableName9} af ON af.id=pc.accountable_forms_id WHERE gcp.general_collections_id={tableName}.id AND af.id={tableName9}.id) AS total FROM {tableName} LEFT JOIN {tableName3} ON {tableName}.id={tableName3}.general_collections_id LEFT JOIN {tableName4} ON {tableName4}.collector_report_id={tableName3}.collector_report_id LEFT JOIN {tableName5} ON {tableName5}.id={tableName4}.payment_collections_id LEFT JOIN {tableName9} ON {tableName5}.accountable_forms_id={tableName9}.id WHERE {tableName}.id='{Id}' GROUP BY formid";

                var dtpc = new DataTable();
                return _dbGenericCommands.Fill(query, dtpc);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataTable GetRecordByCollections(int Id)
        {
            try
            {
                string query = $"SELECT {tableName}.id,{tableName15}.id AS reportid,{tableName15}.report_no,CONCAT({tableName8}.last_name,', ',{tableName8}.first_name,' ',{tableName8}.mid_initial) AS collector,(SELECT SUM(pc.amount) FROM {tableName15} cr LEFT JOIN {tableName4} crp ON cr.id=crp.collector_report_id LEFT JOIN {tableName5} pc ON pc.id=crp.payment_collections_id WHERE cr.id={tableName3}.id) AS total FROM {tableName} LEFT JOIN {tableName3} ON {tableName}.id={tableName3}.general_collections_id LEFT JOIN {tableName4} ON {tableName4}.collector_report_id={tableName3}.collector_report_id LEFT JOIN {tableName5} ON {tableName4}.payment_collections_id={tableName5}.id LEFT JOIN {tableName8} ON {tableName5}.collecting_officers_id={tableName8}.id LEFT JOIN {tableName15} ON {tableName3}.collector_report_id={tableName15}.id WHERE {tableName}.id='{Id}' GROUP BY reportid";

                var dtpc = new DataTable();
                return _dbGenericCommands.Fill(query, dtpc);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetRecordByDeposits(int Id)
        {
            try
            {
                string query = $"SELECT {tableName}.id,{tableName17}.bank_name,{tableName17}.account_no,{tableName7}.reference,{tableName7}.amount FROM {tableName} LEFT JOIN {tableName16} ON {tableName16}.general_collections_id={tableName}.id LEFT JOIN {tableName7} ON {tableName16}.bank_deposits_id={tableName7}.id LEFT JOIN {tableName17} ON {tableName7}.banks_id={tableName17}.id WHERE {tableName}.id='{Id}'";

                var dtpc = new DataTable();
                return _dbGenericCommands.Fill(query, dtpc);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetRecordByReceipts(int Id)
        {
            try
            {
                string query = $"SELECT CONCAT({tableName9}.acc_form_no,'-',{tableName9}.acc_form_desc) AS form,{tableName19}.receiptsfrom,{tableName19}.receiptsto,{tableName20}.issuefrom,{tableName20}.issueto,(SELECT receipt_no FROM {tableName5} WHERE accountable_forms_id={tableName9}.id AND receipt_no BETWEEN {tableName20}.issuefrom-1 AND {tableName20}.issueto+1 ORDER BY receipt_no ASC LIMIT 1) AS ifrom,(SELECT receipt_no FROM {tableName5} WHERE accountable_forms_id={tableName9}.id AND receipt_no BETWEEN {tableName20}.issuefrom-1 AND {tableName20}.issueto+1 ORDER BY receipt_no DESC LIMIT 1) AS ito FROM {tableName9} LEFT JOIN {tableName19} ON {tableName19}.accountable_forms_id={tableName9}.id LEFT JOIN {tableName20} ON {tableName20}.receipts_id={tableName19}.id WHERE {tableName9}.id IN (SELECT {tableName5}.accountable_forms_id FROM {tableName5} LEFT JOIN {tableName4} ON {tableName5}.id={tableName4}.payment_collections_id LEFT JOIN {tableName3} ON {tableName3}.collector_report_id={tableName4}.collector_report_id WHERE {tableName3}.general_collections_id='{Id}' AND {tableName5}.receipt_no BETWEEN {tableName20}.issuefrom-1 AND {tableName20}.issueto+1)";

                var dtpc = new DataTable();
                return _dbGenericCommands.Fill(query, dtpc);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetRecordByReceiptsConsolidated(string to)
        {
            try
            {
                string query = $"SELECT CONCAT({tableName9}.acc_form_no,'-',{tableName9}.acc_form_desc) AS form,{tableName19}.receiptsfrom,{tableName19}.receiptsto,{tableName20}.issuefrom,{tableName20}.issueto,(SELECT receipt_no FROM {tableName5} WHERE accountable_forms_id={tableName9}.id AND collecting_officers_id={tableName8}.id AND payment_date <= CAST('{to}' AS DATE) ORDER BY receipt_no ASC LIMIT 1) AS ifrom,(SELECT receipt_no FROM {tableName5} WHERE accountable_forms_id={tableName9}.id AND collecting_officers_id={tableName8}.id AND payment_date <= CAST('{to}' AS DATE) ORDER BY receipt_no DESC LIMIT 1) AS ito,CONCAT({tableName8}.last_name,', ',{tableName8}.first_name,' ',{tableName8}.mid_initial) AS officers FROM {tableName9} LEFT JOIN {tableName19} ON {tableName19}.accountable_forms_id={tableName9}.id LEFT JOIN {tableName20} ON {tableName20}.receipts_id={tableName19}.id LEFT JOIN {tableName8} ON {tableName20}.collecting_officers_id={tableName8}.id WHERE {tableName9}.id IN (SELECT accountable_forms_id FROM {tableName5} WHERE payment_date <= CAST('{to}' AS DATE))";

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
 