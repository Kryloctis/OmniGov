using ACC.Data;
using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace AccountingSystem
{
    internal class CattleTransferOfOwnershipRepository : ICattleTransferOfOwnershipRepository
    {
        private AccGenericCommands _mySqlGenericCommandsLFS;
        private readonly string tableName = "cattle_transfer";

        public CattleTransferOfOwnershipRepository(AccGenericCommands mySqlGenericCommandsLFS)
        {
            _mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
        }

        public bool IdExist(int id)
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

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new System.NotImplementedException();
        }

        public int CountRecords()
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(CattleTransferOfOwnershipModel entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(CattleTransferOfOwnershipModel entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(List<CattleTransferOfOwnershipModel> entityList)
        {
            throw new System.NotImplementedException();
        }

        public bool InsertWithCattleOwnershipPayment(CattleTransferOfOwnershipModel cattleTransferOfOwnershipModel)
        {
            var parameters = new object[][]
            {
                new object[] { "@cattle_ownership_id", DbType.Int32, cattleTransferOfOwnershipModel.CattleOwnershipID},
                new object[] { "@old_owner_id", DbType.Int32, cattleTransferOfOwnershipModel.OldOwnerID},
                new object[] { "@new_owner_id", DbType.Int32, cattleTransferOfOwnershipModel.NewOwnerID},
                new object[] { "@barangay", DbType.String, cattleTransferOfOwnershipModel.Barangay},
                new object[] { "@municipality", DbType.String, cattleTransferOfOwnershipModel.Municipality},
                new object[] { "@province", DbType.String, cattleTransferOfOwnershipModel.Province},
                new object[] { "@amount", DbType.Decimal, cattleTransferOfOwnershipModel.Amount},
                new object[] { "@cattle_type", DbType.String, cattleTransferOfOwnershipModel.CattleType},
                new object[] { "@cattle_sex", DbType.String, cattleTransferOfOwnershipModel.CattleSex},
                new object[] { "@cattle_age", DbType.Int32, cattleTransferOfOwnershipModel.CattleAge},
                new object[] { "@description", DbType.String, cattleTransferOfOwnershipModel.Description},
                new object[] { "@created_at", DbType.DateTime, cattleTransferOfOwnershipModel.CreatedAt},
                new object[] { "@created_by", DbType.Int32, cattleTransferOfOwnershipModel.CreatedBy},
            };

            string query = $"INSERT INTO {tableName} (cattle_ownership_id, old_owner_id, new_owner_id, barangay, municipality, province, amount, cattle_type, cattle_sex, cattle_age, description, created_at, created_by, updated_at, updated_by) VALUES(@cattle_ownership_id, @old_owner_id, @new_owner_id, @barangay, @municipality, @province, @amount, @cattle_type, @cattle_sex, @cattle_age, @description, @created_at, @created_by)";

            bool result = _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
            return result;
        }
    }
}