using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Transactions;

namespace ACC.Data
{
    class GeneralCollectionsPaymentsRepository:IGeneralCollectionsPaymentsRepository
    {
        private readonly IAccGenericCommands _dbGenericCommands;
        private readonly string tableName = "general_collections_payment";
        private readonly string viewTableName = "view_general_collections_payment";


        public GeneralCollectionsPaymentsRepository(IAccGenericCommands dbGenericCommands)
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
                    record.Add("collector_report_id", reader.Rows[0]["collector_report_id"].ToString());
                    record.Add("general_collections_id", reader.Rows[0]["general_collections_id"].ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }

            return record;
        }

        public bool Insert(GeneralCollectionPaymentsModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@collector_report_id", DbType.Int16, entity.CollectorsReportId},
                    new object[] { "@general_collections_id", DbType.Int16, entity.GeneralCollectionsId},
                };

                string query = $"INSERT INTO {tableName} (collector_report_id, general_collections_id) VALUES (@collector_report_id, @general_collections_id)";
             
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(List<GeneralCollectionPaymentsModel> entityList)
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
                            new object[] { "@collector_report_id", DbType.Int16, entity.CollectorsReportId},
                            new object[] { "@general_collections_id", DbType.Int16, entity.GeneralCollectionsId},
                        };

                        string query = $"UPDATE {tableName} SET collector_report_id=@collector_report_id,general_collections_id=@general_collections_id WHERE id=@id";
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

        public bool Delete(List<GeneralCollectionsModel> entityList)
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

        public bool Append(List<GeneralCollectionPaymentsModel> entityList)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    foreach (var entity in entityList)
                    {
                        if (entity.Id > 0)
                        {

                            var parameters = new object[][]
                           {
                                new object[] { "@id", DbType.Int16, entity.Id},
                                new object[] { "@collector_report_id", DbType.Int16, entity.CollectorsReportId},
                                new object[] { "@general_collections_id", DbType.Int16, entity.GeneralCollectionsId},
                           };

                            string query = $"UPDATE {tableName} SET collector_report_id=@collector_report_id,general_collections_id=@general_collections_id WHERE id=@id";
                            _ = _dbGenericCommands.ExecuteNonQuery(query, parameters);
                        }
                        else
                        {
                            var parameters = new object[][]
                               {
                                    new object[] { "@collector_report_id", DbType.Int16, entity.CollectorsReportId},
                                    new object[] { "@general_collections_id", DbType.Int16, entity.GeneralCollectionsId},
                               };

                            string query = $"INSERT INTO {tableName} (collector_report_id,general_collections_id) VALUES(@collector_report_id,@general_collections_id)";
                            _ = _dbGenericCommands.ExecuteNonQuery(query, parameters);
                        }
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

        public bool IdExist(int id)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@collector_report_id", DbType.Int16, id },
                };

                string query = $"SELECT collector_report_id FROM {tableName} WHERE collector_report_id = @collector_report_id";
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

        public DataTable GetRecords()
        {
            try
            {
                string query = $"SELECT * FROM {viewTableName}";
                var dtRCD = new DataTable();

                return _dbGenericCommands.Fill(query, dtRCD);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetCollectionPaymentByRCDNo(string rcdNo)
        {
            try
            {

                var parameter = new object[][] { 
                    new object[] {"@rcdNo", DbType.String, rcdNo}
                };

                string query = $"SELECT * FROM {viewTableName} WHERE rcd_no=@rcdNo";
                var dtRCD = new DataTable();

                return _dbGenericCommands.FillBySearch(query, dtRCD, parameter);
            }
            catch (Exception)
            {

                throw;
            }   
        }


        public DataTable GetRecordsByRCDNO(string RCDNo)
        {
            var parameter = new object[][] {
                new object[]{"@rcd_no", DbType.String, RCDNo}
            };

            string query = $"SELECT " +
                           $"collectors_report_id, " +
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
                           $"FROM {viewTableName} WHERE rcd_no = @rcd_no";

            var dt = new DataTable();
            return _dbGenericCommands.FillBySearch(query, dt, parameter);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new NotImplementedException();
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }



        public bool Update(GeneralCollectionPaymentsModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<GeneralCollectionPaymentsModel> entityList)
        {
            throw new NotImplementedException();
        }


    }
}
