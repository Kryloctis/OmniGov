using OmniGov.Core.Repositories;
using OmniGov.Core.Services;
using System.Data;
using Treasury.Domain.Entities;
using Treasury.Domain.Interfaces;

namespace Treasury.Data.Repositories
{
    internal class BidRepository : IBidRepository
    {
        private GenericCommands mySqlGenericCommands;
        private string tableName = "bid";
        private string viewTableName = "view_bid";

        public BidRepository(GenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public bool Delete(List<BidModel> entityList)
        {
            throw new System.NotImplementedException();
        }

        public Dictionary<string, string> GetBidderWinnerAndBidDetails(int taxpayersId, int rptId)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][] {
                new object[] { "@taxpayers_id", DbType.Int32, taxpayersId },
                new object[] { "@real_properties_id", DbType.Int32, rptId }
            };

            string query = $"SELECT * FROM {viewTableName} WHERE taxpayers_id = @taxpayers_id AND real_properties_id = @real_properties_id  ORDER BY bid_amount DESC LIMIT 1";

            DataTable dataTable = mySqlGenericCommands.ExecuteReader(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                foreach (DataColumn column in dataTable.Columns)
                    recordDictionary[column.ColumnName] = row[column].ToString();

                return recordDictionary;
            }
            return recordDictionary;
        }

        public Dictionary<string, string> GetHighestBidderByAuctionIdAndRptId(int auctionId, int rptId)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][] {
                new object[] { "@auction_id", DbType.Int32, auctionId },
                new object[] { "@real_properties_id", DbType.Int32, rptId }
            };

            string query = $"SELECT * FROM {viewTableName} WHERE auction_id = @auction_id  ORDER BY bid_amount DESC LIMIT 1";

            DataTable dataTable = mySqlGenericCommands.ExecuteReader(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                foreach (DataColumn column in dataTable.Columns)
                    recordDictionary[column.ColumnName] = row[column].ToString();

                return recordDictionary;
            }
            return recordDictionary;
        }

        public Dictionary<string, string> GetRecordByAuctionIdAndBidderId(int rptAuctionId, int biddersId)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][] {
                new object[] { "@rpt_auction_id", DbType.Int32, rptAuctionId },
                new object[] { "@bidders_id", DbType.Int32, biddersId }
            };

            string query = $"SELECT * FROM {viewTableName} WHERE rpt_auction_id = @rpt_auction_id AND bidders_id = @bidders_id";

            DataTable dataTable = mySqlGenericCommands.ExecuteReader(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                foreach (DataColumn column in dataTable.Columns)
                    recordDictionary[column.ColumnName] = row[column].ToString();

                return recordDictionary;
            }
            return recordDictionary;
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

        public DataTable GetSoldRpt(int auctionId)
        {
            var parameters = new object[][] {
                new object[] { "@auction_id", DbType.Int32, auctionId },
            };

            string query = $"SELECT rpt_auction_id, complete_arp_no, assessed_value, auction_id, name, address, municipality, province, contact_info, MAX(bid_amount) AS bid_amount FROM  {viewTableName} WHERE auction_id = @auction_id GROUP BY rpt_auction_id ORDER BY bid_amount DESC";

            return mySqlGenericCommands.FillBySearch(query, new DataTable(), parameters);
        }

        public Dictionary<string, string> GetViewRecordById(int bidId)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][] {
                new object[] { "@id", DbType.Int32, bidId },
            };

            string query = $"SELECT * FROM {viewTableName} WHERE id = @id";

            DataTable dataTable = mySqlGenericCommands.ExecuteReader(query, parameters);

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
            string query = $"SELECT * FROM {viewTableName}";
            return mySqlGenericCommands.Fill(query, new DataTable());
        }

        public DataTable GetViewRecordsByAuctionId(int auctionId)
        {
            var parameters = new object[][] {
                new object[] { "@auction_id", DbType.Int32, auctionId },
            };

            string query = $"SELECT * FROM {viewTableName} WHERE auction_id = @auction_id";

            return mySqlGenericCommands.FillBySearch(query, new DataTable(), parameters);
        }

        public bool IdExist(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(BidModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@rpt_auction_id", DbType.Int32, entity.RptAuctionId},
                new object[] { "@bidders_id", DbType.Int32, entity.BiddersId},
                new object[] { "@ordinance_no", DbType.String, entity.OrdinanceNo},
                new object[] { "@date", DbType.DateTime, entity.Date},
                new object[] { "@bid_amount", DbType.Decimal, entity.BidAmount},
                new object[] { "@created_by", DbType.Int32, entity.CreatedBy},
            };

            string query = $"INSERT INTO {tableName} (rpt_auction_id, bidders_id, ordinance_no, date, bid_amount, created_by) VALUES (@rpt_auction_id, @bidders_id, @ordinance_no, @date, @bid_amount, @created_by)";
            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(BidModel entity)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateBidDetails(BiddersModel biddersModel, BidModel bidModel)
        {
            throw new System.NotImplementedException();
        }

        DataTable IBidRepository.GetHighestBidderByRptId(int rptId)
        {
            var parameters = new object[][] {
                new object[] { "@real_properties_id", DbType.Int32, rptId },
            };

            string query = $"SELECT * FROM {viewTableName} WHERE real_properties_id = @real_properties_id  ORDER BY bid_amount DESC LIMIT 1";

            return mySqlGenericCommands.FillBySearch(query, new DataTable(), parameters);
        }
    }
}

