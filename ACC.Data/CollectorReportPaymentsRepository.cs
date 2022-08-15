using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    class CollectorReportPaymentsRepository:ICollectorReportPaymentsRepository
    {
        private readonly IDbGenericCommands _dbGenericCommands;
        private readonly string tableName = "collector_report_payments";
        private readonly string viewTableName = "view_collector_report_payments";

        public CollectorReportPaymentsRepository(IDbGenericCommands dbGenericCommands)
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

                    record.Add("collector_report_id", reader.Rows[0]["collector_report_id"].ToString());
                    record.Add("payment_collections_id", reader.Rows[0]["payment_collections_id"].ToString());
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
            throw new NotImplementedException();
        }

        public bool Append(List<CollectorReportPaymentModel> entityList)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    foreach (var entity in entityList)
                    {
                        if (entity.Id > 0)
                        {

                            var parameters = new object[][]
                           {
                                new object[] { "@id", DbType.Int16, entity.Id},
                                new object[] { "@collector_report_id", DbType.Int16, entity.CollectorsReportId},
                                new object[] { "@payment_collections_id", DbType.Int16, entity.PaymentCollectionsId},
                           };

                            string query = $"UPDATE {tableName} SET collector_report_id=@collector_report_id,payment_collections_id=@payment_collections_id WHERE id=@id";
                            _ = _dbGenericCommands.ExecuteNonQuery(query, parameters);
                        }
                        else
                        {
                            var parameters = new object[][]
                               {
                                    new object[] { "@collector_report_id", DbType.Int16, entity.CollectorsReportId},
                                    new object[] { "@payment_collections_id", DbType.Int16, entity.PaymentCollectionsId},
                               };

                            string query = $"INSERT INTO {tableName} (collector_report_id,payment_collections_id) VALUES(@collector_report_id,@payment_collections_id)";
                            _ = _dbGenericCommands.ExecuteNonQuery(query, parameters);
                        }
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

        public bool Delete(CollectorReportPaymentModel entity)
        {
            try
            {
                using (var scope = new TransactionScope())
                {

                    var parameter = new object[][] {
                        new object[]{"@reportId", DbType.Int32, entity.CollectorsReportId}
                    };

                    var query = $"DELETE FROM {tableName} WHERE collector_report_id = @reportId";
                    _ = _dbGenericCommands.ExecuteNonQuery(query, parameter);

                   
                    scope.Complete();
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(List<CollectorReportPaymentModel> entityList)
        {
            throw new NotImplementedException();
        }

        public int CountRecords(int id)
        {
            try
            {
                string query = $"SELECT COUNT(*) FROM {tableName} WHERE {tableName}.collector_report_id='{id}'";

                return int.Parse(_dbGenericCommands.ExecuteScalar(query));
            }
            catch (Exception)
            {
                throw;
            }
        }
     
        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new NotImplementedException();
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }
     
        public bool Insert(CollectorReportPaymentModel entity)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    var parameters = new object[][]
                    {
                        new object[] { "@collector_report_id", DbType.Int16, entity.CollectorsReportId},
                        new object[] { "@payment_collections_id", DbType.Int16, entity.PaymentCollectionsId},
                    };

                    string query = $"INSERT INTO {tableName} (collector_report_id, payment_collections_id) VALUES(@collector_report_id, @payment_collections_id)";
                    _ = _dbGenericCommands.ExecuteNonQuery(query, parameters);
                 
                    scope.Complete();
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(CollectorReportPaymentModel entity)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    var parameters = new object[][]
                    {
                        new object[] { "@id", DbType.Int16, entity.Id},
                        new object[] { "@collector_report_id", DbType.Int16, entity.CollectorsReportId},
                        new object[] { "@payment_collections_id", DbType.Int16, entity.PaymentCollectionsId},
                    };

                    string query = $"UPDATE {tableName} SET collector_report_id=@collector_report_id,payment_collections_id=@payment_collections_id WHERE id=@id";
                    _ = _dbGenericCommands.ExecuteNonQuery(query, parameters);
          
                    scope.Complete();
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetRecordsByReportNo(string reportNo)
        {
            var parameter = new object[][] { 
                new object[]{ "@report_no", DbType.String, reportNo},
            };

            string query = $"SELECT payment_collections_id, funds_id, fund_name, accountable_forms_id, account_code, accountable_forms_no, accountable_forms_desc, accountable_forms, general_ledger_accounts_id, ledger_name, payee, LPAD(receipt_no, 7, 0) AS receipt_no, quantity, payment_date, amount FROM {viewTableName} WHERE report_no = @report_no";

            var dtpc = new DataTable();
            return _dbGenericCommands.FillBySearch(query, dtpc, parameter);
        }

        public DataTable GetCollectorsReportByReportNo(string reportNo)
        {
            var parameter = new object[][] {
                new object[]{"@reportNo", DbType.String, reportNo},
            };

            string query =  $"SELECT " +
                            $"accountable_forms,  " +
                            $"MIN(receipt_no)report_number_from, " +
                            $"MAX(receipt_no)report_number_to, " +
                            $"SUM(amount) amount " +
                            $"FROM {viewTableName} " +
                            $"WHERE report_no = @reportNo " +
                            $"GROUP BY accountable_form_id ";

            var dtpc = new DataTable();
            return _dbGenericCommands.FillBySearch(query, dtpc, parameter);
        }

    }
}
