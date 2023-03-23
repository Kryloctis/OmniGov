using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace AccountingSystem
{
    internal class TaxTypesRepository : ITaxTypesRepository
    {

        private readonly IAccGenericCommands _dbGenericCommands;
        private readonly string tableName = "tax_type";
        private readonly string viewTableName = "view_taxtypes";

        public TaxTypesRepository(IAccGenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
        }

        public int CountRecords()
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(List<TaxTypesModel> entityList)
        {
            throw new System.NotImplementedException();
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

        public DataTable GetParentNodesTaxTypes()
        {
            string query = $"SELECT * FROM {tableName} WHERE parent IS NULL";

            var dt = new DataTable();
            return _dbGenericCommands.Fill(query, dt);
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {tableName}";

            var dt = new DataTable();
            return _dbGenericCommands.Fill(query, dt);

        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetTaxTypeCodes()
        {
            string query = $"SELECT id, code FROM {tableName}";

            var dt = new DataTable();
            return _dbGenericCommands.Fill(query, dt);
        }

        public bool IdExist(int id)
        {
            throw new System.NotImplementedException();
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

        public bool Update(TaxTypesModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}