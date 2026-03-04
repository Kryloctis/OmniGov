using OmniGov.Budget.Domain.Entities;
using OmniGov.Budget.Domain.Interfaces;
using OmniGov.Core.Interfaces.Services;
using System.Data;

namespace OmniGov.Budget.Data.Repositories
{
    public class ObligationAccountRepository : IObligationAccountRepository
    {
        private readonly string tableName = "obligation_account";
        private IGenericCommands _genericCommands;

        public ObligationAccountRepository(IGenericCommands genericCommands)
        {
            _genericCommands = genericCommands;
        }

        public bool Delete(List<ObligationAccountModel> entityList)
        {
            throw new NotImplementedException();
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

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(ObligationAccountModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(ObligationAccountModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@obligation_request_id",DbType.Int32, entity.ObligationRequestId },
                new object[] { "@allotment_account_id", DbType.Int32, entity.AllotmentAccountId},
                new object[] { "@amount", DbType.Decimal, entity.Amount}
            };

            string query = $@"INSERT INTO {tableName}
                            (obligation_request_id, allotment_account_id, amount) VALUES
                            (@obligation_request_id, @allotment_account_id, @amount)";

            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool DeleteByOblgtnId(int ObligationRequestId)
        {
            var parameters = new object[][]
            {
                new object[] { "@obligation_request_id",DbType.Int32, ObligationRequestId}
            };

            string query = $"DELETE FROM {tableName} WHERE obligation_request_id = @obligation_request_id";

            return _genericCommands.ExecuteNonQuery(query, parameters);
        }
    }
}
