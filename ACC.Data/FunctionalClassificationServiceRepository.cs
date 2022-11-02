using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;


namespace ACC.Data
{
    public class FunctionalClassificationServiceRepository : IFunctionalClassificationServiceRepository
    {
        private readonly IAccGenericCommands _dbGenericCommands;
        private readonly string tableName = "functional_classification_services";
        private readonly string viewTableName = "view_function_classification_services";

        public FunctionalClassificationServiceRepository(IAccGenericCommands dbGenericCommands)
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

                string query = $"SELECT functional_classifications_id, service_name, created_at, updated_at FROM {tableName} WHERE id = @id";

                using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;

                    record.Add("functional_classifications_id", reader.Rows[0][0].ToString());
                    record.Add("service_name", reader.Rows[0][1].ToString());
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
            throw new NotImplementedException();
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new NotImplementedException();
        }

        public bool Insert(FunctionalClassificationServiceModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@functional_classifications_id", DbType.String, entity.functionalClassificationId},
                    new object[] { "@service_name", DbType.String, entity.ServiceName},
                };

                string query = $"INSERT INTO {tableName} (functional_classifications_id, service_name) VALUES (@functional_classifications_id, @service_name)";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(FunctionalClassificationServiceModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Byte, entity.Id},
                    new object[] { "@functional_classifications_id", DbType.String, entity.functionalClassificationId},
                    new object[] { "@service_name", DbType.String, entity.ServiceName},
                };

                string query = $"UPDATE {tableName} SET functional_classifications_id = @functional_classifications_id, service_name = @service_name WHERE id = @id";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(List<FunctionalClassificationServiceModel> entityList)
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
            };

            return false;
        }

        public bool NameExist(string name)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@service_name", DbType.String, name },
                };

                string query = $"SELECT service_name FROM {tableName} WHERE service_name = @service_name";
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

        public bool NameExist(string name, int id)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int16, id },
                    new object[] { "@service_name", DbType.String, name },
                };

                string query = $"SELECT service_name FROM {tableName} WHERE id <> @id AND service_name = @service_name";
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

        public DataTable GetViewRecords()
        {
            string query = $"SELECT * FROM {viewTableName} ORDER BY service_name";
            var dataTable = new DataTable();
            return _dbGenericCommands.Fill(query, dataTable);
        }

        public DataTable GetViewRecordsBySearch_And_Sector(string searchText, int sectorId)
        {
            var parameters = new object[][]
            {
                new object[] { "@searchText", DbType.String, $"%{searchText}%"},
                new object[] { "@functional_classifications_id", DbType.Int32, sectorId }
            };

            string query = $"SELECT * FROM {viewTableName} WHERE (service_name LIKE @searchText OR functional_classifications_sector_code LIKE @searchText OR functional_classifications_sector_name LIKE @searchText) AND functional_classifications_id = @functional_classifications_id ORDER BY service_name";
            var dataTable = new DataTable();
            return _dbGenericCommands.FillBySearch(query, dataTable, parameters);
        }

        public DataTable GetViewRecordsBySearch(string searchText)
        {
            var parameters = new object[][]
           {
                new object[] { "@searchText", DbType.String, $"%{searchText}%"},
           };

            string query = $"SELECT * FROM {viewTableName} WHERE (service_name LIKE @searchText OR functional_classifications_sector_code LIKE @searchText OR functional_classifications_sector_name LIKE @searchText) ORDER BY service_name";
            var dataTable = new DataTable();
            return _dbGenericCommands.FillBySearch(query, dataTable, parameters);
        }
    }
}
