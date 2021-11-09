using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Transactions;
using ACC.Domain.Interfaces;
using ACC.Domain.Models;

namespace ACC.Data
{
    public class FaceValueRepository : IFaceValueRepository
    {
        private readonly IDbGenericCommands _dbGenericCommands;
        private readonly string tableName = "face_values";
        public FaceValueRepository(IDbGenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
        }
        public int CountRecords()
        {
            try
            {
                string query = $"SELECT COUNT(*) FROM {tableName}";

                return int.Parse(_dbGenericCommands.ExecuteScalar(query));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(List<FaceValueModel> entityList)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    foreach (var entity in entityList)
                    {
                        var parameters = new object[][]
                        {
                            new object[] { "@id", DbType.Int16, entity.id},
                        };

                        string query = $"DELETE FROM {tableName} WHERE id = @id";
                        _ = _dbGenericCommands.ExecuteNonQuery(query, parameters);
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
                    new object[] { "@id", DbType.Int32, Id},
                };

                string query = $"SELECT * FROM {tableName} WHERE id = @id";

                using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;

                    record.Add("id", reader.Rows[0]["id"].ToString());
                    record.Add("accountable_forms_id", reader.Rows[0]["accountable_forms_id"].ToString());
                    record.Add("faceyear", reader.Rows[0]["faceyear"].ToString());
                    record.Add("facevalue", reader.Rows[0]["facevalue"].ToString());
                    record.Add("facedefault", reader.Rows[0]["facedefault"].ToString());
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
                string query = $"SELECT * FROM {tableName} ORDER BY faceyear DESC";

                var dtBanks = new DataTable();
                return _dbGenericCommands.Fill(query, dtBanks);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetRecords(int id)
        {
            try
            {
                string query = $"SELECT * FROM {tableName} WHERE accountable_forms_id={id} ORDER BY faceyear DESC";

                var dtBanks = new DataTable();
                return _dbGenericCommands.Fill(query, dtBanks);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            try
            {
                string query = $"SELECT * FROM {tableName} WHERE faceyear LIKE '%{searchText}%' OR facevalue LIKE '%{searchText}%' ORDER BY faceyear DESC";

                var dtBanks = new DataTable();
                return _dbGenericCommands.Fill(query, dtBanks);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(FaceValueModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@accountable_forms_id", DbType.String, entity.accountable_forms_id},
                    new object[] { "@faceyear", DbType.Int32, entity.faceyear},
                    new object[] { "@facevalue", DbType.Decimal, entity.facevalue},
                    new object[] { "@facedefault", DbType.Int16, entity.facedefault},
                };

                string query = $"INSERT INTO {tableName} (accountable_forms_id,faceyear,facevalue,facedefault) VALUES (@accountable_forms_id,@faceyear,@facevalue,@facedefault)";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(FaceValueModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, entity.id},
                    new object[] { "@accountable_forms_id", DbType.String, entity.accountable_forms_id},
                    new object[] { "@faceyear", DbType.Int32, entity.faceyear},
                    new object[] { "@facevalue", DbType.Decimal, entity.facevalue},
                    new object[] { "@facedefault", DbType.Int16, entity.facedefault},
                };

                string query = $"UPDATE {tableName} SET accountable_forms_id=@accountable_forms_id,faceyear=@faceyear,facevalue=@facevalue,facedefault=@facedefault WHERE id = @id";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool SetDefault(int id)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, id},
                    
                };

                string query = $"UPDATE {tableName} SET facedefault=1 WHERE id = @id;UPDATE {tableName} SET facedefault=0 WHERE id <> @id;";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool YearExist(int id,int year)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@accountable_forms_id", DbType.Int32, id },
                    new object[] { "@faceyear", DbType.Int32, year },
                };

                string query = $"SELECT * FROM {tableName} WHERE accountable_forms_id = @accountable_forms_id AND faceyear=@faceyear";
                string queryResult = _dbGenericCommands.ExecuteScalar(query, parameters);

                // if query is not null, means found some record, so true
                if (!string.IsNullOrEmpty(queryResult)) return true;
            }
            catch (Exception)
            {
                throw;
            };

            return false;
        }

        public decimal GetFaceValueByAccountableFormId(int id)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] {"@accountableFormId", DbType.Int32, id},
                };

                string query = $"SELECT COALESCE(amount, 0) AS amount FROM {tableName} WHERE accountable_forms_id=@accountableFormId";

                var queryResult = _dbGenericCommands.ExecuteScalar(query, parameters);

                if (string.IsNullOrEmpty(queryResult))
                    return 0;
                else
                    return Convert.ToDecimal(queryResult); 

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
