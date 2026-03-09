using OmniGov.Core.Entities;
using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Core.Interfaces.Services;
using System.Data;
using System.Transactions;

namespace OmniGov.Core.Repositories
{
    public class FunctionProgramProjectRepository : IFunctionProgramProjectRepository
    {
        private readonly string tableName = "function_program_project";
        private readonly string viewTableName = "view_function_program_project";
        private IGenericCommands _genericCommands;

        public FunctionProgramProjectRepository(IGenericCommands genericCommands)
        {
            _genericCommands = genericCommands;
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var record = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                    new object[] { "@id", DbType.Int32, Id},
            };

            string query = $"SELECT functional_classification_services_id, fpp_code, fpp_name, is_special, created_at, updated_at FROM {tableName} WHERE id = @id";

            using (var reader = _genericCommands.ExecuteReader(query, parameters))
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
            var parameters = new object[][]
            {
                new object[] { "@searchTxt", DbType.String, $"%{searchTxt}%"}
            };

            string query = $"SELECT id, functional_classification_services_id, fpp_code, fpp_name, is_special, created_at, updated_at FROM {tableName} WHERE fpp_code LIKE @searchTxt OR fpp_name LIKE @searchTxt";

            return _genericCommands.FillBySearch(query, new DataTable(), parameters);
        }

        public bool Insert(FunctionProgramProjectModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@functional_classification_services_id", DbType.String, entity.functionalClassificationServiceId},
                new object[] { "@fpp_code", DbType.String, entity.FppCode},
                new object[] { "@fpp_name", DbType.String, entity.FppName},
                new object[] { "@is_special", DbType.Boolean, entity.IsSpecial}
            };

            string query = $"INSERT INTO {tableName} (functional_classification_services_id, fpp_code, fpp_name, is_special) VALUES (@functional_classification_services_id,@fpp_code, @fpp_name, @is_special)";
            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(FunctionProgramProjectModel entity)
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

            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Delete(List<FunctionProgramProjectModel> entityList)
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
                    _ = _genericCommands.ExecuteNonQuery(query, parameters);
                }

                scope.Complete();
                return true;
            }
        }

        public bool IdExist(int id)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Byte, id },
            };

            string query = $"SELECT id FROM {tableName} WHERE id = @id";

            return !string.IsNullOrEmpty(_genericCommands.ExecuteScalar(query, parameters));
        }

        public bool CodeExist(string code)
        {
            var parameters = new object[][]
            {
                new object[] { "@fpp_code", DbType.String, code },
            };

            string query = $"SELECT functional_classification_services_id FROM {tableName} WHERE fpp_code = @fpp_code";

            return !string.IsNullOrEmpty(_genericCommands.ExecuteScalar(query, parameters));
        }

        public bool CodeExist(string code, int id)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int16, id },
                new object[] { "@fpp_code", DbType.String, code },
            };

            string query = $"SELECT functional_classification_services_id FROM {tableName} WHERE id <> @id AND fpp_code = @fpp_code";

            return !string.IsNullOrEmpty(_genericCommands.ExecuteScalar(query, parameters));
        }

        public bool NameExist(string name, int serviceId)
        {
            var parameters = new object[][]
            {
                new object[] { "@functional_classification_services_id", DbType.Int32, serviceId},
                new object[] { "@fpp_name", DbType.String, name },
            };

            string query = $"SELECT fpp_name FROM {tableName} WHERE fpp_name = @fpp_name AND functional_classification_services_id = @functional_classification_services_id";

            return !string.IsNullOrEmpty(_genericCommands.ExecuteScalar(query, parameters));
        }

        public bool NameExist(string name, int serviceId, int id)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int16, id },
                new object[] { "@functional_classification_services_id", DbType.Int32, serviceId},
                new object[] { "@fpp_name", DbType.String, name },
            };

            string query = $"SELECT fpp_name FROM {tableName} WHERE id <> @id AND fpp_name = @fpp_name AND functional_classification_services_id = @functional_classification_services_id";

            return !string.IsNullOrEmpty(_genericCommands.ExecuteScalar(query, parameters));
        }

        public DataTable GetViewRecords()
        {
            string query = $"SELECT * FROM {viewTableName} ORDER BY fpp_name";
            return _genericCommands.Fill(query, new DataTable());
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

            return _genericCommands.FillBySearch(query, new DataTable(), parameters);
        }

        public DataTable GetViewRecordsBySearch_And_IsSpecial(string searchText, bool isSpecial)
        {
            var parameters = new object[][]
            {
                new object[] { "@searchText", DbType.String, $"%{searchText}%"},
                new object[] { "@is_special", DbType.Boolean, isSpecial}
            };

            string query = $"SELECT * FROM {viewTableName} WHERE (fpp_code LIKE @searchText OR fpp_name LIKE @searchText) AND is_special = @is_special ORDER BY fpp_name";

            return _genericCommands.FillBySearch(query, new DataTable(), parameters);
        }
    }
}