using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace ACC.Data
{
    internal class BidRepository : IBidRepository
    {
        private AccGenericCommands mySqlGenericCommandsLFS;
        private string tableName = "bid";
        private string viewTableName = "view_bid";

        public BidRepository(AccGenericCommands mySqlGenericCommandsLFS)
        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
        }



        public bool Delete(List<BidModel> entityList)
        {
            throw new System.NotImplementedException();
        }

        public Dictionary<string, string> GetHighestBidderByAuctionIdAndRptId(int rptAuctionId, int rptId)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][] {
                new object[] { "@rpt_auction_id", DbType.Int32, rptAuctionId },
                new object[] { "@real_properties_id", DbType.Int32, rptId }
            };

            string query = $"SELECT *, MAX(bid_amount) bid_amount FROM {viewTableName} WHERE rpt_auction_id = 35 AND real_properties_id = 10";

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

        public Dictionary<string, string> GetRecordByAuctionIdAndBidderId(int rptAuctionId, int biddersId)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][] {
                new object[] { "@rpt_auction_id", DbType.Int32, rptAuctionId },
                new object[] { "@bidders_id", DbType.Int32, biddersId }
            };

            string query = $"SELECT * FROM {viewTableName} WHERE rpt_auction_id = @rpt_auction_id AND bidders_id = @bidders_id";

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

        public DataTable GetViewRecords()
        {
            string query = $"SELECT * FROM {viewTableName}";
            return mySqlGenericCommandsLFS.Fill(query, new DataTable());
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
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Update(BidModel entity)
        {
            throw new System.NotImplementedException();
        }

    }
}