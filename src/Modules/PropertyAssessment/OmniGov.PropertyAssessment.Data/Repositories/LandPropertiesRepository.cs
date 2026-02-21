using OmniGov.Core.Interfaces.Services;
using OmniGov.PropertyAssessment.Domain.Entities;
using OmniGov.PropertyAssessment.Domain.Interfaces;
using System.Data;

namespace OmniGov.PropertyAssessment.Data.Repositories
{
    public class LandPropertiesRepository : ILandPropertiesRepository
    {
        private IGenericCommands _genericCommands;
        private readonly string tableName = "land_properties";
        private readonly string viewTableName = "view_land_properties";

        public LandPropertiesRepository(IGenericCommands genericCommands)
        {
            _genericCommands = genericCommands ?? throw new ArgumentNullException(nameof(genericCommands));
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

        public Dictionary<string, string> GetViewRecordByArpNo(string arpNo)
        {
            var dict = new Dictionary<string, string>();
            var parameters = new object[][]
            {
                new object[] { @"complete_arp_no", DbType.String, arpNo}
            };

            string query = $"SELECT real_properties_id, transaction_codes_id, pin, owners_id, barangays_id, property_kind, arp_no, owner_name, owner_address, owner_contact, owner_tin, admin_name, admin_address, admin_contact, admin_tin, street, is_taxable, effectivity_quarter, effectivity_year, memoranda, date_of_entry, gryear, appraised_by, appraised_date, recom_approval_by, recom_approval_date, approved_by, approved_date, is_cancelled, is_pending, created_at, created_by, updated_at, updated_by, complete_arp_no, transaction_code, transaction, owner_types_id, owner_type_code, owner_type, real_owner_name, municipalities_id, barangay_code, barangay_name, is_poblacion, municipality_code, municipality_name, province_code, province_name, land_properties_id, land_restrictions_id, restriction, title_cert, title_cert_date, survey_no, lot_no, block_no, boundary_north, boundary_east, boundary_south, boundary_west, sketch FROM {viewTableName} WHERE complete_arp_no = @complete_arp_no";

            using (var reader = _genericCommands.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return dict;

                foreach (DataRow row in reader.Rows)
                {
                    dict.Add("real_properties_id", row["real_properties_id"].ToString());
                    dict.Add("transaction_codes_id", row["transaction_codes_id"].ToString());
                    dict.Add("pin", row["pin"].ToString());
                    dict.Add("owners_id", row["owners_id"].ToString());
                    dict.Add("barangays_id", row["barangays_id"].ToString());
                    dict.Add("property_kind", row["property_kind"].ToString());
                    dict.Add("arp_no", row["arp_no"].ToString());
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
                    dict.Add("land_properties_id", row["land_properties_id"].ToString());
                    dict.Add("land_restrictions_id", row["land_restrictions_id"].ToString());
                    dict.Add("restriction", row["restriction"].ToString());
                    dict.Add("title_cert", row["title_cert"].ToString());
                    dict.Add("title_cert_date", row["title_cert_date"].ToString());
                    dict.Add("survey_no", row["survey_no"].ToString());
                    dict.Add("lot_no", row["lot_no"].ToString());
                    dict.Add("block_no", row["block_no"].ToString());
                    dict.Add("boundary_north", row["boundary_north"].ToString());
                    dict.Add("boundary_east", row["boundary_east"].ToString());
                    dict.Add("boundary_south", row["boundary_south"].ToString());
                    dict.Add("boundary_west", row["boundary_west"].ToString());
                    dict.Add("sketch", row["sketch"].ToString());
                }
            }

            return dict;
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
