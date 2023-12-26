using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    public class MarriageLicenseRepository : IMarriageLicenseRepository
    {
        private readonly string tableName = "marriage_license";
        private AccGenericCommands mySqlGenericCommandsLFS;

        public MarriageLicenseRepository(AccGenericCommands mySqlGenericCommandsLFS)
        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
        }

        public int CountRecords()
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(List<MarriageLicenseModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var marriageLicenseModel in entityList)
                {
                    var parameters = new object[][] { new object[] { "@id", DbType.Int32, marriageLicenseModel.Id } };
                    string query = $"DELETE FROM {tableName} WHERE id = @id";
                    _ = mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
                }

                scope.Complete();
                return true;
            }
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
            var parameters = new object[][]
            {
                new object[] { "@payment_collections_id", DbType.Int32, entity.PaymentCollectionsModel.Id},
                new object[] { "@registry_no", DbType.String, entity.RegistryNo},
                new object[] { "@marriage_license_no", DbType.String, entity.MarriageLicenseNo},
                new object[] { "@date_issued", DbType.DateTime, entity.DateIssued},
                new object[] { "@date_published", DbType.DateTime, entity.DatePublished},
                new object[] { "@groom_registry_id", DbType.Int32, entity.GroomRegistry.Id},
                new object[] { "@groom_age", DbType.Int32, entity.GroomAge},
                new object[] { "@groom_months", DbType.Int32, entity.GroomMonths},
                new object[] { "@groom_religion", DbType.String, entity.GroomReligion},
                new object[] { "@groom_residence", DbType.String, entity.GroomResidence},
                new object[] { "@bride_registry_id", DbType.Int32, entity.BrideRegistry.Id},
                new object[] { "@bride_age", DbType.Int32, entity.BrideAge},
                new object[] { "@bride_months", DbType.Int32, entity.BrideMonths},
                new object[] { "@bride_religion", DbType.String, entity.BrideReligion},
                new object[] { "@bride_residence", DbType.String, entity.BrideResidence},
                new object[] { "@created_by", DbType.Int32, entity.CreatedBy}
            };

            string query = $"INSERT INTO {tableName} (payment_collections_id, registry_no, marriage_license_no, date_issued, date_published, groom_registry_id, groom_age, groom_months, groom_religion, groom_residence, bride_registry_id, bride_age, bride_months, bride_religion, bride_residence, created_by) VALUES (@payment_collections_id, @registry_no, @marriage_license_no, @date_issued, @date_published, @groom_registry_id, @groom_age, @groom_months, @groom_religion, @groom_residence, @bride_registry_id, @bride_age, @bride_months, @bride_religion, @bride_residence, @created_by)";

            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Update(MarriageLicenseModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.Id},
                new object[] { "@payment_collections_id", DbType.Int32, entity.PaymentCollectionsModel.Id},
                new object[] { "@registry_no", DbType.String, entity.RegistryNo},
                new object[] { "@marriage_license_no", DbType.String, entity.MarriageLicenseNo},
                new object[] { "@date_issued", DbType.DateTime, entity.DateIssued},
                new object[] { "@date_published", DbType.DateTime, entity.DatePublished},
                new object[] { "@groom_registry_id", DbType.Int32, entity.GroomRegistry.Id},
                new object[] { "@groom_age", DbType.Int32, entity.GroomAge},
                new object[] { "@groom_months", DbType.Int32, entity.GroomMonths},
                new object[] { "@groom_religion", DbType.String, entity.GroomReligion},
                new object[] { "@groom_residence", DbType.String, entity.GroomResidence},
                new object[] { "@bride_registry_id", DbType.Int32, entity.BrideRegistry.Id},
                new object[] { "@bride_age", DbType.Int32, entity.BrideAge},
                new object[] { "@bride_months", DbType.Int32, entity.BrideMonths},
                new object[] { "@bride_religion", DbType.String, entity.BrideReligion},
                new object[] { "@bride_residence", DbType.String, entity.BrideResidence},
                new object[] { "@updated_by", DbType.Int32, entity.UpdatedBy}
            };

            string query = $"UPDATE {tableName} SET payment_collections_id = @payment_collections_id, registry_no = @registry_no, marriage_license_no = @marriage_license_no, date_issued = @date_issued, date_published = @date_published, groom_registry_id = @groom_registry_id, groom_age = @groom_age, groom_months = @groom_months, groom_religion = @groom_religion, groom_residence = @groom_residence, bride_registry_id = @bride_registry_id, bride_age = @bride_age, bride_months = @bride_months, bride_religion = @bride_religion, bride_residence = @bride_residence, updated_by = @updated_by WHERE id = @id;";
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }
    }
}