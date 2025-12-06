using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACC.Data
{
    public class SignatoriesHasReferencesRepository : ISignatoriesHasReferences
    {
        private AccGenericCommands mySqlGenericCommandsLFS;
        private readonly string tableName = "signatories_has_document_references";
        private readonly string viewTableName = "view_signatories_has_document_references";

        public SignatoriesHasReferencesRepository(AccGenericCommands mySqlGenericCommandsLFS)
        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
        }

        public bool Delete(List<SignatoriesHasReferencesModel> entityList)
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

        public bool Insert(SignatoriesHasReferencesModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@signatories_id", DbType.Int32, entity.SignatoriesId },
                new object[] { "@document_references_id", DbType.Int32, entity.DocumentReferencesId}
            };

            string query = $"INSERT INTO {tableName} (signatories_id, document_references_id) VALUES (@signatories_id, @document_references_id)";
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Update(SignatoriesHasReferencesModel entity)
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecordsBySignatoryId(int signatoyId)
        {
            var parameters = new object[][]
            {
                new object[] { "@signatories_id", DbType.Int32, signatoyId}
            };

            string query = $"SELECT * FROM {tableName} WHERE signatories_id = @signatories_id";
            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
        }

        public bool DeleteBySignatoryId(int signatoryId)
        {
            var parameters = new object[][]
            {
                new object[] { "@signatories_id", DbType.Int32, signatoryId }
            };

            string query = $"DELETE FROM {tableName} WHERE signatories_id = @signatories_id";
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool IsReferencedBySignatory(int documentReferenceId, int signatories_id)
        {
            var parameters = new object[][]
            {
                new object[] { "@document_references_id", DbType.Int16, documentReferenceId },
                new object[] { "@signatories_id", DbType.String, signatories_id },
            };

            string query = $"SELECT document_references_id FROM {tableName} WHERE document_references_id = @document_references_id AND signatories_id = @signatories_id";
            string result = mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);
            return !string.IsNullOrEmpty(result);
        }

        public bool ReferenceIdExist(int documentReferenceId)
        {
            var parameters = new object[][]
            {
                new object[] { "@document_references_id", DbType.Int32, documentReferenceId }
            };

            string query = $"SELECT document_references_id FROM {tableName} WHERE document_references_id = @document_references_id";
            string result = mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);
            return !string.IsNullOrEmpty(result);
        }

        public bool ReferenceIdExist(int documentReferenceId, int signatories_id)
        {
            var parameters = new object[][]
            {
                new object[] { "@document_references_id", DbType.Int32, documentReferenceId },
                new object[] { "@signatories_id", DbType.Int32, signatories_id }
            };

            string query = $"SELECT document_references_id FROM {tableName} WHERE signatories_id <> @signatories_id AND  document_references_id = @document_references_id";
            string result = mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);
            return !string.IsNullOrEmpty(result);
        }

        public DataTable GetDocumentRecordsBySignatoryId(int signatoryId)
        {
            var parameters = new object[][]
            {
                new object[] { "@signatories_id", DbType.Int32, signatoryId}
            };

            string query = $"SELECT * FROM {viewTableName} WHERE signatories_id = @signatories_id GROUP BY documents_id";
            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
        }

        public Dictionary<string, string> GetSigntryByRefDoc(string reference, string documentName)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@document_references_name", DbType.String, reference},
                new object[] { "@documents_name", DbType.String, documentName }
            };

            string query = $"SELECT * FROM {viewTableName} WHERE document_references_name = @document_references_name AND documents_name = @documents_name";

            DataTable dataTable = mySqlGenericCommandsLFS.ExecuteReader(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                foreach (DataColumn column in dataTable.Columns)
                    recordDictionary[column.ColumnName] = row[column].ToString();

                return recordDictionary;
            }
            return recordDictionary;
        }
    }
}