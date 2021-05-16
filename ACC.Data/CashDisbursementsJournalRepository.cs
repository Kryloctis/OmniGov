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
            throw new NotImplementedException();
        }

        public bool Update(CashDisbursementsJournalModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
