using OmniGov.Core.Interfaces.Services;
using OmniGov.Treasury.Domain.Entities;
using OmniGov.Treasury.Domain.Interfaces;
using System.Data;
using System.Transactions;

namespace OmniGov.Treasury.Data.Repositories
{
    public class RcdDepositsRepository : IRcdDeposits
    {
        private readonly string tableName = "rcd_deposits";
        private readonly IGenericCommands _genericCommands;

        public RcdDepositsRepository(IGenericCommands genericCommands)
        {
            _genericCommands = genericCommands ?? throw new ArgumentNullException(nameof(genericCommands));
        }

        public bool BulkInsert(List<RcdDepositsModel> rcdDepositsModels)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var rcdDepositsModel in rcdDepositsModels)
                    _ = Insert(rcdDepositsModel);

                scope.Complete();
                return true;
            }
            ;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<RcdDepositsModel> entityList)
        {
            throw new NotImplementedException();
        }

        public bool DeleteByRcdId(RcdModel rcdModel)
        {
            var parameters = new object[][] { new object[] { "@rcd_id", DbType.Int32, rcdModel.Id } };
            string query = $"DELETE FROM {tableName} WHERE rcd_id = @rcd_id";
            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecords()
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new NotImplementedException();
        }

        public string GetTableName()
        {
            return tableName;
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(RcdDepositsModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@rcd_id", DbType.Int32, entity.RcdModel.Id},
                new object[] { "@bank_deposits_id", DbType.Int32, entity.BankDepositsModel.Id},
            };

            string query = $"INSERT INTO {tableName} (rcd_id, bank_deposits_id) VALUES  (@rcd_id, @bank_deposits_id)";
            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(RcdDepositsModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
