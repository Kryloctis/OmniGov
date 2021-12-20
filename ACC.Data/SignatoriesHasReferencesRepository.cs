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
    }
}
