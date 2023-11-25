using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACC.Data
{
    public class TaxTypesRepository : ITaxTypesRepository
    {
        private readonly IAccGenericCommands _dbGenericCommands;
        private readonly string tableName = "tax_type";
        //private readonly string viewTableName = "view_taxtypes";

        public TaxTypesRepository(IAccGenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
        }

        public int CountRecords()
        {
            string query = $"SELECT COUNT(id) FROM {tableName} ";
            return Convert.ToInt32(_dbGenericCommands.ExecuteNonQuery(query));
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
            return _dbGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public int GetChildNodesIDs(int taxTypeID)
        {
            var parameter = new object[][]
            {
                new object[] { "@id", DbType.Int32, taxTypeID},
            };

            string query = $"SELECT id FROM {tableName} WHERE parent = @id";

            return Convert.ToInt32(_dbGenericCommands.ExecuteScalar(query, parameter));
        }

        public DataTable GetChildNodesTaxTypes(int parentID)
        {
            var parameter = new object[][]
            {
                new object[] { "@parent", DbType.Int32, parentID},
            };

            string query = $"SELECT * FROM {tableName} WHERE parent = @parent";

            var dt = new DataTable();
            return _dbGenericCommands.FillBySearch(query, dt, parameter);
        }

        public string GetParentCodeByID(int parentID)
        {
            var parameter = new object[][]
            {
                new object[] { "@parent", DbType.Int32, parentID},
            };

            string query = $"SELECT code FROM {tableName} WHERE id = @parent";

            return _dbGenericCommands.ExecuteScalar(query, parameter).ToString();
        }

        public DataTable GetParentNodesTaxTypes()
        {
            string query = $"SELECT * FROM {tableName} WHERE parent IS NULL";

            var dt = new DataTable();
            return _dbGenericCommands.Fill(query, dt);
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var record = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                    new object[] { "@id", DbType.Int32, Id},
            };

            string query = $"SELECT * FROM {tableName} WHERE id = @id";

            using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
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

            var dt = new DataTable();
            return _dbGenericCommands.Fill(query, dt);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new NotImplementedException();
        }

        public DataTable GetTaxTypeCodes()
        {
            string query = $"SELECT id, code, description, parent FROM {tableName}  ORDER BY parent, id DESC";

            var dt = new DataTable();
            return _dbGenericCommands.Fill(query, dt);
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

            return _dbGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool UnDeleteTaxType(int taxTypeID)
        {
            var parameters = new object[][]
            {
            new object[] { "@id", DbType.Int32, taxTypeID},
            };

            string query = $"UPDATE {tableName} SET is_deleted = 0 WHERE id = @id";
            return _dbGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(TaxTypesModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.ID},
                new object[] { "@code", DbType.String, entity.Code },
                new object[] { "@description", DbType.String, entity.Description },
                new object[] { "@parent", DbType.Int32, entity.ParentID },
                new object[] { "@funds_id", DbType.Int16, entity.FundID },
                new object[] { "@coa_account_code", DbType.String, entity.COAAccountCode },
                new object[] { "@blgf_account_code", DbType.String, entity.BLGFAccountCode },
            };

            string query = $"UPDATE {tableName} SET code = @code, description = @description, parent = @parent, funds_id = @funds_id, coa_account_code = @coa_account_code, blgf_account_code = @blgf_account_code WHERE id = @id";

            return _dbGenericCommands.ExecuteNonQuery(query, parameters);
        }
    }
}