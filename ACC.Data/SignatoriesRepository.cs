using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACC.Data
{
    public class SignatoriesRepository : ISignatories
    {
        private MySqlGenericCommands mySqlGenericCommands;
        private readonly string tableName = "signatories";

        public SignatoriesRepository(MySqlGenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<SignatoriesModel> entityList)
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
                string query = $"SELECT id, CONCAT(prefix,'. ',first_name, ' ', middle_initial, '. ', last_name, ' ',suffix) AS name, title, created_at, updated_at FROM {tableName}";

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

        public bool Insert(SignatoriesModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@prefix", DbType.String, entity.Prefix},
                    new object[] { "@first_name", DbType.String, entity.FirstName},
                    new object[] { "@middle_initial",DbType.String, entity.MiddleInitial},
                    new object[] { "@last_name", DbType.String, entity.LastName},
                    new object[] { "@suffix", DbType.String, entity.Suffix},
                    new object[] { "@title", DbType.String, entity.Title}
                };

                string query = $"INSERT INTO {tableName} (prefix, first_name, middle_initial, last_name, suffix, title) VALUES (@prefix, @first_name, @middle_initial, @last_name, @suffix, @title)";

                return mySqlGenericCommands.ExecuteNonQuery(query, parameters);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(SignatoriesModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
