using OmniGov.Core.Interfaces.Services;
using OmniGov.Treasury.Domain.Entities;
using OmniGov.Treasury.Domain.Interfaces;
using System.Data;

namespace OmniGov.Treasury.Data.Repositories
{
    internal class BiddersRepository : IBiddersRepository
    {
        private readonly IGenericCommands _genericCommands;
        private string tableName = "bidders";
        private string viewTableName = "view_bidders";

        public BiddersRepository(IGenericCommands genericCommands)
        {
            _genericCommands = genericCommands ?? throw new ArgumentNullException(nameof(genericCommands));
        }

        public bool Delete(List<BiddersModel> entityList)
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetBiddersByAuctionIdAndRptId(int auctionId, int rptAuctionId)
        {
            var parameters = new object[][] {
                new object[]{ "@auction_id", DbType.Int32, auctionId },
                new object[]{ "@rpt_auction_id", DbType.Int32, rptAuctionId },
            };

            string query = $"SELECT * FROM {viewTableName} WHERE auction_id = @auction_id AND rpt_auction_id = @rpt_auction_id";

            return _genericCommands.FillBySearch(query, new DataTable(), parameters);
        }

        public bool BidderNoExist(int rptAuctionId, string bidderNo)
        {
            var parameters = new object[][] {
                new object[] { "@rpt_auction_id", DbType.Int32, rptAuctionId },
                new object[] { "@bidder_no", DbType.String, bidderNo }
            };

            string query = $"SELECT id FROM {viewTableName} WHERE rpt_auction_id = @rpt_auction_id AND bidder_no = @bidder_no";
            string result = _genericCommands.ExecuteScalar(query, parameters);
            return !string.IsNullOrWhiteSpace(result);
        }

        public int GetLastInsertedId(int createdById)
        {
            var parameters = new object[][]
            {
                new object[] { "@created_by", DbType.Int32, createdById}
            };

            string query = $"SELECT COALESCE(MAX(id)) FROM {tableName} WHERE created_by = @created_by";
            return Convert.ToInt32(_genericCommands.ExecuteScalar(query, parameters));
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
            string query = $"SELECT * FROM {viewTableName} WHERE id = @bidder_id AND auction_id = @auction_id";

            DataTable dataTable = _genericCommands.ExecuteReader(query, parameters);

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
            return _genericCommands.Fill(query, new DataTable());
        }

        public DataTable GetViewRecordsByAuctionIdAndBiddersId(int auctionId, int bidderId)
        {
            var parameters = new object[][] {
                new object[]{ "@auction_id", DbType.Int32, auctionId },
                new object[]{ "@bidder_id", DbType.Int32, bidderId },
            };

            string query = $"SELECT * FROM {viewTableName} WHERE id = @bidder_id AND rpt_auction_id = @auction_id";

            return _genericCommands.FillBySearch(query, new DataTable(), parameters);
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

            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(BiddersModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
