using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using Org.BouncyCastle.Crypto.Parameters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Transactions;

namespace ACC.Data
{
    public class RealignmentsRepository : IRealignments
    {
        private readonly string tableName = "realignments";
        private AccGenericCommands mySqlGenericCommandsLFS;

        public RealignmentsRepository(AccGenericCommands mySqlGenericCommandsLFS)
        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<RealignmentsModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var item in entityList)
                {
                    var parameters = new object[][]
                    {
                        new object[]{ "@id", DbType.Int32, item.Id}
                    };

                    string query = $"DELETE FROM {tableName} WHERE id = @id";
                    _ = mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
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

        public bool Insert(RealignmentsModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@budget_appropriations_id", DbType.Int32, entity.BudgetAppropriationsId },
                new object[] { "@amount", DbType.Decimal, entity.Amount}
            };

            string query = $"";
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Update(RealignmentsModel entity)
        {
            throw new NotImplementedException();
        }
    }
}