using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using Org.BouncyCastle.Crypto.Prng;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    public class RptPreviousAssessmentRepository : IRptPreviousAssessment
    {
        private readonly string tableName = "rpt_previous_assessment";

        private AccGenericCommands mySqlGenericCommandsLFS;

        public RptPreviousAssessmentRepository(AccGenericCommands mySqlGenericCommandsLFS)
        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
        }

        string IRptPreviousAssessment.tableName { get => tableName; }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<RptPreviousAssessmentModel> entityList)
        {
            throw new NotImplementedException();
        }

        public bool DeleteByRealPropertyId(int realPropertyId)
        {
            var parameters = new object[][] { new object[] { "@real_properties_id", DbType.Int32, realPropertyId } };
            string query = $"DELETE FROM {tableName} WHERE real_properties_id = @real_properties_id";
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var dict = new Dictionary<string, string>();
            var parameters = new object[][] { new object[] { "@id", DbType.Int32, Id } };
            string query = $"SELECT real_properties_id, property_pin, complete_arp_no, assessed_value, previous_owner_name, effectivity_assessment, date_recorded FROM {tableName} id = @id";

            using (var reader = mySqlGenericCommandsLFS.ExecuteReader(query, parameters))
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
            return mySqlGenericCommandsLFS.Fill(query, dataTable);
        }

        public DataTable GetRecordsByRptId(int rptId)
        {
            var parameters = new object[][]
            {
                new object[] { "@real_properties_id", DbType.Int32, rptId}
            };

            string query = $"SELECT * FROM {tableName} WHERE real_properties_id = @real_properties_id";
            var dataTabe = new DataTable();
            return mySqlGenericCommandsLFS.FillBySearch(query, dataTabe, parameters);
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
                new object[] { "@prev_real_properties_id", DbType.Int32, entity.PrevPropertiesId},
                new object[] { "@arp_no", DbType.String, entity.CompleteArpNo},
                new object[] { "@pin", DbType.String, entity.Pin},
                new object[] { "@owner_name", DbType.String, entity.Owner},
                new object[] { "@assessed_value", DbType.Decimal, entity.AssessedValue},
                new object[] { "@effectivity", DbType.String, entity.Effectivity},
                new object[] { "@date_recorded", DbType.Date, entity.DateRecorded},
                new object[] { "@recording_person", DbType.String, entity.RecordingPerson}
            };

            string query = $"INSERT INTO {tableName} (real_properties_id, prev_real_properties_id, arp_no, pin, owner_name, assessed_value, effectivity, recording_person, date_recorded) VALUES (@real_properties_id, @prev_real_properties_id, @arp_no, @pin, @owner_name, @assessed_value, @effectivity, @recording_person, @date_recorded)";

            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Update(RptPreviousAssessmentModel entity)
        {
            throw new NotImplementedException();
        }
    }
}