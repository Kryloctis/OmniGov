using OmniGov.Core.Entities;
using OmniGov.Core.Interfaces;
using System.Data;
using System.Transactions;

namespace OmniGov.Core.Repositories
{
    public class FunctionalClassificationRepository : IFunctionalClassificationRepository
    {
        private readonly GenericCommands _dbGenericCommands;
        private readonly string tableName = "functional_classifications";

        public FunctionalClassificationRepository(GenericCommands dbGenericCommands)
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

                string query = $"SELECT sector_code, sector_name, created_at, updated_at FROM {tableName} WHERE id = @id";

                using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;

                    record.Add("sector_code", reader.Rows[0][0].ToString());
                    record.Add("sector_name", reader.Rows[0][1].ToString());
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
                string query = $"SELECT * FROM {tableName}";

                var dtFunctionalClassification = new DataTable();
                return _dbGenericCommands.Fill(query, dtFunctionalClassification);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameters = new object[][]
            {
                new object[] { "@searchText", DbType.String, $"%{searchText}%"}
            };

            string query = $"SELECT * FROM {tableName} WHERE sector_name  LIKE @searchText OR sector_code LIKE @searchText ORDER BY sector_name";

            var dtFunctionProjectProgram = new DataTable();
            return _dbGenericCommands.FillBySearch(query, dtFunctionProjectProgram, parameters);
        }

        public bool Insert(FunctionalClassificationModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@sector_code", DbType.String, entity.SectorCode},
                    new object[] { "@sector_name", DbType.String, entity.SectorName},
                };

                string query = $"INSERT INTO {tableName} (sector_code, sector_name) VALUES (@sector_code, @sector_name)";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(FunctionalClassificationModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Byte, entity.Id},
                    new object[] { "@sector_code", DbType.String, entity.SectorCode},
                    new object[] { "@sector_name", DbType.String, entity.SectorName},
                };

                string query = $"UPDATE {tableName} SET sector_code = @sector_code, sector_name = @sector_name WHERE id = @id";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(List<FunctionalClassificationModel> entityList)
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
                    new object[] { "@id", DbType.Byte, id },
                };

                string query = $"SELECT id FROM {tableName} WHERE id = @id";
                string queryResult = _dbGenericCommands.ExecuteScalar(query, parameters);

                // if query is not null, means found some record, so true
                if (!string.IsNullOrEmpty(queryResult)) return true;
            }
            catch (Exception)
            {
                throw;
            }
            ;

            return false;
        }

        public bool CodeExist(string code)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@sector_code", DbType.String, code },
                };

                string query = $"SELECT sector_code FROM {tableName} WHERE sector_code = @sector_code";
                string queryResult = _dbGenericCommands.ExecuteScalar(query, parameters);

                // if query is not null, means found some record, so true
                if (!string.IsNullOrEmpty(queryResult)) return true;
            }
            catch (Exception)
            {
                throw;
            }
            ;

            return false;
        }

        public bool CodeExist(string code, int id)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.String, id },
                    new object[] { "@sector_code", DbType.String, code },
                };

                string query = $"SELECT sector_code FROM {tableName} WHERE id <> @id AND sector_code = @sector_code";
                string queryResult = _dbGenericCommands.ExecuteScalar(query, parameters);

                // if query is not null, means found some record, so true
                if (!string.IsNullOrEmpty(queryResult)) return true;
            }
            catch (Exception)
            {
                throw;
            }
            ;

            return false;
        }

        public bool NameExist(string name)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@sector_name", DbType.String, name },
                };

                string query = $"SELECT sector_name FROM {tableName} WHERE sector_name = @sector_name";
                string queryResult = _dbGenericCommands.ExecuteScalar(query, parameters);

                // if query is not null, means found some record, so true
                if (!string.IsNullOrEmpty(queryResult)) return true;
            }
            catch (Exception)
            {
                throw;
            }
            ;

            return false;
        }

        public bool NameExist(string name, int id)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.String, id },
                    new object[] { "@sector_name", DbType.String, name },
                };

                string query = $"SELECT sector_name FROM {tableName} WHERE id <> @id AND sector_name = @sector_name";
                string queryResult = _dbGenericCommands.ExecuteScalar(query, parameters);

                // if query is not null, means found some record, so true
                if (!string.IsNullOrEmpty(queryResult)) return true;
            }
            catch (Exception)
            {
                throw;
            }
            ;

            return false;
        }
    }
}