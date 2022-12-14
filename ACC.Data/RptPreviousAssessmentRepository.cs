using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    public class RptPreviousAssessmentRepository : IRptPreviousAssessment
    {
        private readonly string tableName = "rpt_previous_assessment";

        private AccGenericCommands _mySqlGenericCommandsLFS;

        public RptPreviousAssessmentRepository(AccGenericCommands mySqlGenericCommandsLFS)
        {
            _mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<RptPreviousAssessmentModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (RptPreviousAssessmentModel rptPreviousAssessmentModel in entityList)
                {
                    var parameters = new object[][] { new object[] { "@id", } };
                    string query = $"DELETE FROM {tableName} WHERE id = @id";
                    _ = _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
                }

                scope.Complete();
                return true;
            }
        }

        public bool DeleteByRealPropertyId(int realPropertyId)
        {
            var parameters = new object[][] { new object[] { "@real_properties_id", DbType.Int32, realPropertyId } };
            string query = $"DELETE FROM {tableName} WHERE real_properties_id = @real_properties_id";
            return _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var dict = new Dictionary<string, string>();
            var parameters = new object[][] { new object[] { "@id", DbType.Int32, Id } };
            string query = $"SELECT real_properties_id, property_pin, complete_arp_no, assessed_value, previous_owner_name, effectivity_assessment, date_recorded FROM {tableName} id = @id";

            using (var reader = _mySqlGenericCommandsLFS.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return dict;

                foreach (DataRow row in reader.Rows)
                {
                    dict.Add("real_properties_id", row["real_properties_id"].ToString());
                    dict.Add("property_pin", row["property_pin"].ToString());
                    dict.Add("complete_arp_no", row["complete_arp_no"].ToString());
                    dict.Add("assessed_value", row["assessed_value"].ToString());
                    dict.Add("previous_owner_name", row["previous_owner_name"].ToString());
                    dict.Add("effectivity_assessment", row["effectivity_assessment"].ToString());
                    dict.Add("date_recorded", row["date_recorded"].ToString());
                }
                return dict;
            }
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {tableName}";
            var dataTable = new DataTable();
            return _mySqlGenericCommandsLFS.Fill(query, dataTable);
        }

        public Dictionary<string, string> GetRecordsByARPNo(string ARPNo)
        {
            try
            {
                var record = new Dictionary<string, string>();
                var parameters = new object[][]
                {
                    new object[] { "@complete_arp_no", DbType.String, ARPNo},
                };

                string query = $"SELECT * FROM {tableName} WHERE complete_arp_no = @complete_arp_no";

                using (var reader = _mySqlGenericCommandsLFS.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;

                    record.Add("id", reader.Rows[0]["id"].ToString());
                    record.Add("real_properties_id", reader.Rows[0]["real_properties_id"].ToString());
                    record.Add("property_pin", reader.Rows[0]["property_pin"].ToString());
                    record.Add("complete_arp_no", reader.Rows[0]["complete_arp_no"].ToString());
                    record.Add("assessed_value", reader.Rows[0]["assessed_value"].ToString());
                    record.Add("previous_owner_name", reader.Rows[0]["previous_owner_name"].ToString());
                    record.Add("effectivity_assessment", reader.Rows[0]["effectivity_assessment"].ToString());
                    record.Add("date_recorded", reader.Rows[0]["date_recorded"].ToString());
                }

                return record;
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

        public bool Insert(RptPreviousAssessmentModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@real_properties_id", DbType.Int32, entity.RealPropertiesId},
                new object[] { "@property_pin", DbType.String, entity.PropertyPin},
                new object[] { "@complete_arp_no", DbType.String, entity.CompleteArpNo},
                new object[] { "@assessed_value", DbType.Decimal, entity.AssessedValue},
                new object[] { "@previous_owner_name", DbType.String, entity.PreviousOwner},
                new object[] { "@effectivity_assessment", DbType.String, entity.EffectivityAssessment},
                new object[] { "@date_recorded", DbType.Date, entity.DateRecorded}
            };

            string query = $"INSERT INTO {tableName} (real_properties_id, property_pin, complete_arp_no, assessed_value, previous_owner_name, effectivity_assessment, date_recorded) VALUES (@real_properties_id, @property_pin, @complete_arp_no, @assessed_value, @previous_owner_name, @effectivity_assessment, @date_recorded)";

            return _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Update(RptPreviousAssessmentModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.Id},
                new object[] { "@real_properties_id", DbType.Int32, entity.RealPropertiesId},
                new object[] { "@property_pin", DbType.String, entity.PropertyPin},
                new object[] { "@complete_arp_no", DbType.String, entity.CompleteArpNo},
                new object[] { "@assessed_value", DbType.Decimal, entity.AssessedValue},
                new object[] { "@previous_owner_name", DbType.String, entity.PreviousOwner},
                new object[] { "@effectivity_assessment", DbType.String, entity.EffectivityAssessment},
                new object[] { "@date_recorded", DbType.Date, entity.DateRecorded}
            };

            string query = $"UPDATE {tableName} SET real_properties_id = @real_properties_id, property_pin = @property_pin, complete_arp_no = @complete_arp_no, assessed_value = @assessed_value, previous_owner_name = @previous_owner_name, effectivity_assessment = @effectivity_assessment, date_recorded = @date_recorded WHERE id = @id";

            return _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }
    }
}