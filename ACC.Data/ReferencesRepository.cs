using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACC.Data
{
    public class ReferencesRepository : IReferences
    {
        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<ReferencesModel> entityList)
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

        public bool Insert(ReferencesModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(ReferencesModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
