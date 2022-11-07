using RPT.Domain.Interfaces;
using RPT.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace RPT.Data
{
    public class RealPropertiesRepository : IRealPropertiesRepository
    {
        private readonly string viewPropertyAssessmentGrouped = "view_property_assessment_grouped";
        private readonly string viewLfsRealProperties = "view_lfs_real_properties";
        private readonly string viewPropertyAssessessment = "view_property_assessment";
        private readonly string viewRealProperties = "view_real_properties";
        private readonly string tableName = "real_properties";
        private RptGenericCommands _mySqlGenericCommandsRPT;

        public RealPropertiesRepository(RptGenericCommands mySqlGenericCommandsRPT)
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
            var dict = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@id",DbType.Int32, Id}
            };

            string query = $"SELECT transaction_codes_id, owners_id, barangays_id, property_identifier, property_kind, arp_no, pin_section, pin_lot, owner_name, owner_address, owner_contact, owner_tin, admin_name, admin_address, admin_contact, admin_tin, street, is_taxable, effectivity_quarter, effectivity_year, memoranda, date_of_entry, gryear, appraised_by, appraised_date, recom_approval_by, recom_approval_date, approved_by, approved_date, is_cancelled, is_pending, created_at, created_by, updated_at, updated_by FROM {tableName} WHERE id = @id";

            using (var reader = _mySqlGenericCommandsRPT.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return dict;

                foreach (DataRow row in reader.Rows)
                {
                    dict.Add("transaction_codes_id", row["transaction_codes_id"].ToString());
                    dict.Add("owners_id", row["owners_id"].ToString());
                    dict.Add("barangays_id", row["barangays_id"].ToString());
                    dict.Add("property_identifier", row["property_identifier"].ToString());
                    dict.Add("property_kind", row["property_kind"].ToString());
                    dict.Add("arp_no", row["arp_no"].ToString());
                    dict.Add("pin_section", row["pin_section"].ToString());
                    dict.Add("pin_lot", row["pin_lot"].ToString());
                    dict.Add("owner_name", row["owner_name"].ToString());
                    dict.Add("owner_address", row["owner_address"].ToString());
                    dict.Add("owner_contact", row["owner_contact"].ToString());
                    dict.Add("owner_tin", row["owner_tin"].ToString());
                    dict.Add("admin_name", row["admin_name"].ToString());
                    dict.Add("admin_address", row["admin_address"].ToString());
                    dict.Add("admin_contact", row["admin_contact"].ToString());
                    dict.Add("admin_tin", row["admin_tin"].ToString());
                    dict.Add("street", row["street"].ToString());
                    dict.Add("is_taxable", row["is_taxable"].ToString());
                    dict.Add("effectivity_quarter", row["effectivity_quarter"].ToString());
                    dict.Add("effectivity_year", row["effectivity_year"].ToString());
                    dict.Add("memoranda", row["memoranda"].ToString());
                    dict.Add("date_of_entry", row["date_of_entry"].ToString());
                    dict.Add("gryear", row["gryear"].ToString());
                    dict.Add("appraised_by", row["appraised_by"].ToString());
                    dict.Add("appraised_date", row["appraised_date"].ToString());
                    dict.Add("recom_approval_by", row["recom_approval_by"].ToString());
                    dict.Add("recom_approval_date", row["recom_approval_date"].ToString());
                    dict.Add("approved_by", row["approved_by"].ToString());
                    dict.Add("approved_date", row["approved_date"].ToString());
                    dict.Add("is_cancelled", row["is_cancelled"].ToString());
                    dict.Add("is_pending", row["is_pending"].ToString());
                    dict.Add("created_at", row["created_at"].ToString());
                    dict.Add("created_by", row["created_by"].ToString());
                    dict.Add("updated_at", row["updated_at"].ToString());
                    dict.Add("updated_by", row["updated_by"].ToString());
                }
            }

            return dict;
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
                string query = $"SELECT id, code, name, is_poblacion FROM {tableName} ORDER BY code";

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

            string query = $"SELECT * FROM {viewLfsRealProperties} WHERE (owner_name LIKE @search_text OR complete_arp_no LIKE @search_text OR owner_address LIKE @search_text)  AND effectivity_year <= @effectivity_year {BarangayId()} ";

            var dtProperties = new DataTable();
            return _mySqlGenericCommandsRPT.FillBySearch(query, dtProperties, parameters);
        }

        public decimal GetAssessedValueByARPNo(string completeArpNo)
        {
            var parameters = new object[][]
            {
                new object[] { "@complete_arp_no", DbType.String, completeArpNo}
            };

            string query = $"SELECT COALESCE(assessed_value, 0) FROM {viewPropertyAssessmentGrouped} WHERE complete_arp_no = @complete_arp_no";
            return Convert.ToDecimal(_mySqlGenericCommandsRPT.ExecuteScalar(query, parameters));
        }

        public Dictionary<string, string> GetViewRealPropertiesById(int Id)
        {
            var dict = new Dictionary<string, string>();

            var parameters = new object[][] { new object[] { "@id", DbType.Int32, Id } };
            string query = $"SELECT transaction_codes_id, owners_id, barangays_id, property_kind, arp_no, pin, owner_name, owner_address, owner_contact, owner_tin, admin_name, admin_address, admin_contact, admin_tin, street, is_taxable, effectivity_quarter, effectivity_year, memoranda, date_of_entry, gryear, appraised_by, appraised_date, recom_approval_by, recom_approval_date, approved_by, approved_date, is_cancelled, is_pending, created_at, created_by, updated_at, updated_by, complete_arp_no, transaction_code, transaction, owner_types_id, owner_type_code, owner_type, real_owner_name, municipalities_id, barangay_code, barangay_name, is_poblacion, municipality_code, municipality_name, province_code, province_name FROM {viewRealProperties} WHERE id = @id";
            using (var reader = _mySqlGenericCommandsRPT.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return dict;

                foreach (DataRow row in reader.Rows)
                {

                    dict.Add("transaction_codes_id", row["transaction_codes_id"].ToString());
                    dict.Add("owners_id", row["owners_id"].ToString());
                    dict.Add("barangays_id", row["barangays_id"].ToString());
                    dict.Add("property_kind", row["property_kind"].ToString());
                    dict.Add("arp_no", row["arp_no"].ToString());
                    dict.Add("pin", row["pin"].ToString());
                    dict.Add("owner_name", row["owner_name"].ToString());
                    dict.Add("owner_address", row["owner_address"].ToString());
                    dict.Add("owner_contact", row["owner_contact"].ToString());
                    dict.Add("owner_tin", row["owner_tin"].ToString());
                    dict.Add("admin_name", row["admin_name"].ToString());
                    dict.Add("admin_address", row["admin_address"].ToString());
                    dict.Add("admin_contact", row["admin_contact"].ToString());
                    dict.Add("admin_tin", row["admin_tin"].ToString());
                    dict.Add("street", row["street"].ToString());
                    dict.Add("is_taxable", row["is_taxable"].ToString());
                    dict.Add("effectivity_quarter", row["effectivity_quarter"].ToString());
                    dict.Add("effectivity_year", row["effectivity_year"].ToString());
                    dict.Add("memoranda", row["memoranda"].ToString());
                    dict.Add("date_of_entry", row["date_of_entry"].ToString());
                    dict.Add("gryear", row["gryear"].ToString());
                    dict.Add("appraised_by", row["appraised_by"].ToString());
                    dict.Add("appraised_date", row["appraised_date"].ToString());
                    dict.Add("recom_approval_by", row["recom_approval_by"].ToString());
                    dict.Add("recom_approval_date", row["recom_approval_date"].ToString());
                    dict.Add("approved_by", row["approved_by"].ToString());
                    dict.Add("approved_date", row["approved_date"].ToString());
                    dict.Add("is_cancelled", row["is_cancelled"].ToString());
                    dict.Add("is_pending", row["is_pending"].ToString());
                    dict.Add("created_at", row["created_at"].ToString());
                    dict.Add("created_by", row["created_by"].ToString());
                    dict.Add("updated_at", row["updated_at"].ToString());
                    dict.Add("updated_by", row["updated_by"].ToString());
                    dict.Add("complete_arp_no", row["complete_arp_no"].ToString());
                    dict.Add("transaction_code", row["transaction_code"].ToString());
                    dict.Add("transaction", row["transaction"].ToString());
                    dict.Add("owner_types_id", row["owner_types_id"].ToString());
                    dict.Add("owner_type_code", row["owner_type_code"].ToString());
                    dict.Add("owner_type", row["owner_type"].ToString());
                    dict.Add("real_owner_name", row["real_owner_name"].ToString());
                    dict.Add("municipalities_id", row["municipalities_id"].ToString());
                    dict.Add("barangay_code", row["barangay_code"].ToString());
                    dict.Add("barangay_name", row["barangay_name"].ToString());
                    dict.Add("is_poblacion", row["is_poblacion"].ToString());
                    dict.Add("municipality_code", row["municipality_code"].ToString());
                    dict.Add("municipality_name", row["municipality_name"].ToString());
                    dict.Add("province_code", row["province_code"].ToString());
                    dict.Add("province_name", row["province_name"].ToString());
                }
            }

            return dict;
        }

        public decimal GetOtherImprovementsAssessedValueBy_ArpNo_ActualUseCode(string arpNo)
        {
            var parameters = new object[][]
            {
                new object[] { "@complete_arp_no", DbType.String, arpNo},
            };

            string query = $"SELECT COALESCE(SUM(assessed_value), 0) AS assessed_value FROM {viewPropertyAssessessment} WHERE complete_arp_no = @complete_arp_no AND actual_use_code = 'AIM'";

            return Convert.ToDecimal(_mySqlGenericCommandsRPT.ExecuteScalar(query, parameters));
        }


        //LFS View
        public DataTable GetViewLFSRealPropertiesRecords()
        {
            string query = $"SELECT * FROM {viewLfsRealProperties}";
            var dataTable = new DataTable();
            return _mySqlGenericCommandsRPT.Fill(query, dataTable);
        }

        public Dictionary<string, string> GetViewLFSRealPropertiesRecordById(int Id)
        {
            var dict = new Dictionary<string, string>();
            var parameters = new object[][] { new object[] { "@real_properties_id", DbType.Int32, Id } };
            string query = $"SELECT real_properties_id, real_properties_identifier, land_bldg_mach_properties_id, transaction_codes_id, transaction_code, pin, property_kind, barangays_id, barangays_code, barangays_name, municipalities_code, municipality_name, provinces_code, provinces_name, gryear, complete_arp_no, is_taxable, is_cancelled, owner_tin, owner_name, owner_address, owner_contact, real_owners_id, real_owner_tin, real_owner_name, real_owner_street, real_owner_barangay, real_owner_municipality, real_owner_province, real_owner_contact_info, real_owner_type_code, real_owner_type, effectivity_quarter, effectivity_year, date_of_entry, street, classification_codes_id, classification_code, classification_name, classification_is_special, actual_use_codes_id, actual_use_code, actual_use_name, actual_use_is_government, land_lot_no, land_area, other_improvements, assessed_value FROM {viewLfsRealProperties} WHERE real_properties_id = @real_properties_id";

            using (var reader = _mySqlGenericCommandsRPT.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return dict;

                foreach (DataRow row in reader.Rows)
                {
                    dict.Add("real_properties_id", row["real_properties_id"].ToString());
                    dict.Add("real_properties_identifier", row["real_properties_identifier"].ToString());
                    dict.Add("land_bldg_mach_properties_id", row["land_bldg_mach_properties_id"].ToString());
                    dict.Add("transaction_codes_id", row["transaction_codes_id"].ToString());
                    dict.Add("transaction_code", row["transaction_code"].ToString());
                    dict.Add("pin", row["pin"].ToString());
                    dict.Add("property_kind", row["property_kind"].ToString());
                    dict.Add("barangays_id", row["barangays_id"].ToString());
                    dict.Add("barangays_code", row["barangays_code"].ToString());
                    dict.Add("barangays_name", row["barangays_name"].ToString());
                    dict.Add("municipalities_code", row["municipalities_code"].ToString());
                    dict.Add("municipality_name", row["municipality_name"].ToString());
                    dict.Add("provinces_code", row["provinces_code"].ToString());
                    dict.Add("provinces_name", row["provinces_name"].ToString());
                    dict.Add("gryear", row["gryear"].ToString());
                    dict.Add("complete_arp_no", row["complete_arp_no"].ToString());
                    dict.Add("is_taxable", row["is_taxable"].ToString());
                    dict.Add("is_cancelled", row["is_cancelled"].ToString());
                    dict.Add("owner_tin", row["owner_tin"].ToString());
                    dict.Add("owner_name", row["owner_name"].ToString());
                    dict.Add("owner_address", row["owner_address"].ToString());
                    dict.Add("owner_contact", row["owner_contact"].ToString());
                    dict.Add("real_owners_id", row["real_owners_id"].ToString());
                    dict.Add("real_owner_tin", row["real_owner_tin"].ToString());
                    dict.Add("real_owner_name", row["real_owner_name"].ToString());
                    dict.Add("real_owner_street", row["real_owner_street"].ToString());
                    dict.Add("real_owner_barangay", row["real_owner_barangay"].ToString());
                    dict.Add("real_owner_municipality", row["real_owner_municipality"].ToString());
                    dict.Add("real_owner_province", row["real_owner_province"].ToString());
                    dict.Add("real_owner_contact_info", row["real_owner_contact_info"].ToString());
                    dict.Add("real_owner_type_code", row["real_owner_type_code"].ToString());
                    dict.Add("real_owner_type", row["real_owner_type"].ToString());
                    dict.Add("effectivity_quarter", row["effectivity_quarter"].ToString());
                    dict.Add("effectivity_year", row["effectivity_year"].ToString());
                    dict.Add("date_of_entry", row["date_of_entry"].ToString());
                    dict.Add("street", row["street"].ToString());
                    dict.Add("classification_codes_id", row["classification_codes_id"].ToString());
                    dict.Add("classification_code", row["classification_code"].ToString());
                    dict.Add("classification_name", row["classification_name"].ToString());
                    dict.Add("classification_is_special", row["classification_is_special"].ToString());
                    dict.Add("actual_use_codes_id", row["actual_use_codes_id"].ToString());
                    dict.Add("actual_use_code", row["actual_use_code"].ToString());
                    dict.Add("actual_use_name", row["actual_use_name"].ToString());
                    dict.Add("actual_use_is_government", row["actual_use_is_government"].ToString());
                    dict.Add("land_lot_no", row["land_lot_no"].ToString());
                    dict.Add("land_area", row["land_area"].ToString());
                    dict.Add("other_improvements", row["other_improvements"].ToString());
                    dict.Add("assessed_value", row["assessed_value"].ToString());
                }

                return dict;
            }
        }
    }
}
