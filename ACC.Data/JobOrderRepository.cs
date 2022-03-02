using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace ACC.Data
{
    public class JobOrderRepository : IJobOrder
    {
        private MySqlGenericCommands mySqlGenericCommands;
        private string tableName = "job_orders";
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
                           $"WHERE collecting_officers_id = @collecting_officers_id";

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
            throw new System.NotImplementedException();
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
    }
}
