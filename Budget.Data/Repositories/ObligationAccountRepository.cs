using Budget.Domain.Interfaces;
using Budget.Domain.Models;
using OmniGov.Core.Repositories;
using OmniGov.Core.Services;
using System.Data;

namespace Budget.Data.Repositories
{
    public class ObligationAccountRepository : IObligationAccountRepository
    {
        private readonly string tableName = "obligation_account";
        private GenericCommands mySqlGenericCommands;

        public ObligationAccountRepository(GenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
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

            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool DeleteByOblgtnId(int ObligationRequestId)
        {
            var parameters = new object[][]
            {
                new object[] { "@obligation_request_id",DbType.Int32, ObligationRequestId}
            };

            string query = $"DELETE FROM {tableName} WHERE obligation_request_id = @obligation_request_id";

            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }
    }
}

