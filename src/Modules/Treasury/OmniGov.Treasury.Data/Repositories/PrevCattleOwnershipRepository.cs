using OmniGov.Core.Interfaces.Services;
using OmniGov.Treasury.Domain.Entities;
using OmniGov.Treasury.Domain.Interfaces;
using System.Data;
using System.Transactions;

namespace OmniGov.Treasury.Data.Repositories
{
    public class PrevCattleOwnershipRepository : IPrevCattleOwnership
    {
        private readonly string tableName = "prev_cattle_ownership";
        private readonly IGenericCommands _genericCommands;

        public PrevCattleOwnershipRepository(IGenericCommands genericCommands)
        {
            _genericCommands = genericCommands ?? throw new ArgumentNullException(nameof(genericCommands));
        }

        public bool Delete(List<PrevCattleOwnershipModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var model in entityList)
                {
                    var parameters = new object[][]
                    {
                        new object[] {"@id", DbType.Int32, model.Id}
                    };

                    string query = $"DELETE FROM {tableName} WHERE id = @id";
                    _ = _genericCommands.ExecuteNonQuery(query, parameters);
                }

                scope.Complete();
                return true;
            }
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
            string query = $"SELECT * FROM {tableName}";
            return _genericCommands.Fill(query, new DataTable());
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new NotImplementedException();
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(PrevCattleOwnershipModel entity)
        {
            var parameters = new object[][]
            {
                new object[] {"@cattle_ownership_id", DbType.Int32, entity.CattleOwnershipId},
                new object[] {"@previous_cattle_ownership_id", DbType.Int32, entity.PreviousCattleOwnershipId},
                new object[] {"@cattle_price", DbType.Decimal, entity.CattlePrice},
                new object[] {"@transfer_date", DbType.Date, entity.TransferDate}
            };

            string query = $"INSERT INTO {tableName} (cattle_ownership_id, previous_cattle_ownership_id, cattle_price, transfer_date) VALUES (@cattle_ownership_id, @previous_cattle_ownership_id, @cattle_price, @transfer_date)";

            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(PrevCattleOwnershipModel entity)
        {
            var parameters = new object[][]
            {
                new object[] {"@id", DbType.Int32, entity.Id},
                new object[] {"@cattle_ownership_id", DbType.Int32, entity.CattleOwnershipId},
                new object[] {"@previous_cattle_ownership_id", DbType.Int32, entity.PreviousCattleOwnershipId},
                new object[] {"@cattle_price", DbType.Decimal, entity.CattlePrice},
                new object[] {"@transfer_date",DbType.DateTime, entity.TransferDate}
            };

            string query = $"UPDATE {tableName} SET cattle_ownership_id = @cattle_ownership_id, previous_cattle_ownership_id = @previous_cattle_ownership_id, cattle_price = @cattle_price, transfer_date = @transfer_date WHERE id = @id;";
            return _genericCommands.ExecuteNonQuery(query, parameters);
        }
    }
}
