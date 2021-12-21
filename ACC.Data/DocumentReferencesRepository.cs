using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACC.Data
{
    public class DocumentReferencesRepository : IDocumentReferences
    {
        private MySqlGenericCommands mySqlGenericCommands;
        private const string tableName = "document_references";
        private const string viewTableName = "view_document_references";

        public DocumentReferencesRepository(MySqlGenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
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
            try
            {
                string query = $"Select * FROM {tableName}";
                var dataTable = new DataTable();
                return mySqlGenericCommands.Fill(query, dataTable);
            }
            catch (Exception)
            {
                throw;
            }
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
            try
            {
                string query = $"SELECT * FROM {viewTableName}";
                var dataTable = new DataTable();
                return mySqlGenericCommands.Fill(query, dataTable);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
