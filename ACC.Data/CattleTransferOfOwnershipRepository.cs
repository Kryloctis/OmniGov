using ACC.Data;
using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace AccountingSystem
{
    internal class CattleTransferOfOwnershipRepository : ICattleTransferOfOwnershipRepository
    {
        private AccGenericCommands _mySqlGenericCommandsLFS;
        private readonly string tableName = "cattle_transfer";

        public CattleTransferOfOwnershipRepository(AccGenericCommands mySqlGenericCommandsLFS)
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

        public bool Insert(CattleTransferOfOwnershipModel entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(CattleTransferOfOwnershipModel entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(List<CattleTransferOfOwnershipModel> entityList)
        {
            throw new System.NotImplementedException();
        }
    }
}