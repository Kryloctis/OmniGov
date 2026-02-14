using OmniGov.Core.Repositories;
using System.Data;
using System.Transactions;
using Treasury.Domain.Entities;
using Treasury.Domain.Interfaces;

namespace Treasury.Data.Repositories
{
    public class CollectingOfficerHasJobOrdersRepository : ICollectingOfficerHasJobOrders
    {
        private readonly GenericCommands mySqlGenericCommandsLFS;
        private readonly string tableName = "collecting_officers_has_job_orders";
        private readonly string viewTableName = "view_collecting_officers_has_job_orders";

        public CollectingOfficerHasJobOrdersRepository(GenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommands;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<CollectingOfficerHasJobOrdersModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var entity in entityList)
                {
                    var parameters = new object[][]
                    {
                        new object[] { "@collecting_officers_id", DbType.Int32, entity.CollectingOfficerId},
                        new object[] { "@job_orders_id", DbType.Int32, entity.JobOrdersId},
                    };

                    string query = $"DELETE FROM {tableName} WHERE collecting_officers_id = @collecting_officers_id AND job_orders_id = @job_orders_id";
                    _ = mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
                }

                scope.Complete();
                return true;
            }
        }

        public int GetCollectingOfficerIDByJobOrderId(int? collectingOfficerId)
        {
            var parameter = new object[][] {
                new object[] { "@job_orders_id", DbType.Int32, collectingOfficerId }
            };

            string query = $"SELECT collecting_officers_id FROM {tableName} WHERE job_orders_id = @job_orders_id LIMIT 1";

            if (!string.IsNullOrEmpty(mySqlGenericCommandsLFS.ExecuteScalar(query, parameter)))
                return int.Parse(mySqlGenericCommandsLFS.ExecuteScalar(query, parameter));

            return 0;
        }

        public DataTable GetJobOrdersByCollectingOfficerId(int collectingOfficerId)
        {
            var parameter = new object[][] {
                new object[]{"@collecting_officers_id", DbType.Int32, collectingOfficerId }
            };

            string query = $"SELECT job_orders_id, CONCAT(job_orders_first_name, ' ', job_orders_mid_initial, ' ', job_orders_last_name) as fullname, job_orders_job_title FROM {viewTableName} WHERE collecting_officers_id = @collecting_officers_id AND job_orders_is_deleted = 0";

            var dataTable = new DataTable();
            return mySqlGenericCommandsLFS.FillBySearch(query, dataTable, parameter);
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {tableName}";

            var dataTable = new DataTable();
            return mySqlGenericCommandsLFS.Fill(query, dataTable);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecordsBySearch(int collectingOfficerId, string searchText)
        {
            var parameter = new object[][] {
                new object[]{"@collecting_officers_id", DbType.Int32, collectingOfficerId},
                new object[]{"@search_text", DbType.String, $"%{searchText}%" }
            };

            string query = $"SELECT job_orders_id, CONCAT(job_orders_first_name, ' ', job_orders_mid_initial, ' ', job_orders_last_name) as fullname, job_orders_job_title FROM {viewTableName} WHERE collecting_officers_id = @collecting_officers_id AND (job_orders_first_name LIKE @search_text OR  job_orders_last_name LIKE  @search_text)";

            var dataTable = new DataTable();
            return mySqlGenericCommandsLFS.FillBySearch(query, dataTable, parameter);
        }

        public Dictionary<string, string> GetViewRecordByJobOrderUserId(int jobOrderUserId)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@job_orders_user_id", DbType.Int32, jobOrderUserId}
            };

            string query = $"SELECT collecting_officers_id, collecting_officers_prefix, collecting_officers_firstname, collecting_officers_mid_initial, collecting_officers_last_name, collecting_officers_suffix, collecting_officers_job_title, collecting_officers_is_deleted, job_orders_id, job_orders_user_id, job_orders_prefix, job_orders_first_name, job_orders_mid_initial, job_orders_last_name, job_orders_suffix, job_orders_job_title, job_orders_is_deleted FROM {viewTableName} WHERE job_orders_user_id = @job_orders_user_id AND job_orders_is_deleted = 0";

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

        public DataTable GetViewRecords()
        {
            string query = $"SELECT * FROM {viewTableName} WHERE job_orders_is_deleted = 0";

            DataTable dataTable = new DataTable();
            return mySqlGenericCommandsLFS.Fill(query, dataTable);
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(CollectingOfficerHasJobOrdersModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@collecting_officers_id", DbType.Int32, entity.CollectingOfficerId},
                new object[] { "@job_orders_id", DbType.Int32, entity.JobOrdersId}
            };

            string query = $"INSERT INTO {tableName} VALUES (@collecting_officers_id, @job_orders_id)";
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool IsJobOrderCollector(int jobOrderId)
        {
            var parameters = new object[][]
            {
                new object[] {"@job_orders_id", DbType.Int32,  jobOrderId},
            };

            string query = $"SELECT COUNT(*) FROM {tableName} WHERE job_orders_id = @job_orders_id";
            return mySqlGenericCommandsLFS.ExecuteScalar(query, parameters) == "0";
        }

        public bool Update(CollectingOfficerHasJobOrdersModel entity)
        {
            throw new NotImplementedException();
        }
    }
}