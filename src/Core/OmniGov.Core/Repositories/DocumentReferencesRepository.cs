using OmniGov.Core.Entities;
using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Core.Interfaces.Services;
using System.Data;

namespace OmniGov.Core.Repositories
{
    public class DocumentReferencesRepository : IDocumentReferences
    {
        private IGenericCommands _genericCommands;
        private const string tableName = "document_references";
        private const string viewTableName = "view_document_references";

        public DocumentReferencesRepository(IGenericCommands genericCommands)
        {
            _genericCommands = genericCommands;
        }

        public bool Delete(List<DocumentReferencesModel> entityList)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecords()
        {
            string query = $"Select * FROM {tableName}";
            var dataTable = new DataTable();
            return _genericCommands.Fill(query, dataTable);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new NotImplementedException();
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(DocumentReferencesModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(DocumentReferencesModel entity)
        {
            throw new NotImplementedException();
        }

        public DataTable GetViewRecords()
        {
            string query = $"SELECT * FROM {viewTableName}";
            return _genericCommands.Fill(query, new DataTable());
        }

        public DataTable GetViewRecordsByOffice(string office)
        {
            var parameters = new dynamic[][]
            {
                new dynamic[] { "@office", DbType.String, $"%{office}%"}
            };

            string Filter()
            {
                if (office == "All")
                    return string.Empty;
                else
                    return "WHERE office LIKE @office";
            }

            string query = $"SELECT * FROM {viewTableName} {Filter()}";
            return _genericCommands.FillBySearch(query, new DataTable(), parameters);
        }
    }
}