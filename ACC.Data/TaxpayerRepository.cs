using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    public class TaxpayerRepository : ITaxpayers
    {
        private MySqlGenericCommands _mySqlGenericCommandsLFS;
        private readonly string tableName = "Taxpayers";

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

            string query = $"SELECT id, tin, name, type, contact_info, street, barangay, municipality, province FROM {tableName} WHER id = @id";

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
                    dict.Add("street", row["street"].ToString());
                    dict.Add("barangay", row["barangay"].ToString());
                    dict.Add("municipality", row["province"].ToString());
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

            string query = $"SELECT * FROM {tableName} WHERE tin LIKE @tin OR name LIKE @name";
            var dataTable = new DataTable();
            return _mySqlGenericCommandsLFS.FillBySearch(query, dataTable);
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
                new object[] { "@type", DbType.String, entity.Type },
                new object[] { "@contact_info", DbType.String, entity.ContactInfo },
                new object[] { "@street", DbType.String, entity.Street },
                new object[] { "@barangay", DbType.String, entity.Barangay },
                new object[] { "@municipality", DbType.String, entity.Municipality },
                new object[] { "@province", DbType.String, entity.Province }
            };

            string query = $"INSERT INTO {tableName} (tin, name, type, contact_info, street, barangay, municipality, province) VALUES (@tin, @name, @type, @contact_info, @street, @barangay, @municipality, @province)";
            return _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Update(TaxpayersModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.Id},
                new object[] { "@tin", DbType.String, entity.Tin },
                new object[] { "@name", DbType.String, entity.Name },
                new object[] { "@type", DbType.String, entity.Type },
                new object[] { "@contact_info", DbType.String, entity.ContactInfo },
                new object[] { "@street", DbType.String, entity.Street },
                new object[] { "@barangay", DbType.String, entity.Barangay },
                new object[] { "@municipality", DbType.String, entity.Municipality },
                new object[] { "@province", DbType.String, entity.Province }
            };

            string query = $"UPDATE {tableName} SET tin = @tin, name = @name, type = @type, contact_info = @contact_info, street = @street, barangay = @barangay, municipality = @municipality, province = @province WHERE id = @id";
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
    }
}
