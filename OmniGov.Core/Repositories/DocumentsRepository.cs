using OmniGov.Core.Entities;
using OmniGov.Core.Interfaces;
using System.Data;

namespace OmniGov.Core.Repositories
{
    public class DocumentsRepository : IDocuments
    {
        private GenericCommands mySqlGenericCommands;

        public DocumentsRepository(GenericCommands mySqlGenericCommands)
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