using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Transactions;

namespace ACC.Data
{
    public class OthersFPPRepository : IOthersFPPRepository
    {

        private readonly string tableName = "others_fpp";

        private MySqlGenericCommands mySqlGenericCommands;

        public OthersFPPRepository(MySqlGenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<OthersFPPModel> entityList)
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
            var record = new Dictionary<string, string>();

            try
            {
                var parameters = new object[][]
                {
                   new object[] {"@id", DbType.Int32, Id},
                };
                string query = $"SELECT name FROM {tableName} WHERE id = @id";

                using (var reader = mySqlGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;

                    foreach (DataRow item in reader.Rows)
                    {
                        record.Add("name", item[0].ToString());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return record;
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

        public bool Insert(OthersFPPModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@name", DbType.String, entity.Name},
                    new object[] { "@function_program_project_id", DbType.Int32, entity.functionProgramProjectId}
                };

                string query = $"INSERT INTO {tableName} (name , function_program_project_id) VALUES (@name, @function_program_project_id)";
                return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(OthersFPPModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, entity.Id},
                    new object[] { "@name", DbType.String, entity.Name},

                };

                string query = $"UPDATE {tableName} SET name = @name WHERE id = @id";
                return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region Validations

        public bool NameExist(string name)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@name", DbType.String, name},
                };

                string query = $"SELECT id FROM {tableName} WHERE name = @name";
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

        public bool NameExist(int id, string name)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@name", DbType.String, name},
                    new object[] { "@id", DbType.Int32, id}
                };

                string query = $"SELECT id FROM {tableName} WHERE id <> @id AND name = @name";
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

        public DataTable GetRecordsByID(int id)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@function_program_project_id", DbType.Int32, id }
                };


                string query = $"SELECT id, function_program_project_id, name, created_at, updated_at FROM {tableName} WHERE function_program_project_id = @function_program_project_id";

                var dtOthersFPP = new DataTable();
                return mySqlGenericCommands.FillBySearch(query, dtOthersFPP, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetRecorsBySearchAndID(int id, string searchtxt)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@function_program_project_id", DbType.Int32, id },
                    new object[] {"@name", DbType.String, $"%{searchtxt}%"}
                };


                string query = $"SELECT id, function_program_project_id, name, created_at, updated_at FROM {tableName} WHERE function_program_project_id = @function_program_project_id AND name LIKE @name";

                var dtOthersFPP = new DataTable();
                return mySqlGenericCommands.FillBySearch(query, dtOthersFPP, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Validations
    }
}
