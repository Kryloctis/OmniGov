using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    public class RealPropertiesRepository : IRealPropertiesRepository
    {
        private MySqlGenericCommands _mySqlGenericCommandsLFS;
        private readonly string tableName = "real_properties";

        public RealPropertiesRepository(MySqlGenericCommands mySqlGenericCommandsLFS)
        {
            _mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<RealPropertiesModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (RealPropertiesModel realPropertiesModel in entityList)
                {
                    var parameters = new object[][]
                    {
                        new object[] { "@id", DbType.Int32, realPropertiesModel.Id}
                    };

                    string query = $"DELETE FROM {tableName} WHERE id = @id";
                    _ = _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
                }

                scope.Complete();
                return true;
            }
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var dict = new Dictionary<string, string>();

            var parameters = new object[][] { new object[] { "@id", DbType.Int32, Id } };

            string query = $"SELECT real_taxpayers_id, barangays_id, classification_codes_id, actual_use_codes_id, street, property_identifier, complete_arp_no, property_pin, property_kind, effectivity_quarter, effectivity_year, other_improvements, assessed_value, area, lot_no, gr_year, is_taxable, is_cancelled FROM {tableName} WHERE id = @id";


            using (var reader = _mySqlGenericCommandsLFS.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return dict;

                foreach (DataRow row in reader.Rows)
                {
                    dict.Add("real_taxpayers_id", row["real_taxpayers_id"].ToString());
                    dict.Add("barangays_id", row["barangays_id"].ToString());
                    dict.Add("classification_codes_id", row["classification_codes_id"].ToString());
                    dict.Add("actual_use_codes_id", row["actual_use_codes_id"].ToString());
                    dict.Add("street", row["street"].ToString());
                    dict.Add("property_identifier", row["property_identifier"].ToString());
                    dict.Add("complete_arp_no", row["complete_arp_no"].ToString());
                    dict.Add("property_pin", row["property_pin"].ToString());
                    dict.Add("property_kind", row["property_kind"].ToString());
                    dict.Add("effectivity_quarter", row["effectivity_quarter"].ToString());
                    dict.Add("effectivity_year", row["effectivity_year"].ToString());
                    dict.Add("other_improvements", row["other_improvements"].ToString());
                    dict.Add("assessed_value", row["assessed_value"].ToString());
                    dict.Add("area", row["area"].ToString());
                    dict.Add("lot_no", row["lot_no"].ToString());
                    dict.Add("gr_year", row["gr_year"].ToString());
                    dict.Add("is_taxable", row["is_taxable"].ToString());
                    dict.Add("is_cancelled", row["is_cancelled"].ToString());
                }

                return dict;
            }
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {tableName}";
            var dataTable = new DataTable();
            return _mySqlGenericCommandsLFS.Fill(query, dataTable);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameters = new object[][] { new object[] { "@search_text", DbType.String, $"%{searchText}%" } };
            string query = $"SELECT * FROM {tableName} WHERE street LIKE @search_text OR complete_arp_no LIKE @search_text OR property_pin LIKE @search_text OR lot_no LIKE @search_text";
            var dataTable = new DataTable();
            return _mySqlGenericCommandsLFS.FillBySearch(query, dataTable, parameters);
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(RealPropertiesModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@real_taxpayers_id", DbType.Int32, entity.RealTaxpayersId },
                new object[] { "@barangays_id", DbType.Int32, entity.BarangaysId },
                new object[] { "@classification_codes_id", DbType.Int32, entity.ClassificationCodesId },
                new object[] { "@actual_use_codes_id", DbType.Int32, entity.ActualUseCodesId },
                new object[] { "@taxpayer_tin", DbType.String, entity.TaxpayerTin},
                new object[] { "@taxpayer_name", DbType.String, entity.TaxpayerName},
                new object[] { "@taxpayer_contact_info", DbType.String, entity.TaxpayerContactInfo},
                new object[] { "@taxpayer_address", DbType.String, entity.TaxpayerAddress},
                new object[] { "@street", DbType.String, entity.Street },
                new object[] { "@property_identifier", DbType.String, entity.PropertyIdentifier },
                new object[] { "@complete_arp_no", DbType.String, entity.CompleteArpNo },
                new object[] { "@property_pin", DbType.String, entity.PropertyPin },
                new object[] { "@property_kind", DbType.String, entity.PropertyKind },
                new object[] { "@effectivity_quarter", DbType.Int32, entity.EffectivityQuarter},
                new object[] { "@effectivity_year", DbType.Int32, entity.EffectivityYear },
                new object[] { "@other_improvements", DbType.Decimal, entity.OtherImprovements },
                new object[] { "@assessed_value", DbType.Decimal, entity.AssessedValue },
                new object[] { "@area", DbType.Decimal, entity.Area },
                new object[] { "@lot_no", DbType.String, entity.LotNo },
                new object[] { "@gr_year", DbType.Int32, entity.GrYear },
                new object[] { "@is_taxable", DbType.Boolean, entity.IsTaxable },
                new object[] { "@is_cancelled", DbType.Boolean, entity.IsCancelled },
                new object[] { "@created_by", DbType.Int16, entity.CreatedBy}
            };

            string query = $"INSERT INTO {tableName} (real_taxpayers_id, barangays_id, classification_codes_id, actual_use_codes_id, taxpayer_tin, taxpayer_name, taxpayer_contact_info, taxpayer_address, street, property_identifier, complete_arp_no, property_pin, property_kind, effectivity_quarter, effectivity_year, other_improvements, assessed_value, area, lot_no, gr_year, is_taxable, is_cancelled, created_by) VALUES (@real_taxpayers_id, @barangays_id, @classification_codes_id, @actual_use_codes_id, @taxpayer_tin, @taxpayer_name, @taxpayer_contact_info, @taxpayer_address, @street, @property_identifier, @complete_arp_no, @property_pin, @property_kind, @effectivity_quarter, @effectivity_year, @other_improvements, @assessed_value, @area, @lot_no, @gr_year, @is_taxable, @is_cancelled, @created_by)";

            return _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Update(RealPropertiesModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.Id},
                new object[] { "@real_taxpayers_id", DbType.Int32, entity.RealTaxpayersId },
                new object[] { "@barangays_id", DbType.Int32, entity.BarangaysId },
                new object[] { "@classification_codes_id", DbType.Int32, entity.ClassificationCodesId },
                new object[] { "@actual_use_codes_id", DbType.Int32, entity.ActualUseCodesId },
                new object[] { "@taxpayer_tin", DbType.String, entity.TaxpayerTin},
                new object[] { "@taxpayer_name", DbType.String, entity.TaxpayerName},
                new object[] { "@taxpayer_contact_info", DbType.String, entity.TaxpayerContactInfo},
                new object[] { "@taxpayer_address", DbType.String, entity.TaxpayerAddress},
                new object[] { "@street", DbType.String, entity.Street },
                new object[] { "@property_identifier", DbType.String, entity.PropertyIdentifier },
                new object[] { "@complete_arp_no", DbType.String, entity.CompleteArpNo },
                new object[] { "@property_pin", DbType.String, entity.PropertyPin },
                new object[] { "@property_kind", DbType.String, entity.PropertyKind },
                new object[] { "@effectivity_quarter", DbType.Int32, entity.EffectivityQuarter},
                new object[] { "@effectivity_year", DbType.Int32, entity.EffectivityYear },
                new object[] { "@other_improvements", DbType.Decimal, entity.OtherImprovements },
                new object[] { "@assessed_value", DbType.Decimal, entity.AssessedValue },
                new object[] { "@area", DbType.Decimal, entity.Area },
                new object[] { "@lot_no", DbType.String, entity.LotNo },
                new object[] { "@gr_year", DbType.Int32, entity.GrYear },
                new object[] { "@is_taxable", DbType.Boolean, entity.IsTaxable },
                new object[] { "@is_cancelled", DbType.Boolean, entity.IsCancelled },
                new object[] { "@updated_by", DbType.Int32, entity.UpdatedBy}
            };

            string query = $"UPDATE {tableName} SET real_taxpayers_id = @real_taxpayers_id, barangays_id = @barangays_id, classification_codes_id = @classification_codes_id, actual_use_codes_id = @actual_use_codes_id, taxpayer_tin = @taxpayer_tin, taxpayer_name = @taxpayer_name, taxpayer_contact_info = @taxpayer_contact_info, taxpayer_address = @taxpayer_address, street = @street, property_identifier = @property_identifier, complete_arp_no = @complete_arp_no, property_pin = @property_pin, property_kind = @property_kind, effectivity_quarter = @effectivity_quarter, effectivity_year = @effectivity_year, other_improvements = @other_improvements, assessed_value = @assessed_value, area = @area, lot_no = @lot_no, gr_year = @gr_year, is_taxable = @is_taxable, is_cancelled = @is_cancelled, updated_by = @updated_by WHERE id = @id";

            return _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool CompleteArpNoExist(string completeArpNo)
        {
            var parameters = new object[][]
            {
                new object[] { "@complete_arp_no", DbType.String, completeArpNo}
            };

            string query = $"SELECT id FROM {tableName} WHERE complete_arp_no = @complete_arp_no";
            string result = _mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);

            if (!string.IsNullOrWhiteSpace(result))
                return true;
            return false;
        }

        public bool CompleteArpNoExist(string completeArpNo, int Id)
        {
            var parameters = new object[][]
             {
                new object[] { "@id", DbType.Int32, Id},
                new object[] { "@complete_arp_no", DbType.String, completeArpNo}
             };

            string query = $"SELECT id FROM {tableName} WHERE complete_arp_no = @complete_arp_no AND id <> @id";
            string result = _mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);

            if (!string.IsNullOrWhiteSpace(result))
                return true;
            return false;
        }

        public string GetLastInsertedId()
        {
            string query = $"SELECT MAX(id) FROM {tableName}";
            return _mySqlGenericCommandsLFS.ExecuteScalar(query).ToString();
        }

        public DataTable GetRecordsBy_EffectivivtyYear_Barangay_Search(int effectivityYear, string barangay, string searchText)
        {
            var parameters = new object[][]
            {
                new object[] { "@effectivity_year", DbType.Int32, effectivityYear},
                new object[] { "@barangay_name", DbType.String, barangay},
                new object[] { "@search_text", DbType.String, $"%{searchText}%"}
            };

            string BarangayQuery()
            {
                if (barangay == "All")
                    return string.Empty;
                else
                    return "AND barangay_name = @barangay_name";
            }

            string query = $"SELECT * FROM {tableName} WHERE (owner_name LIKE @search_text OR complete_arp_no LIKE @search_text OR owner_address LIKE @search_text) AND is_cancelled = 0 AND effectivity_year <= @effectivity_year {BarangayQuery()} ORDER BY owner_name ASC";

            var dataTable = new DataTable();
            return _mySqlGenericCommandsLFS.FillBySearch(query, dataTable, parameters);
        }

        public int GetIdByCompleteArpNo(string completeArpNo)
        {
            var parameters = new object[][] { new object[] { "@complete_arp_no", DbType.String, completeArpNo } };
            string query = $"SELECT id FROM {tableName} WHERE complete_arp_no = @complete_arp_no";
            return Convert.ToInt32(_mySqlGenericCommandsLFS.ExecuteScalar(query, parameters));
        }
    }
}