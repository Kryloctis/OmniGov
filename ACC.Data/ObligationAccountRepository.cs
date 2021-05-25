using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ACC.Data
{
    public class ObligationAccountRepository : IObligationAccountRepository
    {
        private readonly string tableName = "obligation_account";

        private MySqlGenericCommands _mySqlGenericCommands;

        public ObligationAccountRepository(MySqlGenericCommands mySqlGenericCommands)
        {
            _mySqlGenericCommands = mySqlGenericCommands;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<ObligationAccountModel> entityList)
        {
            throw new NotImplementedException();
        }

        public bool DeleteByObligationRequestId(int ObligationRequestId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@obligation_request_id",DbType.Int32, ObligationRequestId}
                };

                string query = $"DELETE FROM {tableName} WHERE obligation_request_id = @obligation_request_id";

                return _mySqlGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
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

        public bool Insert(ObligationAccountModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@obligation_request_id",DbType.Int32, entity.ObligationRequestId },
                    new object[] { "@general_ledger_accounts_id", DbType.Int32, entity.AccountId},
                    new object[] { "@amount", DbType.Decimal, entity.Amount}
                };

                string query = $"INSERT INTO {tableName} " +
                    $"(obligation_request_id, " +
                    $"general_ledger_accounts_id, " +
                    $"amount) " +
                    $"VALUES " +
                    $"(@obligation_request_id, " +
                    $"@general_ledger_accounts_id, " +
                    $"@amount) ";

                return _mySqlGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int ObligationsRecordCount()
        {
            try
            {
                string query = $"SELECT COUNT(*) FROM lfsdb.obligation_account";

                return Convert.ToInt32(_mySqlGenericCommands.ExecuteScalar(query));
            }

            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(ObligationAccountModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
