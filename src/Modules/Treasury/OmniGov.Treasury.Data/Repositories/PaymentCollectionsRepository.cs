using OmniGov.Core.Entities;
using OmniGov.Core.Interfaces.Services;
using System.Data;
using System.Transactions;
using Treasury.Data.Factories;
using Treasury.Domain.Entities;
using Treasury.Domain.Interfaces;

namespace Treasury.Data.Repositories
{
    public class PaymentCollectionsRepository : IPaymentCollectionsRepository
    {
        private readonly string tableName = "payment_collections";
        private readonly string viewTableName = "view_payment_collections";
        private readonly IGenericCommands _genericCommands;
        private readonly IRptPaymentRepository _rptPaymentRepository;
        private readonly IMarriageLicenseRepository _marriageLicenseRepository;
        private readonly ICattleOwnershipRepository _cattleOwnershipRepository;
        private readonly IPrevCattleOwnership _prevCattleOwnershipRepository;
        private readonly IBurialPermitRepository _burialPermitRepository;
        private readonly IPaymentCollectionHasChequesRepository _paymentCollectionHasChequesRepository;
        private readonly IPaymentFeesCharges _paymentFeesCharges;
        private readonly IRcdCollections _rcdCollectionsRepository;
        private readonly IRcdDeposits _rcdDepositsRepository;
        private readonly IBidRepository _biddingsRepository;
        private readonly IBiddersRepository _biddersRepository;
        private readonly ICommunityTaxCertificateRepository _communityTaxCertificateRepository;

        public PaymentCollectionsRepository(
            IGenericCommands genericCommands,
            IRptPaymentRepository rptPaymentRepository,
            IMarriageLicenseRepository marriageLicenseRepository,
            ICattleOwnershipRepository cattleOwnershipRepository,
            IPrevCattleOwnership prevCattleOwnership,
            IBurialPermitRepository burialPermitRepository,
            IPaymentCollectionHasChequesRepository paymentCollectionHasChequesRepository,
            IPaymentFeesCharges paymentFeesCharges,
            IRcdCollections rcdCollections,
            IRcdDeposits rcdDeposits,
            IBidRepository biddingsRepository,
            IBiddersRepository biddersRepository,
            ICommunityTaxCertificateRepository communityTaxCertificateRepository)
        {
            _genericCommands = genericCommands ?? throw new ArgumentNullException(nameof(genericCommands));
            _rptPaymentRepository = rptPaymentRepository ?? throw new ArgumentNullException(nameof(rptPaymentRepository));
            _marriageLicenseRepository = marriageLicenseRepository ?? throw new ArgumentNullException(nameof(marriageLicenseRepository));
            _cattleOwnershipRepository = cattleOwnershipRepository ?? throw new ArgumentNullException(nameof(cattleOwnershipRepository));
            _prevCattleOwnershipRepository = prevCattleOwnership ?? throw new ArgumentNullException(nameof(prevCattleOwnership));
            _burialPermitRepository = burialPermitRepository ?? throw new ArgumentNullException(nameof(burialPermitRepository));
            _paymentCollectionHasChequesRepository = paymentCollectionHasChequesRepository ?? throw new ArgumentNullException(nameof(paymentCollectionHasChequesRepository));
            _paymentFeesCharges = paymentFeesCharges ?? throw new ArgumentNullException(nameof(paymentFeesCharges));
            _rcdCollectionsRepository = rcdCollections ?? throw new ArgumentNullException(nameof(rcdCollections));
            _rcdDepositsRepository = rcdDeposits ?? throw new ArgumentNullException(nameof(rcdDeposits));
            _biddingsRepository = biddingsRepository ?? throw new ArgumentNullException(nameof(biddingsRepository));
            _biddersRepository = biddersRepository ?? throw new ArgumentNullException(nameof(biddersRepository));
            _communityTaxCertificateRepository = communityTaxCertificateRepository ?? throw new ArgumentNullException(nameof(_communityTaxCertificateRepository));
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, Id},
            };

            string query = $"SELECT * FROM {tableName} WHERE id = @id";

            DataTable dataTable = _genericCommands.ExecuteReader(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                foreach (DataColumn column in dataTable.Columns)
                    recordDictionary[column.ColumnName] = row[column].ToString();

                return recordDictionary;
            }
            return recordDictionary;
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {viewTableName}";

            var dataTable = new DataTable();
            return _genericCommands.Fill(query, dataTable);
        }

        public bool Insert(PaymentCollectionsModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@collecting_officers_id", DbType.Int32, entity.CollectingOfficerId},
                new object[] { "@job_orders_id", DbType.Object, entity.JobOrderId},
                new object[] { "@accountable_forms_id", DbType.Int32, entity.AccountableFormId},
                new object[] { "@payee", DbType.String, entity.Payee},
                new object[] { "@receipt_no", DbType.String, entity.ReceiptNo},
                new object[] { "@payment_date", DbType.DateTime, entity.PaymentDate},
                new object[] { "@amount", DbType.Decimal, entity.Amount},
                new object[] { "@is_cancelled", DbType.Boolean, entity.IsCancelled},
                new object[] { "@created_by", DbType.Int32, entity.CreatedBy}
            };

            string query = $"INSERT INTO {tableName} (collecting_officers_id, job_orders_id, accountable_forms_id, payee, receipt_no, payment_date, amount, is_cancelled, created_by) VALUES (@collecting_officers_id, @job_orders_id, @accountable_forms_id, @payee, @receipt_no, @payment_date, @amount, @is_cancelled, @created_by)";

            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(PaymentCollectionsModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.Id},
                new object[] { "@collecting_officers_id", DbType.Int32, entity.CollectingOfficerId},
                new object[] { "@job_orders_id", DbType.Object, entity.JobOrderId},
                new object[] { "@accountable_forms_id", DbType.Int32, entity.AccountableFormId},
                new object[] { "@payee", DbType.String, entity.Payee},
                new object[] { "@receipt_no", DbType.String, entity.ReceiptNo},
                new object[] { "@payment_date", DbType.DateTime, entity.PaymentDate},
                new object[] { "@amount", DbType.Decimal, entity.Amount},
                new object[] { "@is_cancelled", DbType.Boolean, entity.IsCancelled},
                new object[] { "@updated_by", DbType.Int16, entity.UpdatedBy}
            };

            string query = $"UPDATE {tableName} SET collecting_officers_id = @collecting_officers_id, job_orders_id = @job_orders_id, accountable_forms_id = @accountable_forms_id, payee = @payee, receipt_no = @receipt_no, payment_date = @payment_date, amount = @amount, is_cancelled = @is_cancelled, updated_by = @updated_by WHERE id = @id;";

            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Delete(List<PaymentCollectionsModel> entityList)
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
                    _ = _genericCommands.ExecuteNonQuery(query, parameters);
                }

                scope.Complete();
                return true;
            }
        }

        public int CountRecords()
        {
            string query = $"SELECT COUNT(*) FROM {tableName}";
            return int.Parse(_genericCommands.ExecuteScalar(query));
        }

        public bool IdExist(int id)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int16, id },
            };

            string query = $"SELECT id FROM {tableName} WHERE id = @id";
            string queryResult = _genericCommands.ExecuteScalar(query, parameters);

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
            string queryResult = _genericCommands.ExecuteScalar(query, parameters);

            if (!string.IsNullOrEmpty(queryResult))
                return true;

            return false;
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameter = new object[][]
            {
                new object[] { "@searchText", DbType.String, $"%{searchText}%" }
            };

            string query = $"SELECT * FROM {viewTableName}  WHERE acc_form_desc LIKE @searchText || acc_form_no LIKE @searchText";

            var dataTable = new DataTable();
            return _genericCommands.FillBySearch(query, dataTable, parameter);
        }

        public DataTable GetRecordByLedger(object[] parameter)
        {
            var parameters = new object[][]
            {
                new object[] { "@collecting_officers_id", DbType.UInt16, parameter[0] },
                new object[] { "@funds_id", DbType.UInt16, parameter[1] },
                new object[] { "@collection_from", DbType.Date, parameter[2] },
                new object[] { "@collection_to", DbType.Date, parameter[3] }
            };

            string columnFilter = Convert.ToBoolean(parameter[4]) ? "jo_id" : "ISNULL(jo_id) AND co_id";

            string query = $"SELECT * FROM {viewTableName} WHERE {columnFilter} = @co_id AND payment_date BETWEEN @collection_from AND @collection_to ";

            var dataTable = new DataTable();
            return _genericCommands.FillBySearch(query, dataTable, parameters);
        }

        public DataTable GetCollectionsPerCollector()
        {
            string query = $"SELECT co_id, co_first_name, co_mid_initial, co_last_name, jo_id, jo_first_name, jo_mid_initial, jo_last_name, SUM(amount) AS amount FROM {viewTableName} GROUP BY jo_id";

            var dataTable = new DataTable();
            return _genericCommands.FillBySearch(query, dataTable);
        }

        public int GetLastInsertedID(int createdById)
        {
            var parameters = new object[][]
            {
                new object[] { "@created_by", DbType.Int32, createdById}
            };

            string query = $"SELECT COALESCE(MAX(id)) FROM {tableName} WHERE created_by = @created_by";
            return Convert.ToInt32(_genericCommands.ExecuteScalar(query, parameters));
        }

        public List<int> GetRecordsReceiptsByAccFormId(int accountableFormId)
        {
            var receiptNos = new List<int>();
            var parameters = new object[][]
            {
                new object[] { "@accountable_forms_id", DbType.Int32, accountableFormId}
            };

            string query = $"SELECT receipt_no FROM {tableName} WHERE accountable_forms_id = @accountable_forms_id";

            foreach (DataRow row in _genericCommands.ExecuteReader(query, parameters).Rows)
                receiptNos.Add(Convert.ToInt32(row["receipt_no"]));

            return receiptNos;
        }

        public int GetTotalUsedAccountableFormByCollectingOfficerID(int collectingOfficerID, int accountableFormID)
        {
            var parameter = new object[][]
            {
                new object[]{ "@co_id", DbType.Int32, collectingOfficerID},
                new object[]{ "@acc_form_id", DbType.Int32, accountableFormID},
            };

            string query = $"SELECT COALESCE(COUNT(id), 0) FROM {viewTableName} WHERE co_id = @co_id AND acc_form_id = @acc_form_id";

            return Convert.ToInt32(_genericCommands.ExecuteScalar(query, parameter));
        }

        public bool ReceiptAlreadyUsed(int accountableFormID, int receiptNumberFrom)
        {
            var parameters = new object[][]
            {
                new object[] { "@accountable_forms_id", DbType.Int32, accountableFormID },
                new object[] { "@receipt_no", DbType.Int64, receiptNumberFrom },
            };

            string query = $"SELECT id FROM {tableName} WHERE receipt_no = @receipt_no AND accountable_forms_id = @accountable_forms_id";

            string queryResult = _genericCommands.ExecuteScalar(query, parameters);

            if (!string.IsNullOrEmpty(queryResult))
                return true;

            return false;
        }

        public bool InsertWithRptPayment(PaymentCollectionsModel paymentCollectionsModel, PaymentCollectionHasChequesModel paymentCollectionHasChequesModel, RptPaymentsModel rptPaymentsModel, List<RptTaxDuesModel> rptTaxDuesModels)
        {
            using (var scope = new TransactionScope())
            {
                _ = Insert(paymentCollectionsModel);
                int paymentCollectionId = GetLastInsertedID(paymentCollectionsModel.CreatedBy);
                rptPaymentsModel.PaymentCollectionsId = paymentCollectionId;
                //paymentCollectionHasChequesModel.PaymentCollectionId = paymentCollectionId;
                _rptPaymentRepository.InsertWithRptTaxDues(rptPaymentsModel, rptTaxDuesModels);
                //_paymentCollectionHasChequesRepository.InsertWithCheques(paymentCollectionHasChequesModel);

                scope.Complete();
                return true;
            }
        }

        public bool InsertWithMarriageLicensePayment(PaymentCollectionsModel paymentCollectionsModel, PaymentCollectionHasChequesModel paymentCollectionHasChequesModel, MarriageLicenseModel marriageLicenseModel, List<PaymentFeesChargesModel> _paymentFeesChargesModels)
        {
            using (var scope = new TransactionScope())
            {
                _ = Insert(paymentCollectionsModel);
                int paymentCollectionId = GetLastInsertedID(paymentCollectionsModel.CreatedBy);
                //paymentCollectionHasChequesModel.PaymentCollectionId = paymentCollectionId;
                marriageLicenseModel.PaymentCollectionsId = paymentCollectionId;
                _marriageLicenseRepository.Insert(marriageLicenseModel);
                _paymentFeesChargesModels.ForEach(model => model.PaymentCollectionsId = paymentCollectionId);
                _paymentFeesCharges.InsertBulk(_paymentFeesChargesModels);
                //_paymentCollectionHasChequesRepository.InsertWithCheques(paymentCollectionHasChequesModel);

                scope.Complete();
                return true;
            }
        }

        public bool InsertWithBurialPermitPayment(PaymentCollectionsModel paymentCollectionsModel, PaymentCollectionHasChequesModel paymentCollectionHasChequesModel, BurialPermitModel burialPermitModel, List<PaymentFeesChargesModel> _paymentFeesChargesModels)
        {
            using (var scope = new TransactionScope())
            {
                _ = Insert(paymentCollectionsModel);
                int paymentCollectionId = GetLastInsertedID(paymentCollectionsModel.CreatedBy);
                burialPermitModel.PaymentCollectionsId = paymentCollectionId;
                //paymentCollectionHasChequesModel.PaymentCollectionId = paymentCollectionId;
                _burialPermitRepository.Insert(burialPermitModel);
                _paymentFeesChargesModels.ForEach(model => model.PaymentCollectionsId = paymentCollectionId);
                _paymentFeesCharges.InsertBulk(_paymentFeesChargesModels);
                //_paymentCollectionHasChequesRepository.InsertWithCheques(paymentCollectionHasChequesModel);

                scope.Complete();
                return true;
            }
        }

        public bool InsertWithCattleOwnershipPayment(PaymentCollectionsModel paymentCollectionsModel, PaymentCollectionHasChequesModel paymentCollectionHasChequesModel, CattleOwnershipModel cattleOwnershipModel, List<PaymentFeesChargesModel> _paymentFeesChargesModels)
        {
            using (var scope = new TransactionScope())
            {
                _ = Insert(paymentCollectionsModel);
                int paymentCollectionId = GetLastInsertedID(paymentCollectionsModel.CreatedBy);
                //paymentCollectionHasChequesModel.PaymentCollectionId = paymentCollectionId;
                cattleOwnershipModel.PaymentCollectionId = paymentCollectionId;
                _cattleOwnershipRepository.Insert(cattleOwnershipModel);
                _paymentFeesChargesModels.ForEach(model => model.PaymentCollectionsId = paymentCollectionId);
                _paymentFeesCharges.InsertBulk(_paymentFeesChargesModels);
                //_paymentCollectionHasChequesRepository.InsertWithCheques(paymentCollectionHasChequesModel);

                scope.Complete();
                return true;
            }
        }

        public bool InsertWithFeesCharges(PaymentCollectionsModel paymentCollectionsModel, PaymentCollectionHasChequesModel paymentCollectionHasChequesModel, List<PaymentFeesChargesModel> _paymentFeesChargesModels)
        {
            using (var scope = new TransactionScope())
            {
                _ = Insert(paymentCollectionsModel);
                int paymentCollectionId = GetLastInsertedID(paymentCollectionsModel.CreatedBy);
                //paymentCollectionHasChequesModel.PaymentCollectionId = paymentCollectionId;
                _paymentFeesChargesModels.ForEach(model => model.PaymentCollectionsId = paymentCollectionId);
                _paymentFeesCharges.InsertBulk(_paymentFeesChargesModels);
                //_paymentCollectionHasChequesRepository.InsertWithCheques(paymentCollectionHasChequesModel);

                scope.Complete();
                return true;
            }
            ;
        }

        public DataTable GerViewRecordsByCoIdAccFormId(int coId, int accFormId, string searchKey, int rowFilter)
        {
            var parameters = new object[][]
            {
                new object[] { "@co_id", DbType.Int32, coId},
                new object[] { "@acc_form_id", DbType.Int32, accFormId},
                new object[] { "@search_key", DbType.String, $"%{searchKey}%"},
                new object[] { "@row_filter", DbType.Int32, rowFilter},
            };

            string query = $"SELECT * FROM {viewTableName} WHERE co_id = @co_id AND acc_form_id = @acc_form_id AND (payee LIKE @search_key OR receipt_no LIKE @search_key OR amount LIKE @search_key) LIMIT @row_filter";
            var dataTable = new DataTable();
            return _genericCommands.FillBySearch(query, dataTable, parameters);
        }

        public DataTable GerViewRecordsByJoIdAccFormId(int joId, int accFormId, string searchKey, int rowFilter)
        {
            var parameters = new object[][]
            {
                new object[] { "@jo_id", DbType.Int32, joId},
                new object[] { "@acc_form_id", DbType.Int32, accFormId},
                new object[] { "@search_key", DbType.String, $"%{searchKey}%"},
                new object[] { "@row_filter", DbType.Int32, rowFilter},
            };

            string query = $"SELECT * FROM {viewTableName} WHERE jo_id = @jo_id AND acc_form_id = @acc_form_id AND (payee LIKE @search_key OR receipt_no LIKE @search_key OR amount LIKE @search_key) LIMIT @row_filter";
            var dataTable = new DataTable();
            return _genericCommands.FillBySearch(query, dataTable, parameters);
        }

        public bool InsertWithPrevCattleOwnership(PaymentCollectionsModel paymentCollectionsModel, PaymentCollectionHasChequesModel paymentCollectionHasChequesModel, CattleOwnershipModel cattleOwnershipModel, PrevCattleOwnershipModel prevCattleOwnershipModel, List<PaymentFeesChargesModel> _paymentFeesChargesModels)
        {
            using (var scope = new TransactionScope())
            {
                _ = Insert(paymentCollectionsModel);
                int lastPaymentCollectionId = GetLastInsertedID(paymentCollectionsModel.CreatedBy);

                cattleOwnershipModel.PaymentCollectionId = lastPaymentCollectionId;
                _cattleOwnershipRepository.Insert(cattleOwnershipModel);
                int lastCattleOwnershipId = _cattleOwnershipRepository.GetLastInsertedId(cattleOwnershipModel.CreatedBy);
                prevCattleOwnershipModel.CattleOwnershipId = lastCattleOwnershipId;
                _prevCattleOwnershipRepository.Insert(prevCattleOwnershipModel);
                _paymentFeesChargesModels.ForEach(model => model.PaymentCollectionsId = lastPaymentCollectionId);
                _paymentFeesCharges.InsertBulk(_paymentFeesChargesModels);

                scope.Complete();
                return true;
            }
        }

        public DataTable GetViewConsolidatedRcdRecords(DateTime date, UsersModel createdBy)
        {
            var parameters = new object[][]
            {
                new object[] { "@date", DbType.DateTime, date},
                new object[] { "@created_by", DbType.Int32, createdBy.Id}
            };

            string query = $"SELECT acc_form_id, acc_form_no, acc_form_desc, MIN(receipt_no) AS receipt_from, MAX(receipt_no) AS receipt_to, SUM(amount) AS total_amount FROM {viewTableName} WHERE created_by = @created_by AND DATE(payment_date) < DATE(@date) AND id NOT IN (SELECT payment_collections_id FROM {_rcdCollectionsRepository.GetTableName()}) GROUP BY acc_form_id ORDER BY acc_form_no ASC";
            return _genericCommands.FillBySearch(query, new DataTable(), parameters);
        }

        public DataTable GetViewConsolidatedRcdRecords(RcdCollectionsModel rcdCollectionsModel)
        {
            var parameters = new object[][]
            {
                new object[] { "@rcd_id", DbType.Int32, rcdCollectionsModel.RcdModel.Id},
            };

            string query = $"SELECT acc_form_id, acc_form_no, acc_form_desc, MIN(receipt_no) AS receipt_from, MAX(receipt_no) AS receipt_to, SUM(amount) AS total_amount, created_by FROM {viewTableName} WHERE id IN (SELECT payment_collections_id FROM {_rcdCollectionsRepository.GetTableName()} WHERE rcd_id = @rcd_id) GROUP BY acc_form_id ORDER BY acc_form_no ASC";
            return _genericCommands.FillBySearch(query, new DataTable(), parameters);
        }

        public List<RcdCollectionsModel> GetRcdCollections(DateTime date, UsersModel createdBy)
        {
            var rcdCollectionsModels = new List<RcdCollectionsModel>();

            var parameters = new object[][]
            {
                new object[] { "@date", DbType.DateTime, date},
                new object[] { "@created_by", DbType.Int32, createdBy.Id}
            };

            string query = $"SELECT * FROM {viewTableName} WHERE created_by = @created_by AND DATE(payment_date) < DATE(@date) AND id NOT IN (SELECT payment_collections_id FROM {_rcdCollectionsRepository.GetTableName()}) ORDER BY acc_form_no ASC ";

            using (DataTable dataTable = _genericCommands.ExecuteReader(query, parameters))
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    var rcdCollectionModel = new RcdCollectionsModel()
                    {
                        PaymentCollectionsModel = new PaymentCollectionsModel() { Id = Convert.ToInt32(dataRow["id"]) },
                    };

                    rcdCollectionsModels.Add(rcdCollectionModel);
                }
            }

            return rcdCollectionsModels;
        }

        public List<RcdCollectionsModel> GetRcdCollections(RcdModel rcdModel)
        {
            var rcdCollectionsModels = new List<RcdCollectionsModel>();

            var parameters = new object[][]
            {
                new object[] { "@rcd_id", DbType.Int32, rcdModel.Id},
            };

            string query = $"SELECT * FROM {viewTableName} WHERE id IN (SELECT payment_collections_id FROM {_rcdCollectionsRepository.GetTableName()} WHERE rcd_id = @rcd_id) ORDER BY acc_form_no ASC ";

            using (DataTable dataTable = _genericCommands.ExecuteReader(query, parameters))
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    var rcdCollectionModel = new RcdCollectionsModel()
                    {
                        PaymentCollectionsModel = new PaymentCollectionsModel() { Id = Convert.ToInt32(dataRow["id"]) },
                    };

                    rcdCollectionsModels.Add(rcdCollectionModel);
                }
            }

            return rcdCollectionsModels;
        }

        public bool InsertWithBiddingPayment(PaymentCollectionsModel paymentCollectionsModel, PaymentCollectionHasChequesModel paymentCollectionHasChequesModel, TaxpayersModel taxpayersModel, BidModel bidModel, BiddersModel biddersModel)
        {
            using (var scope = new TransactionScope())
            {
                int createdBy = paymentCollectionsModel.CreatedBy;
                _ = Insert(paymentCollectionsModel);
                int lastPaymentCollectionId = GetLastInsertedID(createdBy);

                var taxpayerRepo = TreasuryFactory.TaxpayersRepository();
                taxpayersModel.CreatedBy = createdBy;
                taxpayerRepo.Insert(taxpayersModel);
                int lastInsertedTaxpayerId = taxpayerRepo.GetLastInsertedId(createdBy);

                biddersModel.PaymentCollectionsId = lastPaymentCollectionId;
                biddersModel.TaxpayersId = lastInsertedTaxpayerId;
                _biddersRepository.Insert(biddersModel);

                int lastInsertedBiddersId = _biddersRepository.GetLastInsertedId(biddersModel.CreatedBy);
                bidModel.BiddersId = lastInsertedBiddersId;
                _biddingsRepository.Insert(bidModel);

                scope.Complete();
                return true;
            }
        }

        bool IPaymentCollectionsRepository.VoidPayment(PaymentCollectionsModel paymentCollectionModel)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, paymentCollectionModel.Id},
                new object[] { "@is_cancelled", DbType.Boolean, paymentCollectionModel.IsCancelled},
            };

            string query = $"UPDATE {tableName} SET  is_cancelled = @is_cancelled WHERE id = @id";

            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool InsertWithCommunityTaxCertificate(PaymentCollectionsModel paymentCollectionsModel, CommunityTaxCertificateModel communityTaxCertificateModel)
        {
            using (var scope = new TransactionScope())
            {
                _ = Insert(paymentCollectionsModel);
                int paymentCollectionId = GetLastInsertedID(paymentCollectionsModel.CreatedBy);
                //paymentCollectionHasChequesModel.PaymentCollectionId = paymentCollectionId;
                communityTaxCertificateModel.PaymentCollectionsId = paymentCollectionId;
                _communityTaxCertificateRepository.Insert(communityTaxCertificateModel);
                //paymentCollectionHasChequesRepository.InsertWithCheques(paymentCollectionHasChequesModel);

                scope.Complete();
                return true;
            }
        }
    }
}