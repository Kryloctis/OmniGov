using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    public class PaymentCollectionsRepository : IPaymentCollectionsRepository
    {
        private readonly string tableName = "payment_collections";
        private readonly string viewTableName = "view_payment_collections";
        private AccGenericCommands _mySqlGenericCommandsLFS;
        private IGeneralPaymentsRepository _generalPaymentsRepository;
        private IRptPaymentPostsRepository _rptPaymentPostsRepository;

        public PaymentCollectionsRepository(AccGenericCommands mySqlGenericCommandsLFS,
                                            IGeneralPaymentsRepository generalPaymentsRepository,
                                            IRptPaymentPostsRepository rptPaymentPostsRepository)
        {
            _mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
            _generalPaymentsRepository = generalPaymentsRepository;
            _rptPaymentPostsRepository = rptPaymentPostsRepository;
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

                using (var reader = _mySqlGenericCommandsLFS.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;
                    record.Add("funds_id", reader.Rows[0]["funds_id"].ToString());
                    record.Add("collecting_officers_id", reader.Rows[0]["collecting_officers_id"].ToString());
                    record.Add("job_orders_id", reader.Rows[0]["job_orders_id"].ToString());
                    record.Add("accountable_forms_id", reader.Rows[0]["accountable_forms_id"].ToString());
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

        public DataTable GetRecordsByCollectingOfficerId(int collectorId)
        {
            var parameter = new object[][] {
                new object[] {"@collectorId", DbType.Int32, collectorId}
            };

            string query = $"SELECT " +
                            $"id, " +
                            $"funds_id, " +
                            $"fund_name, " +
                            $"accountable_form_id, " +
                            $"accountable_forms, " +
                            $"account_code, " +
                            $"general_ledger_accounts_id, " +
                            $"ledger_name, " +
                            $"payee, " +
                            $"receipt_no, " +
                            $"quantity, " +
                            $"payment_date, " +
                            $"amount " +
                            $"FROM {viewTableName} " +
                            $"WHERE collecting_officer_id = @collectorId " +
                            $"ORDER BY accountable_form_id";

            var dt = new DataTable();
            return _mySqlGenericCommandsLFS.FillBySearch(query, dt, parameter);
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {viewTableName}";

            var dtPaymentCollection = new DataTable();
            return _mySqlGenericCommandsLFS.Fill(query, dtPaymentCollection);
        }

        public DataTable GetRecordsByDate(string date)
        {
            var parameter = new object[][]
            {
                new object[]{"@date", DbType.DateTime2, date}
            };

            string query = $"SELECT * FROM {viewTableName} WHERE payment_date = @date";

            var dtPaymentCollection = new DataTable();
            return _mySqlGenericCommandsLFS.FillBySearch(query, dtPaymentCollection, parameter);
        }

        public DataTable FilterRecords(string date, int collectingOfficerID, bool collectingOfficerJO, string searchKey)
        {
            var parameter = new object[][]
            {
                new object[]{ "@payment_date", DbType.DateTime2, date},
                new object[]{ "@collecting_officer_id", DbType.Int32, collectingOfficerID },
                new object[]{ "@search_key", DbType.String, $"%{searchKey}%" }
            };

            string columnFilter = collectingOfficerJO ? "job_orders_id" : "ISNULL(job_orders_id) AND collecting_officer_id";

            string query = $"SELECT id, funds_id, fund_name, accountable_forms_id, accountable_forms_no, accountable_forms_desc, payee, receipt_no, payment_date, amount FROM {viewTableName} WHERE {columnFilter} = @collecting_officer_id AND payment_date = @payment_date ORDER BY accountable_forms_id";

            var dtPaymentCollection = new DataTable();
            return _mySqlGenericCommandsLFS.FillBySearch(query, dtPaymentCollection, parameter);
        }

        public bool Insert(PaymentCollectionsModel entity)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    var parameters = new object[][]
                    {
                        new object[] { "@collecting_officers_id", DbType.Int32, entity.CollectingOfficerId},
                        new object[] { "@job_orders_id", DbType.Int32, entity.JobOrderId},
                        new object[] { "@funds_id", DbType.Int16, entity.FundId},
                        new object[] { "@accountable_forms_id", DbType.Int16, entity.AccountableFormId},
                        new object[] { "@payee", DbType.String, entity.Payee},
                        new object[] { "@receipt_no", DbType.String, entity.ReceiptNo},
                        new object[] { "@payment_date", DbType.DateTime, entity.PaymentDate},
                        new object[] { "@amount", DbType.Decimal, entity.Amount},
                        new object[] { "@is_cancelled", DbType.Boolean, entity.IsCancelled},
                        new object[] { "@created_by", DbType.Int16, entity.CreatedBy}
                    };

                    string query = $"INSERT INTO {tableName} " +
                               $"(collecting_officers_id, " +
                               $"job_orders_id," +
                               $"funds_id, " +
                               $"accountable_forms_id, " +
                               $"payee, " +
                               $"receipt_no,  " +
                               $"payment_date, " +
                               $"amount, " +
                               $"is_cancelled, " +
                               $"created_by) " +
                               $"VALUES " +
                               $"(@collecting_officers_id, " +
                               $"@job_orders_id, " +
                               $"@funds_id, " +
                               $"@accountable_forms_id, " +
                               $"@payee, " +
                               $"@receipt_no, " +
                               $"@payment_date, " +
                               $"@amount, " +
                               $"@is_cancelled, " +
                               $"@created_by)";

                    _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
                    scope.Complete();
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(PaymentCollectionsModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int16, entity.Id},
                    new object[] { "@funds_id", DbType.Int16, entity.FundId},
                    new object[] { "@collecting_officers_id", DbType.Int16, entity.CollectingOfficerId},
                    new object[] { "@accountable_forms_id", DbType.Int16, entity.AccountableFormId},
                    new object[] { "@payee", DbType.String, entity.Payee},
                    new object[] { "@receipt_no", DbType.String, entity.ReceiptNo},
                    new object[] { "@payment_date", DbType.DateTime, entity.PaymentDate},
                    new object[] { "@amount", DbType.Decimal, entity.Amount},
                    new object[] { "@updated_by", DbType.Int16, entity.UpdatedBy}
                };

                string query = $"UPDATE {tableName} SET funds_id = @funds_id, payee = @payee, receipt_no = @receipt_no, payment_date = @payment_date, amount = @amount, updated_by = @updated_by WHERE id = @id";

                return _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(List<PaymentCollectionsModel> entityList)
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
                        _ = _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
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

                return int.Parse(_mySqlGenericCommandsLFS.ExecuteScalar(query));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IdExist(int id)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int16, id },
            };

            string query = $"SELECT id FROM {tableName} WHERE id = @id";
            string queryResult = _mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);

            if (!string.IsNullOrEmpty(queryResult))
                return true;

            return false;
        }

        public bool ReceiptExist(int receipt, int accountableFormId)
        {
            var parameters = new object[][]
            {
                new object[] { "@receipt_no", DbType.Int32, receipt },
                new object[] { "@accountable_forms_id", DbType.Int32, accountableFormId },
            };

            string query = $"SELECT id FROM {tableName} WHERE receipt_no = @receipt_no AND accountable_forms_id = @accountable_forms_id";
            string queryResult = _mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);

            if (!string.IsNullOrEmpty(queryResult))
                return true;

            return false;
        }

        public bool ReceiptExist(int paymentCollectionId, int receipt, int accountableFormId)
        {
            var parameters = new object[][]
            {
                new object[] { "@payment_collection_id", DbType.Int64, paymentCollectionId },
                new object[] { "@receipt_no", DbType.Int32, receipt },
                new object[] { "@accountable_forms_id", DbType.Int32, accountableFormId },
            };

            string query = $"SELECT id FROM {tableName} WHERE id <> @payment_collection_id AND receipt_no = @receipt_no AND accountable_forms_id = @accountable_forms_id";

            string queryResult = _mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);

            if (!string.IsNullOrEmpty(queryResult))
                return true;

            return false;
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameter = new object[][] {
                new object[] { "@searchText", DbType.String, $"%{searchText}%" }
            };

            string query = $"SELECT * FROM {viewTableName}  WHERE accountable_forms LIKE @searchText";

            var dtpc = new DataTable();
            return _mySqlGenericCommandsLFS.FillBySearch(query, dtpc, parameter);
        }

        public DataTable GetRecordByLedger(object[] parameter)
        {
            var parameters = new object[][]
            {
                new object[] { "@collecting_officer_id", DbType.UInt16, parameter[0] },
                new object[] { "@funds_id", DbType.UInt16, parameter[1] },
                new object[] { "@collection_from", DbType.Date, parameter[2] },
                new object[] { "@collection_to", DbType.Date, parameter[3] }
            };

            string columnFilter = Convert.ToBoolean(parameter[4]) ? "job_orders_id" : "ISNULL(job_orders_id) AND collecting_officer_id";

            string query = $"SELECT id AS payment_collections_id, funds_id, fund_name, accountable_forms_id, accountable_forms_no, accountable_forms_desc, payee, receipt_no, payment_date, amount FROM {viewTableName} WHERE {columnFilter} = @collecting_officer_id AND payment_date BETWEEN @collection_from AND @collection_to ";

            var dtPaymentCollection = new DataTable();
            return _mySqlGenericCommandsLFS.FillBySearch(query, dtPaymentCollection, parameters);
        }

        public DataTable GetRecordsByUserId(int userId)
        {
            var parameter = new object[][] {
                new object[] {"@userId", DbType.Int32, userId }
            };

            string query = $"SELECT * FROM {viewTableName} WHERE created_by = @userId";

            var dt = new DataTable();

            return _mySqlGenericCommandsLFS.FillBySearch(query, dt, parameter);
        }

        public DataTable GetCollectionsPerCollector()
        {
            string query = $"SELECT collecting_officer_id, collecting_officers_first_name, collecting_officers_mid_initial, collecting_officers_last_name, job_orders_id, job_orders_first_name, job_orders_mid_initial, job_orders_last_name, SUM(amount) AS amount FROM {viewTableName} GROUP BY job_orders_id";

            var dt = new DataTable();
            return _mySqlGenericCommandsLFS.FillBySearch(query, dt);
        }

        public int GetLastInsertedID()
        {
            try
            {
                string query = $"SELECT COALESCE(MAX(id)) FROM {tableName}";
                return Convert.ToInt32(_mySqlGenericCommandsLFS.ExecuteScalar(query));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool InsertWithGeneralPayment(PaymentCollectionsModel paymentCollectionModel, GeneralPaymentsModel generalPaymentModel)
        {
            using (var scope = new TransactionScope())
            {
                var parameters = new object[][]
                {
                    new object[] { "@collecting_officers_id", DbType.Int32, paymentCollectionModel.CollectingOfficerId},
                    new object[] { "@job_orders_id", DbType.Int32, paymentCollectionModel.JobOrderId},
                    new object[] { "@funds_id", DbType.Int16, paymentCollectionModel.FundId},
                    new object[] { "@accountable_forms_id", DbType.Int16, paymentCollectionModel.AccountableFormId},
                    new object[] { "@payee", DbType.String, paymentCollectionModel.Payee},
                    new object[] { "@receipt_no", DbType.String, paymentCollectionModel.ReceiptNo},
                    new object[] { "@payment_date", DbType.DateTime, paymentCollectionModel.PaymentDate},
                    new object[] { "@amount", DbType.Decimal, paymentCollectionModel.Amount},
                    new object[] { "@is_cancelled", DbType.Boolean, paymentCollectionModel.IsCancelled},
                    new object[] { "@created_by", DbType.Int16, paymentCollectionModel.CreatedBy}
                };

                string query = $"INSERT INTO {tableName} (collecting_officers_id, job_orders_id, funds_id, accountable_forms_id, payee, receipt_no, payment_date, amount, is_cancelled, created_by) VALUES (@collecting_officers_id, @job_orders_id, @funds_id, @accountable_forms_id, @payee, @receipt_no, @payment_date, @amount, @is_cancelled, @created_by)";

                _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);

                generalPaymentModel.PaymentCollectionId = GetLastInsertedID();
                generalPaymentModel.GeneralLedgerAccountsId = paymentCollectionModel.AccountableFormId;

                _generalPaymentsRepository.Insert(generalPaymentModel);

                scope.Complete();
                return true;
            }
        }

        public int GetPreviouslyUsedReceiptNumber(int collectingOfficerID, int accountableFormID)
        {
            try
            {
                var parameter = new object[][] {
                    new object[]{"@collecting_officers_id", DbType.Int32, collectingOfficerID},
                    new object[]{"@accountable_forms_id", DbType.Int32, accountableFormID},
                };

                string query = $"SELECT COALESCE(MAX(receipt_no), 0) FROM payment_collections WHERE collecting_officers_id = @collecting_officers_id AND accountable_forms_id = @accountable_forms_id AND is_cancelled <> 1";

                return Convert.ToInt32(_mySqlGenericCommandsLFS.ExecuteScalar(query, parameter));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool InsertWithRptPaymentPosts(PaymentCollectionsModel paymentCollectionsModel, RptPaymentPostsModel rptPaymentPostsModel, List<RptTaxDuesModel> rptTaxDuesModels)
        {
            using (var scope = new TransactionScope())
            {
                var parameters = new object[][]
                   {
                        new object[] { "@collecting_officers_id", DbType.Int32, paymentCollectionsModel.CollectingOfficerId},
                        new object[] { "@job_orders_id", DbType.Int32, paymentCollectionsModel.JobOrderId},
                        new object[] { "@funds_id", DbType.Int16, paymentCollectionsModel.FundId},
                        new object[] { "@accountable_forms_id", DbType.Int16, paymentCollectionsModel.AccountableFormId},
                        new object[] { "@payee", DbType.String, paymentCollectionsModel.Payee},
                        new object[] { "@receipt_no", DbType.String, paymentCollectionsModel.ReceiptNo},
                        new object[] { "@payment_date", DbType.DateTime, paymentCollectionsModel.PaymentDate},
                        new object[] { "@amount", DbType.Decimal, paymentCollectionsModel.Amount},
                        new object[] { "@is_cancelled", DbType.Boolean, paymentCollectionsModel.IsCancelled},
                        new object[] { "@created_by", DbType.Int16, paymentCollectionsModel.CreatedBy}
                   };

                string query = $"INSERT INTO {tableName} " +
                               $"(collecting_officers_id, " +
                               $"job_orders_id," +
                               $"funds_id, " +
                               $"accountable_forms_id, " +
                               $"payee, " +
                               $"receipt_no,  " +
                               $"payment_date, " +
                               $"amount, " +
                               $"is_cancelled, " +
                               $"created_by) " +
                               $"VALUES " +
                               $"(@collecting_officers_id, " +
                               $"@job_orders_id, " +
                               $"@funds_id, " +
                               $"@accountable_forms_id, " +
                               $"@payee, " +
                               $"@receipt_no, " +
                               $"@payment_date, " +
                               $"@amount, " +
                               $"@is_cancelled, " +
                               $"@created_by)";

                _ = _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);

                rptPaymentPostsModel.PaymentCollectionsId = GetLastInsertedID();

                _rptPaymentPostsRepository.InsertWithRptTaxDues(rptPaymentPostsModel, rptTaxDuesModels);

                scope.Complete();
                return true;
            }
        }

        public List<int> GetRecordsReceiptsByAccFormId(int accountableFormId)
        {
            var receiptNos = new List<int>();

            var parameters = new object[][]
            {
                new object[] { "@accountable_forms_id", DbType.Int32, accountableFormId}
            };

            string query = $"SELECT receipt_no FROM {tableName} WHERE accountable_forms_id = @accountable_forms_id";

            foreach (DataRow row in _mySqlGenericCommandsLFS.ExecuteReader(query, parameters).Rows)
                receiptNos.Add(Convert.ToInt32(row["receipt_no"]));

            return receiptNos;
        }
    }
}