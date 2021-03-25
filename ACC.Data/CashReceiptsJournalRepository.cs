using System;
using System.Collections.Generic;
using System.Data;
using ACC.Domain.Interfaces;
using ACC.Domain.Models;

namespace ACC.Data
{
    class CashReceiptsJournalRepository : ICashReceiptsJournalRepository
    {
        private readonly IDbGenericCommands _dbGenericCommands;
        private const string tableName = "cash_receipts_journal";

        public CashReceiptsJournalRepository(IDbGenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<CashReceiptsJournalModel> entityList)
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

        public bool Insert(CashReceiptsJournalModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@jev_id", DbType.Int32, entity.JevId},
                    new object[] { "@collecting_officers_id", DbType.Byte, entity.CollectingOfficerId},
                    new object[] { "@rcd_number", DbType.String, entity.RCDNumber},
                };

                string query = $"INSERT INTO {tableName} (jev_id, collecting_officers_id, rcd_number) VALUES (@jev_id, @collecting_officers_id, @rcd_number)";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(CashReceiptsJournalModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
