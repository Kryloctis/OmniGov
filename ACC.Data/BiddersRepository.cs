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
        private string viewTableName = "view_bidders";

        public BiddersRepository(AccGenericCommands mySqlGenericCommandsLFS)
        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
        }

        public bool Delete(List<BiddersModel> entityList)
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetBiddersByAuctionIdAndRptId(int auctionId, int rptId)
        {
            var parameters = new object[][] {
                new object[]{ "@auction_id", DbType.Int32, auctionId },
                new object[]{ "@rpt_auction_id", DbType.Int32, rptId },
            };

            string query = $"SELECT * FROM {viewTableName} WHERE auction_id = @auction_id AND ";

            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
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

        public Dictionary<string, string> GetViewRecordByAuctionIdAndBidderId(int auctionId, int bidderId)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][] { new object[] { "@auction_id", DbType.Int32, auctionId }, new object[] { "@bidder_id", DbType.Int32, bidderId } };
            string query = $"Select bidders.id, bidders.taxpayers_id, bidders.auction_id, taxpayers.name AS bidder, bidders.bidder_no, bid.ordinance_no, bid.date, bid.bid_amount  FROM bidders AS bidders INNER JOIN bid AS bid ON bidders.id = bid.bidders_id INNER JOIN taxpayers AS taxpayers  ON bidders.taxpayers_id = taxpayers.id WHERE bidders.id = @bidder_id AND bidders.auction_id = @auction_id";

            DataTable dataTable = mySqlGenericCommandsLFS.ExecuteReader(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                foreach (DataColumn column in dataTable.Columns)
                    recordDictionary[column.ColumnName] = row[column].ToString();

                return recordDictionary;
            }
            return recordDictionary;
        }

        public DataTable GetViewRecords()
        {
            string query = $"Select bidders.id, bidders.taxpayers_id, bidders.auction_id, taxpayers.name AS bidder, bidders.bidder_no, bid.ordinance_no, bid.date, bid.bid_amount  FROM bidders AS bidders INNER JOIN bid AS bid ON bidders.id = bid.bidders_id INNER JOIN taxpayers AS taxpayers  ON bidders.taxpayers_id = taxpayers.id";

            return mySqlGenericCommandsLFS.Fill(query, new DataTable());
        }

        public DataTable GetViewRecordsByAuctionIdAndBiddersId(int auctionId, int bidderId)
        {
            var parameters = new object[][] {
                new object[]{ "@auction_id", DbType.Int32, auctionId },
                new object[]{ "@bidder_id", DbType.Int32, bidderId },
            };

            string query = $"Select bidders.id, bidders.taxpayers_id, bidders.auction_id, taxpayers.name AS bidder, bidders.bidder_no, bid.ordinance_no, bid.date, bid.bid_amount  FROM bidders AS bidders INNER JOIN bid AS bid ON bidders.id = bid.bidders_id INNER JOIN taxpayers AS taxpayers  ON bidders.taxpayers_id = taxpayers.id WHERE bidders.id = @bidder_id AND bid.rpt_auction_id = @auction_id";

            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
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
                new object[] { "@created_by", DbType.Int32, entity.CreatedBy},

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