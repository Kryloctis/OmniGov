using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ACC.Data
{
    public class ObligationRequestRepository : IObligationRequestRepository
    {
        private MySqlGenericCommands mySqlGenericCommands;
        private readonly string tableName = "obligation_request";


        public ObligationRequestRepository(MySqlGenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<ObligationRequestModel> entityList)
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

        public bool Insert(ObligationRequestModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(ObligationRequestModel entity)
        {
            throw new NotImplementedException();
        }

        #region Validations

        public bool ObligationNumExist(string obligationNum)
        {
            try
            {
                var parameters = new object[][]
                {
                   new object[] { "@obligation_no", DbType.String, obligationNum }
                };

                string query = $"SELECT id FROM {tableName} WHERE obligation_no = @obligation_no";
                string queryResult = mySqlGenericCommands.ExecuteScalar(query, parameters);

                // if query is not null, means found some record, so true
                if (!string.IsNullOrEmpty(queryResult)) return true;
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }
        public bool ObligationNumExist(int id, string obligationNum)
        {
            try
            {
                var parameters = new object[][]
                {
                   new object[] { "@id", DbType.Int32, id },
                   new object[] { "@obligation_no", DbType.String, obligationNum }
                };

                string query = $"SELECT id FROM {tableName} WHERE id <> @id AND obligation_no = @obligation_no";
                string queryResult = mySqlGenericCommands.ExecuteScalar(query, parameters);

                // if query is not null, means found some record, so true
                if (!string.IsNullOrEmpty(queryResult)) return true;
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        #endregion Validations
    }
}
