using OmniGov.Core.Interfaces.Services;
using System.Data;
using System.Transactions;
using Treasury.Domain.Entities;
using Treasury.Domain.Interfaces;

namespace Treasury.Data.Repositories
{
    public class RCIObligationsRepository : IRciObligationsRepository
    {
        private readonly IGenericCommands _genericCommands;
        private readonly string tableName = "rci_obligations";

        public RCIObligationsRepository(IGenericCommands genericCommands)
        {
            _genericCommands = genericCommands ?? throw new ArgumentNullException(nameof(genericCommands));
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<RCIObligationsModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var entity in entityList)
                {
                    var parameters = new object[][]
                    {
                            new object[] { "@id", DbType.Int32, entity.Id},
                    };

                    string query = $"DELETE FROM {tableName} WHERE id = @id";
                    _ = _genericCommands.ExecuteNonQuery(query, parameters);
                }

                scope.Complete();
                return true;
            }
        }

        public bool DeleteRecordsByRCIId(int rcidId)
        {
            using (var scope = new TransactionScope())
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, rcidId }
                };

                string query = $"DELETE FROM {tableName} WHERE rci_id = @id";

                _ = _genericCommands.ExecuteNonQuery(query, parameters);

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
            throw new NotImplementedException();
        }

        public DataTable GetRecordsByRCIId(int rciId)
        {
            var parameter = new object[][] {
                new object[] {"@rciId", DbType.Int32, rciId}
            };

            string query = $"SELECT obligation_no, date_entry FROM {tableName} WHERE rci_id = @rciId";
            var dtRCI = new DataTable();

            return _genericCommands.FillBySearch(query, dtRCI, parameter);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new NotImplementedException();
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(RCIObligationsModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@rci_id", DbType.Int32, entity.Rcid},
                new object[] { "@obligations_id", DbType.String, entity.Obid}
            };

            string query = $"INSERT INTO {tableName} (rci_id,obligations_id) VALUES (@rci_id,@obligations_id)";
            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(RCIObligationsModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.Id},
                new object[] { "@rci_id", DbType.Int32, entity.Rcid},
                new object[] { "@obligations_id", DbType.String, entity.Obid}
            };

            string query = $"UPDATE {tableName} SET rci_id = @rci_id, obligations_id = @obligations_id WHERE id = @id";
            return _genericCommands.ExecuteNonQuery(query, parameters);
        }
    }
}