using ACC.Data;
using RPT.Domain.Interfaces;
using RPT.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPT.Data
{
    public class LandPropertiesRepository : ILandPropertiesRepository
    {
        private MySqlGenericCommands mySqlGenericCommandsRPT;

        public LandPropertiesRepository(MySqlGenericCommands mySqlGenericCommandsRPT)
        {
            this.mySqlGenericCommandsRPT = mySqlGenericCommandsRPT;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<LandPropertiesModel> entityList)
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

        public bool Insert(LandPropertiesModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(LandPropertiesModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
