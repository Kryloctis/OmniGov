using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace AccountingSystem
{
    internal class CattleOwnershipRepository : ICattleOwnershipRepository
    {
        private readonly IAccGenericCommands _dbGenericCommands;
        private readonly string tableName = "cattle_ownership";

        public CattleOwnershipRepository(IAccGenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
        }

        public int CountRecords()
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(List<CattleOwnershipModel> entityList)
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

        public bool Insert(CattleOwnershipModel entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(CattleOwnershipModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}