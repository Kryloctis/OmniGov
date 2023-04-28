using ACC.Data;
using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;
using System.Transactions;
using System.Xml.XPath;

namespace AccountingSystem
{
    public class MarriageLicenseRepository : IMarriageLicenseRepository
    {

        private readonly IAccGenericCommands _dbGenericCommands;
        private readonly string tableName = "marriage_license";

        public MarriageLicenseRepository(IAccGenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
        }

        public int CountRecords()
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(List<MarriageLicenseModel> entityList)
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

        public bool Insert(MarriageLicenseModel entity)
        {
            throw new System.NotImplementedException();
        }

        public bool InsertWithMarriageLicensePayment(PaymentCollectionHasChequesModel paymentCollectionHasChequesModel, PaymentCollectionsModel paymentCollectionsModel, MarriageLicenseModel marriageLicenseModel)
        {
                var parameters = new object[][]
                   {
                        new object[] { "@issued_on", DbType.DateTime, marriageLicenseModel.IssuedOn},
                        new object[] { "@register_no", DbType.String, marriageLicenseModel.RegisterNo},
                        new object[] { "@published_on", DbType.DateTime, marriageLicenseModel.PublishedOn},
                        new object[] { "@husband_name", DbType.String, marriageLicenseModel.HusbandName},
                        new object[] { "@husband_age", DbType.Int32, marriageLicenseModel.HusbandAge},
                        new object[] { "@husband_months", DbType.Int32, marriageLicenseModel.HusbandMonth},
                        new object[] { "@husband_street", DbType.String, marriageLicenseModel.HusbandStreet},
                        new object[] { "@husband_barangay", DbType.String, marriageLicenseModel.HusbandBarangay},
                        new object[] { "@husband_municipality", DbType.String, marriageLicenseModel.HusbandMunipality},
                        new object[] { "@husband_province", DbType.String, marriageLicenseModel.HusbandProvince},
                        new object[] { "@wife_name", DbType.String, marriageLicenseModel.WifeName},
                        new object[] { "@wife_months", DbType.Int32, marriageLicenseModel.WifeMonth},
                        new object[] { "@wife_age", DbType.Int32, marriageLicenseModel.WifeAge},
                        new object[] { "@wife_street", DbType.String, marriageLicenseModel.WifeStreet},
                        new object[] { "@wife_barangay", DbType.String, marriageLicenseModel.WifeBarangay},
                        new object[] { "@wife_municipality", DbType.String, marriageLicenseModel.WifeMunicipality},
                        new object[] { "@wife_province", DbType.String, marriageLicenseModel.WifeProvince},
                        new object[] { "@created_at", DbType.DateTime, marriageLicenseModel.IssuedOn},
                        new object[] { "@created_by", DbType.Int32, marriageLicenseModel.CreatedBy}
                   };

                string query = $"INSERT INTO {tableName} (issued_on, register_no, published_on, husband_name, husband_age, husband_months, husband_street, husband_barangay, husband_municipality, husband_province, wife_name, wife_months, wife_age, wife_street, wife_barangay, wife_municipality, wife_province, created_at, created_by) VALUES(@issued_on, @register_no, @published_on, @husband_name, @husband_age, @husband_months, @husband_street, @husband_barangay, @husband_municipality, @husband_province, @wife_name, @wife_months, @wife_age, @wife_street, @wife_barangay, @wife_municipality, @wife_province, @created_at, @created_by)";


                bool result = _dbGenericCommands.ExecuteNonQuery(query, parameters);
                return result;
        }

        public bool Update(MarriageLicenseModel entity)
                //    return true;
        {
            throw new System.NotImplementedException();
        }
    }
}