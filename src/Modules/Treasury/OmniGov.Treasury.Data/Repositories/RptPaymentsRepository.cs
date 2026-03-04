using OmniGov.Core.Interfaces.Services;
using OmniGov.Treasury.Domain.Entities;
using OmniGov.Treasury.Domain.Interfaces;
using System.Data;
using System.Transactions;

namespace OmniGov.Treasury.Data.Repositories
{
    public class RptPaymentsRepository : IRptPaymentRepository
    {
        private readonly IGenericCommands _genericCommands;
        private readonly IRptTaxDuesRepository _rptTaxDuesRepository;

        private readonly string tableName = "rpt_payments";
        private readonly string viewTableName = "view_rpt_payments";

        public RptPaymentsRepository(IGenericCommands genericCommands, IRptTaxDuesRepository rptTaxDuesRepository)
        {
            _genericCommands = genericCommands ?? throw new ArgumentNullException(nameof(genericCommands));
            _rptTaxDuesRepository = rptTaxDuesRepository ?? throw new ArgumentNullException(nameof(rptTaxDuesRepository));
        }

        public bool Delete(List<RptPaymentsModel> entityList)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecords()
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new NotImplementedException();
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(RptPaymentsModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@payment_collections_id", DbType.Int32, entity.PaymentCollectionsId },
                new object[] { "@posted_by", DbType.Int32, entity.PostedBy }
            };

            string query = $"INSERT INTO  {tableName}  (payment_collections_id, posted_by ) VALUES (@payment_collections_id, @posted_by)";
            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(RptPaymentsModel entity)
        {
            throw new NotImplementedException();
        }

        public int GetLastInsertedID(int createdBy)
        {
            string query = $"SELECT COALESCE(MAX(id)) FROM {tableName}";
            return Convert.ToInt32(_genericCommands.ExecuteScalar(query));
        }

        public bool InsertWithRptTaxDues(RptPaymentsModel rptPaymentModel, List<RptTaxDuesModel> rptTaxDuesModels)
        {
            using (var scope = new TransactionScope())
            {
                _ = Insert(rptPaymentModel);
                foreach (var model in rptTaxDuesModels)
                    model.RptPaymentsId = GetLastInsertedID(rptPaymentModel.PostedBy);
                _ = _rptTaxDuesRepository.BulkInsert(rptTaxDuesModels);

                scope.Complete();
                return true;
            }
        }

        public DataTable GetViewRecordsByDateTaxPayerName(DateTime dateFrom, DateTime dateTo, string taxPayerName)
        {
            var parameters = new object[][]
            {
                new object[] { "@taxpayer_name", DbType.String, taxPayerName},
                new object[] { "@date_from", DbType.DateTime, dateFrom},
                new object[] { "@date_to", DbType.DateTime, dateTo}
            };

            string filter;

            if (dateFrom.Date == dateTo.Date)
                filter = "AND payment_collections_payment_date = @date_from";
            else
                filter = "AND payment_collections_payment_date BETWEEN @date_from AND @date_to";

            string query = $"SELECT * FROM {viewTableName} WHERE taxpayer_name = @taxpayer_name {filter}";
            var dataTable = new DataTable();
            return _genericCommands.FillBySearch(query, dataTable, parameters);
        }

        public Dictionary<string, string> GetViewRecordById(int Id)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@rpt_payment_posts_id", DbType.Int32, Id }
            };

            string query = $"SELECT rpt_payment_posts_id, taxpayer_name, taxpayer_tin, taxpayer_address, taxpayer_contact, rpt_payment_posts_posted_at, rpt_payment_posts_posted_by, payment_collections_id, payment_collections_collecting_officers_id, payment_collections_job_orders_id, payment_collections_funds_id, payment_collections_accountable_forms_id, payment_collections_payee, payment_collections_receipt_no, payment_collections_payment_date, payment_collections_amount, payment_collections_is_cancelled, payment_collections_created_at, payment_collections_created_by, payment_collections_updated_at, payment_collections_updated_by FROM {viewTableName} WHERE rpt_payment_posts_id = @rpt_payment_posts_id";

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

        public DataTable GetRecordsByAssessmentPostId(int assessmentPostId)
        {
            var parameters = new object[][]
            {
                new object[] { "@rpt_assessment_posts_id", DbType.Int32, assessmentPostId},
            };

            string query = $"SELECT * FROM {viewTableName} WHERE rpt_assessment_posts_id = @rpt_assessment_posts_id ";

            var dataTable = new DataTable();
            return _genericCommands.FillBySearch(query, dataTable, parameters);
        }

        Dictionary<string, string> IRptPaymentRepository.GetRecordByAssessmentPostId(int assessmentPostId)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@rpt_assessment_posts_id", DbType.Int32, assessmentPostId }
            };

            string query = $"SELECT * FROM {viewTableName} WHERE rpt_assessment_posts_id = @rpt_assessment_posts_id";

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
    }
}
