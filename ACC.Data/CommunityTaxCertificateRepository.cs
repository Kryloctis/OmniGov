using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace ACC.Data
{
    internal class CommunityTaxCertificateRepository : ICommunityTaxCertificateRepository
    {
        private AccGenericCommands mySqlGenericCommandsLFS;
        private readonly string tableName = "community_tax_certificate";

        public CommunityTaxCertificateRepository(AccGenericCommands mySqlGenericCommandsLFS)
        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
        }

        public bool Delete(List<CommunityTaxCertificateModel> entityList)
        {
            throw new System.NotImplementedException();
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetRecords()
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new System.NotImplementedException();
        }

        public bool IdExist(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(CommunityTaxCertificateModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@payment_collections_id", DbType.String, entity.PaymentCollectionsId},
                new object[] { "@year", DbType.Int32, entity.Year},
                new object[] { "@place_of_issued", DbType.String, entity.PlaceOfIssued},
                new object[] { "@date_issued", DbType.Date, entity.DateOfIssued},
                new object[] { "@first_name", DbType.String, entity.FirstName},
                new object[] { "@middle_name", DbType.String, entity.MiddleName},
                new object[] { "@last_name", DbType.String, entity.LastName},
                new object[] { "@sex", DbType.Int16, entity.Sex},
                new object[] { "@citizenship", DbType.String, entity.Citizenship},
                new object[] { "@address", DbType.String, entity.Address},
                new object[] { "@tin", DbType.String, entity.TIN},
                new object[] { "@icr_no", DbType.String, entity.ICR},
                new object[] { "@place_of_birth", DbType.String, entity.PlaceOfBirth},
                new object[] { "@height", DbType.Decimal, entity.Height},
                new object[] { "@weight", DbType.Decimal, entity.Weight},
                new object[] { "@civil_status", DbType.String, entity.CivilStatus},
                new object[] { "@date_of_birth", DbType.Date, entity.DateOfBirth},
                new object[] { "@profession_occupation_business", DbType.String, entity.Profession},
                new object[] { "@basic_community_tax", DbType.Decimal, entity.BasicCommunityTax},
                new object[] { "@additional_community_tax", DbType.Decimal, entity.AdditionalCommunityTax},
                new object[] { "@created_by", DbType.Int32, entity.CreatedBy},
            };

            string query = $"INSERT INTO {tableName} (payment_collections_id, year, place_of_issued, date_issued,  first_name, middle_name, last_name, sex, citizenship, address, tin, icr_no, place_of_birth, height, weight, civil_status, date_of_birth, profession_occupation_business, basic_community_tax, additional_community_tax, created_by) VALUES (@payment_collections_id, @year, @place_of_issued, @date_issued, @first_name, @middle_name, @last_name, @sex, @citizenship, @address, @tin, @icr_no, @place_of_birth, @height, @weight, @civil_status, @date_of_birth, @profession_occupation_business,  @basic_community_tax, @additional_community_tax,  @created_by)";
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Update(CommunityTaxCertificateModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}