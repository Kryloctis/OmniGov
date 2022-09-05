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
            throw new NotImplementedException();
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {tableName}";
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
                new object[] { "@property_identifier", DbType.String, entity.PropertyIdentifier},
                new object[] { "@complete_arp_no", DbType.String, entity.CompleteArpNo},
                new object[] { "@property_pin", DbType.String, entity.Pin},
                new object[] { "@owner_name", DbType.String, entity.OwnerName},
                new object[] { "@owner_tin", DbType.String, entity.OwnerTin},
                new object[] { "@owner_address", DbType.String, entity.OwnerAddress},
                new object[] { "@owner_contact", DbType.String, entity.OwnerContact},
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

            string query = $"INSERT INTO {tableName} (property_identifier, complete_arp_no, property_pin, owner_name, owner_tin, owner_address, owner_contact, barangay_name, municipality_name, province_name, property_kind, effectivity_quarter, effectivity_year, other_improvements, assessed_value, area, lot_no, classification_code, classification_name, actual_use_code, actual_use_name, gr_year, is_taxable, is_cancelled) VALUES (@property_identifier, @complete_arp_no, @property_pin, @owner_name, @owner_tin, @owner_address, @owner_contact, @barangay_name, @municipality_name, @province_name, @property_kind, @effectivity_quarter, @effectivity_year, @other_improvements, @assessed_value, @area, @lot_no, @classification_code, @classification_name, @actual_use_code, @actual_use_name, @gr_year, @is_taxable, @is_cancelled)";

            return _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Update(RealPropertiesModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@property_identifier", DbType.String, entity.PropertyIdentifier},
                new object[] { "@complete_arp_no", DbType.String, entity.CompleteArpNo},
                new object[] { "@property_pin", DbType.String, entity.Pin},
                new object[] { "@owner_name", DbType.String, entity.OwnerName},
                new object[] { "@owner_tin", DbType.String, entity.OwnerTin},
                new object[] { "@owner_address", DbType.String, entity.OwnerAddress},
                new object[] { "@owner_contact", DbType.String, entity.OwnerContact},
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

            string query = $"UPDATE {tableName} SET property_identifier = @property_identifier, complete_arp_no = @complete_arp_no, property_pin = @property_pin, owner_name = @owner_name, owner_tin = @owner_tin, owner_address = @owner_address, owner_contact = @owner_contact, barangay_name = @barangay_name, municipality_name = @municipality_name, province_name = @province_name, property_kind = @property_kind, effectivity_quarter = @effectivity_quarter, effectivity_year = @effectivity_year, other_improvements = @other_improvements, assessed_value = @assessed_value, area = @area, lot_no = @lot_no, classification_code = @classification_code, classification_name = @classification_name, actual_use_code = @actual_use_code, actual_use_name = @actual_use_name, gr_year = @gr_year, is_taxable = @is_taxable, is_cancelled = @is_cancelled WHERE complete_arp_no = @complete_arp_no";

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
            using (var scope = new TransactionScope())
            {
                foreach (RealPropertiesModel realPropertiesModel in realPropertiesModels)
                {
                    bool arpExist = CompleteArpNoExist(realPropertiesModel.CompleteArpNo);

                    if (arpExist)
                        Update(realPropertiesModel);
                    else
                        Insert(realPropertiesModel);
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
    }
}