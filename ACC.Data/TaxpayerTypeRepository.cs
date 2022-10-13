using ACC.Data;
using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace AccountingSystem
{
    internal class TaxpayerTypeRepository : ITaxpayerTypeRepository
    {
        private MySqlGenericCommands _mySqlGenericCommandsLFS;
        private readonly string tableName = "taxpayer_type";

        public TaxpayerTypeRepository(MySqlGenericCommands mySqlGenericCommandsLFS)
        {
            _mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
        }

        public bool IdExist(int id)
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetRecords()
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new System.NotImplementedException();
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new System.NotImplementedException();
        }

        public int CountRecords()
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(TaxpayerTypeModel entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(TaxpayerTypeModel entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(List<TaxpayerTypeModel> entityList)
        {
            throw new System.NotImplementedException();
        }
    }
}