using ACC.Data;
using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

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
            throw new System.NotImplementedException();
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new System.NotImplementedException();
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

        public bool IdExist(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(OtherPaymentRatesModel entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(OtherPaymentRatesModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}