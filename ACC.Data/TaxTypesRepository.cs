using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace AccountingSystem
{
    internal class TaxTypesRepository : ITaxTypesRepository
    {

        private readonly IAccGenericCommands _dbGenericCommands;
        private readonly string tableName = "tax_types";
        private readonly string viewTableName = "view_taxtypes";

        public TaxTypesRepository(IAccGenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
        }

        public int CountRecords()
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(List<TaxTypesModel> entityList)
        {
            throw new System.NotImplementedException();
        }

        public Dictionary<string, string> GetRecordByID(int Id)
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

        public bool IdExist(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(TaxTypesModel entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(TaxTypesModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}