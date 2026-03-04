using OmniGov.Core.Interfaces.Services;
using OmniGov.Treasury.Domain.Entities;
using OmniGov.Treasury.Domain.Interfaces;
using System.Data;
using System.Transactions;

namespace OmniGov.Treasury.Data.Repositories
{
    internal class RptAuctionRepository : IRptAuctionRepository
    {
        private readonly string tableName = "rpt_auction";
        private readonly string viewTableName = "view_rpt_auction";

        private readonly IGenericCommands _genericCommands;

        public RptAuctionRepository(IGenericCommands genericCommands)
        {
            _genericCommands = genericCommands ?? throw new ArgumentNullException(nameof(genericCommands));
        }

        public bool Delete(List<RptAuctionModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var entity in entityList)
                {
                    var parameters = new object[][] { new object[] { "@id", DbType.Int32, entity.Id } };
                    string query = $"DELETE FROM {tableName} WHERE id = @id";
                    _ = _genericCommands.ExecuteNonQuery(query, parameters);
                }

                scope.Complete();
                return true;
            }
        }

        public DataTable GetAuctionProperties(RptAuctionModel rptAuctionModel)
        {
            var parameters = new object[][]
            {
                new object[] { "@auction_id", DbType.Int32, rptAuctionModel.AuctionId },
            };

            string query = $"SELECT * FROM {viewTableName} WHERE auction_id = @auction_id";

            return _genericCommands.FillBySearch(query, new DataTable(), parameters);
        }

        public DataTable GetAuctionProperties(int auctionId)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> GetAuctionPropertiesByAuctionIdAndRptId(int auctionId, int rptId)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@rpt_auction_id", DbType.Int32, auctionId },
                new object[] { "@real_properties_id", DbType.Int32, rptId },
            };

            string query = $"SELECT * FROM {viewTableName} WHERE auction_id = @rpt_auction_id AND real_properties_id = @real_properties_id";
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

        public Dictionary<string, string> GetAuctionPropertiesByAuctionIdAndTaxpayerId(int auctionId, int taxpayerId)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@rpt_auction_id", DbType.Int32, auctionId },
                new object[] { "@taxpayers_id", DbType.Int32, taxpayerId },
            };

            string query = $"SELECT * FROM {viewTableName} WHERE auction_id = @rpt_auction_id AND taxpayers_id = @taxpayers_id";
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

        public DataTable GetBiddersByAuctionAndPropertyId(int auctionId, int rptId)
        {
            var parameters = new object[][]
            {
                new object[] { "@auction_id", DbType.Int32, auctionId },
                new object[] { "@real_properties_id", DbType.Int32, rptId },
            };

            string query = $"SELECT * FROM {viewTableName} WHERE auction_id = @auction_id AND real_properties_id = @real_properties_id";

            return _genericCommands.FillBySearch(query, new DataTable(), parameters);
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var recordDictionary = new Dictionary<string, string>();
            var parameters = new object[][] { new object[] { "@id", DbType.Int32, Id } };
            string query = $"SELECT * FROM {tableName} WHERE id = @id";
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

        public DataTable GetRecords()
        {
            string query = $"SELECT id, real_properties_id, auction_id, created_at FROM {tableName}";

            return _genericCommands.Fill(query, new DataTable());
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetViewRecords(string searchKey, DateTime date, int rowFilter)
        {
            var parameters = new object[][]
            {
                new object[] { "@search_key", DbType.String, $"%{searchKey}%"},
                new object[] { "@date", DbType.Date, date},
                new object[] { "@row_filter", DbType.Int32, rowFilter},
            };

            string query = $"SELECT * FROM {viewTableName} WHERE (complete_arp_no LIKE @search_key OR location LIKE @search_key) AND DATE(start_date) = @date LIMIT @row_filter";

            return _genericCommands.FillBySearch(query, new DataTable(), parameters);
        }

        public bool IdExist(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(RptAuctionModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@real_properties_id", DbType.Int32, entity.RptPropertiesId},
                new object[] { "@auction_id", DbType.Int32, entity.AuctionId},
                new object[] { "@created_by", DbType.Int32, entity.CreatedBy},
            };

            string query = $"INSERT INTO {tableName} (real_properties_id, auction_id, created_by) VALUES (@real_properties_id, @auction_id, @created_by)";
            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(RptAuctionModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.Id},
                new object[] { "@auction_id", DbType.Int32, entity.AuctionId},
                new object[] { "@real_properties_id", DbType.Int32, entity.RptPropertiesId},
                new object[] { "@updated_by", DbType.Int32, entity.CreatedBy},
            };

            string query = $"UPDATE {tableName} SET  auction_id = @auction_id, real_properties_id = @real_properties_id, updated_by = @updated_by WHERE id = @id;";
            return _genericCommands.ExecuteNonQuery(query, parameters);
        }
    }
}
