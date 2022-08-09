using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ACC.Data
{
    public class GeneralPaymentsRepository : IGeneralPaymentsRepository
    {
        private MySqlGenericCommands mySqlGenericCommandsLFS;

        public GeneralPaymentsRepository(MySqlGenericCommands mySqlGenericCommandsLFS)
        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
        }

        public GeneralPaymentsRepository()
        {

        }

        public bool IdExist(int id)
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

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new NotImplementedException();
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Insert(GeneralPaymentsModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(GeneralPaymentsModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<GeneralPaymentsModel> entityList)
        {
            throw new NotImplementedException();
        }
    }
}
