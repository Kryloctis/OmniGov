using OmniGov.Core.Entities;
using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Core.Interfaces.Services;
using System.Data;

using OmniGov.Core.Services;

namespace OmniGov.Core.Repositories
{
    public class DocumentsRepository : IDocuments
    {
        private IGenericCommands mySqlGenericCommands;

        public DocumentsRepository(IGenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public int CountRecords()
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(List<DocumentsModel> entityList)
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

        public bool Insert(DocumentsModel entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(DocumentsModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
