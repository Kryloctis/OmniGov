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
            var parameters = new object[][]
            {
                new object[] { "rate_id", DbType.String, entity.RateID},
                new object[] { "tax_type_id", DbType.Int32, entity.TaxTypeID},
                new object[] { "description", DbType.String, entity.Description},
                new object[] { "amount", DbType.Decimal, entity.Amount},
                new object[] { "starting_year", DbType.Int32, entity.StartingYear},
                new object[] { "created_by", DbType.Int32, entity.CreatedBy},
            };

            string query = $"INSERT INTO {tableName} (rate_id, tax_type_id, description, amount, starting_year, created_by) VALUES (@rate_id, @tax_type_id, @description, @amount, @starting_year, @created_by)";
            return _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Update(OtherPaymentRatesModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}