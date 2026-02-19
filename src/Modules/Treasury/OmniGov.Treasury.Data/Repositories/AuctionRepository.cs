using OmniGov.Core.Interfaces.Services;
using System.Data;
using System.Transactions;
using Treasury.Domain.Entities;
using Treasury.Domain.Interfaces;

namespace Treasury.Data.Repositories
{
    internal class AuctionRepository : IAuctionRepository
    {
        private readonly IGenericCommands _genericCommands;
        private readonly string tableName = "auction";

        public AuctionRepository(IGenericCommands genericCommands)
        {
            _genericCommands = genericCommands ?? throw new ArgumentNullException(nameof(genericCommands));
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<AuctionModel> entityList)
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

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT id, start_date, end_date, location, created_at FROM {tableName}";

            return _genericCommands.Fill(query, new DataTable());
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new NotImplementedException();
        }

        public DataTable GetViewRecords(string searchKey, DateTime date, int rowFilter)
        {
            throw new NotImplementedException();
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(AuctionModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@start_date", DbType.Date, entity.StartDate},
                new object[] { "@end_date", DbType.Date, entity.EndDate},
                new object[] { "@location", DbType.String, entity.Location},
                new object[] { "@created_by", DbType.Int32, entity.CreatedBy},
            };

            string query = $"INSERT INTO {tableName} (start_date, end_date, location, created_by) VALUES (@start_date, @end_date, @location, @created_by)";
            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(AuctionModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.Id},
                new object[] { "@start_date", DbType.Date, entity.StartDate},
                new object[] { "@end_date", DbType.Date, entity.EndDate},
                new object[] { "@location", DbType.String, entity.Location},
                new object[] { "@updated_by", DbType.Int32, entity.CreatedBy},
            };

            string query = $"UPDATE {tableName} SET  start_date = @start_date, end_date = @end_date, location = @location, updated_by = @updated_by WHERE id = @id;";
            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public Dictionary<string, string> GetRecordById(int id)
        {
            var recordDictionary = new Dictionary<string, string>();
            var parameters = new object[][] { new object[] { "@id", DbType.Int32, id } };
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

        public DataTable GetAuctionSchedule()
        {
            string query = $"SELECT id, CONCAT(DATE_FORMAT(start_date, '%M %e, %Y'), ' - ' , DATE_FORMAT(end_date,  '%M %e, %Y')) AS date FROM {tableName}";

            return _genericCommands.Fill(query, new DataTable());
        }
    }
}