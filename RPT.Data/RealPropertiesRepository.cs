using System;
using System.Collections.Generic;
using System.Data;
using ACC.Data;
using RPT.Domain.Interfaces;
using RPT.Domain.Models;

namespace RPT.Data
{
    public class RealPropertiesRepository : IRealPropertiesRepository
    {
        private readonly string viewPropertyAssessmentGrouped  = "view_property_assessment_grouped";
        private readonly string viewPropertyAssessmentGroupedCancelled = "view_property_assessment_grouped_cancelled";
        private readonly string viewRealProperties = "view_real_properties";
        private MySqlGenericCommands _mySqlGenericCommandsRPT;

        public RealPropertiesRepository(MySqlGenericCommands mySqlGenericCommandsRPT)
        {
            _mySqlGenericCommandsRPT = mySqlGenericCommandsRPT;
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
            return _mySqlGenericCommandsRPT.FillBySearch(query, dataTable, parameters);
        }

        public DataTable GetBarangays()
        {
            try
            {
                string query = $"SELECT id, code, name, is_poblacion FROM barangays ORDER BY code";

                var dtBarangay = new DataTable();
                return _mySqlGenericCommandsRPT.Fill(query, dtBarangay);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetPropertiesBy_Quarter_Year_BarangayId_Search(int effectivityYear, int barangayId, string searchText)
        {

            var parameters = new object[][] 
            { 
                new object[] { "@effectivity_year", DbType.Int32, effectivityYear },
                new object[] { "@barangays_id", DbType.Int32, barangayId },
                new object[] { "@search_text", DbType.String, $"%{searchText}%" }
            };

            string BarangayId() 
            {
                if (barangayId == 0)
                    return string.Empty;
                else
                    return "AND barangays_id = @barangays_id";
            }

            string query = $"SELECT *  FROM {viewRealProperties} WHERE (owner_name LIKE @search_text OR pin LIKE @search_text OR complete_arp_no LIKE @search_text OR owner_tin LIKE @search_text OR owner_address LIKE @search_text) AND effectivity_year <= @effectivity_year {BarangayId()} ";

            var dtProperties = new DataTable();
            return _mySqlGenericCommandsRPT.FillBySearch(query, dtProperties, parameters);
        }

        public decimal GetAssessedValueByARPNo(string completeArpNo, string ownerName)
        {
            return 0;
        }
    }
}
