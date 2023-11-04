using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    public class CollectingOfficerRepository : ICollectingOfficerRepository
    {
        private readonly string tableName = "collecting_officers";
        private readonly string tableName3 = "receipts_issued";
        private AccGenericCommands mySqlGenericCommandsLFS;

        public CollectingOfficerRepository(AccGenericCommands mySqlGenericCommandsLFS)
        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
        }

        public int CountRecords()
        {
            string query = $"SELECT COUNT(id) FROM {tableName}";

            return int.Parse(mySqlGenericCommandsLFS.ExecuteScalar(query));
        }

        public bool Delete(List<CollectingOfficerModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var entity in entityList)
                {
                    var parameters = new object[][]
                    {
                        new object[] { "@id", DbType.Int16, entity.Id},
                    };

                    string query = $"DELETE FROM {tableName} WHERE id = @id";
                    _ = mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
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
                new object[] { "@id", DbType.Int32, Id},
            };

            string query = $"SELECT * FROM {tableName} WHERE id = @id";

            using (var reader = mySqlGenericCommandsLFS.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return record;

                foreach (DataRow item in reader.Rows)
                {
                    record.Add("prefix", item["prefix"].ToString());
                    record.Add("first_name", item["first_name"].ToString());
                    record.Add("mid_initial", item["mid_initial"].ToString());
                    record.Add("last_name", item["last_name"].ToString());
                    record.Add("suffix", item["suffix"].ToString());
                    record.Add("job_title", item["job_title"].ToString());
                    record.Add("created_at", item["created_at"].ToString());
                    record.Add("updated_at", item["updated_at"].ToString());
                    record.Add("users_id", item["users_id"].ToString());
                }
            }

            return record;
        }

        public Dictionary<string, string> GetRecordByUserID(int Id)
        {
            var record = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@users_id", DbType.Int32, Id},
            };

            string query = $"SELECT id, prefix, first_name, mid_initial, last_name, suffix, job_title, created_at, updated_at, users_id FROM {tableName} WHERE users_id = @users_id AND is_deleted = 0";

            using (var reader = mySqlGenericCommandsLFS.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
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
            }

            return record;
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT id, prefix, first_name, mid_initial, last_name, suffix, job_title, is_deleted, created_at, updated_at, users_id FROM {tableName}";

            var dataTable = new DataTable();
            return mySqlGenericCommandsLFS.Fill(query, dataTable);
        }

        public DataTable GetCollectorsWithReceiptsIssuedByReceiptId(int receiptsId)
        {
            var parameters = new object[][] { new object[] { "@receipts_id", DbType.Int32, receiptsId } };

            string query = $"SELECT id, " +
                            $"CONCAT(`first_name`, ' ', `mid_initial`, ' ', `last_name`) as fullname " +
                            $"FROM {tableName} " +
                            $"WHERE id NOT IN(SELECT collecting_officers_id " +
                            $"FROM {tableName3} " +
                            $"WHERE receipts_id = @receipts_id AND is_returned='NO')";

            var collectingOfficerReceiptsDt = new DataTable();
            return mySqlGenericCommandsLFS.FillBySearch(query, collectingOfficerReceiptsDt, parameters);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameters = new object[][]
            {
                new object[] {"@search_text", DbType.String, $"%{searchText}%"}
            };

            string query = $"SELECT id, prefix, first_name, mid_initial, last_name, suffix, job_title, is_deleted, created_at, updated_at, users_id FROM {tableName} WHERE prefix LIKE @search_text OR first_name LIKE @search_text OR last_name LIKE @search_text OR suffix LIKE @search_text OR job_title LIKE @search_text";

            var dtFunds = new DataTable();
            return mySqlGenericCommandsLFS.FillBySearch(query, dtFunds, parameters);
        }

        public bool IdExist(int id)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, id },
            };

            string query = $"SELECT id FROM {tableName} WHERE id = @id";
            string queryResult = mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);

            if (!string.IsNullOrEmpty(queryResult)) return true;

            return false;
        }

        public bool Insert(CollectingOfficerModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@prefix", DbType.String, entity.Prefix},
                new object[] { "@first_name", DbType.String, entity.FirstName},
                new object[] { "@mid_initial", DbType.String, entity.MiddleInitial},
                new object[] { "@last_name", DbType.String, entity.LastName},
                new object[] { "@suffix", DbType.String, entity.Suffix},
                new object[] { "@job_title", DbType.String, entity.JobTitle},
                new object[] { "@users_id", DbType.Object, entity.UserId}
            };

            string query = $"INSERT INTO {tableName} (prefix, first_name, mid_initial, last_name, suffix, job_title, users_id) VALUES (@prefix, @first_name, @mid_initial, @last_name, @suffix, @job_title, @users_id)";
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Update(CollectingOfficerModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int16, entity.Id},
                new object[] { "@prefix", DbType.String, entity.Prefix},
                new object[] { "@first_name", DbType.String, entity.FirstName},
                new object[] { "@mid_initial", DbType.String, entity.MiddleInitial},
                new object[] { "@last_name", DbType.String, entity.LastName},
                new object[] { "@suffix", DbType.String, entity.Suffix},
                new object[] { "@job_title", DbType.String, entity.JobTitle},
                new object[] { "@users_id", DbType.Object, entity.UserId }
            };

            string query = $"UPDATE {tableName} SET prefix = @prefix, first_name = @first_name, mid_initial = @mid_initial, last_name = @last_name, suffix = @suffix, job_title = @job_title, users_id = @users_id WHERE id = @id";
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool FullNameExist(string firstName, string middleInitial, string lastName, int id)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int16, id },
                new object[] { "@first_name", DbType.String, firstName },
                new object[] { "@middle_initial", DbType.String, middleInitial },
                new object[] { "@last_name", DbType.String, lastName },
            };

            string query = $"SELECT * FROM {tableName} " +
                           $"WHERE id <> @id AND first_name = @first_name AND mid_initial = @middle_initial AND last_name = @last_name";

            string queryResult = mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);

            if (!string.IsNullOrEmpty(queryResult))
                return true;

            return false;
        }

        public int CollectingOfficerJOCount(int collectingOfficerId)
        {
            var parameter = new object[][]
            {
                new object[] { "@collecting_officers_id", DbType.Int32, collectingOfficerId },
            };

            string query = $"SELECT COUNT(collecting_officers_id) FROM collecting_officers_has_job_orders WHERE collecting_officers_id =    @collecting_officers_id";

            return int.Parse(mySqlGenericCommandsLFS.ExecuteScalar(query, parameter));
        }
    }
}