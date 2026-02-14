using OmniGov.Core.Repositories;
using System.Data;
using System.Transactions;
using Treasury.Domain.Entities;
using Treasury.Domain.Interfaces;

namespace Treasury.Data.Repositories
{
    public class RCIDeductionsRepository : IRCIDeductionsRepository
    {
        private readonly GenericCommands _dbGenericCommands;
        private readonly string tableName = "rci_deductions";

        public RCIDeductionsRepository(GenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<RCIDeductionsModel> entityList)
        {
            throw new NotImplementedException();
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

                _ = _dbGenericCommands.ExecuteNonQuery(query, parameters);

                scope.Complete();
                return true;
            }
            ;
        }

        public DataTable GetDeductionsByRCIId(int rciId)
        {
            var parameter = new object[][] {
                new object[] {"@rciId", DbType.Int32, rciId}
            };

            string query = $"SELECT description, amount FROM {tableName} WHERE rci_id = @rciId";
            var dtRCIDeduction = new DataTable();

            return _dbGenericCommands.FillBySearch(query, dtRCIDeduction, parameter);
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

        public bool Insert(RCIDeductionsModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(RCIDeductionsModel entity)
        {
            throw new NotImplementedException();
        }
    }
}