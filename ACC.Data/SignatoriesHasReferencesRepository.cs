using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACC.Data
{
    public class SignatoriesHasReferencesRepository : ISignatoriesHasReferences
    {
        private MySqlGenericCommands mySqlGenericCommands;
        private const string tableName = "signatories_has_document_references";
        private const string viewTableName = "view_signatories_has_document_references";

        public SignatoriesHasReferencesRepository(MySqlGenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public int CountRecords()
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(List<SignatoriesHasReferencesModel> entityList)
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

        public bool Insert(SignatoriesHasReferencesModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@signatories_id", DbType.Int32, entity.SignatoriesId },
                    new object[] { "@document_references_id", DbType.Int32, entity.DocumentReferencesId}
                };

                string query = $"INSERT INTO {tableName} (signatories_id, document_references_id) VALUES (@signatories_id, @document_references_id)";
                return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(SignatoriesHasReferencesModel entity)
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetRecordsBySignatoryId(int signatoyId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@signatories_id", DbType.Int32, signatoyId}
                };

                string query = $"SELECT * FROM {tableName} WHERE signatories_id = @signatories_id";
                var dataTable = new DataTable();
                return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteBySignatoryId(int signatoryId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@signatories_id", DbType.Int32, signatoryId }
                };

                string query = $"DELETE FROM {tableName} WHERE signatories_id = @signatories_id";
                return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IsReferencedBySignatory(int documentReferenceId, int signatories_id)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@document_references_id", DbType.Int16, documentReferenceId },
                    new object[] { "@signatories_id", DbType.String, signatories_id },
                };

                string query = $"SELECT document_references_id FROM {tableName} WHERE document_references_id = @document_references_id AND signatories_id = @signatories_id";
                string queryResult = mySqlGenericCommands.ExecuteScalar(query, parameters);

                // if query is not null, means found some record, so true
                if (!string.IsNullOrEmpty(queryResult)) return true;
            }
            catch (Exception)
            {
                throw;
            };

            return false;
        }

        public bool ReferenceIdExist(int documentReferenceId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@document_references_id", DbType.Int32, documentReferenceId }
                };

                string query = $"SELECT document_references_id FROM {tableName} WHERE document_references_id = @document_references_id";
                string queryResult = mySqlGenericCommands.ExecuteScalar(query, parameters);

                // if query is not null, means found some record, so true
                if (!string.IsNullOrEmpty(queryResult)) return true;
            }
            catch (Exception)
            {
                throw;
            };

            return false;
        }

        public bool ReferenceIdExist(int documentReferenceId, int signatories_id)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@document_references_id", DbType.Int32, documentReferenceId },
                    new object[] { "@signatories_id", DbType.Int32, signatories_id }
                };

                string query = $"SELECT document_references_id FROM {tableName} WHERE signatories_id <> @signatories_id AND  document_references_id = @document_references_id";
                string queryResult = mySqlGenericCommands.ExecuteScalar(query, parameters);

                // if query is not null, means found some record, so true
                if (!string.IsNullOrEmpty(queryResult)) return true;
            }
            catch (Exception)
            {
                throw;
            };

            return false;
        }

        public DataTable GetDocumentRecordsBySignatoryId(int signatoryId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@signatories_id", DbType.Int32, signatoryId}
                };

                string query = $"SELECT * FROM {viewTableName} WHERE signatories_id = @signatories_id GROUP BY documents_id";
                var dataTable = new DataTable();
                return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Dictionary<string, string> GetSignatoryByReferenceAndDocumentName(string reference, string documentName)
        {
            try
            {
                var record = new Dictionary<string, string>();


                var parameters = new object[][]
                {
                    new object[] { "@document_references_name", DbType.String, reference},
                    new object[] { "@documents_name", DbType.String, documentName }
                };

                string query = $"SELECT signatories_full_name, signatories_title FROM {viewTableName} WHERE document_references_name = @document_references_name AND documents_name = @documents_name";

                using (var reader = mySqlGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;

                    record.Add("signatories_full_name", reader.Rows[0]["signatories_full_name"].ToString());
                    record.Add("signatories_title", reader.Rows[0]["signatories_title"].ToString());
                }

                return record;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
