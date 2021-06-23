using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Transactions;

namespace ACC.Data
{
    class CollectorReportPaymentsRepository:ICollectorReportPaymentRepository
    {
        private readonly IDbGenericCommands _dbGenericCommands;
        private readonly string tableName = "collector_report_payments";
        private readonly string tableName2 = "collector_report";
        private readonly string tableName3 = "payment_collections";
        private readonly string tableName4 = "collecting_officers";
        private readonly string tableName5 = "accountable_forms";
        private readonly string tableName6 = "general_ledger_accounts";
        private readonly string tableName7 = "users";
        private readonly string tableName8 = "account_group";
        private readonly string tableName9 = "major_account_group";
        private readonly string tableName10 = "sub_major_account_group";
        private readonly string tableName11 = "subsidiary_ledger_accounts";

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
        public DataTable GetRecords(int id)
        {
            try
            {
                string query = $"SELECT {tableName}.id,{tableName3}.id AS pid,CONCAT({tableName8}.account_group_code,'-',{tableName9}.maj_acc_group_code,'-',{tableName10}.sub_maj_acc_group_code,'-',{tableName6}.ledger_code) AS account_code,CONCAT({tableName5}.acc_form_no,'-',{tableName5}.acc_form_desc) AS accform,{tableName6}.ledger_name,CONCAT({tableName11}.sub_code,'-',{tableName11}.sub_name) AS subsidiary,{tableName3}.payee,{tableName3}.receipt_no,{tableName3}.payment_date,{tableName3}.amount,CONCAT({tableName4}.last_name,', ',{tableName4}.first_name,' ',{tableName4}.mid_initial) AS collector FROM {tableName} LEFT JOIN {tableName2} ON {tableName}.collector_report_id={tableName2}.id LEFT JOIN {tableName3} ON {tableName}.payment_collections_id={tableName3}.id LEFT JOIN {tableName4} ON {tableName3}.collecting_officers_id={tableName4}.id LEFT JOIN {tableName5} ON {tableName3}.accountable_forms_id={tableName5}.id LEFT JOIN {tableName6} ON {tableName3}.general_ledger_accounts_id={tableName6}.id LEFT JOIN {tableName11} ON {tableName3}.subsidiary_ledger_accounts_id={tableName11}.id LEFT JOIN {tableName10} ON {tableName6}.sub_major_account_group_id={tableName10}.id LEFT JOIN {tableName9} ON {tableName10}.major_account_group_id={tableName9}.id LEFT JOIN {tableName8} ON {tableName9}.account_group_id = {tableName8}.id WHERE {tableName2}.id='{id}' ORDER BY {tableName}.id ASC";

                var dtcrp = new DataTable();
                return _dbGenericCommands.Fill(query, dtcrp);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetRecords(string reportno)
        {
            try
            {
                string query = $"SELECT {tableName}.id,{tableName3}.id AS pid,CONCAT({tableName8}.account_group_code,'-',{tableName9}.maj_acc_group_code,'-',{tableName10}.sub_maj_acc_group_code,'-',{tableName6}.ledger_code) AS account_code,CONCAT({tableName5}.acc_form_no,'-',{tableName5}.acc_form_desc) AS accform,{tableName6}.ledger_name,CONCAT({tableName11}.sub_code,'-',{tableName11}.sub_name) AS subsidiary,{tableName3}.payee,{tableName3}.receipt_no,{tableName3}.payment_date,{tableName3}.amount,CONCAT({tableName4}.last_name,', ',{tableName4}.first_name,' ',{tableName4}.mid_initial) AS collector FROM {tableName} LEFT JOIN {tableName2} ON {tableName}.collector_report_id={tableName2}.id LEFT JOIN {tableName3} ON {tableName}.payment_collections_id={tableName3}.id LEFT JOIN {tableName4} ON {tableName3}.collecting_officers_id={tableName4}.id LEFT JOIN {tableName5} ON {tableName3}.accountable_forms_id={tableName5}.id LEFT JOIN {tableName6} ON {tableName3}.general_ledger_accounts_id={tableName6}.id LEFT JOIN {tableName11} ON {tableName3}.subsidiary_ledger_accounts_id={tableName11}.id LEFT JOIN {tableName10} ON {tableName6}.sub_major_account_group_id={tableName10}.id LEFT JOIN {tableName9} ON {tableName10}.major_account_group_id={tableName9}.id LEFT JOIN {tableName8} ON {tableName9}.account_group_id = {tableName8}.id WHERE {tableName2}.report_no='{reportno}' ORDER BY {tableName}.id ASC";

                var dtcrp = new DataTable();
                return _dbGenericCommands.Fill(query, dtcrp);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Insert(List<CollectorReportPaymentModel> entityList)
        {
            try
            {
                using (var scope = new TransactionScope())
                {                    
                    foreach (var entity in entityList)
                    {
                        var parameters = new object[][]
                        {
                            new object[] { "@collector_report_id", DbType.Int16, entity.CoId},
                            new object[] { "@payment_collections_id", DbType.Int16, entity.PcId},
                        };

                        string query = $"INSERT INTO {tableName} (collector_report_id,payment_collections_id) VALUES(@collector_report_id,@payment_collections_id)";
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

        public bool Update(List<CollectorReportPaymentModel> entityList)
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
                            new object[] { "@collector_report_id", DbType.Int16, entity.CoId},
                            new object[] { "@payment_collections_id", DbType.Int16, entity.PcId},
                        };

                        string query = $"UPDATE {tableName} SET collector_report_id=@collector_report_id,payment_collections_id=@payment_collections_id WHERE id=@id";
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
                                new object[] { "@collector_report_id", DbType.Int16, entity.CoId},
                                new object[] { "@payment_collections_id", DbType.Int16, entity.PcId},
                           };

                            string query = $"UPDATE {tableName} SET collector_report_id=@collector_report_id,payment_collections_id=@payment_collections_id WHERE id=@id";
                            _ = _dbGenericCommands.ExecuteNonQuery(query, parameters);
                        }
                        else
                        {
                            var parameters = new object[][]
                               {
                                    new object[] { "@collector_report_id", DbType.Int16, entity.CoId},
                                    new object[] { "@payment_collections_id", DbType.Int16, entity.PcId},
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

        public bool Delete(List<CollectorReportPaymentModel> entityList)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    foreach (var entity in entityList)
                    {
                        if(entity.CoId > 0)
                        {
                           var parameters = new object[][]
                           {
                                new object[] { "@collector_report_id", DbType.Int16, entity.CoId},
                           };

                            string query = $"DELETE FROM {tableName} WHERE collector_report_id = @collector_report_id";
                            _ = _dbGenericCommands.ExecuteNonQuery(query, parameters);
                        }
                        if(entity.Id > 0)
                        {
                           var parameters = new object[][]
                           {
                                new object[] { "@id", DbType.Int16, entity.Id},
                           };

                            string query = $"DELETE FROM {tableName} WHERE id = @id";
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

        public decimal SumRecords(string reportno)
        {
            try
            {
                string query = $"SELECT SUM({tableName3}.amount) FROM {tableName2} LEFT JOIN {tableName} ON {tableName}.collector_report_id={tableName2}.id LEFT JOIN {tableName3} ON {tableName}.payment_collections_id={tableName3}.id WHERE {tableName2}.report_no='{reportno}'";
                string result = _dbGenericCommands.ExecuteScalar(query);
                return !string.IsNullOrEmpty(result) ? decimal.Parse(result):decimal.Parse("0.00");
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
                string query = $"SELECT SUM({tableName3}.amount) FROM {tableName2} LEFT JOIN {tableName} ON {tableName}.collector_report_id={tableName2}.id LEFT JOIN {tableName3} ON {tableName}.payment_collections_id={tableName3}.id WHERE {tableName2}.id='{id}'";
                string result = _dbGenericCommands.ExecuteScalar(query);
                return !string.IsNullOrEmpty(result) ? decimal.Parse(result) : decimal.Parse("0.00");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetRecordByLedger(string Id)
        {
            try
            {
                string query = $"SELECT {tableName}.id,{tableName2}.report_no,{tableName2}.date,CONCAT({tableName8}.account_group_code,'-',{tableName9}.maj_acc_group_code,'-',{tableName10}.sub_maj_acc_group_code,'-',{tableName6}.ledger_code) AS account_code,CONCAT({tableName5}.acc_form_no,'-',{tableName5}.acc_form_desc) AS accform,{tableName6}.ledger_name,CONCAT({tableName11}.sub_code,'-',{tableName11}.sub_name) AS subsidiary,{tableName3}.payee,{tableName3}.receipt_no,{tableName3}.payment_date,{tableName3}.amount,CONCAT({tableName4}.last_name,', ',{tableName4}.first_name,' ',{tableName4}.mid_initial) AS collector,{tableName3}.created_at,{tableName3}.updated_at,CONCAT(u1.last_name,', ',u1.first_name,' ',u1.mid_initial) AS createdby,CONCAT(u2.last_name,', ',u2.first_name,' ',u2.mid_initial) AS updatedby FROM {tableName} LEFT JOIN {tableName2} ON {tableName2}.id={tableName}.collector_report_id LEFT JOIN {tableName3} ON {tableName3}.id={tableName}.payment_collections_id LEFT JOIN {tableName5} ON {tableName5}.id={tableName3}.accountable_forms_id LEFT JOIN {tableName6} ON {tableName6}.id={tableName3}.general_ledger_accounts_id LEFT JOIN {tableName7} u1 ON u1.id={tableName3}.created_by LEFT JOIN {tableName7} u2 ON u2.id={tableName3}.updated_by LEFT JOIN {tableName10} ON {tableName6}.sub_major_account_group_id={tableName10}.id LEFT JOIN {tableName9} ON {tableName10}.major_account_group_id={tableName9}.id LEFT JOIN {tableName8} ON {tableName9}.account_group_id={tableName8}.id LEFT JOIN {tableName11} ON {tableName3}.subsidiary_ledger_accounts_id={tableName11}.id LEFT JOIN {tableName4} ON {tableName4}.id={tableName3}.collecting_officers_id WHERE {tableName2}.id IN ({Id})";

                var dtpc = new DataTable();
                return _dbGenericCommands.Fill(query, dtpc);
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
        public bool Delete(CollectorReportPaymentModel entity)
        {
            throw new NotImplementedException();
        }
        public bool Insert(CollectorReportPaymentModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(CollectorReportPaymentModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
