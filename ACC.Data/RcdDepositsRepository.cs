using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    public class RcdDepositsRepository : IRcdDeposits
    {
        private readonly string tableName = "rcd_deposits";
        private AccGenericCommands mySqlGenericCommandsLFS;

        public RcdDepositsRepository(AccGenericCommands mySqlGenericCommandsLFS)
        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
        }

        public bool BulkInsert(List<RcdDepositsModel> rcdDepositsModels)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var rcdDepositsModel in rcdDepositsModels)
                    _ = Insert(rcdDepositsModel);

                scope.Complete();
                return true;
            };
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
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
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

        public bool Insert(RcdDepositsModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@rcd_id", DbType.Int32, entity.RcdModel.Id},
                new object[] { "@bank_deposits_id", DbType.Int32, entity.BankDepositsModel.Id},
            };

            string query = $"INSERT INTO {tableName} (rcd_id, bank_deposits_id) VALUES  (@rcd_id, @bank_deposits_id)";
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Update(RcdDepositsModel entity)
        {
            throw new NotImplementedException();
        }
    }
}