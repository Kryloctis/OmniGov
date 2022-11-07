using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using AccountingSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    public class RealPropertiesRepository : IRealPropertiesRepository
    {
        private AccGenericCommands _mySqlGenericCommandsLFS;
        private readonly string tableName = "real_properties";
        private readonly string viewTableName = "view_real_properties";
        private IProvinces _provinces;
        private IMunicipalities _municipalities;
        private IBarangayRepository _barangayRepository;
        private IActualUseCodes _actualUseCodes;
        private IClassificationCodes _classificationCodes;
        private ITaxpayerTypeRepository _taxpayerTypeRepository;
        private ITaxpayersRepository _taxpayersRepository;
        private IRptPreviousAssessment _rptPreviousAssessment;

        public RealPropertiesRepository(AccGenericCommands mySqlGenericCommandsLFS, IProvinces provinces, IMunicipalities municipalities, IBarangayRepository barangayRepository, IActualUseCodes actualUseCodes, IClassificationCodes classificationCodes, ITaxpayerTypeRepository taxpayerTypeRepository, ITaxpayersRepository taxpayersRepository, IRptPreviousAssessment rptPreviousAssessment)
        {
            _mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
            _provinces = provinces;
            _municipalities = municipalities;
            _barangayRepository = barangayRepository;
            _actualUseCodes = actualUseCodes;
            _classificationCodes = classificationCodes;
            _taxpayerTypeRepository = taxpayerTypeRepository;
            _taxpayersRepository = taxpayersRepository;
            _rptPreviousAssessment = rptPreviousAssessment;
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
            string query = $"SELECT * FROM {viewTableName}";
            var dataTable = new DataTable();
            return _mySqlGenericCommandsLFS.Fill(query, dataTable);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameters = new object[][] { new object[] { "@search_text", DbType.String, $"%{searchText}%" } };
            string query = $"SELECT * FROM {viewTableName} WHERE real_taxpayers_name LIKE @search_text OR real_taxpayers_street LIKE @search_text OR complete_arp_no LIKE @search_text OR property_pin LIKE @search_text OR lot_no LIKE @search_text";
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

        public int GetLastInsertedId()
        {
            string query = $"SELECT MAX(id) FROM {tableName}";
            return Convert.ToInt32(_mySqlGenericCommandsLFS.ExecuteScalar(query));
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

        public Dictionary<string, string> GetRecordByCompleteArpNo(string completeArpNo)
        {
            var dict = new Dictionary<string, string>();
            var parameters = new object[][] { new object[] { "@complete_arp_no", DbType.String, completeArpNo } };
            string query = $"SELECT id, real_taxpayers_id, barangays_id, classification_codes_id, actual_use_codes_id, property_identifier, taxpayer_tin, taxpayer_name, taxpayer_contact_info, taxpayer_address, street, complete_arp_no, property_pin, property_kind, effectivity_quarter, effectivity_year, other_improvements, assessed_value, area, lot_no, gr_year, is_taxable, is_cancelled, created_at, created_by, updated_at, updated_by FROM {tableName} WHERE complete_arp_no = @complete_arp_no";

            using (var reader = _mySqlGenericCommandsLFS.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return dict;

                foreach (DataRow row in reader.Rows)
                {
                    dict.Add("id", row["id"].ToString());
                    dict.Add("real_taxpayers_id", row["real_taxpayers_id"].ToString());
                    dict.Add("barangays_id", row["barangays_id"].ToString());
                    dict.Add("classification_codes_id", row["classification_codes_id"].ToString());
                    dict.Add("actual_use_codes_id", row["actual_use_codes_id"].ToString());
                    dict.Add("property_identifier", row["property_identifier"].ToString());
                    dict.Add("taxpayer_tin", row["taxpayer_tin"].ToString());
                    dict.Add("taxpayer_name", row["taxpayer_name"].ToString());
                    dict.Add("taxpayer_contact_info", row["taxpayer_contact_info"].ToString());
                    dict.Add("taxpayer_address", row["taxpayer_address"].ToString());
                    dict.Add("street", row["street"].ToString());
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
                    dict.Add("created_at", row["created_at"].ToString());
                    dict.Add("created_by", row["created_by"].ToString());
                    dict.Add("updated_at", row["updated_at"].ToString());
                    dict.Add("updated_by", row["updated_by"].ToString());
                }

                return dict;
            }
        }

        public bool Synchronize(List<RealPropertiesModel> realPropertiesModels)
        {
            using (var scope = new TransactionScope())
            {
                foreach (RealPropertiesModel realPropertiesModel in realPropertiesModels)
                {
                    int provinceId;
                    int municipalityId;
                    int barangayId;
                    int taxpayerTypeId;
                    int taxpayerId;
                    int actualUseId;
                    int classificationId;
                    int realPropertiesId;


                    ProvincesModel provinceModel = realPropertiesModel.ProvincesModel;
                    MunicipalitiesModel municipalityModel = realPropertiesModel.MunicipalitiesModel;
                    BarangayModel barangayModel = realPropertiesModel.BarangayModel;
                    TaxpayerTypeModel taxpayerTypeModel = realPropertiesModel.TaxpayerTypeModel;
                    TaxpayersModel taxpayersModel = realPropertiesModel.TaxpayersModel;
                    ActualUseCodesModel actualUseModel = realPropertiesModel.ActualUseCodesModel;
                    ClassificationCodesModel classificationModel = realPropertiesModel.ClassificationCodesModel;
                    RptPreviousAssessmentModel rptPreviousAssessmentModel = realPropertiesModel.RptPreviousAssessmentModel;

                    string provinceName = provinceModel.Name;
                    string municipallityName = municipalityModel.Name;
                    string barangayName = barangayModel.Name;
                    string actualUseName = actualUseModel.Name;
                    string classificationName = classificationModel.Name;
                    string taxpayerType = taxpayerTypeModel.taxpayerType;
                    string taxpayerName = taxpayersModel.Name;
                    string completeArpNo = realPropertiesModel.CompleteArpNo;


                    //Actual Use
                    if (_actualUseCodes.NameExist(actualUseName))
                        actualUseId = _actualUseCodes.GetIdByName(actualUseName);
                    else
                    {
                        _ = _actualUseCodes.Insert(actualUseModel);
                        actualUseId = _actualUseCodes.GetLastInsertedId();
                    }

                    //Classification
                    if (_classificationCodes.NameExist(classificationName))
                        classificationId = _classificationCodes.GetIdByName(classificationName);
                    else
                    {
                        _ = _classificationCodes.Insert(classificationModel);
                        classificationId = _classificationCodes.GetLastInsertedId();
                    }

                    //Taxpayer Type
                    if (_taxpayerTypeRepository.NameExist(taxpayerType))
                        taxpayerTypeId = _taxpayerTypeRepository.GetIdByName(taxpayerType);
                    else
                    {
                        _ = _taxpayerTypeRepository.Insert(taxpayerTypeModel);
                        taxpayerTypeId = _taxpayerTypeRepository.GetLastInsertedId();
                    }


                    //Province
                    if (_provinces.NameExist(provinceName))
                        provinceId = _provinces.GetIdByName(provinceName);
                    else
                    {
                        _ = _provinces.Insert(provinceModel);
                        provinceId = _provinces.GetLastInsertedId();
                    }

                    //Municipality
                    if (_municipalities.NameExistByProvinceName(municipallityName, provinceName))
                        municipalityId = _municipalities.GetIdByNameProvinceName(municipallityName, provinceName);
                    else
                    {
                        municipalityModel.ProvincesId = provinceId;
                        _ = _municipalities.Insert(municipalityModel);
                        municipalityId = _municipalities.GetLastInsertedId();
                    }

                    //Barangay
                    if (_barangayRepository.NameExistByMunicipalitiesName_ProvincesName(barangayName, municipallityName, provinceName))
                        barangayId = _barangayRepository.GetIdByName_MunicipalitiesName_ProvincesName(barangayName, municipallityName, provinceName);
                    else
                    {
                        barangayModel.MunicipalityID = municipalityId;
                        _ = _barangayRepository.Insert(barangayModel);
                        barangayId = _barangayRepository.GetLastInsertedId();
                    }

                    //Taxpayers
                    if (_taxpayersRepository.TaxpayerNameExist(taxpayerName))
                    {
                        taxpayerId = _taxpayersRepository.GetIdByName(taxpayerName);
                        var dictTaxpayers = AccFactory.TaxpayersRepository().GetRecordByID(taxpayerId);
                        taxpayersModel.Id = taxpayerId;
                        taxpayersModel.TaxpayerTypeId = taxpayerTypeId;
                        taxpayersModel.IsActive = Convert.ToBoolean(Convert.ToByte(dictTaxpayers["is_active"]));
                        _taxpayersRepository.Update(taxpayersModel);
                    }
                    else
                    {
                        taxpayersModel.TaxpayerTypeId = taxpayerTypeId;
                        taxpayersModel.IsActive = true;
                        _ = _taxpayersRepository.Insert(taxpayersModel);
                        taxpayerId = _taxpayersRepository.GetLastInsertedId();
                    }


                    //Real Properties
                    if (CompleteArpNoExist(completeArpNo))
                    {
                        realPropertiesId = Convert.ToInt32(GetRecordByCompleteArpNo(completeArpNo)["id"]);
                        rptPreviousAssessmentModel.RealPropertiesId = realPropertiesId;
                        var dictRealProperty = GetRecordByCompleteArpNo(realPropertiesModel.PropertyIdentifier);
                        realPropertiesModel.PropertyIdentifier = dictRealProperty.Count < 1 ? string.Empty : dictRealProperty["id"];
                        realPropertiesModel.Id = realPropertiesId;
                        realPropertiesModel.ActualUseCodesId = actualUseId;
                        realPropertiesModel.BarangaysId = barangayId;
                        realPropertiesModel.ClassificationCodesId = classificationId;
                        realPropertiesModel.RealTaxpayersId = taxpayerId;
                        Update(realPropertiesModel);


                        //Delete RPT previous assessment
                        _rptPreviousAssessment.DeleteByRealPropertyId(realPropertiesId);

                        //Insert RPT previous assessment
                        _rptPreviousAssessment.Insert(rptPreviousAssessmentModel);
                    }
                    else
                    {
                        var dictRealProperty = GetRecordByCompleteArpNo(realPropertiesModel.PropertyIdentifier);
                        realPropertiesModel.PropertyIdentifier = dictRealProperty.Count < 1 ? string.Empty : dictRealProperty["id"];
                        realPropertiesModel.ActualUseCodesId = actualUseId;
                        realPropertiesModel.BarangaysId = barangayId;
                        realPropertiesModel.ClassificationCodesId = classificationId;
                        realPropertiesModel.RealTaxpayersId = taxpayerId;
                        Insert(realPropertiesModel);
                        realPropertiesId = GetLastInsertedId();

                        //Insert RPT previous assessment
                        rptPreviousAssessmentModel.RealPropertiesId = realPropertiesId;
                        _rptPreviousAssessment.Insert(rptPreviousAssessmentModel);
                    }


                }

                scope.Complete();
                return true;
            }
        }
    }
}