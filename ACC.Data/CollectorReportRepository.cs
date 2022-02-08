using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using AccountingSystem;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Transactions;

namespace ACC.Data
{
    class CollectorReportRepository : ICollectorReportRepository
    {
        private readonly IDbGenericCommands _dbGenericCommands;
        private readonly string tableName = "collector_report";
        private readonly string tableCollectingOfficer = "collecting_officers";
        private readonly string tableCollectorReportPayments = "collector_report_payments";
        private readonly string tablePaymentCollections = "payment_collections";
        private readonly string tableFunds = "funds";



        private readonly string viewTableName = "view_collector_report";

        public CollectorReportRepository(IDbGenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
        }

        public Dictionary<string, string> GetRecordByID(int id)
        {
            var record = new Dictionary<string, string>();

            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, id},
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
                    record.Add("is_approved", reader.Rows[0]["is_approved"].ToString());
                    record.Add("funds_id", reader.Rows[0]["funds_id"].ToString());
                    record.Add("remarks", reader.Rows[0]["remarks"].ToString());
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
                    record.Add("is_approved", reader.Rows[0]["is_approved"].ToString());
                    record.Add("funds_id", reader.Rows[0]["funds_id"].ToString());
                    record.Add("remarks", reader.Rows[0]["remarks"].ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }

            return record;
        }

        public DataTable GetCollectorsReportByReportNo(string reportNumber)
        {
            try
            {
                var parameter = new object[][] {
                    new object[]{"@reportNo", DbType.String, reportNumber},
                };

                string query = $"SELECT " +
                    $"collecting_officer,  " +
                    $"report_no, " +
                    $"amount " +
                    $"FROM {viewTableName} " +
                    $"WHERE is_approved = 1 ";

                var dtpc = new DataTable();
                return _dbGenericCommands.FillBySearch(query, dtpc, parameter);
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
                List<string> conditions = new List<string>();
                string query = $"SELECT {tableName}.id," +
                        $"{tableName}.report_no," +
                        $"CONCAT({tableFunds}.fund_code,'-',{tableFunds}.fund_name) AS fund," +
                        $"{tableName}.date," +
                        $"CONCAT({tableCollectingOfficer}.last_name,', ',{tableCollectingOfficer}.first_name,' ',{tableCollectingOfficer}.mid_initial) AS collector," +
                        $"(SELECT SUM({tablePaymentCollections}.amount) FROM {tableCollectorReportPayments} LEFT JOIN {tablePaymentCollections} ON {tableCollectorReportPayments}.payment_collections_id={tablePaymentCollections}.id AND {tableCollectorReportPayments}.collector_report_id={tableName}.id) AS colamount," +
                        $"{tableName}.is_approved " +
                        $"FROM {tableName} LEFT JOIN {tableCollectingOfficer} ON {tableCollectingOfficer}.id={tableName}.collecting_officers_id LEFT JOIN {tableFunds} ON {tableName}.funds_id={tableFunds}.id";
                var uRepository = Factory.UsersRepository();
                int cid = uRepository.LinkedCollector(Factory.UserId) ? int.Parse(uRepository.GetCollectorByUserId(Factory.UserId)) : 0;
                if (cid > 0) conditions.Add($"{tableName}.collecting_officers_id={cid}");
                if (conditions.Count > 0)
                {
                    query += $" WHERE {string.Join(" AND ", conditions)}";
                }
                var dtcr = new DataTable();
                return _dbGenericCommands.Fill(query, dtcr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetRecords(string id)
        {
            try
            {
                List<string> conditions = new List<string>();
                string query = $"SELECT {tableName}.id," +
                        $"{tableName}.report_no," +
                        $"CONCAT({tableFunds}.fund_code,'-',{tableFunds}.fund_name) AS fund," +
                        $"{tableName}.date," +
                        $"CONCAT({tableCollectingOfficer}.last_name,', ',{tableCollectingOfficer}.first_name,' ',{tableCollectingOfficer}.mid_initial) AS collector," +
                        $"(SELECT SUM({tablePaymentCollections}.amount) FROM {tableCollectorReportPayments} LEFT JOIN {tablePaymentCollections} ON {tableCollectorReportPayments}.payment_collections_id={tablePaymentCollections}.id AND {tableCollectorReportPayments}.collector_report_id={tableName}.id) AS colamount," +
                        $"{tableName}.is_approved " +
                        $"FROM {tableName} LEFT JOIN {tableCollectingOfficer} ON {tableCollectingOfficer}.id={tableName}.collecting_officers_id LEFT JOIN {tableFunds} ON {tableName}.funds_id={tableFunds}.id";
                var uRepository = Factory.UsersRepository();
                int cid = uRepository.LinkedCollector(Factory.UserId) ? int.Parse(uRepository.GetCollectorByUserId(Factory.UserId)) : 0;
                if (cid > 0) conditions.Add($"{tableName}.collecting_officers_id={cid}");
                if (id.Length > 0) conditions.Add($"{tableName}.id IN ({id})");
                if (conditions.Count > 0)
                {
                    query += $" WHERE {string.Join(" AND ", conditions)}";
                }
                var dtcr = new DataTable();
                return _dbGenericCommands.Fill(query, dtcr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetRecords(int approved, string status, int fid, string date)
        {
            try
            {
                List<string> conditions = new List<string>();
                var uRepository = Factory.UsersRepository();
                int colid = uRepository.LinkedCollector(Factory.UserId) ? int.Parse(uRepository.GetCollectorByUserId(Factory.UserId)) : 0;
                string query = $"SELECT {tableName}.id," +
                       $"{tableName}.report_no," +
                       $"CONCAT({tableFunds}.fund_code,'-',{tableFunds}.fund_name) AS fund," +
                       $"{tableName}.date," +
                       $"CONCAT({tableCollectingOfficer}.last_name,', ',{tableCollectingOfficer}.first_name,' ',{tableCollectingOfficer}.mid_initial) AS collector," +
                       $"(SELECT SUM({tablePaymentCollections}.amount) FROM {tableCollectorReportPayments} LEFT JOIN {tablePaymentCollections} ON {tableCollectorReportPayments}.payment_collections_id={tablePaymentCollections}.id AND {tableCollectorReportPayments}.collector_report_id={tableName}.id) AS colamount," +
                       $"{tableName}.is_approved " +
                       $"FROM {tableName} LEFT JOIN {tableCollectingOfficer} ON {tableCollectingOfficer}.id={tableName}.collecting_officers_id LEFT JOIN {tableFunds} ON {tableName}.funds_id={tableFunds}.id";
                if (colid > 0) conditions.Add($"{tableName}.collecting_officers_id={colid}");
                if (date.Length > 0) conditions.Add($"{tableName}.date='{date}'");
                if (approved > 0) conditions.Add($"{tableName}.is_approved={approved}");
                if (status.Length > 0) conditions.Add($"{tableName}.status='{status}'");
                if (fid > 0) conditions.Add($"{tableName}.funds_id={fid}");
                if (conditions.Count > 0)
                {
                    query += $" WHERE {string.Join(" AND ", conditions)}";
                }
                var dtcr = new DataTable();
                return _dbGenericCommands.Fill(query, dtcr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetRecordsByReportNumber(string reportNumber)
        {
            try
            {
                var parameter = new object[][] {
                    new object[] {"@reportNumber", DbType.String, reportNumber}
                };

                string query = $"SELECT * FROM {viewTableName} WHERE report_no = @reportNumber";

                var dtReport = new DataTable();
                return _dbGenericCommands.FillBySearch(query, dtReport, parameter);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable GetSummary(int cid, int fid, int year)
        {
            try
            {
                List<string> conditions = new List<string>();
                string query = $"SELECT * FROM {tableName}";
                if (cid > 0) conditions.Add($"collecting_officers_id={cid}");
                if (year > 0) conditions.Add($"DATE_FORMAT(date,'%Y')={year}");
                if (fid > 0) conditions.Add($"funds_id={fid}");

                if (conditions.Count > 0)
                {
                    query += $" WHERE {string.Join(" AND ", conditions)}";
                }
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
                    new object[] { "@collecting_officers_id", DbType.Int16, entity.CollectorId},
                    new object[] { "@report_no", DbType.String, entity.ReportNo},
                    new object[] { "@date", DbType.Date, entity.Date},
                    new object[] { "@is_approved", DbType.Int16, entity.IsApproved},
                    new object[] { "@is_disapproved", DbType.Int16, entity.IsDisapproved},
                    new object[] { "@funds_id", DbType.Int16, entity.FundId},
                    new object[] { "@remarks", DbType.String, entity.Remarks}
                };

                string query = $"INSERT INTO {tableName} VALUES (null, @collecting_officers_id, @report_no, @date, @is_approved, @is_disapproved, @funds_id, @remarks)";

                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int InsertId(CollectorReportModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@collecting_officers_id", DbType.Int16, entity.CollectorId},
                    new object[] { "@report_no", DbType.String, entity.ReportNo},
                    new object[] { "@date", DbType.Date, entity.Date},
                    new object[] { "@is_approved", DbType.Int16, entity.IsApproved},
                    new object[] { "@funds_id", DbType.Int16, entity.FundId},
                    new object[] { "@status", DbType.String, entity.IsApproved > 0 ? "COMPLETED":"PENDING"},
                    new object[] { "@remarks", DbType.String, entity.Remarks}
                };

                string query = $"INSERT INTO {tableName} (collecting_officers_id,report_no,date,is_approved,funds_id,status,remarks) VALUES (@collecting_officers_id,@report_no,@date,@is_approved,@funds_id,@status,@remarks)";


                return _dbGenericCommands.ExecuteNonQueryId(query, parameters);


            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(CollectorReportModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int16, entity.Id},
                new object[] { "@collecting_officers_id", DbType.Int16, entity.CollectorId},
                new object[] { "@report_no", DbType.String, entity.ReportNo},
                new object[] { "@date", DbType.Date, entity.Date},
                new object[] { "@is_approved", DbType.Int16, entity.IsApproved},
                new object[] { "@is_disapproved", DbType.Int16, entity.IsDisapproved},
                new object[] { "@funds_id", DbType.Int16, entity.FundId},
                new object[] { "@remarks", DbType.String, entity.Remarks}
            };

            string query =  $"UPDATE {tableName} " +
                            $"SET " +
                            $"collecting_officers_id = @collecting_officers_id, " +
                            $"report_no              = @report_no, " +
                            $"date                   = @date, " +
                            $"is_approved            = @is_approved, " +
                            $"is_disapproved         = @is_disapproved, " +
                            $"funds_id               = @funds_id, " +
                            $"remarks                = @remarks " +
                            $"WHERE id               = @id";



            return _dbGenericCommands.ExecuteNonQuery(query, parameters);
        }
        public bool Approved(CollectorReportModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int16, entity.Id},
                    new object[] { "@is_approved", DbType.Int16, entity.IsApproved},
                    new object[] { "@status", DbType.String, entity.IsApproved > 0 ? "COMPLETED":"PENDING"},
                };

                string query = $"UPDATE {tableName} SET is_approved=@is_approved,status=@status WHERE id=@id";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Cancel(int id)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, id},
                    new object[] { "@status", DbType.String, "CANCELLED"}
                };

                string query = $"UPDATE {tableName} SET status=@status WHERE id=@id";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remarks(CollectorReportModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int16, entity.Id},
                    new object[] { "@remarks", DbType.String, entity.Remarks}
                };

                string query = $"UPDATE {tableName} SET remarks=@remarks WHERE id=@id";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(CollectorReportModel entity)
        {
            using (var scope = new TransactionScope())
            {
               
                var parameters = new object[][]
                {
                        new object[] { "@id", DbType.Int32, entity.Id},
                        new object[] { "@report_no", DbType.String, entity.ReportNo},
                };

                string query = $"DELETE FROM {tableName} WHERE id = @id AND report_no = @report_no";
                _ = _dbGenericCommands.ExecuteNonQuery(query, parameters);
               
                scope.Complete();
                return true;
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


        public bool ReportNumberExist(int reportId, string reporNo)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@report_id", DbType.String, reportId },
                    new object[] { "@report_no", DbType.String, reporNo }
                };

                string query = $"SELECT report_no FROM {tableName} WHERE report_no = @report_no AND id <> @report_id";
                string queryResult = _dbGenericCommands.ExecuteScalar(query, parameters);

                if (!string.IsNullOrEmpty(queryResult)) return true;
            }
            catch (Exception)
            {
                throw;
            };

            return false;
        }
        public bool ReportNumberExist(string reporNo)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@report_no", DbType.String, reporNo }
                };

                string query = $"SELECT report_no FROM {tableName} WHERE report_no = @report_no";
                string queryResult = _dbGenericCommands.ExecuteScalar(query, parameters);

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

        public bool HasGenerated(int paymentCollectionId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@payment_collection_id", DbType.Int16, paymentCollectionId },
                };

                string query = $"SELECT * FROM {tableCollectorReportPayments} WHERE payment_collections_id = @payment_collection_id";
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

        public bool HasReported(int id)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@payment_collections_id", DbType.Int16, id },
                };

                string query = $"SELECT * FROM {tableCollectorReportPayments} WHERE payment_collections_id = @payment_collections_id";
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
                string query = string.Empty;
                var uRepository = Factory.UsersRepository();
                int colid = uRepository.LinkedCollector(Factory.UserId) ? int.Parse(uRepository.GetCollectorByUserId(Factory.UserId)) : 0;
                if (colid > 0)
                {
                    query = $"SELECT {tableName}.id,{tableName}.report_no,CONCAT({tableFunds}.fund_code,'-',{tableFunds}.fund_name) AS fund,{tableName}.date,CONCAT({tableCollectingOfficer}.last_name,', ',{tableCollectingOfficer}.first_name,' ',{tableCollectingOfficer}.mid_initial) AS collector,(SELECT SUM({tablePaymentCollections}.amount) FROM {tableCollectorReportPayments} LEFT JOIN {tablePaymentCollections} ON {tableCollectorReportPayments}.payment_collections_id={tablePaymentCollections}.id AND {tableCollectorReportPayments}.collector_report_id={tableName}.id) AS colamount,{tableName}.is_approved FROM {tableName} LEFT JOIN {tableCollectingOfficer} ON {tableCollectingOfficer}.id={tableName}.collecting_officers_id LEFT JOIN {tableFunds} ON {tableName}.funds_id={tableFunds}.id WHERE {tableName}.collecting_officers_id={colid} AND {tableName}.report_no LIKE '%{searchText}%' OR CONCAT({tableCollectingOfficer}.last_name,', ',{tableCollectingOfficer}.first_name,' ',{tableCollectingOfficer}.mid_initial) LIKE '%{searchText}%' OR ({tableFunds}.fund_code,'-',{tableFunds}.fund_name) LIKE '%{searchText}%' ORDER BY {tableName}.date DESC";
                }
                else
                {
                    query = $"SELECT {tableName}.id,{tableName}.report_no,CONCAT({tableFunds}.fund_code,'-',{tableFunds}.fund_name) AS fund,{tableName}.date,CONCAT({tableCollectingOfficer}.last_name,', ',{tableCollectingOfficer}.first_name,' ',{tableCollectingOfficer}.mid_initial) AS collector,(SELECT SUM({tablePaymentCollections}.amount) FROM {tableCollectorReportPayments} LEFT JOIN {tablePaymentCollections} ON {tableCollectorReportPayments}.payment_collections_id={tablePaymentCollections}.id AND {tableCollectorReportPayments}.collector_report_id={tableName}.id) AS colamount,{tableName}.is_approved FROM {tableName} LEFT JOIN {tableCollectingOfficer} ON {tableCollectingOfficer}.id={tableName}.collecting_officers_id LEFT JOIN {tableFunds} ON {tableName}.funds_id={tableFunds}.id WHERE {tableName}.report_no LIKE '%{searchText}%' OR CONCAT({tableCollectingOfficer}.last_name,', ',{tableCollectingOfficer}.first_name,' ',{tableCollectingOfficer}.mid_initial) LIKE '%{searchText}%' OR ({tableFunds}.fund_code,'-',{tableFunds}.fund_name) LIKE '%{searchText}%' ORDER BY {tableName}.date DESC";
                }

                var dtpc = new DataTable();
                return _dbGenericCommands.Fill(query, dtpc);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int GetReportId(int collectorId, string collectorReportNumber)
        {

            var parameter = new object[][] {
                new object[] {"@collectorId", DbType.Int16, collectorId},
                new object[] { "@collectorReportNumber", DbType.String, collectorReportNumber}
            };

            string query = $"SELECT id FROM {tableName} " +
                $"WHERE collecting_officers_id = @collectorId AND report_no = @collectorReportNumber ";

            return int.Parse(_dbGenericCommands.ExecuteScalar(query, parameter));

        }

        public DataTable FilterRecords(string status, byte fundId, string keySearch)
        {
            try
            {
                string statusQuery;

                switch (status)
                {
                    case "pending":
                        statusQuery = " is_approved = 0 AND is_disapproved = 0 AND ";
                        break;

                    case "approved":
                        statusQuery = " is_approved = 1 AND is_disapproved = 0 AND  ";
                        break;

                    case "disapproved":
                        statusQuery = " is_approved = 0 AND is_disapproved = 1 AND  ";
                        break;

                    default:
                        statusQuery = string.Empty;
                        break;
                }

                var parameter = new object[][] {
                    new object[] {"@keySearch", DbType.String, $"%{keySearch}%" },
                    new object[] {"@fundId", DbType.Byte, fundId }
                };

                string query = $"SELECT * FROM {viewTableName} " +
                    $"WHERE {statusQuery} " +
                    $"fund_id = @fundId AND " +
                    $"(collecting_officer LIKE @keySearch OR report_no LIKE @keySearch)";

                var dtCollectorReport = new DataTable();
                return _dbGenericCommands.FillBySearch(query, dtCollectorReport, parameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable FilterRecords(string status, byte fundId, string keySearch, short collectingOfficerId)
        {
            try
            {
                string statusQuery;

                switch (status)
                {
                    case "pending":
                        statusQuery = " is_approved = 0 AND is_disapproved = 0 AND ";
                        break;

                    case "approved":
                        statusQuery = " is_approved = 1 AND is_disapproved = 0 AND  ";
                        break;

                    case "disapproved":
                        statusQuery = " is_approved = 0 AND is_disapproved = 1 AND  ";
                        break;

                    default:
                        statusQuery = string.Empty;
                        break;
                }

                var parameter = new object[][] {
                    new object[] {"@keySearch", DbType.String, $"%{keySearch}%" },
                    new object[] {"@fundId", DbType.Byte, fundId },
                    new object[] {"@collectingOfficerId", DbType.Byte, collectingOfficerId }
                };

                string query = $"SELECT * FROM {viewTableName} " +
                    $"WHERE {statusQuery} fund_id = @fundId AND collecting_officers_id = @collectingOfficerId AND " +
                    $"(collecting_officer LIKE @keySearch OR report_no LIKE @keySearch OR fund_name LIKE @keySearch) AND " +
                    $"is_approved = 1";

                var dtCollectorReport = new DataTable();
                return _dbGenericCommands.FillBySearch(query, dtCollectorReport, parameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable FilterRecords(sbyte fundId, ushort collectorId, string reportNo)
        {
            try
            {
                var parameter = new object[][] {
                    new object[] {"@fundId", DbType.SByte, fundId },
                    new object[] {"@collectorId", DbType.Int16, collectorId },
                    new object[] {"@reportNo", DbType.String, reportNo }
                };

                string query = $"SELECT * FROM {viewTableName} WHERE fund_id = @fundId AND collecting_officers_id = @collectorId AND report_no = @reportNo";

                var dtCollectorReport = new DataTable();
                return _dbGenericCommands.FillBySearch(query, dtCollectorReport, parameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string GetRCDStatus(string reportNo)
        {
            var record = new Dictionary<string, byte>();
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@reportNo", DbType.String, reportNo }
                };

                string query = $"SELECT is_approved, is_disapproved FROM {tableName} WHERE report_no = @reportNo";
                using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
                {
                    foreach (DataRow item in reader.Rows)
                    {
                        record.Add("is_approved", Convert.ToByte(item[0]));
                        record.Add("is_disapproved", Convert.ToByte(item[1]));
                    }
                }

                if (record["is_approved"] == 1)
                    return "approved";
                else if (record["is_disapproved"] == 1)
                    return "disapproved";
                else
                    return "pending";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool SetRCDStatus(byte status, string reportNo)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@status", DbType.Int16, status},
                    new object[] { "@reportNo", DbType.String, reportNo},
                };

                string queryStatus = string.Empty;

                if (status == 0)
                    queryStatus = $"is_approved = 0, is_disapproved = 0";
                else if (status == 1)
                    queryStatus = $"is_approved = 1, is_disapproved = 0";
                else if (status == 2)
                    queryStatus = $"is_approved = 0, is_disapproved = 1";

                string query = $"UPDATE {tableName} SET {queryStatus} WHERE report_no = @reportNo";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool SetRemarks(string reportNo, string remarks)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@reportNo", DbType.String, reportNo},
                    new object[] { "@remarks", DbType.String, remarks }
                };

                string query = $"UPDATE {tableName} SET remarks = @remarks WHERE report_no = @reportNo";

                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (MySqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string GetRemarks(string reportNo)
        {
            var parameters = new object[][]
            {
                new object[] { "@reportNo", DbType.String, reportNo}
            };

            string query = $"SELECT remarks FROM {tableName} WHERE report_no = @reportNo";
            return _dbGenericCommands.ExecuteScalar(query, parameters).ToString();
            
        }

        public string GetCollectorIdByReportNumber(string reportNumber)
        {
            var parameters = new object[][]
            {
                new object[] { "@report_number", DbType.String, reportNumber }
            };

            string query = $"SELECT collecting_officers_id FROM {tableName} WHERE report_no = @report_number LIMIT 1 ";
            return _dbGenericCommands.ExecuteScalar(query, parameters).ToString();
        }
    }
}
