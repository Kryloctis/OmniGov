using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACC.Data
{
    public class DocumentReferencesRepository : IDocumentReferences
    {
        private AccGenericCommands mySqlGenericCommands;
        private const string tableName = "document_references";
        private const string viewTableName = "view_document_references";

        public DocumentReferencesRepository(AccGenericCommands mySqlGenericCommands)
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
            string query = $"SELECT * FROM {viewTableName}";
            var dataTable = new DataTable();
            return mySqlGenericCommands.Fill(query, dataTable);
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
            var dataTable = new DataTable();
            return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }
    }
}
