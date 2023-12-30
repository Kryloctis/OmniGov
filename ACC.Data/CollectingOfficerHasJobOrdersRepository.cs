using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    public class CollectingOfficerHasJobOrdersRepository : ICollectingOfficerHasJobOrders
    {
        private readonly AccGenericCommands mySqlGenericCommands;
        private readonly string tableName = "collecting_officers_has_job_orders";
        private readonly string viewTableName = "view_collecting_officers_has_job_orders";

        public CollectingOfficerHasJobOrdersRepository(AccGenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
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
                    _ = mySqlGenericCommands.ExecuteNonQuery(query, parameters);
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

            if (!string.IsNullOrEmpty(mySqlGenericCommands.ExecuteScalar(query, parameter)))
                return int.Parse(mySqlGenericCommands.ExecuteScalar(query, parameter));

            return 0;
        }

        public DataTable GetJobOrdersByCollectingOfficerId(int collectingOfficerId)
        {
            var parameter = new object[][] {
                new object[]{"@collecting_officers_id", DbType.Int32, collectingOfficerId }
            };

            string query = $"SELECT " +
                           $"job_orders_id, " +
                           $"CONCAT(job_orders_first_name, ' ', job_orders_mid_initial, ' ', job_orders_last_name) as fullname, " +
                           $"job_orders_job_title " +
                           $"FROM {viewTableName} " +
                           $"WHERE collecting_officers_id = @collecting_officers_id AND job_orders_is_deleted = 0";

            var dt = new DataTable();
            return mySqlGenericCommands.FillBySearch(query, dt, parameter);
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

        public DataTable GetRecordsBySearch(int collectingOfficerId, string searchText)
        {
            var parameter = new object[][] {
                new object[]{"@collecting_officers_id", DbType.Int32, collectingOfficerId},
                new object[]{"@search_text", DbType.String, $"%{searchText}%" }
            };

            string query = $"SELECT " +
                           $"job_orders_id, " +
                           $"CONCAT(job_orders_first_name, ' ', job_orders_mid_initial, ' ', job_orders_last_name) as fullname, " +
                           $"job_orders_job_title " +
                           $"FROM {viewTableName} " +
                           $"WHERE " +
                           $"collecting_officers_id = @collecting_officers_id " +
                           $"AND" +
                           $"(job_orders_first_name LIKE @search_text OR  job_orders_last_name LIKE  @search_text) ";

            var dt = new DataTable();
            return mySqlGenericCommands.FillBySearch(query, dt, parameter);
        }

        public Dictionary<string, string> GetViewRecordByJobOrderUserId(int jobOrderUserId)
        {
            var dict = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@job_orders_user_id", DbType.Int32, jobOrderUserId}
            };

            string query = $"SELECT collecting_officers_id, collecting_officers_prefix, collecting_officers_firstname, collecting_officers_mid_initial, collecting_officers_last_name, collecting_officers_suffix, collecting_officers_job_title, collecting_officers_is_deleted, job_orders_id, job_orders_user_id, job_orders_prefix, job_orders_first_name, job_orders_mid_initial, job_orders_last_name, job_orders_suffix, job_orders_job_title, job_orders_is_deleted FROM {viewTableName} WHERE job_orders_user_id = @job_orders_user_id AND job_orders_is_deleted = 0";

            using (var reader = mySqlGenericCommands.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return dict;

                foreach (DataRow row in reader.Rows)
                {
                    dict.Add("collecting_officers_id", row["collecting_officers_id"].ToString());
                    dict.Add("collecting_officers_prefix", row["collecting_officers_prefix"].ToString());
                    dict.Add("collecting_officers_firstname", row["collecting_officers_firstname"].ToString());
                    dict.Add("collecting_officers_mid_initial", row["collecting_officers_mid_initial"].ToString());
                    dict.Add("collecting_officers_last_name", row["collecting_officers_last_name"].ToString());
                    dict.Add("collecting_officers_suffix", row["collecting_officers_suffix"].ToString());
                    dict.Add("collecting_officers_job_title", row["collecting_officers_job_title"].ToString());
                    dict.Add("collecting_officers_is_deleted", row["collecting_officers_is_deleted"].ToString());
                    dict.Add("job_orders_id", row["job_orders_id"].ToString());
                    dict.Add("job_orders_user_id", row["job_orders_user_id"].ToString());
                    dict.Add("job_orders_prefix", row["job_orders_prefix"].ToString());
                    dict.Add("job_orders_first_name", row["job_orders_first_name"].ToString());
                    dict.Add("job_orders_mid_initial", row["job_orders_mid_initial"].ToString());
                    dict.Add("job_orders_last_name", row["job_orders_last_name"].ToString());
                    dict.Add("job_orders_suffix", row["job_orders_suffix"].ToString());
                    dict.Add("job_orders_job_title", row["job_orders_job_title"].ToString());
                    dict.Add("job_orders_is_deleted", row["job_orders_is_deleted"].ToString());
                }

                return dict;
            }
        }

        public DataTable GetViewRecords()
        {
            string query = $"SELECT collecting_officers_id, collecting_officers_prefix, collecting_officers_firstname, collecting_officers_mid_initial, collecting_officers_last_name, collecting_officers_suffix, collecting_officers_job_title, collecting_officers_is_deleted, job_orders_id, job_orders_user_id, job_orders_prefix, job_orders_first_name, job_orders_mid_initial, job_orders_last_name, job_orders_suffix,job_orders_job_title, job_orders_is_deleted FROM {viewTableName} WHERE job_orders_is_deleted = 0";

            DataTable dataTable = new DataTable();
            return mySqlGenericCommands.Fill(query, dataTable);
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
            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool IsJobOrderCollector(int jobOrderId)
        {
            var parameters = new object[][]
            {
                new object[] {"@job_orders_id", DbType.Int32,  jobOrderId},
            };

            string query = $"SELECT COUNT(*) FROM {tableName} WHERE job_orders_id = @job_orders_id";
            return mySqlGenericCommands.ExecuteScalar(query, parameters) == "0";
        }

        public bool Update(CollectingOfficerHasJobOrdersModel entity)
        {
            throw new NotImplementedException();
        }
    }
}