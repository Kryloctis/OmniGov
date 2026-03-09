using OmniGov.Core.Entities;
using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Core.Interfaces.Services;
using System.Data;
using System.Transactions;

namespace OmniGov.Core.Repositories
{
    public class MunicipalitiesRepository : IMunicipalities
    {
        private IGenericCommands _genericCommands;
        private readonly string tableName = "municipalities";
        private readonly string viewTableName = "view_municipalities";

        public MunicipalitiesRepository(IGenericCommands genericCommands)
        {
            _genericCommands = genericCommands;
        }

        public bool Delete(List<MunicipalitiesModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var municipalitiesModel in entityList)
                {
                    var parameters = new object[][] { new object[] { "@id", DbType.Int32, municipalitiesModel.Id } };
                    string query = $"DELET FROM {tableName} WHERE id = @id";
                    _ = _genericCommands.ExecuteNonQuery(query, parameters);
                }

                scope.Complete();
                return true;
            }
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var dictionary = new Dictionary<string, string>();
            var parameters = new object[][] { new object[] { "@id", DbType.String, Id } };
            string query = $"SELECT provinces_id, code, name FROM {tableName} WHERE id = @id";
            using (var reader = _genericCommands.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return dictionary;
                foreach (DataRow row in reader.Rows)
                {
                    dictionary.Add("provinces_id", row["province_id"].ToString());
                    dictionary.Add("code", row["code"].ToString());
                    dictionary.Add("name", row["name"].ToString());
                }
                return dictionary;
            }
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {tableName}";

            return _genericCommands.Fill(query, new DataTable());
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameters = new object[][] { new object[] { "@search_text", DbType.String, $"%{searchText}%" } };
            string query = $"SELECT * FROM {tableName} WHERE code LIKE @search_text OR name LIKE @search_text";

            return _genericCommands.FillBySearch(query, new DataTable(), parameters);
        }

        public bool IdExist(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(MunicipalitiesModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@provinces_id", DbType.Int32, entity.ProvincesId},
                new object[] { "@code", DbType.String, entity.Code},
                new object[] { "@name", DbType.String, entity.Name}
            };

            string query = $"INSERT INTO {tableName} (provinces_id, code, name) VALUES (@provinces_id, @code, @name)";
            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(MunicipalitiesModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.Id},
                new object[] { "@provinces_id", DbType.Int32, entity.ProvincesId},
                new object[] { "@code", DbType.String, entity.Code},
                new object[] { "@name", DbType.String, entity.Name}
            };

            string query = $"UPDATE {tableName} SET provinces_id = @provinces_id, code = @code, name = @name WHERE id = @id";

            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool NameExistByProvinceName(string name, string provinceName)
        {
            var parameters = new object[][]
            {
                new object[] { "@municipalities_name", DbType.String, name },
                new object[] { "@provinces_name", DbType.String, provinceName}
            };

            string query = $"SELECT municipalities_name FROM {viewTableName} WHERE municipalities_name = @municipalities_name AND provinces_name = @provinces_name";

            return !string.IsNullOrEmpty(_genericCommands.ExecuteScalar(query, parameters));
        }

        public bool NameExistByProvinceName(int id, string name, string provinceName)
        {
            var parameters = new object[][]
            {
                new object[] { "@municipalities_id", DbType.Int32, id},
                new object[] { "@municipalities_name", DbType.String, name },
                new object[] { "@provinces_name", DbType.String, provinceName}
            };

            string query = $"SELECT municipalities_name FROM {viewTableName} WHERE municipalities_name = @municipalities_name AND provinces_name = @provinces_name AND municipalities_id <> @municipalities_id";

            return !string.IsNullOrEmpty(_genericCommands.ExecuteScalar(query, parameters));
        }

        public int GetLastInsertedId()
        {
            string query = $"Select COALESCE(MAX(id), 0) AS id FROM {tableName}";
            return Convert.ToInt32(_genericCommands.ExecuteScalar(query));
        }

        public int GetIdByNameProvinceName(string name, string provinceName)
        {
            var parameters = new object[][]
            {
                new object[] { "@municipalities_name", DbType.String, name },
                new object[] { "@provinces_name", DbType.String, provinceName}
            };
            string query = $"SELECT municipalities_id FROM {viewTableName} WHERE municipalities_name = @municipalities_name AND provinces_name = @provinces_name";
            return Convert.ToInt32(_genericCommands.ExecuteScalar(query, parameters));
        }
    }
}