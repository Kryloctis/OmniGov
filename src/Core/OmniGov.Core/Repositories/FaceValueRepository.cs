using OmniGov.Core.Entities;
using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Core.Interfaces.Services;
using System.Data;
using System.Transactions;

namespace OmniGov.Core.Repositories
{
    public class FaceValueRepository : IFaceValueRepository
    {
        private readonly string tableName = "face_values";
        private IGenericCommands _genericCommands;

        public FaceValueRepository(IGenericCommands genericCommands)
        {
            _genericCommands = genericCommands;
        }

        public bool Delete(List<FaceValueModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var entity in entityList)
                {
                    var parameters = new object[][]
                    {
                            new object[] { "@id", DbType.Int16, entity.id},
                    };

                    string query = $"DELETE FROM {tableName} WHERE id = @id";
                    _ = _genericCommands.ExecuteNonQuery(query, parameters);
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

            using (var reader = _genericCommands.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return record;

                record.Add("id", reader.Rows[0]["id"].ToString());
                record.Add("accountable_forms_id", reader.Rows[0]["accountable_forms_id"].ToString());
                record.Add("date_effective", reader.Rows[0]["date_effective"].ToString());
                record.Add("amount", reader.Rows[0]["amount"].ToString());
                record.Add("is_default", reader.Rows[0]["is_default"].ToString());
            }

            return record;
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {tableName} ORDER BY id DESC";

            return _genericCommands.Fill(query, new DataTable());
        }

        public DataTable GetRecordsByAccountableFormId(int accountableFormId)
        {
            var parameter = new object[][] {
                new object[] { "@accountable_forms_id", DbType.Int32, accountableFormId}
            };
            string query = $"SELECT * FROM {tableName} WHERE accountable_forms_id= @accountable_forms_id ORDER BY id DESC";

            return _genericCommands.FillBySearch(query, new DataTable(), parameter);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            string query = $"SELECT * FROM {tableName} WHERE date_effective LIKE '%{searchText}%' OR amount LIKE '%{searchText}%' ORDER BY id DESC";

            return _genericCommands.Fill(query, new DataTable());
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(FaceValueModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@accountable_forms_id", DbType.String, entity.accountable_forms_id},
                new object[] { "@date_effective", DbType.DateTime, entity.facedate},
                new object[] { "@amount", DbType.Decimal, entity.facevalue},
                new object[] { "@is_default", DbType.Boolean, entity.isDefault}
            };

            string query = $"INSERT INTO {tableName} (accountable_forms_id, date_effective, amount, is_default) VALUES (@accountable_forms_id, @date_effective, @amount, @is_default)";
            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(FaceValueModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.id},
                new object[] { "@accountable_forms_id", DbType.String, entity.accountable_forms_id},
                new object[] { "@date_effective", DbType.DateTime, entity.facedate},
                new object[] { "@amount", DbType.Decimal, entity.facevalue},
                new object[] { "@is_default", DbType.Boolean, entity.isDefault}
            };

            string query = $"UPDATE {tableName} SET accountable_forms_id = @accountable_forms_id, date_effective = @date_effective, amount = @amount, is_default = @is_default WHERE id = @id";
            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public decimal GetFaceValueByAccountableFormId(int id)
        {
            var parameters = new object[][]
            {
                new object[] {"@accountableFormId", DbType.Int32, id},
            };

            string query = $"SELECT COALESCE(amount, 0) AS amount FROM {tableName} WHERE accountable_forms_id = @accountableFormId";
            var queryResult = _genericCommands.ExecuteScalar(query, parameters);

            if (string.IsNullOrEmpty(queryResult))
                return 0;
            else
                return Convert.ToDecimal(queryResult);
        }
    }
}