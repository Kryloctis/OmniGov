using System;
using System.Collections.Generic;
using ACC.Domain.Models;
using ACC.Domain.Interfaces;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    public class RCIDeductionsRepository : IRCIDeductions
    {
        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<RCIObligationsModel> entityList)
        {
            throw new NotImplementedException();
        }

        public DataTable GetDeductionsByRCIId(int rciId)
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

        public bool Insert(RCIObligationsModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(RCIObligationsModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
