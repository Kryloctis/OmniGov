using OmniGov.Core.Repositories;
using System.Data;
using System.Transactions;
using Treasury.Domain.Entities;
using Treasury.Domain.Interfaces;

namespace Treasury.Data.Repositories
{
    public class RcdCollectionRepository : IRcdCollections
    {
        private readonly string tableName = "rcd_collections";
        private GenericCommands mySqlGenericCommandsLFS;

        public RcdCollectionRepository(GenericCommands mySqlGenericCommandsLFS)
        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
        }

        public bool BulkInsert(List<RcdCollectionsModel> rcdCollectionsModels)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var rcdCollectionModel in rcdCollectionsModels)
                    _ = Insert(rcdCollectionModel);

                scope.Complete();
                return true;
            }
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<RcdCollectionsModel> entityList)
        {
            throw new NotImplementedException();
        }

        public bool DeleteByRcdId(RcdModel rcdModel)
        {
            var parameters = new object[][] { new object[] { "@rcd_id", DbType.Int32, rcdModel.Id } };

            string query = $"DELETE FROM {tableName} WHERE rcd_id = @rcd_id";
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {tableName}";
            return mySqlGenericCommandsLFS.Fill(query, new DataTable());
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new NotImplementedException();
        }

        public string GetTableName()
        {
            return tableName;
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(RcdCollectionsModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@rcd_id", DbType.Int32, entity.RcdModel.Id},
                new object[] { "@payment_collections_id", DbType.Int32, entity.PaymentCollectionsModel.Id},
            };

            string query = $"INSERT INTO {tableName} (rcd_id, payment_collections_id) VALUES (@rcd_id, @payment_collections_id)";
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Update(RcdCollectionsModel entity)
        {
            throw new NotImplementedException();
        }
    }
}