using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    public class JobOrderRepository : IJobOrder
    {
        private AccGenericCommands mySqlGenericCommands;
        private string tableName = "job_orders";

        public JobOrderRepository(AccGenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public int CountRecords()
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(List<JobOrderModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var entity in entityList)
                {
                    var parameters = new object[][]
                    {
                        new object[] { "@id", DbType.Int32, entity.Id},
                    };

                    string query = $"UPDATE {tableName} SET is_deleted = 1 WHERE id = @id";
                    _ = mySqlGenericCommands.ExecuteNonQuery(query, parameters);
                }

                scope.Complete();
                return true;
            }
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var record = new Dictionary<string, string>();


            var parameters = new object[][]
            {
                new object[] { "@users_id", DbType.Int32, Id},
            };

            string query = $"SELECT id, prefix, first_name, mid_initial, last_name, suffix, job_title, created_at, updated_at, users_id FROM {tableName} WHERE id = @id";

            using (var reader = mySqlGenericCommands.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count == 0)
                    return record;

                foreach (DataRow row in reader.Rows)
                {
                    record.Add("id", row["id"].ToString());
                    record.Add("prefix", row["prefix"].ToString());
                    record.Add("first_name", row["first_name"].ToString());
                    record.Add("mid_initial", row["mid_initial"].ToString());
                    record.Add("last_name", row["last_name"].ToString());
                    record.Add("suffix", row["suffix"].ToString());
                    record.Add("job_title", row["job_title"].ToString());
                    record.Add("created_at", row["created_at"].ToString());
                    record.Add("updated_at", row["updated_at"].ToString());
                    record.Add("users_id", row["users_id"].ToString());
                }

                return record;
            }            
        }

        public DataTable GetRecords()
        {
            throw new System.NotImplementedException();
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

        public int GetJobOrderIdByUserId(int userId)
        {
            var parameter = new object[][]
            {
                new object[] {"@users_id", DbType.Int32, userId},
            };

            string query = $"SELECT id FROM {tableName} WHERE users_id = @users_id AND is_deleted = 0 LIMIT 1";

            return int.Parse(mySqlGenericCommands.ExecuteScalar(query, parameter));
        }

        public Dictionary<string, string> GetRecordByUserID(int Id)
        {
            var record = new Dictionary<string, string>();


            var parameters = new object[][]
            {
                new object[] { "@users_id", DbType.Int32, Id},
            };

            string query = $"SELECT id, first_name, mid_initial, last_name, job_title, created_at, updated_at, users_id FROM {tableName} WHERE users_id = @users_id AND is_deleted = 0";

            using (var reader = mySqlGenericCommands.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count == 0)
                    return record;

                record.Add("id", reader.Rows[0][0].ToString());
                record.Add("first_name", reader.Rows[0][1].ToString());
                record.Add("mid_initial", reader.Rows[0][2].ToString());
                record.Add("last_name", reader.Rows[0][3].ToString());
                record.Add("job_title", reader.Rows[0][4].ToString());
                record.Add("created_at", reader.Rows[0][5].ToString());
                record.Add("updated_at", reader.Rows[0][6].ToString());
                record.Add("users_id", reader.Rows[0][7].ToString());
            }


            return record;
        }
    }
}
