using OmniGov.Core.Repositories;
using System.Data;
using Treasury.Domain.Entities;
using Treasury.Domain.Interfaces;

namespace Treasury.Data.Repositories
{
    public class TaxTypesRepository : ITaxTypesRepository
    {
        private readonly string tableName = "tax_type";
        private GenericCommands mySqlGenericCommandsLFS;

        public TaxTypesRepository(GenericCommands mySqlGenericCommandsLFS)
        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
        }

        public int CountRecords()
        {
            string query = $"SELECT COUNT(id) FROM {tableName} ";
            return Convert.ToInt32(mySqlGenericCommandsLFS.ExecuteNonQuery(query));
        }

        public bool Delete(List<TaxTypesModel> entityList)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTaxType(int taxTypeID)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, taxTypeID},
            };

            string query = $"UPDATE {tableName} SET is_deleted = 1 WHERE id = @id OR parent = @id";
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var record = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, Id},
            };

            string query = $"SELECT * FROM {tableName} WHERE id = @id";

            using (var reader = mySqlGenericCommandsLFS.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return record;

                record.Add("id", reader.Rows[0]["id"].ToString());
                record.Add("code", reader.Rows[0]["code"].ToString());
                record.Add("description", reader.Rows[0]["description"].ToString());
                record.Add("parent", reader.Rows[0]["parent"].ToString());
                record.Add("funds_id", reader.Rows[0]["funds_id"].ToString());
                record.Add("coa_account_code", reader.Rows[0]["coa_account_code"].ToString());
                record.Add("blgf_account_code", reader.Rows[0]["blgf_account_code"].ToString());
                record.Add("is_deleted", reader.Rows[0]["is_deleted"].ToString());
                record.Add("created_at", reader.Rows[0]["created_at"].ToString());
                record.Add("updated_at", reader.Rows[0]["updated_at"].ToString());
            }

            return record;
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {tableName}";

            var dataTable = new DataTable();
            return mySqlGenericCommandsLFS.Fill(query, dataTable);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameters = new object[][]
            {
                new object[] {"@search_text", DbType.String, $"%{searchText}%"}
            };

            string query = $"SELECT * FROM {tableName} WHERE description LIKE @search_text";

            var dtFunds = new DataTable();
            return mySqlGenericCommandsLFS.FillBySearch(query, dtFunds, parameters);
        }

        public DataTable GetTaxTypeCodes()
        {
            string query = $"SELECT id, code, description, parent FROM {tableName}  ORDER BY parent, id DESC";

            var dt = new DataTable();
            return mySqlGenericCommandsLFS.Fill(query, dt);
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(TaxTypesModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@code", DbType.String, entity.Code },
                new object[] { "@description", DbType.String, entity.Description },
                new object[] { "@parent", DbType.Int32, entity.ParentID },
                new object[] { "@funds_id", DbType.Int32, entity.FundID },
                new object[] { "@coa_account_code", DbType.String, entity.COAAccountCode },
                new object[] { "@blgf_account_code", DbType.String, entity.BLGFAccountCode },
            };

            string query = $"INSERT INTO {tableName} (code, description, parent, funds_id, coa_account_code, blgf_account_code) VALUES (@code, @description, @parent, @funds_id, @coa_account_code, @blgf_account_code)";

            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool UnDeleteTaxType(int taxTypeID)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, taxTypeID},
            };

            string query = $"UPDATE {tableName} SET is_deleted = 0 WHERE id = @id OR parent = @id";
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Update(TaxTypesModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.Id},
                new object[] { "@code", DbType.String, entity.Code },
                new object[] { "@description", DbType.String, entity.Description },
                new object[] { "@parent", DbType.Int32, entity.ParentID },
                new object[] { "@funds_id", DbType.Int16, entity.FundID },
                new object[] { "@coa_account_code", DbType.String, entity.COAAccountCode },
                new object[] { "@blgf_account_code", DbType.String, entity.BLGFAccountCode },
            };

            string query = $"UPDATE {tableName} SET code = @code, description = @description, parent = @parent, funds_id = @funds_id, coa_account_code = @coa_account_code, blgf_account_code = @blgf_account_code WHERE id = @id";

            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }
    }
}