using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Transactions;

namespace ACC.Data
{
    class CollectorReportRepository:ICollectorReportRepository
    {
        private readonly IDbGenericCommands _dbGenericCommands;
        private readonly string tableName = "collector_report";
        private readonly string tableName2 = "collecting_officers";
        private readonly string tableName3 = "collector_report_payments";
        private readonly string tableName4 = "payment_collections";

        public CollectorReportRepository(IDbGenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
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
                    record.Add("collecting_officers_id", reader.Rows[0]["collecting_officers_id"].ToString());
                    record.Add("report_no", reader.Rows[0]["report_no"].ToString());
                    record.Add("date", reader.Rows[0]["date"].ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }

            return record;
        }

        public Dictionary<string, string> GetRecordByID(string Id)
        {
            var record = new Dictionary<string, string>();

            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@report_no", DbType.String, Id},
                };

                string query = $"SELECT * FROM {tableName} WHERE report_no = @report_no";

                using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;
                    record.Add("id", reader.Rows[0]["id"].ToString());
                    record.Add("collecting_officers_id", reader.Rows[0]["collecting_officers_id"].ToString());
                    record.Add("report_no", reader.Rows[0]["report_no"].ToString());
                    record.Add("date", reader.Rows[0]["date"].ToString());
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
                string query = $"SELECT {tableName}.id,{tableName}.report_no,{tableName}.date,CONCAT({tableName2}.last_name,', ',{tableName2}.first_name,' ',{tableName2}.mid_initial) AS collector FROM {tableName} LEFT JOIN {tableName2} ON {tableName2}.id={tableName}.collecting_officers_id ORDER BY {tableName}.date DESC";

                var dtcr = new DataTable();
                return _dbGenericCommands.Fill(query, dtcr);
            }
            catch (Exception)
            {
                throw;
            }
        }

       
        public bool Insert(CollectorReportModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@collecting_officers_id", DbType.Int16, entity.CoId},
                    new object[] { "@report_no", DbType.String, entity.ReportNo},
                    new object[] { "@date", DbType.Date, entity.Date},
                };

                string query = $"INSERT INTO {tableName} (collecting_officers_id,report_no,date) VALUES (@collecting_officers_id,@report_no,@date)";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(CollectorReportModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int16, entity.Id},
                    new object[] { "@collecting_officers_id", DbType.Int16, entity.CoId},
                    new object[] { "@report_no", DbType.String, entity.ReportNo},
                    new object[] { "@date", DbType.Date, entity.Date},
                };

                string query = $"UPDATE {tableName} SET collecting_officers_id=@collecting_officers_id,report_no=@report_no,date=@date WHERE id=@id";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(List<CollectorReportModel> entityList)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    foreach (var entity in entityList)
                    {
                        var parameters = new object[][]
                        {
                            new object[] { "@id", DbType.Int16, entity.Id},
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

        public bool IdExist(int id)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int16, id },
                };

                string query = $"SELECT id FROM {tableName} WHERE id = @id";
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

        public bool CodeExist(string id)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@report_no", DbType.String, id },
                };

                string query = $"SELECT report_no FROM {tableName} WHERE report_no = @report_no";
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

        public bool HasGenerated(int id)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@collector_report_id", DbType.Int16, id },
                };

                string query = $"SELECT * FROM {tableName3} WHERE collector_report_id = @collector_report_id";
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

        public DataTable GetRecordsBySearch(string searchText)
        {
            try
            {
                var srchtxt = searchText;

                string query = $"SELECT {tableName}.id,{tableName}.report_no,{tableName}.date,CONCAT({tableName2}.last_name,', ',{tableName2}.first_name,' ',{tableName2}.mid_initial) AS collector FROM {tableName} LEFT JOIN {tableName2} ON {tableName2}.id={tableName}.collecting_officers_id WHERE {tableName}.report_no LIKE '%{srchtxt}%' OR CONCAT({tableName2}.last_name,', ',{tableName2}.first_name,' ',{tableName2}.mid_initial) LIKE '%{srchtxt}%' ORDER BY {tableName}.date DESC";

                var dtpc = new DataTable();
                return _dbGenericCommands.Fill(query, dtpc);
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
