using System;
using System.Collections.Generic;
using System.Text;
using ACC.Domain.Models;
using ACC.Domain.Interfaces;
using System.Data;

namespace ACC.Data
{
    class CashDisbursementsJournalRepository : ICashDisbursementsJournalRepository
    {
        private readonly IDbGenericCommands _dbGenericCommands;
        private const string tableName = "cash_disbursement_journal";

        public CashDisbursementsJournalRepository(IDbGenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<CashDisbursementsJournalModel> entityList)
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

        public bool Insert(CashDisbursementsJournalModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@jev_id", DbType.Int32, entity.JevId},
                    new object[] { "@disbursing_officers_id", DbType.Byte, entity.DisbursingOfficerId},
                    new object[] { "@dv_no", DbType.String, entity.DVNo},
                    new object[] { "@date_paid", DbType.Date, entity.DatePaid},
                };

                string query = $"INSERT INTO {tableName} (jev_id, disbursing_officers_id, dv_no, date_paid) VALUES (@jev_id, @disbursing_officers_id, @dv_no, @date_paid)";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(CashDisbursementsJournalModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
