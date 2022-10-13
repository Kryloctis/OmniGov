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
            throw new System.NotImplementedException();
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT id, code, name FROM {tableName}";

            var dtBudgetAppropriation = new DataTable();
            return _mySqlGenericCommandsLFS.Fill(query, dtBudgetAppropriation);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new System.NotImplementedException();
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