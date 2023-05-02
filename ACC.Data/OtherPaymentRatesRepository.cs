using ACC.Data;
using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace AccountingSystem
{
    internal class OtherPaymentRatesRepository : IOtherPaymentRatesRepository
    {
        private readonly string tableName = "other_payment_rates";
        private AccGenericCommands _mySqlGenericCommandsLFS;

        public OtherPaymentRatesRepository(AccGenericCommands mySqlGenericCommandsLFS)
        {
            _mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
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
                    _ = _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
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

            using (var reader = _mySqlGenericCommandsLFS.ExecuteReader(query, parameters))
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
            return _mySqlGenericCommandsLFS.Fill(query, dataTable);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new System.NotImplementedException();
        }

        public Dictionary<string, string> GetRecordsByTaxTypeID(int taxTypeID)
        {
            var record = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                    new object[] { "@tax_type_id", DbType.Int32, taxTypeID},
            };

            string query = $"SELECT * FROM {tableName} WHERE tax_type_id = @tax_type_id";

            using (var reader = _mySqlGenericCommandsLFS.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return record;

                record.Add("id", reader.Rows[0]["id"].ToString());
                record.Add("description", reader.Rows[0]["description"].ToString());
                record.Add("amount", reader.Rows[0]["amount"].ToString());
                record.Add("is_rate_editable", reader.Rows[0]["is_rate_editable"].ToString());
                record.Add("created_by", reader.Rows[0]["created_by"].ToString());
                record.Add("created_at", reader.Rows[0]["created_at"].ToString());
                record.Add("updated_by", reader.Rows[0]["updated_by"].ToString());
                record.Add("updated_at", reader.Rows[0]["updated_at"].ToString());
            }

            return record;
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
            return _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
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

            return _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }
    }
}