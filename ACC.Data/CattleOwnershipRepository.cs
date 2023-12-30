using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    internal class CattleOwnershipRepository : ICattleOwnershipRepository
    {
        private readonly string tableName = "cattle_ownership";
        private AccGenericCommands mySqlGenericCommandsLFS;

        public CattleOwnershipRepository(AccGenericCommands mySqlGenericCommandsLFS)
        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
        }

        public int CountRecords()
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(List<CattleOwnershipModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var cattleOwnershipModel in entityList)
                {
                    var parameters = new object[][] { new object[] { "@id", DbType.Int32, cattleOwnershipModel.Id } };
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
            string query = $"SELECT * FROM {tableName}";
            var dataTable = new DataTable();
            return mySqlGenericCommandsLFS.Fill(query, dataTable);
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
            return mySqlGenericCommandsLFS.FillBySearch(query, dataTable, parameter);
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
            var parameters = new object[][]
            {
                new object[] {"@payment_collections_id" ,DbType.Int32, entity.PaymentCollectionId},
                new object[] {"@taxpayers_id" ,DbType.Int32, entity.TaxpayerId},
                new object[] {"@cattle_name" ,DbType.String, entity.CattleName},
                new object[] {"@cattle_sex" ,DbType.String, entity.CattleSex},
                new object[] {"@cattle_age" ,DbType.Int32, entity.CattleAge},
                new object[] {"@description" ,DbType.String, entity.Description},
                new object[] {"@cattle_price" ,DbType.Decimal, entity.CattlePrice},
                new object[] {"@created_by" ,DbType.Int32, entity.CreatedBy},
            };

            string query = $"INSERT INTO {tableName} (payment_collections_id, taxpayers_id, cattle_name, cattle_sex, cattle_age, description, cattle_price, created_by) VALUES (@payment_collections_id, @taxpayers_id, @cattle_name, @cattle_sex, @cattle_age, @description, @cattle_price, @created_by)";

            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Update(CattleOwnershipModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.Id },
                new object[] { "@payment_collections_id" ,DbType.Int32, entity.PaymentCollectionId },
                new object[] { "@taxpayers_id" ,DbType.Int32, entity.TaxpayerId },
                new object[] { "@cattle_name" ,DbType.String, entity.CattleName },
                new object[] { "@cattle_sex" ,DbType.String, entity.CattleSex },
                new object[] { "@cattle_age" ,DbType.Int32, entity.CattleAge },
                new object[] { "@description" ,DbType.String, entity.Description },
                new object[] { "@cattle_price" ,DbType.Decimal, entity.CattlePrice },
                new object[] { "@updated_by" ,DbType.String, entity.UpdatedBy },
            };

            string query = $"UPDATE {tableName} SET payment_collections_id = @payment_collections_id, taxpayers_id = @taxpayers_id, cattle_name = @cattle_name, cattle_sex = @cattle_sex, cattle_age = @cattle_age, description = @description, cattle_price = @cattle_price, updated_by = @updated_by WHERE id = @id;";
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }
    }
}