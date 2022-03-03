using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACC.Data
{

    public class CollectingOfficerHasJobOrdersRepository : ICollectingOfficerHasJobOrders
    {
        private readonly MySqlGenericCommands mySqlGenericCommands;

        public CollectingOfficerHasJobOrdersRepository(MySqlGenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<CollectingOfficerHasJobOrdersModel> entityList)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecords()
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new NotImplementedException();
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(CollectingOfficerHasJobOrdersModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(CollectingOfficerHasJobOrdersModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
