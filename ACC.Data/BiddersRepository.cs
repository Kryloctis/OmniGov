using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACC.Data
{
    internal class BiddersRepository : IBiddersRepository
    {
        private AccGenericCommands mySqlGenericCommandsLFS;
        private string tableName = "bidders";

        public BiddersRepository(AccGenericCommands mySqlGenericCommandsLFS)
        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
        }

        public bool Delete(List<BiddersModel> entityList)
        {
            throw new System.NotImplementedException();
        }

        public int GetLastInsertedId(int createdById)
        {
            var parameters = new object[][]
            {
                new object[] { "@created_by", DbType.Int32, createdById}
            };

            string query = $"SELECT COALESCE(MAX(id)) FROM {tableName} WHERE created_by = @created_by";
            return Convert.ToInt32(mySqlGenericCommandsLFS.ExecuteScalar(query, parameters));
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

        public bool Insert(BiddersModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@taxpayers_id", DbType.Int32, entity.TaxpayersId},
                new object[] { "@auction_id", DbType.Int32, entity.AuctionId},
                new object[] { "@payment_collections_id", DbType.Int32, entity.PaymentCollectionsId},
                new object[] { "@bidder_no", DbType.String, entity.BidderNo},
                new object[] { "@created_by", DbType.String, entity.CreatedBy},

            };

            string query = $"INSERT INTO {tableName} (taxpayers_id, auction_id, payment_collections_id, bidder_no, created_by) VALUES (@taxpayers_id, @auction_id, @payment_collections_id, @bidder_no, @created_by)";

            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Update(BiddersModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}