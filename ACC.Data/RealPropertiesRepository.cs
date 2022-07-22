using System;
using System.Collections.Generic;
using System.Data;
using ACC.Domain.Interfaces;
using ACC.Domain.Models;

namespace ACC.Data
{
    public class RealPropertiesRepository : IRealPropertiesRepository
    {
        private readonly IDbGenericCommands _dbGenericCommands;
        private readonly string viewPropertyAssessmentGrouped  = "view_property_assessment_grouped";

        public RealPropertiesRepository(IDbGenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<RealPropertiesModel> entityList)
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

        public bool Insert(RealPropertiesModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(RealPropertiesModel entity)
        {
            throw new NotImplementedException();
        }

        public DataTable GetViewPropertiesByPropertyKindAndSearch(string propertyKind, string searchText)
        {
            var parameters = new object[][]
            {
                new object[] {"@property_kind", DbType.String, propertyKind },
                new object[] {"@searchText", DbType.String, $"%{searchText}%" }
            };

            string query = $"SELECT property_kind, complete_arp_no, pin, owner_name, owner_address, market_value, assessed_value  FROM {viewPropertyAssessmentGrouped} WHERE property_kind = @property_kind AND (complete_arp_no LIKE @searchText OR owner_name LIKE @searchText ) LIMIT 30";

            var dataTable = new DataTable();
            return _dbGenericCommands.FillBySearch(query, dataTable, parameters);
        }

    }
}
