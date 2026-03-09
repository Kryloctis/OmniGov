using OmniGov.Core.Entities;
using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Core.Interfaces.Services;
using System.Data;

namespace OmniGov.Core.Repositories
{
    public class DocumentsRepository : IDocuments
    {
        private IGenericCommands _genericCommands;

        public DocumentsRepository(IGenericCommands genericCommands)
        {
            this._genericCommands = genericCommands;
        }

        public bool Delete(List<DocumentsModel> entityList)
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

        public bool Insert(DocumentsModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(DocumentsModel entity)
        {
            throw new NotImplementedException();
        }
    }
}