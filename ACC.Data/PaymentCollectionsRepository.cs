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
        private AccGenericCommands mySqlGenericCommandsLFS;
        private IRptPaymentRepository rptPaymentRepository;
        private IMarriageLicenseRepository marriageLicenseRepository;
        private ICattleOwnershipRepository cattleOwnershipRepository;
        private IBurialPermitRepository burialPermitRepository;
        private IPaymentCollectionHasChequesRepository paymentCollectionHasChequesRepository;
        private IPaymentFeesCharges paymentFeesCharges;

        public PaymentCollectionsRepository(AccGenericCommands mySqlGenericCommandsLFSLFS, IRptPaymentRepository rptPaymentRepository, IMarriageLicenseRepository marriageLicenseRepository, ICattleOwnershipRepository cattleOwnershipRepository, IBurialPermitRepository burialPermitRepository, IPaymentCollectionHasChequesRepository paymentCollectionHasChequesRepository, IPaymentFeesCharges paymentFeesCharges)
        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommandsLFSLFS;
            this.rptPaymentRepository = rptPaymentRepository;
            this.marriageLicenseRepository = marriageLicenseRepository;
            this.cattleOwnershipRepository = cattleOwnershipRepository;
            this.burialPermitRepository = burialPermitRepository;
            this.paymentCollectionHasChequesRepository = paymentCollectionHasChequesRepository;
            this.paymentFeesCharges = paymentFeesCharges;
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, Id},
            };

            string query = $"SELECT * FROM {tableName} WHERE id = @id";

            DataTable dataTable = mySqlGenericCommandsLFS.ExecuteReader(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                foreach (DataColumn column in dataTable.Columns)
                    recordDictionary[column.ColumnName] = row[column].ToString();

                return recordDictionary;
            }
            return recordDictionary;
        }

        public DataTable GetRecordsByCollectingOfficerId(int collectorId)
        {
            var parameter = new object[][] {
                new object[] {"@collectorId", DbType.Int32, collectorId}
            };

            string query = $"SELECT id, funds_id, fund_name, accountable_form_id, accountable_forms, account_code, general_ledger_accounts_id, ledger_name, payee, receipt_no, quantity, payment_date, amount FROM {viewTableName} WHERE collecting_officer_id = @collectorId ORDER BY accountable_form_id";

            var dataTable = new DataTable();
            return mySqlGenericCommandsLFS.FillBySearch(query, dataTable, parameter);
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {viewTableName}";

            var dtPaymentCollection = new DataTable();
            return mySqlGenericCommandsLFS.Fill(query, dtPaymentCollection);
        }

        public DataTable GetRecordsByDate(string date)
        {
            var parameter = new object[][]
            {
                new object[]{"@date", DbType.DateTime2, date}
            };

            string query = $"SELECT * FROM {viewTableName} WHERE payment_date = @date";

            var dtPaymentCollection = new DataTable();
            return mySqlGenericCommandsLFS.FillBySearch(query, dtPaymentCollection, parameter);
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
            return mySqlGenericCommandsLFS.FillBySearch(query, dtPaymentCollection, parameter);
        }

        public bool Insert(PaymentCollectionsModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@collecting_officers_id", DbType.Int32, entity.CollectingOfficerModel.Id},
                new object[] { "@job_orders_id", DbType.Int32, entity.JobOrderModel.Id},
                new object[] { "@accountable_forms_id", DbType.Int16, entity.AccountableFormsModel.Id},
                new object[] { "@payee", DbType.String, entity.Payee},
                new object[] { "@receipt_no", DbType.String, entity.ReceiptNo},
                new object[] { "@payment_date", DbType.DateTime, entity.PaymentDate},
                new object[] { "@amount", DbType.Decimal, entity.Amount},
                new object[] { "@is_cancelled", DbType.Boolean, entity.IsCancelled},
                new object[] { "@created_by", DbType.Int32, entity.CreatedBy}
            };

            string query = $"INSERT INTO {tableName} (collecting_officers_id, job_orders_id, accountable_forms_id, payee, receipt_no, payment_date, amount, is_cancelled, created_by) VALUES (@collecting_officers_id, @job_orders_id, @accountable_forms_id, @payee, @receipt_no, @payment_date, @amount, @is_cancelled, @created_by)";

            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Update(PaymentCollectionsModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int16, entity.Id},
                new object[] { "@collecting_officers_id", DbType.Int32, entity.CollectingOfficerModel.Id},
                new object[] { "@accountable_forms_id", DbType.Int32, entity.AccountableFormsModel.Id},
                new object[] { "@payee", DbType.String, entity.Payee},
                new object[] { "@receipt_no", DbType.String, entity.ReceiptNo},
                new object[] { "@payment_date", DbType.DateTime, entity.PaymentDate},
                new object[] { "@amount", DbType.Decimal, entity.Amount},
                new object[] { "@updated_by", DbType.Int16, entity.UpdatedBy}
            };

            string query = $"UPDATE {tableName} SET funds_id = @funds_id, payee = @payee, receipt_no = @receipt_no, payment_date = @payment_date, amount = @amount, updated_by = @updated_by WHERE id = @id";

            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
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
                        _ = mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
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

                return int.Parse(mySqlGenericCommandsLFS.ExecuteScalar(query));
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
            string queryResult = mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);

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
            string queryResult = mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);

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

            string queryResult = mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);

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
            return mySqlGenericCommandsLFS.FillBySearch(query, dtpc, parameter);
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
            return mySqlGenericCommandsLFS.FillBySearch(query, dtPaymentCollection, parameters);
        }

        public DataTable GetRecordsByUserId(int userId)
        {
            var parameter = new object[][] {
                new object[] {"@userId", DbType.Int32, userId }
            };

            string query = $"SELECT * FROM {viewTableName} WHERE created_by = @userId";

            var dt = new DataTable();

            return mySqlGenericCommandsLFS.FillBySearch(query, dt, parameter);
        }

        public DataTable GetCollectionsPerCollector()
        {
            string query = $"SELECT collecting_officer_id, collecting_officers_first_name, collecting_officers_mid_initial, collecting_officers_last_name, job_orders_id, job_orders_first_name, job_orders_mid_initial, job_orders_last_name, SUM(amount) AS amount FROM {viewTableName} GROUP BY job_orders_id";

            var dt = new DataTable();
            return mySqlGenericCommandsLFS.FillBySearch(query, dt);
        }

        public int GetLastInsertedID(int createdById)
        {
            var parameters = new object[][]
            {
                new object[] { "@created_by", DbType.Int32, createdById}
            };

            string query = $"SELECT COALESCE(MAX(id)) FROM {tableName} WHERE created_by = @created_by";
            return Convert.ToInt32(mySqlGenericCommandsLFS.ExecuteScalar(query, parameters));
        }

        public int GetPreviouslyUsedReceiptNumber(int collectingOfficerID, int accountableFormID)
        {
            var parameter = new object[][]
            {
                new object[]{"@collecting_officers_id", DbType.Int32, collectingOfficerID},
                new object[]{"@accountable_forms_id", DbType.Int32, accountableFormID},
            };

            string query = $"SELECT COALESCE(MAX(receipt_no), 0) FROM payment_collections WHERE collecting_officers_id = @collecting_officers_id AND accountable_forms_id = @accountable_forms_id AND is_cancelled <> 1";

            return Convert.ToInt32(mySqlGenericCommandsLFS.ExecuteScalar(query, parameter));
        }

        public List<int> GetRecordsReceiptsByAccFormId(int accountableFormId)
        {
            var receiptNos = new List<int>();
            var parameters = new object[][]
            {
                new object[] { "@accountable_forms_id", DbType.Int32, accountableFormId}
            };

            string query = $"SELECT receipt_no FROM {tableName} WHERE accountable_forms_id = @accountable_forms_id";

            foreach (DataRow row in mySqlGenericCommandsLFS.ExecuteReader(query, parameters).Rows)
                receiptNos.Add(Convert.ToInt32(row["receipt_no"]));

            return receiptNos;
        }

        public int GetTotalUsedAccountableFormByCollectingOfficerID(int collectingOfficerID, int accountableFormID)
        {
            var parameter = new object[][]
            {
                new object[]{ "@collecting_officer_id", DbType.Int32, collectingOfficerID},
                new object[]{"@accountable_forms_id", DbType.Int32, accountableFormID},
            };

            string query = $"SELECT COUNT(id) FROM {viewTableName} WHERE collecting_officer_id = @collecting_officer_id AND accountable_forms_id = @accountable_forms_id";

            return Convert.ToInt32(mySqlGenericCommandsLFS.ExecuteScalar(query, parameter));
        }

        public bool ReceiptAlreadyUsed(int accountableFormID, int receiptNumberFrom)
        {
            var parameters = new object[][]
            {
                new object[] { "@accountable_forms_id", DbType.Int32, accountableFormID },
                new object[] { "@receipt_no", DbType.Int64, receiptNumberFrom },
            };

            string query = $"SELECT id FROM {tableName} WHERE receipt_no = @receipt_no AND accountable_forms_id = @accountable_forms_id";

            string queryResult = mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);

            if (!string.IsNullOrEmpty(queryResult))
                return true;

            return false;
        }

        public bool InsertWithRptPayment(PaymentCollectionsModel paymentCollectionsModel, PaymentCollectionHasChequesModel paymentCollectionHasChequesModel, RptPaymentsModel rptPaymentsModel, List<RptTaxDuesModel> rptTaxDuesModels, List<PaymentFeesChargesModel> paymentFeesChargesModels)
        {
            using (var scope = new TransactionScope())
            {
                _ = Insert(paymentCollectionsModel);
                int paymentCollectionId = GetLastInsertedID(paymentCollectionsModel.CreatedBy);
                rptPaymentsModel.PaymentCollectionsId = paymentCollectionId;
                paymentCollectionHasChequesModel.PaymentCollectionId = paymentCollectionId;

                rptPaymentRepository.InsertWithRptTaxDues(rptPaymentsModel, rptTaxDuesModels);
                paymentFeesCharges.InsertBulk(paymentFeesChargesModels);
                paymentCollectionHasChequesRepository.InsertWithCheques(paymentCollectionHasChequesModel);

                scope.Complete();
                return true;
            }
        }

        public bool InsertWithMarriageLicensePayment(PaymentCollectionsModel paymentCollectionsModel, PaymentCollectionHasChequesModel paymentCollectionHasChequesModel, MarriageLicenseModel marriageLicenseModel, List<PaymentFeesChargesModel> paymentFeesChargesModels)
        {
            using (var scope = new TransactionScope())
            {
                _ = Insert(paymentCollectionsModel);
                int paymentCollectionId = GetLastInsertedID(paymentCollectionsModel.CreatedBy);
                paymentCollectionHasChequesModel.PaymentCollectionId = paymentCollectionId;
                marriageLicenseModel.PaymentCollectionsModel.Id = paymentCollectionId;
                marriageLicenseRepository.Insert(marriageLicenseModel);
                paymentFeesCharges.InsertBulk(paymentFeesChargesModels);
                paymentCollectionHasChequesRepository.InsertWithCheques(paymentCollectionHasChequesModel);

                scope.Complete();
                return true;
            }
        }

        public bool InsertWithBurialPermitPayment(PaymentCollectionsModel paymentCollectionsModel, PaymentCollectionHasChequesModel paymentCollectionHasChequesModel, BurialPermitModel burialPermitModel, List<PaymentFeesChargesModel> paymentFeesChargesModels)
        {
            using (var scope = new TransactionScope())
            {
                _ = Insert(paymentCollectionsModel);
                int paymentCollectionId = GetLastInsertedID(paymentCollectionsModel.CreatedBy);
                burialPermitModel.PaymentCollections.Id = paymentCollectionId;
                paymentCollectionHasChequesModel.PaymentCollectionId = paymentCollectionId;
                burialPermitRepository.Insert(burialPermitModel);
                paymentFeesCharges.InsertBulk(paymentFeesChargesModels);
                paymentCollectionHasChequesRepository.InsertWithCheques(paymentCollectionHasChequesModel);

                scope.Complete();
                return true;
            }
        }

        public bool InsertWithCattleOwnershipPayment(PaymentCollectionsModel paymentCollectionsModel, PaymentCollectionHasChequesModel paymentCollectionHasChequesModel, CattleOwnershipModel cattleOwnershipModel, List<PaymentFeesChargesModel> paymentFeesChargesModels)
        {
            using (var scope = new TransactionScope())
            {
                _ = Insert(paymentCollectionsModel);
                int paymentCollectionId = GetLastInsertedID(paymentCollectionsModel.CreatedBy);
                paymentCollectionHasChequesModel.PaymentCollectionId = paymentCollectionId;
                cattleOwnershipModel.PaymentCollectionsModel.Id = paymentCollectionId;
                cattleOwnershipRepository.Insert(cattleOwnershipModel);
                paymentFeesCharges.InsertBulk(paymentFeesChargesModels);
                paymentCollectionHasChequesRepository.InsertWithCheques(paymentCollectionHasChequesModel);

                scope.Complete();
                return true;
            }
        }

        public bool InsertWithFeesCharges(PaymentCollectionsModel paymentCollectionsModel, PaymentCollectionHasChequesModel paymentCollectionHasChequesModel, List<PaymentFeesChargesModel> paymentFeesChargesModels)
        {
            using (var scope = new TransactionScope())
            {
                _ = Insert(paymentCollectionsModel);
                int paymentCollectionId = GetLastInsertedID(paymentCollectionsModel.CreatedBy);
                paymentCollectionHasChequesModel.PaymentCollectionId = paymentCollectionId;
                paymentFeesCharges.InsertBulk(paymentFeesChargesModels);
                paymentCollectionHasChequesRepository.InsertWithCheques(paymentCollectionHasChequesModel);

                scope.Complete();
                return true;
            };
        }
    }
}