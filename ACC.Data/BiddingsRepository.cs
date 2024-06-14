using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace ACC.Data
{
    internal class BiddingsRepository : IBiddingsRepository
    {
        private AccGenericCommands mySqlGenericCommandsLFS;
        private string tableName = "bid";

        public BiddingsRepository(AccGenericCommands mySqlGenericCommandsLFS)
        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
        }

        public bool Delete(List<BiddingsModel> entityList)
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

        public bool Insert(BiddingsModel entity)
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

        public bool Update(BiddingsModel entity)
        {
            throw new System.NotImplementedException();
        }

    }
}