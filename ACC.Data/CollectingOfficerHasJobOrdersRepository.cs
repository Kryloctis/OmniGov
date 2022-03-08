using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{

    public class CollectingOfficerHasJobOrdersRepository : ICollectingOfficerHasJobOrders
    {
        private readonly MySqlGenericCommands mySqlGenericCommands;
        private readonly string tableName = "collecting_officers_has_job_orders";
        private readonly string viewTableName = "view_collecting_officers_has_job_orders";
        public CollectingOfficerHasJobOrdersRepository(MySqlGenericCommands mySqlGenericCommands)
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

        public int GetCollectingOfficerIDByJobOrderId(int collectingOfficerId)
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
            string query = $"SELECT " +
                           $"job_orders_id AS Id, " +
                           $"CONCAT(job_orders_first_name, ' ', job_orders_mid_initial, ' ', job_orders_last_name) as fullname " +
                           $"FROM {viewTableName} " +
                           $"WHERE job_orders_is_deleted = 0";

            var dt = new DataTable();
            return mySqlGenericCommands.Fill(query, dt);
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

            string query =  $"INSERT INTO " +
                            $"{tableName} " +
                            $"VALUES (@collecting_officers_id, @job_orders_id)";

            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(CollectingOfficerHasJobOrdersModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
