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
        private IProvinces _provinces;
        private IMunicipalities _municipalities;
        private IBarangayRepository _barangayRepository;
        private ITaxpayersRepository _taxpayersRepository;
        private readonly string tableName = "real_properties";

        public RealPropertiesRepository(MySqlGenericCommands mySqlGenericCommandsLFS, ITaxpayersRepository taxpayersRepository, IProvinces provinces, IMunicipalities municipalities, IBarangayRepository barangayRepository)
        {
            _municipalities = municipalities;
            _barangayRepository = barangayRepository;
            _mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
            _provinces = provinces;
            _taxpayersRepository = taxpayersRepository;
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

            string query = $"SELECT taxpayers_id, barangays_id, classification_codes_id, actual_use_codes_id, street, property_identifier, complete_arp_no, property_pin, property_kind, effectivity_quarter, effectivity_year, other_improvements, assessed_value, area, lot_no, gr_year, is_taxable, is_cancelled FROM {tableName} WHERE id = @id";


            using (var reader = _mySqlGenericCommandsLFS.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return dict;

                foreach (DataRow row in reader.Rows)
                {
                    dict.Add("taxpayers_id", row["taxpayers_id"].ToString());
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
                new object[] { "@taxpayers_id", DbType.Int32, entity.TaxpayersId },
                new object[] { "@barangays_id", DbType.Int32, entity.BarangaysId },
                new object[] { "@classification_codes_id", DbType.Int32, entity.ClassificationCodesId },
                new object[] { "@actual_use_codes_id", DbType.Int32, entity.ActualUseCodesId },
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
                new object[] { "@is_cancelled", DbType.Boolean, entity.IsCancelled }
            };

            string query = $"INSERT INTO {tableName} (taxpayers_id, barangays_id, classification_codes_id, actual_use_codes_id, street, property_identifier, complete_arp_no, property_pin, property_kind, effectivity_quarter, effectivity_year, other_improvements, assessed_value, area, lot_no, gr_year, is_taxable, is_cancelled) VALUES (@taxpayers_id, @barangays_id, @classification_codes_id, @actual_use_codes_id, @street, @property_identifier, @complete_arp_no, @property_pin, @property_kind, @effectivity_quarter, @effectivity_year, @other_improvements, @assessed_value, @area, @lot_no, @gr_year, @is_taxable, @is_cancelled)";

            return _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Update(RealPropertiesModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.Id},
                new object[] { "@taxpayers_id", DbType.Int32, entity.TaxpayersId },
                new object[] { "@barangays_id", DbType.Int32, entity.BarangaysId },
                new object[] { "@classification_codes_id", DbType.Int32, entity.ClassificationCodesId },
                new object[] { "@actual_use_codes_id", DbType.Int32, entity.ActualUseCodesId },
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
                new object[] { "@is_cancelled", DbType.Boolean, entity.IsCancelled }
            };

            string query = $"UPDATE {tableName} SET taxpayers_id = @taxpayers_id, barangays_id = @barangays_id, classification_codes_id = @classification_codes_id, actual_use_codes_id = @actual_use_codes_id, street = @street, property_identifier = @property_identifier, complete_arp_no = @complete_arp_no, property_pin = @property_pin, property_kind = @property_kind, effectivity_quarter = @effectivity_quarter, effectivity_year = @effectivity_year, other_improvements = @other_improvements, assessed_value = @assessed_value, area = @area, lot_no = @lot_no, gr_year = @gr_year, is_taxable = @is_taxable, is_cancelled = @is_cancelled WHERE id = @id";

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

        public bool SynchronizeData(List<RealPropertiesModel> realPropertiesModels, List<ProvincesModel> provincesModels)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var provincesModel in provincesModels)
                {
                    int provincesId;
                    string provincesName = provincesModel.Name;

                    //Province

                    if (!_provinces.NameExist(provincesName))
                    {
                        _provinces.Insert(provincesModel);
                        provincesId = _provinces.GetLastInsertedId();
                    }
                    else
                    {
                        provincesId = _provinces.GetIdByName(provincesName);
                    }

                    //Municipality
                    int municipalitiesId;
                    string municipalitiesName = provincesModel.MunicipalitiesModel.Name;
                    provincesModel.MunicipalitiesModel.ProvincesId = provincesId;

                    if (!_municipalities.NameExistByProvinceName(municipalitiesName, provincesName))
                    {
                        _municipalities.Insert(provincesModel.MunicipalitiesModel);
                        municipalitiesId = _municipalities.GetLastInsertedId();
                    }
                    else
                    {
                        municipalitiesId = _municipalities.GetIdByNameProvinceName(municipalitiesName, provincesName);
                    }

                    //Barangay
                    string barangaysName = provincesModel.MunicipalitiesModel.BarangayModel.Name;
                    provincesModel.MunicipalitiesModel.BarangayModel.MunicipalityID = municipalitiesId;

                    if (!_barangayRepository.NameExistByMunicipalitiesName_ProvincesName(barangaysName, municipalitiesName, provincesName))
                        _barangayRepository.Insert(provincesModel.MunicipalitiesModel.BarangayModel);
                    continue;
                }


                foreach (var realPropertiesModel in realPropertiesModels)
                {
                    string completeArpNo = realPropertiesModel.CompleteArpNo;


                    if (!CompleteArpNoExist(completeArpNo))
                        Insert(realPropertiesModel);
                    else
                        Update(realPropertiesModel);
                }


                scope.Complete();
                return true;
            }
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
    }
}