using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Transactions;
using ACC.Domain.Interfaces;
using ACC.Domain.Models;

namespace ACC.Data
{
    public class CollectingOfficerRepository : ICollectingOfficerRepository
    {
        private readonly IDbGenericCommands _dbGenericCommands;
        private readonly string tableName = "collecting_officers";
        private readonly string tableName3 = "receipts_issued";

        public CollectingOfficerRepository(IDbGenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
        }

        public int CountRecords()
        {
            try
            {
                string query = $"SELECT COUNT(*) FROM {tableName}";

                return int.Parse(_dbGenericCommands.ExecuteScalar(query));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(List<CollectingOfficerModel> entityList)
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

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var record = new Dictionary<string, string>();

            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, Id},
                };

                string query = $"SELECT first_name, mid_initial, last_name, job_title, created_at, updated_at,users_id FROM {tableName} WHERE id = @id";

                using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;

                    record.Add("first_name", reader.Rows[0][0].ToString());
                    record.Add("mid_initial", reader.Rows[0][1].ToString());
                    record.Add("last_name", reader.Rows[0][2].ToString());
                    record.Add("job_title", reader.Rows[0][3].ToString());
                    record.Add("created_at", reader.Rows[0][4].ToString());
                    record.Add("updated_at", reader.Rows[0][5].ToString());
                    record.Add("users_id", reader.Rows[0][6].ToString());
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

                string query = $"SELECT id, first_name, mid_initial, last_name, job_title, created_at, updated_at,users_id FROM {tableName} WHERE users_id = @users_id";

                using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
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
                string query = $"SELECT id, CONCAT(first_name, ' ', mid_initial, ' ', last_name) as fullname, job_title, created_at, updated_at FROM {tableName}";

                var dtFunds = new DataTable();
                return _dbGenericCommands.Fill(query, dtFunds);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetRecords(int rid)
        {
            try
            {
                string query = $"SELECT id, CONCAT(`first_name`, ' ', `mid_initial`, ' ', `last_name`) as fullname FROM {tableName} WHERE id NOT IN(SELECT collecting_officers_id FROM {tableName3} WHERE receipts_id='{rid}' AND is_returned='NO')";

                var dtFunds = new DataTable();
                return _dbGenericCommands.Fill(query, dtFunds);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            try
            {
                string query = $"SELECT id, CONCAT(`first_name`, ' ', `mid_initial`, ' ', `last_name`) as fullname,job_title, created_at, updated_at FROM {tableName} WHERE CONCAT(`first_name`, ' ', `mid_initial`, ' ', `last_name`) LIKE '%{searchText}%' OR job_title LIKE '%{searchText}%'";

                var dtFunds = new DataTable();
                return _dbGenericCommands.Fill(query, dtFunds);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IdExist(int id)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, id },
                };

                string query = $"SELECT id FROM {tableName} WHERE id = @id";
                string queryResult = _dbGenericCommands.ExecuteScalar(query, parameters);

                // if query is not null, means found some record, so true
                if (!string.IsNullOrEmpty(queryResult)) return true;
            }
            catch (Exception)
            {
                throw;
            };

            return false;
        }

        public bool ReceiptsAssigned(int id)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, id },
                };

                string query = $"SELECT id FROM {tableName3} WHERE collecting_officers_id = @id";
                string queryResult = _dbGenericCommands.ExecuteScalar(query, parameters);

                // if query is not null, means found some record, so true
                if (!string.IsNullOrEmpty(queryResult)) return true;
            }
            catch (Exception)
            {
                throw;
            };

            return false;
        }

        public bool Insert(CollectingOfficerModel entity)
        {
            try
            {
               
                var parameters = new object[][]
                {
                    new object[] { "@first_name", DbType.String, entity.FirstName},
                    new object[] { "@mid_initial", DbType.String, entity.MiddleInitial},
                    new object[] { "@last_name", DbType.String, entity.LastName},
                    new object[] { "@job_title", DbType.String, entity.JobTitle},
                    new object[] { "@users_id", DbType.Int16, entity.UserId <= 0 ? (object)DBNull.Value: entity.UserId}
                };

                string query = $"INSERT INTO {tableName} (first_name,mid_initial,last_name,job_title,users_id) VALUES (@first_name,@mid_initial,@last_name,@job_title,@users_id)";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(CollectingOfficerModel entity)
        {
          
            try
            {
                var parameters = new object[][]
                {
                     new object[] { "@id", DbType.Int16, entity.Id},
                    new object[] { "@first_name", DbType.String, entity.FirstName},
                    new object[] { "@mid_initial", DbType.String, entity.MiddleInitial},
                    new object[] { "@last_name", DbType.String, entity.LastName},
                    new object[] { "@job_title", DbType.String, entity.JobTitle},
                    new object[] { "@users_id", DbType.Int16, entity.UserId <= 0 ? (object)DBNull.Value : entity.UserId }
                };

                string query = $"UPDATE {tableName} SET first_name = @first_name, mid_initial = @mid_initial, last_name = @last_name, job_title = @job_title,users_id=@users_id WHERE id = @id";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool FullnameExist(string code)
        {
            throw new NotImplementedException();
        }

        public bool FullNameExist(string firstname, string middleinitial, string lastname, int id)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int16, id },
                    new object[] { "@first_name", DbType.String, firstname },
                    new object[] { "@mid_initial", DbType.String, middleinitial },
                    new object[] { "@last_name", DbType.String, lastname },
                };

                string query = $"SELECT * FROM {tableName} WHERE id <> @id AND first_name = @first_name AND mid_initial = @mid_initial AND last_name = @last_name";
                string queryResult = _dbGenericCommands.ExecuteScalar(query, parameters);

                // if query is not null, means found some record, so true
                if (!string.IsNullOrEmpty(queryResult)) return true;
            }
            catch (Exception)
            {
                throw;
            };

            return false;
        }
    }
}
