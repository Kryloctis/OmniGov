using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACC.Data
{
    public class JobOrderRepository : IJobOrder
    {
        private MySqlGenericCommands mySqlGenericCommands;
        private string tableName = "job_orders";
        private string tableName2 = "collecting_officers_has_job_orders";
        private string viewTableName = "view_collecting_officers_has_job_orders";

        public JobOrderRepository(MySqlGenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public int CountRecords()
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(List<JobOrderModel> entityList)
        {
            throw new System.NotImplementedException();
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetRecords()
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetViewRecordsByCollectingOfficerId(int collectingOfficerId)
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

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new System.NotImplementedException();
        }

        public bool IdExist(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(JobOrderModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@prefix", DbType.String, entity.Prefix},
                new object[] { "@first_name", DbType.String, entity.FirstName},
                new object[] { "@mid_initial", DbType.String, entity.MiddleInitial},
                new object[] { "@last_name", DbType.String, entity.LastName},
                new object[] { "@suffix", DbType.String, entity.Suffix},
                new object[] { "@job_title", DbType.String, entity.JobTitle},
                new object[] { "@users_id", DbType.Int16, entity.UserId <= 0 ? (object)DBNull.Value: entity.UserId}
            };

            string query =  $"INSERT INTO " +
                            $"{tableName} (users_id, prefix, first_name, mid_initial, last_name, suffix, job_title)" +
                            $"VALUES (@users_id, @prefix, @first_name, @mid_initial, @last_name, @suffix, @job_title)";

            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool IsUserJobOrder(int userId)
        {
            var parameter = new object[][] { 
                new object[]{"@users_id", DbType.Int32, userId}
            };

            string query = $"SELECT users_id FROM {tableName} WHERE users_id = @users_id";
            string queryResult = mySqlGenericCommands.ExecuteScalar(query, parameter);

            if (!string.IsNullOrEmpty(queryResult))
                return true;

            return false;
        }

        public bool Update(JobOrderModel entity)
        {
            throw new System.NotImplementedException();
        }

        public bool AssignJOToRegular(int regularCollectorId, int joCollectorId)
        {
            var parameters = new object[][]
            {
                new object[] { "@collecting_officers_id", DbType.Int32, regularCollectorId},
                new object[] { "@job_orders_id", DbType.Int32, joCollectorId}
            };

            string query = $"INSERT INTO " +
                            $"{tableName2} " +
                            $"(collecting_officers_id, job_orders_id) " +
                            $"VALUES (@collecting_officers_id, @job_orders_id)";

            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public int GetJobOrderIdByUserId(int userId)
        {
            var parameter = new object[][]
            {
                new object[] {"@users_id", DbType.Int32, userId},
            };

            string query = $"SELECT id FROM {tableName} WHERE users_id = @users_id";

            return int.Parse(mySqlGenericCommands.ExecuteScalar(query, parameter));
        }

        public DataTable GetViewRecordsByCollectingOfficerIdAndBySearchKey(int collectingOfficerId, string searchKey)
        {
            var parameter = new object[][] {
                new object[]{"@collecting_officers_id", DbType.Int32, collectingOfficerId},
                new object[]{"@search_key", DbType.String, $"%{searchKey}%" }
            };

            string query = $"SELECT " +
               $"job_orders_id, " +
               $"CONCAT(job_orders_first_name, ' ', job_orders_mid_initial, ' ', job_orders_last_name) as fullname, " +
               $"job_orders_job_title " +
               $"FROM {viewTableName} " +
               $"WHERE " +
               $"collecting_officers_id = @collecting_officers_id " +
               $"AND" +
               $"(job_orders_first_name LIKE @search_key OR  job_orders_last_name LIKE  @search_key) ";


            var dt = new DataTable();
            return mySqlGenericCommands.FillBySearch(query, dt, parameter);
        }
    }
}
