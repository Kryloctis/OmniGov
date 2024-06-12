using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace ACC.Data
{
    internal class BiddingsRepository : IBiddingsRepository
    {
        private AccGenericCommands mySqlGenericCommandsLFS;
        private string tableName = "Biddings";

        public BiddingsRepository(AccGenericCommands mySqlGenericCommandsLFS)
        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
        }

        public bool Delete(List<BiddingsModel> entityList)
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

        public bool Insert(BiddingsModel entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(BiddingsModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}