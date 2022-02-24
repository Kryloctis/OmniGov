using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    public class FunctionProgramProjectRepository : IFunctionProgramProjectRepository
    {
        private readonly IDbGenericCommands _dbGenericCommands;
        private readonly string tableName = "function_program_project";
        private readonly string viewTableName = "view_function_program_project";


        public FunctionProgramProjectRepository(IDbGenericCommands dbGenericCommands)
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

                string query = $"SELECT functional_classification_services_id, fpp_code, fpp_name, is_special, created_at, updated_at FROM {tableName} WHERE id = @id";

                using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;

                    record.Add("functional_classification_services_id", reader.Rows[0][0].ToString());
                    record.Add("fpp_code", reader.Rows[0][1].ToString());
                    record.Add("fpp_name", reader.Rows[0][2].ToString());
                    record.Add("is_special", reader.Rows[0][3].ToString());
                    record.Add("created_at", reader.Rows[0][4].ToString());
                    record.Add("updated_at", reader.Rows[0][5].ToString());
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

        public DataTable GetRecordsByCodeName(string searchTxt)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@searchTxt", DbType.String, $"%{searchTxt}%"}
                };

                string query = $"SELECT id, functional_classification_services_id, fpp_code, fpp_name, is_special, created_at, updated_at FROM {tableName} WHERE fpp_code LIKE @searchTxt OR fpp_name LIKE @searchTxt";

                var dtFPP = new DataTable();

                return _dbGenericCommands.FillBySearch(query, dtFPP, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Insert(FunctionProgramProjectModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@functional_classification_services_id", DbType.String, entity.functionalClassificationServiceId},
                    new object[] { "@fpp_code", DbType.String, entity.FppCode},
                    new object[] { "@fpp_name", DbType.String, entity.FppName},
                    new object[] { "@is_special", DbType.Boolean, entity.IsSpecial}
                };

                string query = $"INSERT INTO {tableName} (functional_classification_services_id, fpp_code, fpp_name, is_special) VALUES (@functional_classification_services_id,@fpp_code, @fpp_name, @is_special)";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(FunctionProgramProjectModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Byte, entity.Id},
                    new object[] { "@functional_classification_services_id", DbType.String, entity.functionalClassificationServiceId},
                    new object[] { "@fpp_code", DbType.String, entity.FppCode},
                    new object[] { "@fpp_name", DbType.String, entity.FppName},
                    new object[] { "@is_special", DbType.Boolean, entity.IsSpecial}
                };

                string query = $"UPDATE {tableName} SET functional_classification_services_id = @functional_classification_services_id, fpp_code = @fpp_code, fpp_name = @fpp_name, is_special = @is_special WHERE id = @id";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(List<FunctionProgramProjectModel> entityList)
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

        public bool CodeExist(string code)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@functional_classification_services_id", DbType.String, code },
                };

                string query = $"SELECT functional_classification_services_id FROM {tableName} WHERE functional_classification_services_id = @functional_classification_services_id";
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

        public bool CodeExist(string code, int id)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int16, id },
                    new object[] { "@functional_classification_services_id", DbType.String, code },
                };

                string query = $"SELECT functional_classification_services_id FROM {tableName} WHERE id <> @id AND functional_classification_services_id = @functional_classification_services_id";
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
                    new object[] { "@fpp_name", DbType.String, name },
                };

                string query = $"SELECT fpp_name FROM {tableName} WHERE fpp_name = @fpp_name";
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
                    new object[] { "@fpp_name", DbType.String, name },
                };

                string query = $"SELECT fpp_name FROM {tableName} WHERE id <> @id AND fpp_name = @fpp_name";
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
            string query = $"SELECT * FROM {viewTableName} ORDER BY fpp_name";
            var dataTable = new DataTable();
            return _dbGenericCommands.Fill(query, dataTable);
        }

        public DataTable GetViewRecordsByService_And_Search_And_IsSpecial(int serviceId, string searchText, bool isSpecial)
        {
            var parameters = new object[][]
            {
                new object[] { "@functional_classification_services_id", DbType.Int32, serviceId },
                new object[] { "@searchText", DbType.String, $"%{searchText}%"},
                new object[] { "@is_special", DbType.Boolean, isSpecial}
            };

            string query = $"SELECT * FROM {viewTableName} WHERE functional_classification_services_id = @functional_classification_services_id AND (fpp_code LIKE @searchText OR fpp_name LIKE @searchText) AND is_special = @is_special ORDER BY fpp_name";
            var dataTable = new DataTable();
            return _dbGenericCommands.FillBySearch(query, dataTable, parameters);
        }

        public DataTable GetViewRecordsBySearch_And_IsSpecial(string searchText, bool isSpecial)
        {
            var parameters = new object[][]
            {
                new object[] { "@searchText", DbType.String, $"%{searchText}%"},
                new object[] { "@is_special", DbType.Boolean, isSpecial}
            };

            string query = $"SELECT * FROM {viewTableName} WHERE (fpp_code LIKE @searchText OR fpp_name LIKE @searchText) AND is_special = @is_special ORDER BY fpp_name";
            var dataTable = new DataTable();
            return _dbGenericCommands.FillBySearch(query, dataTable, parameters);
        }
    }
}