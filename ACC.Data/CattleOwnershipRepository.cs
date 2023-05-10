using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace AccountingSystem
{
    internal class CattleOwnershipRepository : ICattleOwnershipRepository
    {
        private readonly IAccGenericCommands _dbGenericCommands;
        private readonly string tableName = "cattle_ownership";

        public CattleOwnershipRepository(IAccGenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
        }

        public int CountRecords()
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(List<CattleOwnershipModel> entityList)
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

        public bool Insert(CattleOwnershipModel entity)
        {
            throw new System.NotImplementedException();
        }

        public bool InsertWithCattleOwnershipPayment(CattleOwnershipModel cattleOwnershipModel)
        {
            var parameters = new object[][]
            {
                new object[] { "@owner_id", DbType.Int32, cattleOwnershipModel.OwnerID},
                new object[] { "@tag", DbType.Int32, cattleOwnershipModel.Tag},
                new object[] { "@barangay", DbType.String, cattleOwnershipModel.Barangay},
                new object[] { "@municipality", DbType.String, cattleOwnershipModel.Municipality},
                new object[] { "@province", DbType.String, cattleOwnershipModel.Province},
                new object[] { "@cattle_type", DbType.String, cattleOwnershipModel.CattleType},
                new object[] { "@cattle_sex", DbType.String, cattleOwnershipModel.CattleSex},
                new object[] { "@cattle_age", DbType.String, cattleOwnershipModel.CattleAge},
                new object[] { "@description", DbType.String, cattleOwnershipModel.Description},
                new object[] { "@created_at", DbType.DateTime, cattleOwnershipModel.CreatedAt},
                new object[] { "@created_by", DbType.Int32, cattleOwnershipModel.CreatedBy},
            };

            string query = $"INSERT INTO {tableName} (owner_id, tag, barangay, municipality, province, cattle_type, cattle_sex, cattle_age, description, created_at, created_by) VALUES(@owner_id, @tag, @barangay, @municipality, @province, @cattle_type, @cattle_sex, @cattle_age, @description, @created_at, @created_by)";


            bool result = _dbGenericCommands.ExecuteNonQuery(query, parameters);
            return result;
        }

        public bool Update(CattleOwnershipModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}