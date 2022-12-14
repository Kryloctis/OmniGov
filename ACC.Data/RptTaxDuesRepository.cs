using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACC.Data
{
    public class RptTaxDuesRepository : IRptTaxDuesRepository
    {
        private AccGenericCommands _mySqlGenericCommandsLFS;
        private readonly string tableName = "rpt_tax_dues";
        private readonly string viewTableName = "view_rpt_tax_dues";

        public RptTaxDuesRepository(AccGenericCommands mySqlGenericCommandsLFS)
        {
            _mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
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
                new object[] { "@rpt_payment_posts_id", DbType.Int32, entity.RptPaymentPostsId },
                new object[] { "@discount_rate", DbType.Decimal, entity.DiscountRate },
                new object[] { "@is_advance", DbType.Boolean, entity.IsAdvance }
            };

            string query = $"INSERT INTO  {tableName}  (rpt_assessment_posts_id ,  rpt_payment_posts_id ,  discount_rate ,  is_advance ) VALUES (@rpt_assessment_posts_id, @rpt_payment_posts_id, @discount_rate, @is_advance)";
            return _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Update(RptTaxDuesModel entity)
        {
            throw new NotImplementedException();
        }

        public DataTable GetViewRecordsByRptPaymentPostsId(int rptPaymentPostsId)
        {
            var parameters = new object[][]
            {
                new object[] { "@rpt_payment_posts_id", DbType.Int32, rptPaymentPostsId }
            };

            string query = $"SELECT * FROM {viewTableName} WHERE rpt_payment_posts_id = @rpt_payment_posts_id";
            var dataTable = new DataTable();
            return _mySqlGenericCommandsLFS.FillBySearch(query, dataTable, parameters);
        }
    }
}