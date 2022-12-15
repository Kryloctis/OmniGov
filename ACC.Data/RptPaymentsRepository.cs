using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    public class RptPaymentsRepository : IRptPaymentPostsRepository
    {
        private AccGenericCommands _mySqlGenericCommandsLFS;
        private IRptTaxDuesRepository _rptTaxDuesRepository;
        private readonly string tableName = "rpt_payments";
        private readonly string viewTableName = "view_rpt_payments";

        public RptPaymentsRepository(AccGenericCommands mySqlGenericCommandsLFS, IRptTaxDuesRepository rptTaxDuesRepository)
        {
            _mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
            _rptTaxDuesRepository = rptTaxDuesRepository;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
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
            return _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Update(RptPaymentsModel entity)
        {
            throw new NotImplementedException();
        }

        public int GetLastInsertedID()
        {
            string query = $"SELECT COALESCE(MAX(id)) FROM {tableName}";
            return Convert.ToInt32(_mySqlGenericCommandsLFS.ExecuteScalar(query));
        }

        public bool InsertWithRptTaxDues(RptPaymentsModel rptPaymentModel, List<RptTaxDuesModel> rptTaxDuesModels)
        {
            using (var scope = new TransactionScope())
            {
                _ = Insert(rptPaymentModel);

                foreach (RptTaxDuesModel rptTaxDuesModel in rptTaxDuesModels)
                {
                    rptTaxDuesModel.RptPaymentsId = GetLastInsertedID();
                    _ = _rptTaxDuesRepository.Insert(rptTaxDuesModel);
                }

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
            return _mySqlGenericCommandsLFS.FillBySearch(query, dataTable, parameters);
        }

        public Dictionary<string, string> GetViewRecordById(int Id)
        {
            var dict = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@rpt_payment_posts_id", DbType.Int32, Id }
            };

            string query = $"SELECT rpt_payment_posts_id, taxpayer_name, taxpayer_tin, taxpayer_address, taxpayer_contact, rpt_payment_posts_posted_at, rpt_payment_posts_posted_by, payment_collections_id, payment_collections_collecting_officers_id, payment_collections_job_orders_id, payment_collections_funds_id, payment_collections_accountable_forms_id, payment_collections_payee, payment_collections_receipt_no, payment_collections_payment_date, payment_collections_amount, payment_collections_is_cancelled, payment_collections_created_at, payment_collections_created_by, payment_collections_updated_at, payment_collections_updated_by FROM {viewTableName} WHERE rpt_payment_posts_id = @rpt_payment_posts_id";

            using (var reader = _mySqlGenericCommandsLFS.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return dict;

                foreach (DataRow row in reader.Rows)
                {
                    dict.Add("rpt_payment_posts_id", row["rpt_payment_posts_id"].ToString());
                    dict.Add("taxpayer_name", row["taxpayer_name"].ToString());
                    dict.Add("taxpayer_tin", row["taxpayer_tin"].ToString());
                    dict.Add("taxpayer_address", row["taxpayer_address"].ToString());
                    dict.Add("taxpayer_contact", row["taxpayer_contact"].ToString());
                    dict.Add("rpt_payment_posts_posted_at", row["rpt_payment_posts_posted_at"].ToString());
                    dict.Add("rpt_payment_posts_posted_by", row["rpt_payment_posts_posted_by"].ToString());
                    dict.Add("payment_collections_id", row["payment_collections_id"].ToString());
                    dict.Add("payment_collections_collecting_officers_id", row["payment_collections_collecting_officers_id"].ToString());
                    dict.Add("payment_collections_job_orders_id", row["payment_collections_job_orders_id"].ToString());
                    dict.Add("payment_collections_funds_id", row["payment_collections_funds_id"].ToString());
                    dict.Add("payment_collections_accountable_forms_id", row["payment_collections_accountable_forms_id"].ToString());
                    dict.Add("payment_collections_payee", row["payment_collections_payee"].ToString());
                    dict.Add("payment_collections_receipt_no", row["payment_collections_receipt_no"].ToString());
                    dict.Add("payment_collections_payment_date", row["payment_collections_payment_date"].ToString());
                    dict.Add("payment_collections_amount", row["payment_collections_amount"].ToString());
                    dict.Add("payment_collections_is_cancelled", row["payment_collections_is_cancelled"].ToString());
                    dict.Add("payment_collections_created_at", row["payment_collections_created_at"].ToString());
                    dict.Add("payment_collections_created_by", row["payment_collections_created_by"].ToString());
                    dict.Add("payment_collections_updated_at", row["payment_collections_updated_at"].ToString());
                    dict.Add("payment_collections_updated_by", row["payment_collections_updated_by"].ToString());
                }

                return dict;
            }
        }
    }
}