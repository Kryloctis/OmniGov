using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace ACC.Data
{
    public class JobOrderRepository : IJobOrder
    {
        private MySqlGenericCommands mySqlGenericCommands;

        public JobOrderRepository(MySqlGenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public int CountRecords()
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(List<JobOrderModel> entityList)
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

        public bool Insert(JobOrderModel entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(JobOrderModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
