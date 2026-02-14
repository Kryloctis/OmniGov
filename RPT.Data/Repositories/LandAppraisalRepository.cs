using RPT.Domain.Interfaces;
using RPT.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace RPT.Data.Repositories
{
    public class LandAppraisalRepository : ILandAppraisalRepository
    {
        private RptGenericCommands _mySqlGenericCommandsRPT;
        private readonly string tableName = "land_appraisal";
        private readonly string viewTableName = "view_land_appraisal";

        public LandAppraisalRepository(RptGenericCommands mySqlGenericCommandsRPT)
        {
            _mySqlGenericCommandsRPT = mySqlGenericCommandsRPT;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<LandAppraisalModel> entityList)
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

        public bool Insert(LandAppraisalModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(LandAppraisalModel entity)
        {
            throw new NotImplementedException();
        }

        public decimal GetTotalAreaByLandPropertiesId(int landPropertiesId)
        {
            var parameters = new object[][]
            {
                new object[] { "@land_properties_id", DbType.Int32, landPropertiesId }
            };

            string query = $"SELECT COALESCE(SUM(area), 0) AS total_area FROM {viewTableName} WHERE land_properties_id = @land_properties_id";
            decimal totalArea = Convert.ToDecimal(_mySqlGenericCommandsRPT.ExecuteScalar(query, parameters));
            return totalArea;
        }
    }
}