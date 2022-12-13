using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    public class DisbursingOfficerRepository : IDisbursingOfficerRepository
    {
        private readonly IAccGenericCommands _dbGenericCommands;
        private readonly string tableName = "disbursing_officers";

        public DisbursingOfficerRepository(IAccGenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<DisbursingOfficerModel> entityList)
        {
            try
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
                        _ = _dbGenericCommands.ExecuteNonQuery(query, parameters);
                    }

                    scope.Complete();
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool FullNameExist(string firstName, string middleInitial, string lastName, int id)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var record = new Dictionary<string, string>();

            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, Id},
                };

                string query = $"SELECT prefix, first_name, mid_initial, last_name, suffix, job_title, created_at, updated_at,users_id FROM {tableName} WHERE id = @id";

                using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
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
            }
            catch (Exception)
            {
                throw;
            }

            return record;
        }

        public Dictionary<string, string> GetRecordByUserID(int Id)
        {
            var record = new Dictionary<string, string>();

            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@users_id", DbType.Int32, Id},
                };

                string query = $"SELECT id,first_name, mid_initial, last_name, job_title, created_at, updated_at,users_id FROM {tableName} WHERE users_id = @users_id";

                using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
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
            }
            catch (Exception)
            {
                throw;
            }

            return record;
        }

        public DataTable GetRecords()
        {
            try
            {
                string query = $"SELECT id, CONCAT(`first_name`, ' ', `mid_initial`, ' ', `last_name`) as fullname, job_title,  created_at, updated_at, users_id FROM {tableName}";

                return _dbGenericCommands.Fill(query, new DataTable());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new NotImplementedException();
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(DisbursingOfficerModel entity)
        {
            try
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
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(DisbursingOfficerModel entity)
        {
            try
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
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}