using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACC.Data
{
    public class ObligationAccountRepository : IObligationAccountRepository
    {
        private readonly string tableName = "obligation_account";
        private AccGenericCommands mySqlGenericCommandsLFS;

        public ObligationAccountRepository(AccGenericCommands mySqlGenericCommandsLFS)
        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
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
                new object[] { "@allotment_release_id", DbType.Int32, entity.AllotmentReleaseId},
                new object[] { "@amount", DbType.Decimal, entity.Amount}
            };

            string query = $@"INSERT INTO {tableName} (obligation_request_id, allotment_release_id, amount) VALUES (@obligation_request_id, @allotment_release_id, @amount)";

            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool DeleteByObligationRequestId(int ObligationRequestId)
        {
            var parameters = new object[][]
            {
                new object[] { "@obligation_request_id",DbType.Int32, ObligationRequestId}
            };

            string query = $"DELETE FROM {tableName} WHERE obligation_request_id = @obligation_request_id";

            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }
    }
}