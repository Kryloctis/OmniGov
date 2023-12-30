using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    public class RptTaxDuesRepository : IRptTaxDuesRepository
    {
        private AccGenericCommands mySqlGenericCommandsLFS;
        private readonly string tableName = "rpt_tax_dues";
        private readonly string viewTableName = "view_rpt_tax_dues";

        public RptTaxDuesRepository(AccGenericCommands mySqlGenericCommandsLFS)
        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<RptTaxDuesModel> entityList)
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

        public bool Insert(RptTaxDuesModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@rpt_assessment_posts_id", DbType.Int32, entity.RptAssessmentPostId },
                new object[] { "@rpt_payments_id", DbType.Int32, entity.RptPaymentsId },
                new object[] { "@discount_rate", DbType.Decimal, entity.DiscountRate },
                new object[] { "@is_advance", DbType.Boolean, entity.IsAdvance }
            };

            string query = $"INSERT INTO  {tableName}  (rpt_assessment_posts_id ,  rpt_payments_id ,  discount_rate ,  is_advance ) VALUES (@rpt_assessment_posts_id, @rpt_payments_id, @discount_rate, @is_advance)";
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Update(RptTaxDuesModel entity)
        {
            throw new NotImplementedException();
        }

        public DataTable GetViewRecordsByRptPaymentPostsId(int rptPaymentsId)
        {
            var parameters = new object[][]
            {
                new object[] { "@rpt_payments_id", DbType.Int32, rptPaymentsId }
            };

            string query = $"SELECT * FROM {viewTableName} WHERE rpt_payments_id = @rpt_payments_id";
            var dataTable = new DataTable();
            return mySqlGenericCommandsLFS.FillBySearch(query, dataTable, parameters);
        }

        public bool BulkInsert(List<RptTaxDuesModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (RptTaxDuesModel rptTaxDuesModel in entityList)
                    _ = Insert(rptTaxDuesModel);

                scope.Complete();
                return true;
            }
        }
    }
}