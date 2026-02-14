using OmniGov.Core.Repositories;
using System.Data;
using System.Transactions;
using Treasury.Domain.Entities;
using Treasury.Domain.Interfaces;

namespace Treasury.Data.Repositories
{
    internal class OtherPaymentRatesRepository : IOtherPaymentRatesRepository
    {
        private readonly string tableName = "other_payment_rates";
        private GenericCommands mySqlGenericCommandsLFS;

        public OtherPaymentRatesRepository(GenericCommands mySqlGenericCommandsLFS)
        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
        }

        public int CountRecords()
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(List<OtherPaymentRatesModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var entity in entityList)
                {
                    var parameters = new object[][]
                    {
                            new object[] { "@id", DbType.Int32, entity.Id},
                    };

                    string query = $"DELETE FROM {tableName} WHERE id = @id";
                    _ = mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
                }

                scope.Complete();
                return true;
            }
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var dict = new Dictionary<string, string>();

            var parameters = new object[][] { new object[] { "@id", DbType.Int32, Id } };

            string query = $"SELECT * FROM {tableName} WHERE id = @id";

            using (var reader = mySqlGenericCommandsLFS.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return dict;

                foreach (DataRow row in reader.Rows)
                {
                    dict.Add("tax_type_id", row["tax_type_id"].ToString());
                    dict.Add("description", row["description"].ToString());
                    dict.Add("amount", row["amount"].ToString());
                    dict.Add("starting_year", row["starting_year"].ToString());
                    dict.Add("is_rate_editable", row["is_rate_editable"].ToString());
                }

                return dict;
            }
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
                new object[]{ "@search_text", DbType.String, $"%{searchText}%"},
            };

            string query = $"SELECT * FROM {tableName} WHERE description LIKE @search_text";
            var dataTable = new DataTable();
            return mySqlGenericCommandsLFS.FillBySearch(query, dataTable, parameters);
        }

        public DataTable GetRecordsByTaxTypeID(int taxTypeID)
        {
            var record = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@tax_type_id", DbType.Int32, taxTypeID},
            };

            string query = $"SELECT * FROM {tableName} WHERE tax_type_id = @tax_type_id";
            var dataTable = new DataTable();

            return mySqlGenericCommandsLFS.FillBySearch(query, dataTable, parameters);
        }

        public DataTable GetRecordsByTaxTypeIDAndDescription(int taxTypeID, string description)
        {
            var record = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@tax_type_id", DbType.Int32, taxTypeID},
                new object[] { "@description", DbType.String, $"%{description}%"},
            };

            string query = $"SELECT * FROM {tableName} WHERE tax_type_id = @tax_type_id AND description LIKE @description";
            var dataTable = new DataTable();

            return mySqlGenericCommandsLFS.FillBySearch(query, dataTable, parameters);
        }

        public bool IdExist(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(OtherPaymentRatesModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "tax_type_id", DbType.Int32, entity.TaxTypeID},
                new object[] { "description", DbType.String, entity.Description},
                new object[] { "amount", DbType.Decimal, entity.Amount},
                new object[] { "starting_year", DbType.Int32, entity.StartingYear},
                new object[] { "is_rate_editable", DbType.Boolean, entity.IsRateEditable},
                new object[] { "created_by", DbType.Int32, entity.CreatedBy},
            };

            string query = $"INSERT INTO {tableName} (tax_type_id, description, amount, starting_year, is_rate_editable, created_by) VALUES (@tax_type_id, @description, @amount, @starting_year, @is_rate_editable, @created_by)";
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Update(OtherPaymentRatesModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "id", DbType.String, entity.Id},
                new object[] { "tax_type_id", DbType.Int32, entity.TaxTypeID},
                new object[] { "description", DbType.String, entity.Description},
                new object[] { "amount", DbType.Decimal, entity.Amount},
                new object[] { "starting_year", DbType.Int32, entity.StartingYear},
                new object[] { "is_rate_editable", DbType.Boolean, entity.IsRateEditable},
                new object[] { "created_by", DbType.Int32, entity.CreatedBy},
            };

            string query = $"UPDATE {tableName} SET tax_type_id = @tax_type_id, description = @description, amount = @amount, starting_year = @starting_year, is_rate_editable = @is_rate_editable WHERE id = @id";

            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }
    }
}