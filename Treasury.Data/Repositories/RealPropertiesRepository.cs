using OmniGov.Core.Entities;
using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Core.Interfaces.Services;
using OmniGov.Core.Interfaces.Factories;
using OmniGov.Core.Repositories;
using OmniGov.Core.Services;
using System.Data;
using System.Transactions;
using Treasury.Domain.Entities;
using Treasury.Domain.Interfaces;
using Treasury.Data.Factories;

namespace Treasury.Data.Repositories
{
    public class RealPropertiesRepository : IRealPropertiesRepository
    {
        private GenericCommands mySqlGenericCommands;
        private readonly string tableName = "real_properties";
        private readonly string viewTableName = "view_real_properties";
        private IProvinces provinces;
        private IMunicipalities municipalities;
        private IBarangayRepository barangayRepository;
        private IActualUseCodes actualUseCodes;
        private IClassificationCodes classificationCodes;
        private ITaxpayerTypeRepository taxpayerTypeRepository;
        private ITaxpayersRepository taxpayersRepository;
        private IRptPreviousAssessment rptPreviousAssessment;

        public RealPropertiesRepository(GenericCommands mySqlGenericCommands,
                                        IProvinces provinces,
                                        IMunicipalities municipalities,
                                        IBarangayRepository barangayRepository,
                                        IActualUseCodes actualUseCodes,
                                        IClassificationCodes classificationCodes,
                                        ITaxpayerTypeRepository taxpayerTypeRepository,
                                        ITaxpayersRepository taxpayersRepository,
                                        IRptPreviousAssessment rptPreviousAssessment)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
            this.provinces = provinces;
            this.municipalities = municipalities;
            this.barangayRepository = barangayRepository;
            this.actualUseCodes = actualUseCodes;
            this.classificationCodes = classificationCodes;
            this.taxpayerTypeRepository = taxpayerTypeRepository;
            this.taxpayersRepository = taxpayersRepository;
            this.rptPreviousAssessment = rptPreviousAssessment;
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
                    _ = mySqlGenericCommands.ExecuteNonQuery(query, parameters);
                }

                scope.Complete();
                return true;
            }
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var recordDictionary = new Dictionary<string, string>();
            var parameters = new object[][] { new object[] { "@real_property_id", DbType.Int32, Id } };

            string query = $"SELECT * FROM {tableName} WHERE id = @real_property_id";

            DataTable dataTable = mySqlGenericCommands.ExecuteReader(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                foreach (DataColumn column in dataTable.Columns)
                    recordDictionary[column.ColumnName] = row[column].ToString();

                return recordDictionary;
            }
            return recordDictionary;
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {tableName}";
            var dataTable = new DataTable();
            return mySqlGenericCommands.Fill(query, dataTable);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameters = new object[][] { new object[] { "@search_text", DbType.String, $"%{searchText}%" } };
            string query = $"SELECT * FROM {viewTableName} WHERE taxpayer_name LIKE @search_text OR complete_arp_no LIKE @search_text OR property_pin LIKE @search_text OR lot_no LIKE @search_text";
            var dataTable = new DataTable();
            return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(RealPropertiesModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@taxpayers_id", DbType.Int32, entity.TaxpayersModel.Id },
                new object[] { "@barangays_id", DbType.Int32, entity.BarangayModel.Id },
                new object[] { "@classification_codes_id", DbType.Int32, entity.ClassificationCodesModel.Id },
                new object[] { "@actual_use_codes_id", DbType.Int32, entity.ActualUseCodesModel.Id },
                new object[] { "@street", DbType.String, entity.Street },
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

            string query = $"INSERT INTO {tableName} (taxpayers_id, barangays_id, classification_codes_id, actual_use_codes_id, street, complete_arp_no, property_pin, property_kind, effectivity_quarter, effectivity_year, other_improvements, assessed_value, area, lot_no, gr_year, is_taxable, is_cancelled, created_by) VALUES (@taxpayers_id, @barangays_id, @classification_codes_id, @actual_use_codes_id, @street, @complete_arp_no, @property_pin, @property_kind, @effectivity_quarter, @effectivity_year, @other_improvements, @assessed_value, @area, @lot_no, @gr_year, @is_taxable, @is_cancelled, @created_by)";

            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(RealPropertiesModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.Id},
                new object[] { "@taxpayers_id", DbType.Int32, entity.TaxpayersModel.Id },
                new object[] { "@barangays_id", DbType.Int32, entity.BarangayModel.Id },
                new object[] { "@classification_codes_id", DbType.Int32, entity.ClassificationCodesModel.Id },
                new object[] { "@actual_use_codes_id", DbType.Int32, entity.ActualUseCodesModel.Id },
                new object[] { "@street", DbType.String, entity.Street },
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

            string query = $"UPDATE {tableName} SET taxpayers_id = @taxpayers_id, barangays_id = @barangays_id, classification_codes_id = @classification_codes_id, actual_use_codes_id = @actual_use_codes_id, street = @street, complete_arp_no = @complete_arp_no, property_pin = @property_pin, property_kind = @property_kind, effectivity_quarter = @effectivity_quarter, effectivity_year = @effectivity_year, other_improvements = @other_improvements, assessed_value = @assessed_value, area = @area, lot_no = @lot_no, gr_year = @gr_year, is_taxable = @is_taxable, is_cancelled = @is_cancelled, updated_by = @updated_by WHERE id = @id;";

            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool CompleteArpNoExist(string completeArpNo)
        {
            var parameters = new object[][]
            {
                new object[] { "@complete_arp_no", DbType.String, completeArpNo}
            };

            string query = $"SELECT id FROM {tableName} WHERE complete_arp_no = @complete_arp_no";
            string result = mySqlGenericCommands.ExecuteScalar(query, parameters);

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
            string result = mySqlGenericCommands.ExecuteScalar(query, parameters);

            if (!string.IsNullOrWhiteSpace(result))
                return true;
            return false;
        }

        public int GetLastInsertedId(int userId)
        {
            var parameters = new object[][]
            {
                new object[] {"@created_by", DbType.Int32, userId }
            };

            string query = $"SELECT MAX(id) FROM {tableName} WHERE created_by = @created_by";
            return Convert.ToInt32(mySqlGenericCommands.ExecuteScalar(query, parameters));
        }

        public DataTable GetRecordsBy_EffectivivtyYear_Barangay_Search(int effectivityYear, string barangay, string searchText, int rowFilter)
        {
            var parameters = new object[][]
            {
                new object[] { "@effectivity_year", DbType.Int32, effectivityYear},
                new object[] { "@barangay_name", DbType.String, barangay},
                new object[] { "@search_text", DbType.String, $"%{searchText}%"},
                new object[] { "@row_filter", DbType.Int32, rowFilter}
            };

            string query = $"SELECT * FROM {viewTableName} WHERE barangay_name = @barangay_name AND (taxpayer_name LIKE @search_text OR complete_arp_no LIKE @search_text) AND is_cancelled = 0 AND effectivity_year <= @effectivity_year ORDER BY taxpayer_name ASC LIMIT @row_filter";

            var dataTable = new DataTable();
            return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }

        public Dictionary<string, string> GetViewRecordByCompleteArpNo(string completeArpNo)
        {
            var recordDictionary = new Dictionary<string, string>();
            var parameters = new object[][] { new object[] { "@complete_arp_no", DbType.String, completeArpNo } };
            string query = $"SELECT * FROM {viewTableName} WHERE complete_arp_no = @complete_arp_no";

            DataTable dataTable = mySqlGenericCommands.ExecuteReader(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                foreach (DataColumn column in dataTable.Columns)
                    recordDictionary[column.ColumnName] = row[column].ToString();

                return recordDictionary;
            }
            return recordDictionary;
        }

        public bool Synchronize(RealPropertiesModel realPropertiesModel)
        {
            using (var scope = new TransactionScope())
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
                //RptPreviousAssessmentModel rptPreviousAssessmentModel = realPropertiesModel.RptPreviousAssessmentModels;

                string provinceName = provinceModel.Name;
                string municipallityName = municipalityModel.Name;
                string barangayName = barangayModel.Name;
                string actualUseName = actualUseModel.Name;
                string classificationName = classificationModel.Name;
                string taxpayerType = taxpayerTypeModel.taxpayerType;
                string taxpayerName = taxpayersModel.Name;
                string completeArpNo = realPropertiesModel.CompleteArpNo;

                //Actual Use
                if (actualUseCodes.NameExist(actualUseName))
                    actualUseId = actualUseCodes.GetIdByName(actualUseName);
                else
                {
                    _ = actualUseCodes.Insert(actualUseModel);
                    actualUseId = actualUseCodes.GetLastInsertedId();
                }

                //Classification
                if (classificationCodes.NameExist(classificationName))
                    classificationId = classificationCodes.GetIdByName(classificationName);
                else
                {
                    _ = classificationCodes.Insert(classificationModel);
                    classificationId = classificationCodes.GetLastInsertedId();
                }

                //Taxpayer Type
                if (taxpayerTypeRepository.NameExist(taxpayerType))
                    taxpayerTypeId = taxpayerTypeRepository.GetIdByName(taxpayerType);
                else
                {
                    _ = taxpayerTypeRepository.Insert(taxpayerTypeModel);
                    taxpayerTypeId = taxpayerTypeRepository.GetLastInsertedId();
                }

                //Province
                if (provinces.NameExist(provinceName))
                    provinceId = provinces.GetIdByName(provinceName);
                else
                {
                    _ = provinces.Insert(provinceModel);
                    provinceId = provinces.GetLastInsertedId();
                }

                //Municipality
                if (municipalities.NameExistByProvinceName(municipallityName, provinceName))
                    municipalityId = municipalities.GetIdByNameProvinceName(municipallityName, provinceName);
                else
                {
                    municipalityModel.ProvincesId = provinceId;
                    _ = municipalities.Insert(municipalityModel);
                    municipalityId = municipalities.GetLastInsertedId();
                }

                //Barangay
                if (barangayRepository.NameExistByMunicipalitiesName_ProvincesName(barangayName, municipallityName, provinceName))
                    barangayId = barangayRepository.GetIdByName_MunicipalitiesName_ProvincesName(barangayName, municipallityName, provinceName);
                else
                {
                    barangayModel.MunicipalityId = municipalityId;
                    _ = barangayRepository.Insert(barangayModel);
                    barangayId = barangayRepository.GetLastInsertedId();
                }

                //Taxpayers
                if (taxpayersRepository.TaxpayerNameExist(taxpayerName))
                {
                    taxpayerId = taxpayersRepository.GetIdByName(taxpayerName);
                    var dictTaxpayers = TreasuryFactory.TaxpayersRepository().GetRecordByID(taxpayerId);
                    taxpayersModel.Id = taxpayerId;
                    taxpayersModel.TaxpayerTypeId = taxpayerTypeId;
                    taxpayersModel.IsActive = Convert.ToBoolean(Convert.ToByte(dictTaxpayers["is_active"]));
                    taxpayersRepository.Update(taxpayersModel);
                }
                else
                {
                    taxpayersModel.TaxpayerTypeId = taxpayerTypeId;
                    taxpayersModel.IsActive = true;
                    _ = taxpayersRepository.Insert(taxpayersModel);
                    taxpayerId = taxpayersRepository.GetLastInsertedId(null);
                }

                //Real Properties
                if (CompleteArpNoExist(completeArpNo))
                {
                    realPropertiesId = Convert.ToInt32(GetViewRecordByCompleteArpNo(completeArpNo)["id"]);
                    //rptPreviousAssessmentModel.RealPropertiesId = realPropertiesId;

                    realPropertiesModel.Id = realPropertiesId;
                    realPropertiesModel.ActualUseCodesModel.Id = actualUseId;
                    realPropertiesModel.BarangayModel.Id = barangayId;
                    realPropertiesModel.ClassificationCodesModel.Id = classificationId;
                    realPropertiesModel.TaxpayersModel.Id = taxpayerId;
                    realPropertiesModel.UpdatedAt = DateTime.Now;
                    Update(realPropertiesModel);

                    //Delete RPT previous assessment
                    rptPreviousAssessment.DeleteByRealPropertyId(realPropertiesId);

                    //Insert RPT previous assessment
                    //rptPreviousAssessment.Insert(rptPreviousAssessmentModel);
                }
                else
                {
                    realPropertiesModel.ActualUseCodesModel.Id = actualUseId;
                    realPropertiesModel.BarangayModel.Id = barangayId;
                    realPropertiesModel.ClassificationCodesModel.Id = classificationId;
                    realPropertiesModel.TaxpayersModel.Id = taxpayerId;
                    Insert(realPropertiesModel);
                    realPropertiesId = GetLastInsertedId(0);

                    //Update property identifier
                    realPropertiesModel.Id = realPropertiesId;
                    realPropertiesModel.UpdatedBy = null;
                    realPropertiesModel.UpdatedAt = null;
                    Update(realPropertiesModel);

                    //Insert RPT previous assessment
                    //rptPreviousAssessmentModel.RealPropertiesId = realPropertiesId;
                    //rptPreviousAssessment.Insert(rptPreviousAssessmentModel);
                }

                scope.Complete();
                return true;
            }
        }

        public DataTable GetRecordsBySearch(string searchText, int rowFilter, bool showCancelled)
        {
            var parameters = new object[][]
            {
                new object[] {"@search_text", DbType.String, $"%{searchText}%"},
                new object[] {"@is_cancelled", DbType.Boolean, showCancelled},
                new object[] {"@row_filter", DbType.Int32, rowFilter},
            };

            string subQuery = showCancelled ? string.Empty : "AND is_cancelled = @is_cancelled";
            string query = $"SELECT * FROM {viewTableName} WHERE (taxpayer_name LIKE @search_text OR representative_name LIKE @search_text OR complete_arp_no LIKE @search_text OR property_pin LIKE @search_text OR lot_no LIKE @search_text) {subQuery} ORDER BY complete_arp_no LIMIT @row_filter";

            var dataTable = new DataTable();
            return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }

        public DataTable GetRecordNotExistedPreviousRpt(int rptId)
        {
            var parameters = new object[][]
            {
                new object[] {"@real_property_id", DbType.Int32, rptId}
            };

            string query = $"SELECT * FROM {viewTableName} WHERE  NOT EXISTS(SELECT {rptPreviousAssessment.tableName}.real_properties_id FROM {rptPreviousAssessment.tableName} WHERE {rptPreviousAssessment.tableName}.real_properties_id = {viewTableName}.real_property_id) AND real_property_id <> @real_property_id";

            var dataTable = new DataTable();
            return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }

        public DataTable GetRecordNotExistedPreviousRpt()
        {
            string query = $"SELECT * FROM {viewTableName} WHERE NOT EXISTS(SELECT {rptPreviousAssessment.tableName}.real_properties_id FROM {rptPreviousAssessment.tableName} WHERE {rptPreviousAssessment.tableName}.real_properties_id = {viewTableName}.real_property_id)";

            var dataTable = new DataTable();
            return mySqlGenericCommands.FillBySearch(query, dataTable); ;
        }

        public Dictionary<string, string> GetViewRecordById(int Id)
        {
            var recordDictionary = new Dictionary<string, string>();
            var parameters = new object[][] { new object[] { "@real_property_id", DbType.Int32, Id } };

            string query = $"SELECT * FROM {viewTableName} WHERE real_property_id = @real_property_id";

            DataTable dataTable = mySqlGenericCommands.ExecuteReader(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                foreach (DataColumn column in dataTable.Columns)
                    recordDictionary[column.ColumnName] = row[column].ToString();

                return recordDictionary;
            }
            return recordDictionary;
        }

        public bool InsertWithPreviousAssessments(RealPropertiesModel realPropertiesModel)
        {
            using (var scope = new TransactionScope())
            {
                Insert(realPropertiesModel);

                var rptId = GetLastInsertedId(realPropertiesModel.CreatedBy);

                foreach (var model in realPropertiesModel.RptPreviousAssessmentModels)
                {
                    model.RealPropertiesId = rptId;
                    _ = rptPreviousAssessment.Insert(model);
                }

                scope.Complete();
                return true;
            }
        }

        public bool UpdateWithPreviousAssessements(RealPropertiesModel realPropertiesModel)
        {
            using (var scope = new TransactionScope())
            {
                Update(realPropertiesModel);
                _ = rptPreviousAssessment.DeleteByRealPropertyId(realPropertiesModel.Id);

                foreach (var model in realPropertiesModel.RptPreviousAssessmentModels)
                {
                    model.RealPropertiesId = realPropertiesModel.Id;
                    _ = rptPreviousAssessment.Insert(model);
                }

                scope.Complete();
                return true;
            }
        }

        public DataTable GetViewRecords()
        {
            string query = $"SELECT * FROM {viewTableName}";
            return mySqlGenericCommands.Fill(query, new DataTable());
        }

        public DataTable GetViewRecordsByKind(char propertyKind)
        {
            var parameters = new object[][]
            {
                new object[] { "@property_kind", DbType.String, propertyKind},
            };

            string query = $"SELECT * FROM {viewTableName} WHERE property_kind = @property_kind";
            return mySqlGenericCommands.FillBySearch(query, new DataTable(), parameters);
        }

        public DataTable GetPropertiesByOwnerId(int taxPayerId)
        {
            var parameters = new object[][]
            {
                new object[] { "@taxpayers_id", DbType.Int32, taxPayerId},
            };

            string query = $"SELECT * FROM {viewTableName} WHERE taxpayers_id = @taxpayers_id";
            var dataTable = new DataTable();
            return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }
    }
}

