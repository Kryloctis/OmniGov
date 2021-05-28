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

        private MySqlGenericCommands _mySqlGenericCommands;

        public OthersFPPRepository(MySqlGenericCommands mySqlGenericCommands)
        {
            this._mySqlGenericCommands = mySqlGenericCommands;
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
                        _ = _mySqlGenericCommands.ExecuteNonQuery(query, parameters);
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
                string query = $"SELECT others_fpp_code, name FROM {tableName} WHERE id = @id";

                using (var reader = _mySqlGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;

                    foreach (DataRow item in reader.Rows)
                    {
                        record.Add("others_fpp_code", item[0].ToString());
                        record.Add("name", item[1].ToString());
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
            try
            {
                string query = $"SELECT id, function_program_project_id, others_fpp_code, name, created_at, updated_at FROM {tableName}";

                var dtPermissions = new DataTable();
                return _mySqlGenericCommands.Fill(query, dtPermissions);
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

        public bool Insert(OthersFPPModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@function_program_project_id", DbType.Int32, entity.functionProgramProjectId},
                    new object[] { "@others_fpp_code", DbType.String, entity.othersFPPCode},
                    new object[] { "@name", DbType.String, entity.othersFPPName}
                };

                string query = $"INSERT INTO {tableName} (function_program_project_id, others_fpp_code, name) VALUES (@function_program_project_id, @others_fpp_code, @name)";
                return _mySqlGenericCommands.ExecuteNonQuery(query, parameters);
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
                    new object[] { "@others_fpp_code", DbType.String, entity.othersFPPCode},
                    new object[] { "@name", DbType.String, entity.othersFPPName},
                };

                string query = $"UPDATE {tableName} SET others_fpp_code = @others_fpp_code, name = @name WHERE id = @id";
                return _mySqlGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetRecordsByFPPID(int id)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@function_program_project_id", DbType.Int32, id }
                };

                string query = $"SELECT " +
                    $"id, " +
                    $"function_program_project_id, " +
                    $"others_fpp_code, " +
                    $"name, " +
                    $"created_at, " +
                    $"updated_at " +
                    $"FROM {tableName} " +
                    $"WHERE " +
                    $"function_program_project_id = @function_program_project_id";

                var dtOthersFPP = new DataTable();
                return _mySqlGenericCommands.FillBySearch(query, dtOthersFPP, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetRecorsByIDSearchCode(int id, string searchtxt)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@function_program_project_id", DbType.Int32, id },
                    new object[] {"@searchTxt", DbType.String, $"%{searchtxt}%"}
                };

                string query = $"SELECT " +
                    $"id, " +
                    $"function_program_project_id, " +
                    $"others_fpp_code, " +
                    $"name, " +
                    $"created_at, " +
                    $"updated_at " +
                    $"FROM {tableName} " +
                    $"WHERE " +
                    $"function_program_project_id = @function_program_project_id  " +
                    $"AND (name LIKE @searchTxt OR others_fpp_code LIKE @searchTxt)";

                var dtOthersFPP = new DataTable();
                return _mySqlGenericCommands.FillBySearch(query, dtOthersFPP, parameters);
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
                string queryResult = _mySqlGenericCommands.ExecuteScalar(query, parameters);

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
                string queryResult = _mySqlGenericCommands.ExecuteScalar(query, parameters);

                // if query is not null, means found some record, so true
                if (!string.IsNullOrEmpty(queryResult)) return true;
            }
            catch (Exception)
            {
                throw;
            };

            return false;
        }


        public bool CodeExist(string otherFPPCode)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@others_fpp_code", DbType.String, otherFPPCode}
                };

                string query = $"SELECT id FROM {tableName} WHERE others_fpp_code = @others_fpp_code";

                string queryResult = _mySqlGenericCommands.ExecuteScalar(query, parameters);

                if (!string.IsNullOrEmpty(queryResult)) return true;
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        public bool CodeExist(int id, string otherFPPCode)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, id},
                    new object[] { "@others_fpp_code",DbType.String, otherFPPCode}
                };

                string query = $"SELECT id FROM {tableName} WHERE id <> @id AND others_fpp_code = @others_fpp_code";

                string queryResult = _mySqlGenericCommands.ExecuteScalar(query, parameters);

                if (!string.IsNullOrEmpty(queryResult)) return true;
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        #endregion Validations
    }
}
