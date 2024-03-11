using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    internal class RptDelinquenciesRepository : IRptDelinquenciesRepository
    {

        private readonly string tableName = "rpt_delinquencies";
        private readonly string viewRptDelinquencies = "view_rpt_delinquencies";

        private AccGenericCommands mySqlGenericCommands;

        public RptDelinquenciesRepository(AccGenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public int CountRecords()
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(List<RptDelinquenciesModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var entity in entityList)
                {
                    var parameters = new object[][] { new object[] { @"id", DbType.Int32, entity.Id } };

                    string query = $"DELETE FROM {tableName} WHERE id = @id";
                    _ = mySqlGenericCommands.ExecuteNonQuery(query, parameters);
                }

                scope.Complete();
                return true;
            }
        }

        public bool DuplicatedNotificationStatus(int rptAssessmentPostId, string status)
        {
            var parameters = new object[][]
            {
                new object[] { "@rpt_assessment_posts_id", DbType.Int32, rptAssessmentPostId },
                new object[] { "@delinquency_status", DbType.String, status },
            };

            string query = $"SELECT id FROM {tableName} WHERE rpt_assessment_posts_id = @rpt_assessment_posts_id AND delinquency_status = @delinquency_status";
            string queryResult = mySqlGenericCommands.ExecuteScalar(query, parameters);

            // if query is not null, means found some record, so true
            if (!string.IsNullOrEmpty(queryResult)) return true;

            return false;
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][] { new object[] { "@id", DbType.Int32, Id } };
            string query = $"SELECT * FROM {tableName} WHERE id = @id";

            DataTable dataTable = mySqlGenericCommands.ExecuteReader(query, parameters);

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
            throw new System.NotImplementedException();
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetViewRptDelinquencies()
        {
            string query = $"SELECT * FROM {viewRptDelinquencies} WHERE id IN (SELECT MAX(id) FROM {viewRptDelinquencies} GROUP BY rpt_assessment_posts_id)";
            var dataTable = new DataTable();

            return mySqlGenericCommands.Fill(query, dataTable);
        }

        public bool IdExist(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(RptDelinquenciesModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@rpt_assessment_posts_id", DbType.String, entity.RptAssessmentPostId },
                new object[] { "@delinquency_status", DbType.String, entity.DelinquenciesStatus },
                new object[] { "@created_by", DbType.Int32, entity.CreatedBy },
            };

            string query = $"INSERT INTO {tableName} (rpt_assessment_posts_id, delinquency_status, created_by) VALUES (@rpt_assessment_posts_id, @delinquency_status, @created_by)";

            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(RptDelinquenciesModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.Id },
                new object[] { "@rpt_assessment_posts_id", DbType.Int32, entity.RptAssessmentPostId },
                new object[] { "@delinquency_status", DbType.String, entity.DelinquenciesStatus },
                new object[] { "@created_by", DbType.Int32, entity.CreatedBy },
            };

            string query = $"UPDATE {tableName} SET delinquency_status = @delinquency_status WHERE id = @id";

            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }
    }
}
