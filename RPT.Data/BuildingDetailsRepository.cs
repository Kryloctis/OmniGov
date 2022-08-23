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
    public class BuildingDetailsRepository : IBuildingDetailsRepository
    {
        private MySqlGenericCommands _mySqlGenericCommandsRPT;

        public BuildingDetailsRepository(MySqlGenericCommands mySqlGenericCommandsRPT)
        {
            _mySqlGenericCommandsRPT = mySqlGenericCommandsRPT;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<BuildingDetailsModel> entityList)
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

        public decimal GetTotalAreaByBuildingPropertiesId(int buidlingPropertiesId)
        {
            var parameters = new object[][]
            {
                new object[] { "@building_properties_id", DbType.Int32, buidlingPropertiesId }
            };

            string query = $"SELECT COALESCE(SUM(area), 0) AS total_area FROM {buidlingPropertiesId} WHERE building_properties_id = @building_properties_id";
            decimal totalArea = Convert.ToDecimal(_mySqlGenericCommandsRPT.ExecuteScalar(query, parameters));
            return totalArea;
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(BuildingDetailsModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(BuildingDetailsModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
