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
        private AccGenericCommands _mySqlGenericCommandsLFS;
        private readonly string tableName = "taxpayers";
        private readonly string viewTableName = "view_taxpayers";

        public TaxpayerRepository(AccGenericCommands mySqlGenericCommandsLFS)
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

            string query = $"SELECT id, tin, name, street, barangay, municipality, province, taxpayer_type_id, contact_info, is_active, created_at, created_by, updated_at, updated_by  FROM {tableName} WHERE id = @id";

            using (var reader = _mySqlGenericCommandsLFS.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return dict;

                foreach (DataRow row in reader.Rows)
                {
                    dict.Add("id", row["id"].ToString());
                    dict.Add("tin", row["tin"].ToString());
                    dict.Add("name", row["name"].ToString());
                    dict.Add("taxpayer_type_id", row["taxpayer_type_id"].ToString());
                    dict.Add("street", row["street"].ToString());
                    dict.Add("barangay", row["barangay"].ToString());
                    dict.Add("municipality", row["municipality"].ToString());
                    dict.Add("province", row["province"].ToString());
                    dict.Add("contact_info", row["contact_info"].ToString());
                    dict.Add("is_active", row["is_active"].ToString());
                    dict.Add("created_at", row["created_at"].ToString());
                    dict.Add("created_by", row["created_by"].ToString());
                    dict.Add("updated_at", row["updated_at"].ToString());
                    dict.Add("updated_by", row["updated_by"].ToString());
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
                new object[] { "@taxpayer_type_id", DbType.Int32, entity.TaxpayerTypeId },
                new object[] { "@tin", DbType.String, entity.Tin },
                new object[] { "@name", DbType.String, entity.Name },
                new object[] { "@street", DbType.String, entity.Street },
                new object[] { "@barangay", DbType.String, entity.Barangay},
                new object[] { "@municipality", DbType.String, entity.Municipality},
                new object[] { "@province", DbType.String, entity.Province},
                new object[] { "@contact_info", DbType.String, entity.ContactInfo },
                new object[] { "@is_active", DbType.Boolean, entity.IsActive },
                new object[] { "@created_by", DbType.Int32, entity.CreatedBy}
            };

            string query = $"INSERT INTO {tableName} (tin, name, taxpayer_type_id, contact_info, street, barangay, municipality, province, is_active, created_by) VALUES (@tin, @name, @taxpayer_type_id, @contact_info, @street, @barangay, @municipality, @province, @is_active, @created_by)";
            return _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Update(TaxpayersModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.Id},
                new object[] { "@tin", DbType.String, entity.Tin },
                new object[] { "@name", DbType.String, entity.Name },
                new object[] { "@taxpayer_type_id", DbType.Int32, entity.TaxpayerTypeId },
                new object[] { "@street", DbType.String, entity.Street },
                new object[] { "@barangay", DbType.String, entity.Barangay},
                new object[] { "@municipality", DbType.String, entity.Municipality},
                new object[] { "@province", DbType.String, entity.Province},
                new object[] { "@contact_info", DbType.String, entity.ContactInfo },
                new object[] { "@is_active", DbType.Boolean, entity.IsActive },
                new object[] { "@updated_by", DbType.Int32, entity.UpdatedBy }
            };

            string query = $"UPDATE {tableName} SET tin = @tin, name = @name, taxpayer_type_id = @taxpayer_type_id, contact_info = @contact_info, street = @street, barangay = @barangay, municipality = @municipality, province = @province, is_active = @is_active, updated_by = @updated_by WHERE id = @id";
            return _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        //VALIDATIONS   
        public bool TaxpayerNameExist(string name)
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

        public bool TaxpayerNameExist(int id, string name)
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

        public int GetLastInsertedId()
        {
            try
            {
                string query = $"SELECT MAX(id) FROM {tableName}";
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

        public DataTable GetViewTaxpayerRecordsBySearch(string searchText)
        {
            var parameters = new object[][] { new object[] { "@search_text", DbType.String, $"%{searchText}%" } };
            string query = $"SELECT * FROM {viewTableName} WHERE taxpayers_tin LIKE @search_text OR taxpayers_name LIKE @search_text";
            var dataTable = new DataTable();
            return _mySqlGenericCommandsLFS.FillBySearch(query, dataTable, parameters);
        }

        public int GetIdByName(string name)
        {
            var parameters = new object[][] { new object[] { "@name", DbType.String, name } };
            string query = $"SELECT id FROM {tableName} WHERE name = @name";
            return Convert.ToInt32(_mySqlGenericCommandsLFS.ExecuteScalar(query, parameters));
        }
    }
}
