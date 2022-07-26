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
        private readonly string tblBarangays = "barangays";
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

        public DataTable GetProperties(string barangayName, string searchKey)
        {
            try
            {
                var parameters = new object[][] { 
                    new object[]{"@barangay_name", DbType.String, barangayName},
                    new object[]{"@search_key", DbType.String, $"%{searchKey}%" },
                };

                string query = $"SELECT id, complete_arp_no, owner_name, barangay_name, pin, is_taxable, is_cancelled FROM {viewRealProperties} " +
                    $"WHERE barangay_name = @barangay_name AND owner_name LIKE @search_key AND effectivity_quarter <= quarter(CURRENT_DATE()) AND effectivity_year <= YEAR(CURRENT_DATE()) ";

                var dtProperties = new DataTable();
                return _mySqlGenericCommandsRPT.FillBySearch(query, dtProperties, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public decimal GetAssessedValueByARPNo(string arpNo)
        {
            var parameters = new object[][]
            {
                new object[] { "@arp_no", DbType.String, arpNo},
            };

            string query = $"SELECT assessed_value FROM {viewPropertyAssessmentGrouped} WHERE complete_arp_no = @arp_no";

            string queryResult = _mySqlGenericCommandsRPT.ExecuteScalar(query, parameters);

            if (!string.IsNullOrEmpty(queryResult))
                return decimal.Parse(queryResult);

            return 0;
        }
    }
}
