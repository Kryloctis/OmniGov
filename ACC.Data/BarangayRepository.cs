using ACC.Data;
using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACC.Data
{
    public class BarangayRepository : IBarangayRepository
    {
        private MySqlGenericCommands _mySqlGenericCommandsLFS;
        private readonly string tableName = "barangays";

        public BarangayRepository(MySqlGenericCommands mySqlGenericCommandsRPT)
        {
            _mySqlGenericCommandsLFS = mySqlGenericCommandsRPT;
        }

        public int CountRecords()
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(List<BarangayModel> entityList)
        {
            throw new System.NotImplementedException();
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var dict = new Dictionary<string, string>();

            var parameter = new object[][] { 
                new object[]{"@barangay_id", DbType.Int32, Id}
            };
            string query = $"SELECT name, code FROM {tableName} WHERE id = @barangay_id";

            using (var items = _mySqlGenericCommandsLFS.ExecuteReader(query, parameter))
            {
                if (items.Rows.Count < 1)
                    return dict;

                foreach (DataRow item in items.Rows)
                {
                    dict.Add("code", item["code"].ToString());
                    dict.Add("name", item["name"].ToString());
                }

                return dict;
            }
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT id, code, name FROM {tableName}";

            var dtBudgetAppropriation = new DataTable();
            return _mySqlGenericCommandsLFS.Fill(query, dtBudgetAppropriation);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameters = new object[][]
            {
                new object[] { "@search_text", DbType.String, $"%{searchText}%"},
            };

            string query = $"SELECT id, code, name FROM {tableName} WHERE code LIKE @search_text OR name LIKE @search_text";

            var dtBarangay = new DataTable();
            return _mySqlGenericCommandsLFS.FillBySearch(query, dtBarangay, parameters);
        }

        public bool IdExist(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(BarangayModel entity)
        {
            var parameter = new object[][] {
                new object[]{"@barangay_code", DbType.String, entity.Code},
                new object[]{"@barangay_name", DbType.String, entity.Name},
                new object[]{"@municipalities_id", DbType.Int32, entity.MunicipalityID}
            };

            string query = $"INSERT INTO barangays (code, name, municipalities_id) VALUES (@barangay_code, @barangay_name, @municipalities_id)";

            return _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameter);
        }

        public bool Update(BarangayModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}