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

        public DataTable GetRecordsByIDAndSearch(int oldOwnerID, string searchKey)
        {
            var parameter = new object[][]
            {
                new object[] { "@owner_id", DbType.Int32, oldOwnerID},
                new object[] { "@searchKey", DbType.String, $"%{searchKey}%" },
            };

            string query = $"SELECT id, cattle_type, cattle_sex, cattle_age, description FROM {tableName} WHERE owner_id = @owner_id AND description LIKE @searchKey AND cattle_type LIKE @searchKey";

            var dataTable = new DataTable();
            return _dbGenericCommands.FillBySearch(query, dataTable, parameter);
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
                new object[] { "@owner_name", DbType.String, cattleOwnershipModel.OwnerName},
                new object[] { "@owner_barangay", DbType.String, cattleOwnershipModel.OwnerBarangay},
                new object[] { "@owner_municipality", DbType.String, cattleOwnershipModel.OwnerMunicipality},
                new object[] { "@owner_province", DbType.String, cattleOwnershipModel.OwnerProvince},
                new object[] { "@cattle_type", DbType.String, cattleOwnershipModel.CattleType},
                new object[] { "@cattle_sex", DbType.String, cattleOwnershipModel.CattleSex},
                new object[] { "@cattle_age", DbType.String, cattleOwnershipModel.CattleAge},
                new object[] { "@description", DbType.String, cattleOwnershipModel.Description},
                new object[] { "@created_at", DbType.DateTime, cattleOwnershipModel.CreatedAt},
                new object[] { "@created_by", DbType.Int32, cattleOwnershipModel.CreatedBy},
            };

            string query = $"INSERT INTO {tableName} (owner_id, tag, owner_name, owner_barangay, owner_municipality, owner_province, cattle_type, cattle_sex, cattle_age, description, created_at, created_by) VALUES(@owner_id, @tag, @owner_name, @owner_barangay, @owner_municipality, @owner_province, @cattle_type, @cattle_sex, @cattle_age, @description, @created_at, @created_by)";


            bool result = _dbGenericCommands.ExecuteNonQuery(query, parameters);
            return result;
        }

        public bool Update(CattleOwnershipModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}