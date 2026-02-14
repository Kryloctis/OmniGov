using OmniGov.Core.Repositories;
using System.Data;
using System.Transactions;
using Treasury.Domain.Entities;
using Treasury.Domain.Interfaces;

namespace Treasury.Data.Repositories
{
    public class DisbursingOfficerRepository : IDisbursingOfficerRepository
    {
        private readonly string tableName = "disbursing_officers";
        private GenericCommands mySqlGenericCommandsLFS;

        public DisbursingOfficerRepository(GenericCommands mySqlGenericCommandsLFS)
        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<DisbursingOfficerModel> entityList)
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

            string query = $"SELECT prefix, first_name, mid_initial, last_name, suffix, job_title, created_at, updated_at,users_id FROM {tableName} WHERE id = @id";

            using (var reader = mySqlGenericCommandsLFS.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return record;

                record.Add("prefix", reader.Rows[0]["prefix"].ToString());
                record.Add("first_name", reader.Rows[0]["first_name"].ToString());
                record.Add("mid_initial", reader.Rows[0]["mid_initial"].ToString());
                record.Add("last_name", reader.Rows[0]["last_name"].ToString());
                record.Add("suffix", reader.Rows[0]["suffix"].ToString());
                record.Add("job_title", reader.Rows[0]["job_title"].ToString());
                record.Add("created_at", reader.Rows[0]["created_at"].ToString());
                record.Add("updated_at", reader.Rows[0]["updated_at"].ToString());
                record.Add("users_id", reader.Rows[0]["users_id"].ToString());
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

            string query = $"SELECT id,first_name, mid_initial, last_name, job_title, created_at, updated_at,users_id FROM {tableName} WHERE users_id = @users_id";

            using (var reader = mySqlGenericCommandsLFS.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return record;
                record.Add("id", reader.Rows[0]["id"].ToString());
                record.Add("first_name", reader.Rows[0]["first_name"].ToString());
                record.Add("mid_initial", reader.Rows[0]["mid_initial"].ToString());
                record.Add("last_name", reader.Rows[0]["last_name"].ToString());
                record.Add("job_title", reader.Rows[0]["job_title"].ToString());
                record.Add("created_at", reader.Rows[0]["created_at"].ToString());
                record.Add("updated_at", reader.Rows[0]["updated_at"].ToString());
                record.Add("users_id", reader.Rows[0]["users_id"].ToString());
            }

            return record;
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT id, prefix, first_name, mid_initial, last_name, suffix, job_title, created_at, updated_at, users_id FROM {tableName}";

            var dataTable = new DataTable();
            return mySqlGenericCommandsLFS.Fill(query, dataTable);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameters = new object[][]
            {
                new object[] { "@search_text", DbType.String, $"%{searchText}%"}
            };

            string query = $"SELECT id, prefix, first_name, mid_initial, last_name, suffix, job_title, created_at, updated_at, users_id FROM {tableName} WHERE prefix LIKE @search_text OR first_name LIKE @search_text OR last_name LIKE @search_text OR suffix LIKE @search_text OR job_title LIKE @search_text";

            var dataTable = new DataTable();
            return mySqlGenericCommandsLFS.FillBySearch(query, dataTable, parameters);
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(DisbursingOfficerModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@prefix", DbType.String, entity.Prefix},
                new object[] { "@first_name", DbType.String, entity.FirstName},
                new object[] { "@mid_initial", DbType.String, entity.MiddleInitial},
                new object[] { "@last_name", DbType.String, entity.LastName},
                new object[] { "@suffix", DbType.String, entity.Suffix},
                new object[] { "@job_title", DbType.String, entity.JobTitle},
                new object[] { "@users_id", DbType.Int16, entity.UserId <= 0 ? (object)DBNull.Value : entity.UserId }
            };

            string query = $"INSERT INTO {tableName} (prefix, first_name, mid_initial, last_name, suffix, job_title, users_id) VALUES (@prefix, @first_name, @mid_initial, @last_name, @suffix, @job_title,@users_id)";
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Update(DisbursingOfficerModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.Id},
                new object[] { "@prefix", DbType.String, entity.Prefix},
                new object[] { "@first_name", DbType.String, entity.FirstName},
                new object[] { "@mid_initial", DbType.String, entity.MiddleInitial},
                new object[] { "@last_name", DbType.String, entity.LastName},
                new object[] { "@suffix", DbType.String, entity.Suffix},
                new object[] { "@job_title", DbType.String, entity.JobTitle},
                new object[] { "@users_id", DbType.Int16, entity.UserId <= 0 ? (object)DBNull.Value : entity.UserId }
            };

            string query = $"UPDATE {tableName} SET prefix = @prefix, first_name = @first_name, mid_initial = @mid_initial, last_name = @last_name, suffix = @suffix, job_title = @job_title, users_id = @users_id WHERE id = @id";
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }
    }
}