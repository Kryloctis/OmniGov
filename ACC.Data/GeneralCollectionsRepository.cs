using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    class GeneralCollectionsRepository:IGeneralCollectionsRepository
    {
        private readonly IDbGenericCommands _dbGenericCommands;
        private readonly string tableGeneralCollections = "general_collections";
        private readonly string tableUsers = "users";
        private readonly string tableGeneralCollectionsPayment = "general_collections_payment";
        private readonly string tableCollectorReportPayments = "collector_report_payments";
        private readonly string tablePaymentCollections = "payment_collections";
        private readonly string tableCollectingOfficers = "collecting_officers";
        private readonly string tableAccountableForms = "accountable_forms";
        private readonly string tableAccountGroup = "account_group";
        private readonly string tableMajorAccountGroup = "major_account_group";
        private readonly string tableSubMajorAccountGroup = "sub_major_account_group";
        private readonly string tableSubsidiaryLedgerAccounts = "subsidiary_ledger_accounts";
        private readonly string tableCollectorReport = "collector_report";
        private readonly string tableName10 = "general_collections_deposits";
        private readonly string tableReceipts = "receipts";
        private readonly string tableReceiptsIssued = "receipts_issued";
        private readonly string tableGeneralLedgerAccounts = "general_ledger_accounts";

        private readonly string viewTableName = "view_general_collections";

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

                string query = $"SELECT * FROM {tableGeneralCollections} WHERE id = @id";

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

                string query = $"SELECT * FROM {tableGeneralCollections} WHERE  rcd_no = @rcd_no";

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
                string query = $"SELECT * FROM {viewTableName}";
                var dtRCD = new DataTable();

                return _dbGenericCommands.Fill(query, dtRCD);
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
                    new object[] { "@rcd_no", DbType.String, entity.RcdNo},
                    new object[] { "@rcd_date", DbType.Date, entity.Rcddate},
                    new object[] { "@fund_id", DbType.Int32, entity.FundId},
                    new object[] { "@users_id", DbType.Int16, entity.Userid},
                };

                string query = $"INSERT INTO {tableGeneralCollections} (rcd_no, rcd_date, funds_id, users_id) VALUES (@rcd_no, @rcd_date, @fund_id, @users_id)";
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
                    new object[] { "@rcd_no", DbType.String, entity.RcdNo},
                    new object[] { "@rcd_date", DbType.Date, entity.Rcddate},
                    new object[] { "@fund_id", DbType.Int32, entity.FundId},
                };

                string query = $"UPDATE {tableGeneralCollections} SET rcd_no = @rcd_no, rcd_date = @rcd_date, fund_id = @fund_id WHERE id=@id";
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

                        string query = $"DELETE FROM {tableGeneralCollections} WHERE id = @id";
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
                string query = $"SELECT COUNT(*) FROM {tableGeneralCollections}";

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

                string query = $"SELECT id FROM {tableGeneralCollections} WHERE id = @id";
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

                string query = $"SELECT rcd_no FROM {tableGeneralCollections} WHERE rcd_no = @rcd_no";
                string queryResult = _dbGenericCommands.ExecuteScalar(query, parameters);

                if (!string.IsNullOrEmpty(queryResult)) return true;
            }
            catch (Exception)
            {
                throw;
            };

            return false;
        }

        public DataTable GetRecordsBySearch(int fund_id, string searchText)
        {
            try
            {
                var parameter = new object[][] { 
                    new object[]{"@fund_id", DbType.String, fund_id },
                    new object[]{"@searchKey", DbType.String, $"%{ searchText }%" }
                };

                string query = $"SELECT * FROM {viewTableName} WHERE rcd_no LIKE @searchKey AND fund_id = @fund_id";
                var dtpc = new DataTable();

                return _dbGenericCommands.FillBySearch(query, dtpc, parameter);
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
                string query = $"SELECT SUM({tablePaymentCollections}.amount) FROM {tablePaymentCollections} LEFT JOIN {tableCollectorReportPayments} ON {tableCollectorReportPayments}.payment_collections_id={tablePaymentCollections}.id LEFT JOIN {tableGeneralCollectionsPayment} ON {tableGeneralCollectionsPayment}.collector_report_id={tableCollectorReportPayments}.collector_report_id WHERE {tableGeneralCollectionsPayment}.general_collections_id='{id}'";
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
                string query = $"SELECT {tableGeneralCollections}.id,{tableGeneralCollections}.rcd_no,{tableCollectorReport}.report_no,CONCAT({tableAccountGroup}.account_group_code,'-',{tableMajorAccountGroup}.maj_acc_group_code,'-',{tableSubMajorAccountGroup}.sub_maj_acc_group_code,'-', {tableName10}.ledger_code) AS account_code,CONCAT({tableAccountableForms}.acc_form_no,'-',{tableAccountableForms}.acc_form_desc) AS accform,{tableName10}.ledger_name,CONCAT({tableSubsidiaryLedgerAccounts}.sub_code,'-',{tableSubsidiaryLedgerAccounts}.sub_name) AS subsidiary,{tablePaymentCollections}.payee,{tablePaymentCollections}.receipt_no,{tablePaymentCollections}.payment_date,{tablePaymentCollections}.amount,CONCAT({tableCollectingOfficers}.last_name,', ',{tableCollectingOfficers}.first_name,' ',{tableCollectingOfficers}.mid_initial) AS collector,{tablePaymentCollections}.created_at,{tablePaymentCollections}.updated_at,CONCAT(u1.last_name,', ',u1.first_name,' ',u1.mid_initial) AS createdby,CONCAT(u2.last_name,', ',u2.first_name,' ',u2.mid_initial) AS updatedby,CONCAT(u3.last_name,', ',u3.first_name,' ',u3.mid_initial) AS officer FROM {tableGeneralCollections} LEFT JOIN {tableGeneralCollectionsPayment} ON {tableGeneralCollectionsPayment}.general_collections_id={tableGeneralCollections}.id LEFT JOIN {tableCollectorReportPayments} ON {tableCollectorReportPayments}.collector_report_id={tableGeneralCollectionsPayment}.collector_report_id LEFT JOIN {tablePaymentCollections} ON {tablePaymentCollections}.id={tableCollectorReportPayments}.payment_collections_id LEFT JOIN {tableCollectorReport} ON {tableCollectorReportPayments}.collector_report_id={tableCollectorReport}.id LEFT JOIN {tableAccountableForms} ON {tablePaymentCollections}.accountable_forms_id={tableAccountableForms}.id LEFT JOIN {tableName10} ON {tablePaymentCollections}.general_ledger_accounts_id={tableName10}.id LEFT JOIN {tableUsers} u1 ON u1.id={tablePaymentCollections}.created_by LEFT JOIN {tableUsers} u2 ON u2.id={tablePaymentCollections}.updated_by LEFT JOIN {tableUsers} u3 ON u3.id={tableGeneralCollections}.users_id LEFT JOIN {tableSubMajorAccountGroup} ON {tableSubMajorAccountGroup}.id={tableName10}.sub_major_account_group_id LEFT JOIN {tableMajorAccountGroup} ON {tableSubMajorAccountGroup}.major_account_group_id={tableMajorAccountGroup}.id LEFT JOIN {tableAccountGroup} ON {tableMajorAccountGroup}.account_group_id={tableAccountGroup}.id LEFT JOIN {tableSubsidiaryLedgerAccounts} ON {tablePaymentCollections}.subsidiary_ledger_accounts_id={tableSubsidiaryLedgerAccounts}.id LEFT JOIN {tableCollectingOfficers} ON {tableCollectingOfficers}.id={tablePaymentCollections}.collecting_officers_id WHERE {tableGeneralCollections}.id IN ({Id})";

                var dtpc = new DataTable();
                return _dbGenericCommands.Fill(query, dtpc);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetRecordOfGeneralCollectionByDateRange(string from, string to)
        {
            try
            {
                //string query = $"SELECT * FROM view_abstract_of_general_collection";

                string query = $"SELECT * FROM view_payment_collections";
                var dtpc = new DataTable();
                return _dbGenericCommands.Fill(query, dtpc);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetRecordByData(string rcdId)
        {
            try
            {
                var parameter = new object[][] {
                    new object[]{"@rcdId", DbType.Int32, rcdId},
                };

                string query = $"SELECT * FROM {viewTableName} WHERE id = @rcdId";

                var dtcr = new DataTable();
                return _dbGenericCommands.FillBySearch(query, dtcr, parameter);
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
                string query = $"SELECT {tableGeneralCollections}.id,{tableAccountableForms}.id AS formid,{tableAccountableForms}.acc_form_no,{tableAccountableForms}.acc_form_desc,(SELECT pc.receipt_no FROM {tableGeneralCollectionsPayment} gcp LEFT JOIN {tableCollectorReportPayments} crp ON gcp.collector_report_id=crp.collector_report_id LEFT JOIN {tablePaymentCollections} pc ON pc.id=crp.payment_collections_id LEFT JOIN {tableAccountableForms} af ON af.id=pc.accountable_forms_id WHERE gcp.general_collections_id={tableGeneralCollections}.id AND af.id={tableAccountableForms}.id ORDER BY pc.receipt_no ASC LIMIT 1) AS orfrom,(SELECT pc.receipt_no FROM {tableGeneralCollectionsPayment} gcp LEFT JOIN {tableCollectorReportPayments} crp ON gcp.collector_report_id=crp.collector_report_id LEFT JOIN {tablePaymentCollections} pc ON pc.id=crp.payment_collections_id LEFT JOIN {tableAccountableForms} af ON af.id=pc.accountable_forms_id WHERE gcp.general_collections_id={tableGeneralCollections}.id AND af.id={tableAccountableForms}.id ORDER BY pc.receipt_no DESC LIMIT 1) AS orto,(SELECT SUM(pc.amount) FROM {tableGeneralCollectionsPayment} gcp LEFT JOIN {tableCollectorReportPayments} crp ON gcp.collector_report_id=crp.collector_report_id LEFT JOIN {tablePaymentCollections} pc ON pc.id=crp.payment_collections_id LEFT JOIN {tableAccountableForms} af ON af.id=pc.accountable_forms_id WHERE gcp.general_collections_id={tableGeneralCollections}.id AND af.id={tableAccountableForms}.id) AS total FROM {tableGeneralCollections} LEFT JOIN {tableGeneralCollectionsPayment} ON {tableGeneralCollections}.id={tableGeneralCollectionsPayment}.general_collections_id LEFT JOIN {tableCollectorReportPayments} ON {tableCollectorReportPayments}.collector_report_id={tableGeneralCollectionsPayment}.collector_report_id LEFT JOIN {tablePaymentCollections} ON {tablePaymentCollections}.id={tableCollectorReportPayments}.payment_collections_id LEFT JOIN {tableAccountableForms} ON {tablePaymentCollections}.accountable_forms_id={tableAccountableForms}.id WHERE {tableGeneralCollections}.id='{Id}' GROUP BY formid";

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
               string query = $"SELECT {tableGeneralCollections}.id,{tableCollectorReport}.id AS reportid,{tableCollectorReport}.report_no,CONCAT({tableCollectingOfficers}.last_name,', ',{tableCollectingOfficers}.first_name,' ',{tableCollectingOfficers}.mid_initial) AS collector,(SELECT SUM(pc.amount) FROM {tableCollectorReport} cr LEFT JOIN {tableCollectorReportPayments} crp ON cr.id=crp.collector_report_id LEFT JOIN {tablePaymentCollections} pc ON pc.id=crp.payment_collections_id WHERE cr.id={tableGeneralCollectionsPayment}.id) AS total FROM {tableGeneralCollections} LEFT JOIN {tableGeneralCollectionsPayment} ON {tableGeneralCollections}.id={tableGeneralCollectionsPayment}.general_collections_id LEFT JOIN {tableCollectorReportPayments} ON {tableCollectorReportPayments}.collector_report_id={tableGeneralCollectionsPayment}.collector_report_id LEFT JOIN {tablePaymentCollections} ON {tableCollectorReportPayments}.payment_collections_id={tablePaymentCollections}.id LEFT JOIN {tableCollectingOfficers} ON {tablePaymentCollections}.collecting_officers_id={tableCollectingOfficers}.id LEFT JOIN {tableCollectorReport} ON {tableGeneralCollectionsPayment}.collector_report_id={tableCollectorReport}.id WHERE {tableGeneralCollections}.id='{Id}' GROUP BY reportid";


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
                //string query = $"SELECT {tableGeneralCollections}.id,{tableName17}.bank_name,{tableName17}.account_no,{tableBankDeposits}.reference,{tableBankDeposits}.amount FROM {tableGeneralCollections} LEFT JOIN {tableGeneralCollectionsDeposits} ON {tableGeneralCollectionsDeposits}.general_collections_id={tableGeneralCollections}.id LEFT JOIN {tableBankDeposits} ON {tableGeneralCollectionsDeposits}.bank_deposits_id={tableBankDeposits}.id LEFT JOIN {tableName17} ON {tableBankDeposits}.banks_id={tableName17}.id WHERE {tableGeneralCollections}.id='{Id}'";

                var parameter = new object[][] {
                    new object[] {"@bankId", DbType.String, Id}        
                };

                string query = $"SELECT * FROM view_bank_deposits WHERE bank_id = 1";


                var dtpc = new DataTable();
                return _dbGenericCommands.FillBySearch(query, dtpc, parameter);
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

                string query = $"SELECT CONCAT({tableAccountableForms}.acc_form_no,'-',{tableAccountableForms}.acc_form_desc) AS form,{tableReceipts}.receipt_number_from,{tableReceipts}.receipt_number_to,{tableReceiptsIssued}.receipt_issued_from,{tableReceiptsIssued}.receipt_issued_to,(SELECT receipt_no FROM {tablePaymentCollections} WHERE accountable_forms_id={tableAccountableForms}.id AND receipt_no BETWEEN {tableReceiptsIssued}.receipt_issued_from-1 AND {tableReceiptsIssued}.receipt_issued_to+1 ORDER BY receipt_no ASC LIMIT 1) AS ifrom,(SELECT receipt_no FROM {tablePaymentCollections} WHERE accountable_forms_id={tableAccountableForms}.id AND receipt_no BETWEEN {tableReceiptsIssued}.receipt_issued_from-1 AND {tableReceiptsIssued}.receipt_issued_to+1 ORDER BY receipt_no DESC LIMIT 1) AS ito FROM {tableAccountableForms} LEFT JOIN {tableReceipts} ON {tableReceipts}.accountable_forms_id={tableAccountableForms}.id LEFT JOIN {tableReceiptsIssued} ON {tableReceiptsIssued}.receipts_id={tableReceipts}.id WHERE {tableAccountableForms}.id IN (SELECT {tablePaymentCollections}.accountable_forms_id FROM {tablePaymentCollections} LEFT JOIN {tableCollectorReportPayments} ON {tablePaymentCollections}.id={tableCollectorReportPayments}.payment_collections_id LEFT JOIN {tableGeneralCollectionsPayment} ON {tableGeneralCollectionsPayment}.collector_report_id={tableCollectorReportPayments}.collector_report_id WHERE {tableGeneralCollectionsPayment}.general_collections_id='{Id}' AND {tablePaymentCollections}.receipt_no BETWEEN {tableReceiptsIssued}.receipt_issued_from-1 AND {tableReceiptsIssued}.receipt_issued_to+1)";

                var dtpc = new DataTable();
                return _dbGenericCommands.Fill(query, dtpc);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetRecordsOfConsolidatedReceiptsByEndingDate(string to)
        {
            try
            {
                string query = $"SELECT " +
                    $"{tableAccountableForms}.acc_form_no," +
                    $"{tableReceipts}.receipt_number_from, " +
                    $"{tableReceipts}.receipt_number_to, " +
                    $"{tableReceiptsIssued}.receipt_issued_from, " +
                    $"{tableReceiptsIssued}.receipt_issued_to, " +
                    $"(SELECT receipt_no FROM {tablePaymentCollections} WHERE accountable_forms_id={tableAccountableForms}.id AND collecting_officers_id={tableCollectingOfficers}.id AND payment_date <= CAST('{to}' AS DATE) ORDER BY receipt_no ASC LIMIT 1) AS ifrom, " +
                    $"(SELECT receipt_no FROM {tablePaymentCollections} WHERE accountable_forms_id={tableAccountableForms}.id AND collecting_officers_id={tableCollectingOfficers}.id AND payment_date <= CAST('{to}' AS DATE) ORDER BY receipt_no DESC LIMIT 1) AS ito," +
                    $"CONCAT({tableCollectingOfficers}.last_name,', ',{tableCollectingOfficers}.first_name,' ',{tableCollectingOfficers}.mid_initial) AS officers " +
                    $"FROM {tableAccountableForms} " +
                    $"LEFT JOIN {tableReceipts} ON {tableReceipts}.accountable_forms_id={tableAccountableForms}.id " +
                    $"LEFT JOIN {tableReceiptsIssued} ON {tableReceiptsIssued}.receipts_id={tableReceipts}.id " +
                    $"LEFT JOIN {tableCollectingOfficers} ON {tableReceiptsIssued}.collecting_officers_id={tableCollectingOfficers}.id " +
                    $"WHERE {tableAccountableForms}.id IN (SELECT accountable_forms_id FROM {tablePaymentCollections} WHERE payment_date <= CAST('{to}' AS DATE))";

                var dtpc = new DataTable();
                return _dbGenericCommands.Fill(query, dtpc);
            }
            catch (Exception) 
            {
                throw;
            }
        }


        public int GetGeneralCollectionId(string rcdNo)
        {       
            var parameter = new object[][] {
                new object[] {"@rcdNo", DbType.String, rcdNo}
            };
            string query = $"SELECT id FROM {tableGeneralCollections} WHERE rcd_no=@rcdNo";

            return int.Parse(_dbGenericCommands.ExecuteScalar(query, parameter));
        }

        public DataTable GetRecordsByRCDNo(string rcdNo)
        {
            var parameter = new object[][] {
                new object[]{ "@rcdNo", DbType.String, rcdNo},
            };

            string query = $"SELECT * FROM {viewTableName} WHERE rcd_no = @rcdNo";

            var dtRCD = new DataTable();
            return _dbGenericCommands.FillBySearch(query, dtRCD, parameter);
           
        }

        public DataTable GetRecordsByFundId(int fundId)
        {
            var parameter = new object[][] {
                new object[]{"@fund_id", DbType.Int32, fundId }
            };

            string query = $"SELECT * FROM {viewTableName} WHERE fund_id = @fund_id";
            var dtpc = new DataTable();

            return _dbGenericCommands.FillBySearch(query, dtpc, parameter);
        }

        public DataTable GetRecordsByFundIdAndSearchKey(int fundId, string searchKey)
        {
            var parameter = new object[][] {
                new object[]{"@fund_id", DbType.String, fundId },
                new object[]{"@searchKey", DbType.String, $"%{ searchKey }%" }
            };

            string query = $"SELECT * FROM {viewTableName} WHERE rcd_no LIKE @searchKey AND fund_id = @fund_id";
            var dtpc = new DataTable();

            return _dbGenericCommands.FillBySearch(query, dtpc, parameter);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new NotImplementedException();
        }

        public int GetRCDCount()
        {
            string query = $"SELECT COUNT(id) FROM {tableGeneralCollections}";
            return int.Parse(_dbGenericCommands.ExecuteScalar(query));
        }
    }
}
 