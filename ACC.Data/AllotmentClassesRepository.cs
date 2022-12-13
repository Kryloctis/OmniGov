using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    public class AllotmentClassesRepository : IAllotmentClassesRepository
    {
        private readonly IAccGenericCommands _dbGenericCommands;

        private readonly string tableName = "allotment_classes";

        public AllotmentClassesRepository(IAccGenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
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

                string query = $"SELECT allotment_code, allotment_name, created_at, updated_at FROM {tableName} WHERE id = @id";

                using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;

                    record.Add("allotment_code", reader.Rows[0][0].ToString());
                    record.Add("allotment_name", reader.Rows[0][1].ToString());
                    record.Add("created_at", reader.Rows[0][2].ToString());
                    record.Add("updated_at", reader.Rows[0][3].ToString());
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
                string query = $"SELECT id, allotment_code, allotment_name, created_at, updated_at FROM {tableName}";

                var dtAllotmentClasses = new DataTable();
                return _dbGenericCommands.Fill(query, dtAllotmentClasses);
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

        public bool Insert(AllotmentClassesModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@allotment_name", DbType.String, entity.AllotmentName},
                    new object[] { "@allotment_code", DbType.String, entity.AllotmentCode},
                };

                string query = $"INSERT INTO {tableName} (allotment_code, allotment_name) VALUES (@allotment_code, @allotment_name)";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(AllotmentClassesModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int16, entity.Id},
                    new object[] { "@allotment_name", DbType.String, entity.AllotmentName},
                    new object[] { "@allotment_code", DbType.String, entity.AllotmentCode},
                };

                string query = $"UPDATE {tableName} SET allotment_name = @allotment_name, allotment_code = @allotment_code WHERE id = @id";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(List<AllotmentClassesModel> entityList)
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

        public bool CodeExist(string allotmentCode)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@allotment_code", DbType.String, allotmentCode },
                };

                string query = $"SELECT allotment_code FROM {tableName} WHERE allotment_code = @allotment_code";
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

        public bool CodeExist(string allotmentCode, int allotmentId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int16, allotmentId },
                    new object[] { "@allotment_code", DbType.String, allotmentCode },
                };

                string query = $"SELECT allotment_code FROM {tableName} WHERE id <> @id AND allotment_code = @allotment_code";
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

        public bool NameExist(string allotmentName)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@allotment_name", DbType.String, allotmentName },
                };

                string query = $"SELECT allotment_name FROM {tableName} WHERE allotment_name = @allotment_name";
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

        public bool NameExist(string allotmentName, int allotmentId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int16, allotmentId },
                    new object[] { "@allotment_name", DbType.String, allotmentName },
                };

                string query = $"SELECT allotment_name FROM {tableName} WHERE id <> @id AND allotment_name = @allotment_name";
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