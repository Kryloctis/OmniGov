using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    internal class CollectorReportRepository : ICollectorReportRepository
    {
        private readonly IAccGenericCommands _dbGenericCommands;
        private readonly ICollectorReportPaymentsRepository _collectorReportPaymentsRepository;

        private readonly string tableName = "collector_report";
        private readonly string viewTableName = "view_collector_report";
        private readonly string tableCollectorReportPayments = "collector_report_payments";

        public CollectorReportRepository(IAccGenericCommands dbGenericCommands, ICollectorReportPaymentsRepository collectorReportPaymentsRepository)
        {
            _dbGenericCommands = dbGenericCommands;
            _collectorReportPaymentsRepository = collectorReportPaymentsRepository;
        }

        public Dictionary<string, string> GetRecordByID(int id)
        {
            var record = new Dictionary<string, string>();

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

            return record;
        }

        public Dictionary<string, string> GetRecordByID(string Id)
        {
            var record = new Dictionary<string, string>();

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
                record.Add("job_orders_id", reader.Rows[0]["job_orders_id"].ToString());
                record.Add("report_no", reader.Rows[0]["report_no"].ToString());
                record.Add("date", reader.Rows[0]["date"].ToString());
                record.Add("is_approved", reader.Rows[0]["is_approved"].ToString());
                record.Add("funds_id", reader.Rows[0]["funds_id"].ToString());
                record.Add("remarks", reader.Rows[0]["remarks"].ToString());
            }

            return record;
        }

        public DataTable GetCollectorsReportByReportNo(string reportNumber)
        {
            var parameter = new object[][] {
                new object[]{"@reportNo", DbType.String, reportNumber},
            };

            string query = $"SELECT " +
                            $"collecting_officers_id, " +
                            $"collecting_officers_first_name, " +
                            $"collecting_officers_mid_initial, " +
                            $"collecting_officers_last_name, " +
                            $"job_orders_id, " +
                            $"job_orders_first_name, " +
                            $"job_orders_mid_initial, " +
                            $"job_orders_last_name, " +
                            $"report_no, " +
                            $"amount " +
                            $"FROM {viewTableName} " +
                            $"WHERE is_approved = 1 ";

            var dt = new DataTable();
            return _dbGenericCommands.FillBySearch(query, dt, parameter);
        }

        public DataTable GetRecordsByReportNumber(string reportNumber)
        {
            var parameter = new object[][] {
                new object[] {"@reportNumber", DbType.String, reportNumber}
            };

            string query = $"SELECT report_no, date, collecting_officers_id, collecting_officers_first_name, collecting_officers_mid_initial, collecting_officers_last_name, job_orders_id, job_orders_first_name, job_orders_mid_initial, job_orders_last_name, fund_name FROM {viewTableName} WHERE report_no = @reportNumber";

            var dtReport = new DataTable();
            return _dbGenericCommands.FillBySearch(query, dtReport, parameter);
        }

        public bool Insert(CollectorReportModel entity)
        {
            var parameters = new object[][]
            {
                new object[] {"@collecting_officers_id", DbType.Int32, entity.CollectorId},
                new object[] {"@job_orders_id", DbType.Int32, entity.JobOrderId},
                new object[] {"@report_no", DbType.String, entity.ReportNo},
                new object[] {"@date", DbType.Date, entity.Date},
                new object[] {"@is_approved", DbType.Int16, entity.IsApproved},
                new object[] {"@is_disapproved", DbType.Int16, entity.IsDisapproved},
                new object[] {"@funds_id", DbType.Int16, entity.FundId},
                new object[] {"@remarks", DbType.String, entity.Remarks}
           };

            string query = $"INSERT INTO {tableName} " +
                           $"VALUES (" +
                           $"null, " +
                           $"@collecting_officers_id, " +
                           $"@job_orders_id, " +
                           $"@funds_id, " +
                           $"@report_no, " +
                           $"@date, " +
                           $"@is_approved, " +
                           $"@is_disapproved, " +
                           $"@remarks)";

            return _dbGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(CollectorReportModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int16, entity.Id},
                new object[] { "@collecting_officers_id", DbType.Int16, entity.CollectorId},
                new object[] { "@job_orders_id", DbType.Int16, entity.JobOrderId},
                new object[] { "@report_no", DbType.String, entity.ReportNo},
                new object[] { "@date", DbType.Date, entity.Date},
                new object[] { "@is_approved", DbType.Int16, entity.IsApproved},
                new object[] { "@is_disapproved", DbType.Int16, entity.IsDisapproved},
                new object[] { "@funds_id", DbType.Int16, entity.FundId},
                new object[] { "@remarks", DbType.String, entity.Remarks}
            };

            string query = $"UPDATE {tableName} " +
                            $"SET " +
                            $"collecting_officers_id = @collecting_officers_id, " +
                            $"job_orders_id          = @job_orders_id, " +
                            $"report_no              = @report_no, " +
                            $"date                   = @date, " +
                            $"is_approved            = @is_approved, " +
                            $"is_disapproved         = @is_disapproved, " +
                            $"funds_id               = @funds_id, " +
                            $"remarks                = @remarks " +
                            $"WHERE id               = @id";

            return _dbGenericCommands.ExecuteNonQuery(query, parameters);
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

        public int CountRecords()
        {
            string query = $"SELECT COUNT(*) FROM {tableName}";

            return int.Parse(_dbGenericCommands.ExecuteScalar(query));
        }

        public bool ReportNumberExist(int reportId, string reporNo)
        {
            var parameters = new object[][]
            {
                new object[] { "@report_id", DbType.String, reportId },
                new object[] { "@report_no", DbType.String, reporNo }
            };

            string query = $"SELECT report_no FROM {tableName} WHERE report_no = @report_no AND id <> @report_id";
            string queryResult = _dbGenericCommands.ExecuteScalar(query, parameters);

            if (!string.IsNullOrEmpty(queryResult)) return true;

            return false;
        }

        public bool ReportNumberExist(string reporNo)
        {
            var parameters = new object[][]
            {
                new object[] { "@report_no", DbType.String, reporNo }
            };

            string query = $"SELECT report_no FROM {tableName} WHERE report_no = @report_no";
            string queryResult = _dbGenericCommands.ExecuteScalar(query, parameters);

            if (!string.IsNullOrEmpty(queryResult)) return true;

            return false;
        }

        public bool HasReported(int id)
        {
            var parameters = new object[][]
            {
                new object[] { "@payment_collections_id", DbType.Int16, id },
            };

            string query = $"SELECT * FROM {tableCollectorReportPayments} WHERE payment_collections_id = @payment_collections_id";
            string queryResult = _dbGenericCommands.ExecuteScalar(query, parameters);

            if (!string.IsNullOrEmpty(queryResult)) return true;

            return false;
        }

        public int GetReportID(int collectorId, string collectorReportNumber, bool isJO)
        {
            var parameter = new object[][] {
                new object[] {"@collectorId", DbType.Int32, collectorId},
                new object[] {"@collectorReportNumber", DbType.String, collectorReportNumber}
            };

            string filter;
            if (isJO)
                filter = $"job_orders_id";
            else
                filter = $"collecting_officers_id";

            string query = $"SELECT id " +
                           $"FROM {tableName} " +
                           $"WHERE " +
                           $"{filter} = @collectorId " +
                           $"AND " +
                           $"report_no = @collectorReportNumber ";

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

                string query = $"SELECT id, fund_id, fund_name, date, report_no, collecting_officers_id, collecting_officers_first_name, collecting_officers_mid_initial, collecting_officers_last_name, job_orders_id, job_orders_first_name, job_orders_mid_initial, job_orders_last_name, amount, is_approved, is_disapproved  FROM {viewTableName} WHERE {statusQuery} fund_id = @fundId";

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
                                $"WHERE {statusQuery} " +
                                $"fund_id = @fundId AND " +
                                $"(collecting_officers_id = @collectingOfficerId AND ISNULL(job_orders_id)) OR " +
                                $"job_orders_id = @collectingOfficerId AND " +
                                $"(collecting_officers_first_name LIKE @keySearch OR " +
                                $"collecting_officers_last_name LIKE @keySearch OR " +
                                $"job_orders_first_name LIKE @keySearch OR " +
                                $"job_orders_last_name LIKE @keySearch OR " +
                                $"report_no LIKE @keySearch OR fund_name LIKE @keySearch) AND " +
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
            var parameter = new object[][] {
                new object[] {"@fundId", DbType.SByte, fundId },
                new object[] {"@collectorId", DbType.Int16, collectorId },
                new object[] {"@reportNo", DbType.String, reportNo }
            };

            string query = $"SELECT * FROM {viewTableName} WHERE fund_id = @fundId AND collecting_officers_id = @collectorId AND report_no = @reportNo";

            var dtCollectorReport = new DataTable();
            return _dbGenericCommands.FillBySearch(query, dtCollectorReport, parameter);
        }

        public string GetRCDStatus(string reportNo)
        {
            var record = new Dictionary<string, byte>();

            var parameters = new object[][]
            {
                new object[] { "@report_no", DbType.String, reportNo }
            };

            string query = $"SELECT is_approved, is_disapproved FROM {tableName} WHERE report_no = @report_no";
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

        public bool SetRCDStatus(byte status, string reportNo)
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

        public bool SetRemarks(string reportNo, string remarks)
        {
            var parameters = new object[][]
            {
                new object[] { "@reportNo", DbType.String, reportNo},
                new object[] { "@remarks", DbType.String, remarks }
            };

            string query = $"UPDATE {tableName} SET remarks = @remarks WHERE report_no = @reportNo";

            return _dbGenericCommands.ExecuteNonQuery(query, parameters);
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

        public DataTable GetRecords()
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new NotImplementedException();
        }

        public bool HasGenerated(int paymentCollectionsId)
        {
            var parameters = new object[][]
            {
                new object[] { "@payment_collection_id", DbType.Int16, paymentCollectionsId },
            };

            string query = $"SELECT * FROM {tableCollectorReportPayments} WHERE payment_collections_id = @payment_collection_id";
            string queryResult = _dbGenericCommands.ExecuteScalar(query, parameters);

            if (!string.IsNullOrEmpty(queryResult)) return true;

            return false;
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool InsertWithCollectorReportPayments(CollectorReportModel collectorReportModel, List<CollectorReportPaymentModel> collectorReportPaymentModelList)
        {
            using (var scope = new TransactionScope())
            {
                var parameters = new object[][]
               {
                new object[] {"@collecting_officers_id", DbType.Int32, collectorReportModel.CollectorId},
                new object[] {"@job_orders_id", DbType.Int32, collectorReportModel.JobOrderId},
                new object[] {"@funds_id", DbType.Int16, collectorReportModel.FundId},
                new object[] {"@report_no", DbType.String, collectorReportModel.ReportNo},
                new object[] {"@date", DbType.Date, collectorReportModel.Date},
                new object[] {"@is_approved", DbType.Int16, collectorReportModel.IsApproved},
                new object[] {"@is_disapproved", DbType.Int16, collectorReportModel.IsDisapproved},
                new object[] {"@remarks", DbType.String, collectorReportModel.Remarks}
               };

                string query = $"INSERT INTO {tableName} VALUES (null, @collecting_officers_id, @job_orders_id,  @funds_id,  @report_no, @date,            @is_approved, @is_disapproved, @remarks)";

                _dbGenericCommands.ExecuteNonQuery(query, parameters);

                foreach (var collectorsPayments in collectorReportPaymentModelList)
                {
                    collectorsPayments.CollectorsReportId = GetReportID(collectorReportModel.CollectorId, collectorReportModel.ReportNo, collectorReportModel.IsJO);
                    collectorsPayments.PaymentCollectionsId = collectorsPayments.PaymentCollectionsId;

                    _collectorReportPaymentsRepository.Insert(collectorsPayments);
                }

                scope.Complete();
                return true;
            }
        }

        #region RCD DashBoard Counter

        public int GetApprovedRCDCount(int fundId, short month, short year)
        {
            var parameters = new object[][]
             {
                    new object[] { "@fund_id", DbType.Int32, fundId},
                    new object[] { "@month", DbType.Int16, month},
                    new object[] { "@year", DbType.Int16, year}
             };

            string fundQuery = fundId == 0 ? string.Empty : "funds_id = @fund_id AND";

            string query = $"SELECT COUNT(id) FROM {tableName} WHERE is_approved = 1 AND {fundQuery} MONTH(date)<=@month AND YEAR(date)=@year";
            return int.Parse(_dbGenericCommands.ExecuteScalar(query, parameters));
        }

        public int GetPendingRCDCount(int fundId, short month, short year)
        {
            var parameters = new object[][]
            {
                new object[] { "@fund_id", DbType.Int32, fundId},
                new object[] { "@month", DbType.Int16, month},
                new object[] { "@year", DbType.Int16, year}
            };

            string fundQuery = fundId == 0 ? string.Empty : "funds_id = @fund_id AND";

            string query = $"SELECT COUNT(id) FROM {tableName} WHERE is_approved = 0 AND {fundQuery} MONTH(date)<=@month AND YEAR(date)=@year";
            return int.Parse(_dbGenericCommands.ExecuteScalar(query, parameters));
        }

        public int GetDisapprovedRCDCount(int fundId, short month, short year)
        {
            var parameters = new object[][]
            {
                new object[] { "@fund_id", DbType.Int32, fundId},
                new object[] { "@month", DbType.Int16, month},
                new object[] { "@year", DbType.Int16, year}
            };

            string fundQuery = fundId == 0 ? string.Empty : "funds_id = @fund_id AND";

            string query = $"SELECT COUNT(id) FROM {tableName} WHERE is_disapproved = 1 AND {fundQuery} MONTH(date)<=@month AND YEAR(date)=@year";
            return int.Parse(_dbGenericCommands.ExecuteScalar(query, parameters));
        }

        public int GetCancelledRCDCount(int fundId, short month, short year)
        {
            var parameters = new object[][]
            {
                new object[] { "@fund_id", DbType.Int32, fundId},
                new object[] { "@month", DbType.Int16, month},
                new object[] { "@year", DbType.Int16, year}
            };

            string fundQuery = fundId == 0 ? string.Empty : "funds_id = @fund_id AND";

            string query = $"SELECT COUNT(id) FROM {tableName} WHERE is_approved = 1 AND is_disapproved = 1 AND {fundQuery} MONTH(date)<=@month AND YEAR(date)=@year";
            return int.Parse(_dbGenericCommands.ExecuteScalar(query, parameters));
        }

        #endregion RCD DashBoard Counter
    }
}