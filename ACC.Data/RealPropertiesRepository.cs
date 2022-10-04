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

            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, Id}
            };

            string query = $"SELECT property_identifier, complete_arp_no, property_pin, barangay_name, municipality_name, province_name, property_kind, effectivity_quarter, effectivity_year, other_improvements, assessed_value, area, lot_no, classification_code, classification_name, actual_use_code, actual_use_name, gr_year, is_taxable, is_cancelled FROM {tableName} WHERE id = @id";


            using (var reader = _mySqlGenericCommandsLFS.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return dict;

                foreach (DataRow row in reader.Rows)
                {
                    dict.Add("property_identifier", row["property_identifier"].ToString());
                    dict.Add("complete_arp_no", row["complete_arp_no"].ToString());
                    dict.Add("property_pin", row["property_pin"].ToString());
                    dict.Add("barangay_name", row["barangay_name"].ToString());
                    dict.Add("municipality_name", row["municipality_name"].ToString());
                    dict.Add("province_name", row["province_name"].ToString());
                    dict.Add("property_kind", row["property_kind"].ToString());
                    dict.Add("effectivity_quarter", row["effectivity_quarter"].ToString());
                    dict.Add("effectivity_year", row["effectivity_year"].ToString());
                    dict.Add("other_improvements", row["other_improvements"].ToString());
                    dict.Add("assessed_value", row["assessed_value"].ToString());
                    dict.Add("area", row["area"].ToString());
                    dict.Add("lot_no", row["lot_no"].ToString());
                    dict.Add("classification_code", row["classification_code"].ToString());
                    dict.Add("classification_name", row["classification_name"].ToString());
                    dict.Add("actual_use_code", row["actual_use_code"].ToString());
                    dict.Add("actual_use_name", row["actual_use_name"].ToString());
                    dict.Add("gr_year", row["gr_year"].ToString());
                    dict.Add("is_taxable", row["is_taxable"].ToString());
                    dict.Add("is_cancelled", row["is_cancelled"].ToString());
                }

                return dict;
            }
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {tableName} ORDER BY owner_name";
            var dataTable = new DataTable();
            return _mySqlGenericCommandsLFS.Fill(query, dataTable);
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
            var parameters = new object[][]
            {
                new object[] { "@taxpayers_id", DbType.Int32, entity.TaxpayersId},
                new object[] { "@property_identifier", DbType.String, entity.PropertyIdentifier},
                new object[] { "@complete_arp_no", DbType.String, entity.CompleteArpNo},
                new object[] { "@property_pin", DbType.String, entity.Pin},
                new object[] { "@barangay_name", DbType.String, entity.BarangayName},
                new object[] { "@municipality_name", DbType.String, entity.MunicipalityName},
                new object[] { "@province_name", DbType.String, entity.ProvinceName },
                new object[] { "@property_kind", DbType.String, entity.PropertyKind},
                new object[] { "@effectivity_quarter", DbType.Int32, entity.EffectivityQuarter},
                new object[] { "@effectivity_year", DbType.Int32, entity.EffectivityYear},
                new object[] { "@other_improvements", DbType.Decimal, entity.OtherImprovements},
                new object[] { "@assessed_value", DbType.Decimal, entity.AssessedValue},
                new object[] { "@area", DbType.Decimal, entity.Area},
                new object[] { "@lot_no", DbType.String, entity.LotNo},
                new object[] { "@classification_code", DbType.String, entity.ClassificationCode},
                new object[] { "@classification_name", DbType.String, entity.ClassificationName},
                new object[] { "@actual_use_code", DbType.String, entity.ActualUseCode},
                new object[] { "@actual_use_name", DbType.String, entity.ActualUseName},
                new object[] { "@gr_year", DbType.Int32, entity.GrYear},
                new object[] { "@is_taxable", DbType.Boolean, entity.IsTaxable},
                new object[] { "@is_cancelled", DbType.Boolean, entity.IsCancelled}
            };

            string query = $"INSERT INTO {tableName} (taxpayers_id, property_identifier, complete_arp_no, property_pin, barangay_name, municipality_name, province_name, property_kind, effectivity_quarter, effectivity_year, other_improvements, assessed_value, area, lot_no, classification_code, classification_name, actual_use_code, actual_use_name, gr_year, is_taxable, is_cancelled) VALUES (@taxpayers_id, @property_identifier, @complete_arp_no, @property_pin, @barangay_name, @municipality_name, @province_name, @property_kind, @effectivity_quarter, @effectivity_year, @other_improvements, @assessed_value, @area, @lot_no, @classification_code, @classification_name, @actual_use_code, @actual_use_name, @gr_year, @is_taxable, @is_cancelled)";




            return _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Update(RealPropertiesModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32,entity.Id},
                new object[] { "@taxpayers_id", DbType.Int32, entity.TaxpayersId},
                new object[] { "@property_identifier", DbType.String, entity.PropertyIdentifier},
                new object[] { "@complete_arp_no", DbType.String, entity.CompleteArpNo},
                new object[] { "@property_pin", DbType.String, entity.Pin},
                new object[] { "@barangay_name", DbType.String, entity.BarangayName},
                new object[] { "@municipality_name", DbType.String, entity.MunicipalityName},
                new object[] { "@province_name", DbType.String, entity.ProvinceName },
                new object[] { "@property_kind", DbType.String, entity.PropertyKind},
                new object[] { "@effectivity_quarter", DbType.Int32, entity.EffectivityQuarter},
                new object[] { "@effectivity_year", DbType.Int32, entity.EffectivityYear},
                new object[] { "@other_improvements", DbType.Decimal, entity.OtherImprovements},
                new object[] { "@assessed_value", DbType.Decimal, entity.AssessedValue},
                new object[] { "@area", DbType.Decimal, entity.Area},
                new object[] { "@lot_no", DbType.String, entity.LotNo},
                new object[] { "@classification_code", DbType.String, entity.ClassificationCode},
                new object[] { "@classification_name", DbType.String, entity.ClassificationName},
                new object[] { "@actual_use_code", DbType.String, entity.ActualUseCode},
                new object[] { "@actual_use_name", DbType.String, entity.ActualUseName},
                new object[] { "@gr_year", DbType.Int32, entity.GrYear},
                new object[] { "@is_taxable", DbType.Boolean, entity.IsTaxable},
                new object[] { "@is_cancelled", DbType.Boolean, entity.IsCancelled}
            };

            string query = $"UPDATE {tableName} SET taxpayers_id = @taxpayers_id, property_identifier = @property_identifier, complete_arp_no = @complete_arp_no, property_pin = @property_pin, barangay_name = @barangay_name, municipality_name = @municipality_name, province_name = @province_name, property_kind = @property_kind, effectivity_quarter = @effectivity_quarter, effectivity_year = @effectivity_year, other_improvements = @other_improvements, assessed_value = @assessed_value, area = @area, lot_no = @lot_no, classification_code = @classification_code, classification_name = @classification_name, actual_use_code = @actual_use_code, actual_use_name = @actual_use_name, gr_year = @gr_year, is_taxable = @is_taxable, is_cancelled = @is_cancelled WHERE id = @id";

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

        public bool SynchronizeData(List<RealPropertiesModel> realPropertiesModels)
        {
            throw new NotImplementedException();
        }

        public string GetLastInsertedId()
        {
            string query = $"SELECT MAX(id) FROM {tableName}";
            return _mySqlGenericCommandsLFS.ExecuteScalar(query).ToString();
        }

        public bool UpdateByArpNo(RealPropertiesModel realPropertiesModel)
        {
            var parameters = new object[][]
            {
                new object[] { "@taxpayers_id", DbType.Int32, realPropertiesModel.TaxpayersId},
                new object[] { "@property_identifier", DbType.String, realPropertiesModel.PropertyIdentifier},
                new object[] { "@complete_arp_no", DbType.String, realPropertiesModel.CompleteArpNo},
                new object[] { "@property_pin", DbType.String, realPropertiesModel.Pin},
                new object[] { "@barangay_name", DbType.String, realPropertiesModel.BarangayName},
                new object[] { "@municipality_name", DbType.String, realPropertiesModel.MunicipalityName},
                new object[] { "@province_name", DbType.String, realPropertiesModel.ProvinceName },
                new object[] { "@property_kind", DbType.String, realPropertiesModel.PropertyKind},
                new object[] { "@effectivity_quarter", DbType.Int32, realPropertiesModel.EffectivityQuarter},
                new object[] { "@effectivity_year", DbType.Int32, realPropertiesModel.EffectivityYear},
                new object[] { "@other_improvements", DbType.Decimal, realPropertiesModel.OtherImprovements},
                new object[] { "@assessed_value", DbType.Decimal, realPropertiesModel.AssessedValue},
                new object[] { "@area", DbType.Decimal, realPropertiesModel.Area},
                new object[] { "@lot_no", DbType.String, realPropertiesModel.LotNo},
                new object[] { "@classification_code", DbType.String, realPropertiesModel.ClassificationCode},
                new object[] { "@classification_name", DbType.String, realPropertiesModel.ClassificationName},
                new object[] { "@actual_use_code", DbType.String, realPropertiesModel.ActualUseCode},
                new object[] { "@actual_use_name", DbType.String, realPropertiesModel.ActualUseName},
                new object[] { "@gr_year", DbType.Int32, realPropertiesModel.GrYear},
                new object[] { "@is_taxable", DbType.Boolean, realPropertiesModel.IsTaxable},
                new object[] { "@is_cancelled", DbType.Boolean, realPropertiesModel.IsCancelled}
            };

            string query = $"UPDATE {tableName} SET  taxpayers_id = @taxpayers_id, property_identifier = @property_identifier, complete_arp_no = @complete_arp_no, property_pin = @property_pin, barangay_name = @barangay_name, municipality_name = @municipality_name, province_name = @province_name, property_kind = @property_kind, effectivity_quarter = @effectivity_quarter, effectivity_year = @effectivity_year, other_improvements = @other_improvements, assessed_value = @assessed_value, area = @area, lot_no = @lot_no, classification_code = @classification_code, classification_name = @classification_name, actual_use_code = @actual_use_code, actual_use_name = @actual_use_name, gr_year = @gr_year, is_taxable = @is_taxable, is_cancelled = @is_cancelled WHERE complete_arp_no = @complete_arp_no";

            return _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
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

        public string GetPropertyIdentifierByCompleteArpNumber(string completeArpNumber)
        {
            var parameters = new object[][] { new object[] {"@complete_arp_no", DbType.String, completeArpNumber} };

            string query = $"SELECT COALESCE(property_identifier, 0) FROM {tableName} WHERE complete_arp_no = @complete_arp_no";


            return _mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);
        }

        public DataTable GetPropertiesByTaxpayerId(int taxPayerId)
        {

            var parameters = new object[][]
            {
                new object[] { "@taxpayer_id", DbType.Int32, taxPayerId }
            };

            string query = $"SELECT id, property_identifier, complete_arp_no, property_pin, barangay_name, municipality_name, province_name, property_kind, effectivity_quarter, effectivity_year, other_improvements, assessed_value, area, lot_no, classification_code, classification_name, actual_use_code, actual_use_name, gr_year, is_taxable, is_cancelled FROM {tableName} WHERE taxpayers_id = @taxpayer_id";

            var dataTable = new DataTable();
            return _mySqlGenericCommandsLFS.FillBySearch(query, dataTable, parameters);
        }
    }
}