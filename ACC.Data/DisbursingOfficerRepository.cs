using System;
using System.Collections.Generic;
using ACC.Domain.Models;
using ACC.Domain.Interfaces;
using System.Data;

namespace ACC.Data
{
    public class DisbursingOfficerRepository : IDisbursingOfficerRepository
    {
        private readonly IDbGenericCommands _dbGenericCommands;
        private readonly string tableName = "disbursing_officers";

        public DisbursingOfficerRepository(IDbGenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<DisbursingOfficerModel> entityList)
        {
            throw new NotImplementedException();
        }

        public bool FullNameExist(string firstName, string middleInitial, string lastName, int id)
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

        public bool Insert(DisbursingOfficerModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@first_name", DbType.String, entity.FirstName},
                    new object[] { "@mid_initial", DbType.String, entity.MiddleInitial},
                    new object[] { "@last_name", DbType.String, entity.LastName},
                    new object[] { "@job_title", DbType.String, entity.JobTitle},
                };

                string query = $"INSERT INTO {tableName} (first_name, mid_initial, last_name, job_title) VALUES (@first_name, @mid_initial, @last_name, @job_title)";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(DisbursingOfficerModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
