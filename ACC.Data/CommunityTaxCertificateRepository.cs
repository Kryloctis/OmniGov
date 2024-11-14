using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace ACC.Data
{
    internal class CommunityTaxCertificateRepository : ICommunityTaxCertificateRepository
    {
        private AccGenericCommands mySqlGenericCommandsLFS;

        public CommunityTaxCertificateRepository(AccGenericCommands mySqlGenericCommandsLFS)
        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
        }

        public bool Delete(List<CommunityTaxCertificateModel> entityList)
        {
            throw new System.NotImplementedException();
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetRecords()
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new System.NotImplementedException();
        }

        public bool IdExist(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(CommunityTaxCertificateModel entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(CommunityTaxCertificateModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}