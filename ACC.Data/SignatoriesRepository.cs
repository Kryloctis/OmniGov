using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    public class SignatoriesRepository : ISignatories
    {
        private MySqlGenericCommands mySqlGenericCommands;
        private readonly string tableName = "signatories";
        private readonly ISignatoriesHasReferences _signatoriesHasReferences;

        public SignatoriesRepository(MySqlGenericCommands mySqlGenericCommands, ISignatoriesHasReferences signatoriesHasReferences)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
            _signatoriesHasReferences = signatoriesHasReferences;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public byte GetLastInsertedID()
        {
            try
            {
                string query = $"SELECT MAX(id) FROM {tableName}";
                return byte.Parse(mySqlGenericCommands.ExecuteScalar(query));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(List<SignatoriesModel> entityList)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    foreach (var entity in entityList)
                    {
                        var parameters = new object[][]
                        {
                            new object[] { "@id", DbType.Int32, entity.Id},
                        };

                        string query = $"DELETE FROM {tableName} WHERE id = @id";
                        _ = mySqlGenericCommands.ExecuteNonQuery(query, parameters);
                    }

                    scope.Complete();
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            try
            {
                var record = new Dictionary<string, string>();

                try
                {
                    var parameters = new object[][]
                    {
                    new object[] { "@id", DbType.Int32, Id},
                    };

                    string query = $"SELECT prefix, first_name, middle_initial, last_name, suffix, title FROM {tableName} WHERE id = @id";

                    using (var reader = mySqlGenericCommands.ExecuteReader(query, parameters))
                    {
                        if (reader.Rows.Count < 1)
                            return record;

                        record.Add("prefix", reader.Rows[0]["prefix"].ToString());
                        record.Add("first_name", reader.Rows[0]["first_name"].ToString());
                        record.Add("middle_initial", reader.Rows[0]["middle_initial"].ToString());
                        record.Add("last_name", reader.Rows[0]["last_name"].ToString());
                        record.Add("suffix", reader.Rows[0]["suffix"].ToString());
                        record.Add("title", reader.Rows[0]["title"].ToString());
                    }
                }
                catch (Exception)
                {
                    throw;
                }

                return record;
            }
            catch (Exception)
            {
                throw;
            }
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
            throw new NotImplementedException();
        }

        public bool Update(SignatoriesModel entity)
        {
            try
            {
                var parameters = new object[][]
                  {
                    new object[] { "@id", DbType.Int32, entity.Id},
                    new object[] { "@prefix", DbType.String, entity.Prefix},
                    new object[] { "@first_name", DbType.String, entity.FirstName},
                    new object[] { "@middle_initial",DbType.String, entity.MiddleInitial},
                    new object[] { "@last_name", DbType.String, entity.LastName},
                    new object[] { "@suffix", DbType.String, entity.Suffix},
                    new object[] { "@title", DbType.String, entity.Title}
                  };

                string query = $"UPDATE {tableName} SET prefix = @prefix, first_name = @first_name, middle_initial = @middle_initial, last_name = @last_name, suffix = @suffix, title = @title WHERE id = @id";

                return mySqlGenericCommands.ExecuteNonQuery(query, parameters);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Insert(SignatoriesModel signatoriesModel, List<SignatoriesHasReferencesModel> signatoriesHasReferencesModelList)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    var parameters = new object[][]
                     {
                        new object[] { "@prefix", DbType.String, signatoriesModel.Prefix},
                        new object[] { "@first_name", DbType.String, signatoriesModel.FirstName},
                        new object[] { "@middle_initial",DbType.String, signatoriesModel.MiddleInitial},
                        new object[] { "@last_name", DbType.String, signatoriesModel.LastName},
                        new object[] { "@suffix", DbType.String, signatoriesModel.Suffix},
                        new object[] { "@title", DbType.String, signatoriesModel.Title}
                     };

                    string query = $"INSERT INTO {tableName} (prefix, first_name, middle_initial, last_name, suffix, title) VALUES (@prefix, @first_name, @middle_initial, @last_name, @suffix, @title)";

                    _ = mySqlGenericCommands.ExecuteNonQuery(query, parameters);

                    foreach (SignatoriesHasReferencesModel signatoriesHasReferencesModel in signatoriesHasReferencesModelList)
                    {
                        signatoriesHasReferencesModel.SignatoriesId = GetLastInsertedID();
                        _signatoriesHasReferences.Insert(signatoriesHasReferencesModel);
                    }

                    scope.Complete();
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
