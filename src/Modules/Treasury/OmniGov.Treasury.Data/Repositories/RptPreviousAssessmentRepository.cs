using OmniGov.Core.Interfaces.Services;
using OmniGov.Treasury.Domain.Entities;
using OmniGov.Treasury.Domain.Interfaces;
using System.Data;

namespace OmniGov.Treasury.Data.Repositories
{
    public class RptPreviousAssessmentRepository : IRptPreviousAssessment
    {
        private readonly string tableName = "rpt_previous_assessment";
        private readonly IGenericCommands _genericCommands;

        public RptPreviousAssessmentRepository(IGenericCommands genericCommands)
        {
            _genericCommands = genericCommands ?? throw new ArgumentNullException(nameof(genericCommands));
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
            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var dict = new Dictionary<string, string>();
            var parameters = new object[][] { new object[] { "@id", DbType.Int32, Id } };
            string query = $"SELECT * FROM {tableName} WHERE id = @id";

            using (var reader = _genericCommands.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return dict;

                foreach (DataRow row in reader.Rows)
                {
                    dict.Add("real_properties_id", row["real_properties_id"].ToString());
                    dict.Add("taxpayers_id", row["taxpayers_id"].ToString());
                    dict.Add("complete_arp_no", row["complete_arp_no"].ToString());
                    dict.Add("pin", row["pin"].ToString());
                    dict.Add("assessed_value", row["assessed_value"].ToString());
                    dict.Add("date_of_entry", row["date_of_entry"].ToString());
                    dict.Add("effectivity_quarter", row["effectivity_quarter"].ToString());
                    dict.Add("effectivity_year", row["effectivity_year"].ToString());
                    dict.Add("is_taxable", row["is_taxable"].ToString());
                    dict.Add("is_cancelled", row["is_cancelled"].ToString());
                    dict.Add("recording_person", row["recording_person"].ToString());
                }
                return dict;
            }
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {tableName}";
            var dataTable = new DataTable();
            return _genericCommands.Fill(query, dataTable);
        }

        public DataTable GetRecordsByRptId(int rptId)
        {
            var parameters = new object[][]
            {
                new object[] { "@real_properties_id", DbType.Int32, rptId}
            };

            string query = $"SELECT * FROM {tableName} WHERE real_properties_id = @real_properties_id";
            var dataTabe = new DataTable();
            return _genericCommands.FillBySearch(query, dataTabe, parameters);
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
                new object[] { "@taxpayers_id", DbType.Int32, entity.TaxpayersModel.Id},
                new object[] { "@complete_arp_no", DbType.String, entity.CompleteArpNo},
                new object[] { "@pin", DbType.String, entity.Pin},
                new object[] { "@assessed_value", DbType.Decimal, entity.AssessedValue},
                new object[] { "@date_of_entry", DbType.DateTime2, entity.DateOfEntry},
                new object[] { "@effectivity_quarter", DbType.String, entity.EffectivityQtr},
                new object[] { "@effectivity_year", DbType.String, entity.EffectivityYear},
                new object[] { "@recording_person", DbType.String, entity.RecordingPerson},
                new object[] { "gr_year", DbType.String, entity.GrYear },
                new object[] { "@is_taxable", DbType.Int16, entity.IsTaxable },
                new object[] { "@is_cancelled", DbType.Int16, entity.IsCancelled },
                new object[] { "@created_by", DbType.Int16, entity.CreatedBy}
            };

            string query = $"INSERT INTO {tableName} (real_properties_id, taxpayers_id, complete_arp_no, pin,  assessed_value, date_of_entry, effectivity_quarter, effectivity_year, gr_year, is_taxable, is_cancelled, recording_person, created_by) VALUES (@real_properties_id, @taxpayers_id, @complete_arp_no, @pin,  @assessed_value, @date_of_entry, @effectivity_quarter, @effectivity_year, @gr_year, @is_taxable, @is_cancelled, @recording_person, @created_by)";

            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(RptPreviousAssessmentModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
