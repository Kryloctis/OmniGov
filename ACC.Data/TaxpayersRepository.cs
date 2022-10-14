using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    public class TaxpayerRepository : ITaxpayersRepository
    {
        private MySqlGenericCommands _mySqlGenericCommandsLFS;
        private readonly string tableName = "taxpayers";
        private readonly string viewTableName = "view_taxpayers";

        public TaxpayerRepository(MySqlGenericCommands mySqlGenericCommandsLFS)
        {
            _mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<TaxpayersModel> entityList)
        {
            using (var scope = new TransactionScope())
            {

                foreach (TaxpayersModel taxpayersModel in entityList)
                {
                    var parameters = new object[][] { new object[] { "@id", DbType.Int32, taxpayersModel.Id } };
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
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, Id}
            };

            string query = $"SELECT id, tin, name, type, contact_info,  barangays_id, taxpayer_type_id FROM {tableName} WHERE id = @tax_pidayer_id";

            using (var reader = _mySqlGenericCommandsLFS.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return dict;

                foreach (DataRow row in reader.Rows)
                {
                    dict.Add("id", row["id"].ToString());
                    dict.Add("tin", row["tin"].ToString());
                    dict.Add("name", row["name"].ToString());
                    dict.Add("type", row["type"].ToString());
                    dict.Add("contact_info", row["contact_info"].ToString());
                    dict.Add("barangays_id", row["barangays_id"].ToString());
                    dict.Add("taxpayer_type_id", row["taxpayer_type_id"].ToString());
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
            var parameters = new object[][]
            {
                new object[] {"@search_text", DbType.String, searchText }
            };

            string query = $"SELECT * FROM {tableName} WHERE tin LIKE @search_text OR name LIKE @search_text";
            var dataTable = new DataTable();
            return _mySqlGenericCommandsLFS.FillBySearch(query, dataTable, parameters);
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(TaxpayersModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@tin", DbType.String, entity.Tin },
                new object[] { "@name", DbType.String, entity.Name },
                new object[] { "@taxpayer_type_id", DbType.Int32, entity.TaxpayerTypeId },
                new object[] { "@contact_info", DbType.String, entity.ContactInfo },
                new object[] { "@barangays_id", DbType.String, entity.BarangayId }
            };

            string query = $"INSERT INTO {tableName} (tin, name, taxpayer_type_id, contact_info, barangays_id) VALUES (@tin, @name, @taxpayer_type_id, @contact_info, @barangays_id)";
            return _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Update(TaxpayersModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.Id},
                new object[] { "@barangays_id", DbType.String, entity.BarangayId },
                new object[] { "@taxpayer_type_id", DbType.String, entity.TaxpayerTypeId },
                new object[] { "@tin", DbType.String, entity.Tin },
                new object[] { "@name", DbType.String, entity.Name },
                new object[] { "@contact_info", DbType.String, entity.ContactInfo },
            };

            string query = $"UPDATE {tableName} SET tin = @tin, name = @name, taxpayer_type_id = @taxpayer_type_id, contact_info = @contact_info, barangays_id = @barangays_id WHERE id = @id";
            return _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        //VALIDATIONS   
        public bool ITaxpayerNameExist(string name)
        {
            var parameters = new object[][]
            {
                new object[] { "@name", DbType.String, name}
            };

            string query = $"SELECT id FROM {tableName} WHERE name = @name";
            string result = _mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);

            if (!string.IsNullOrWhiteSpace(result))
                return true;
            return false;
        }

        public bool ITaxpayerNameExist(int id, string name)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, id},
                new object[] { "@name", DbType.String, name}
            };

            string query = $"SELECT id FROM {tableName} WHERE id <> @id AND name = @name";
            string result = _mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);

            if (!string.IsNullOrWhiteSpace(result))
                return true;
            return false;
        }

        public int LastInsertedId()
        {
            try
            {
                string query = $"SELECT MAX(tax_payer_id) FROM {tableName}";
                return int.Parse(_mySqlGenericCommandsLFS.ExecuteScalar(query));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetViewTaxpayerRecords()
        {
            var query = $"SELECT * FROM {viewTableName}";
            var dataTable = new DataTable();
            return _mySqlGenericCommandsLFS.Fill(query, dataTable);
        }
    }
}
