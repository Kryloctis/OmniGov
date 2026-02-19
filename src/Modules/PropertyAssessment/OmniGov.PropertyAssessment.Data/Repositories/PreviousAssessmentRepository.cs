using OmniGov.Core.Interfaces.Services;
using PropertyAssessment.Domain.Entities;
using PropertyAssessment.Domain.Interfaces;
using System.Data;

namespace PropertyAssessment.Data.Repositories
{
    public class PreviousAssessmentRepository : IPreviousAssessment
    {
        private readonly string tableName = "previous_assessment";
        private IGenericCommands _genericCommands;

        public PreviousAssessmentRepository(IGenericCommands genericCommands)
        {
            _genericCommands = genericCommands ?? throw new ArgumentNullException(nameof(genericCommands));
        }

        public bool Delete(List<PreviousAssessmentModel> entityList)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> GetRecordByRealPropertiesId(int realPropertiesId)
        {
            var dict = new Dictionary<string, string>();
            var parameters = new object[][] { new object[] { "@real_properties_id", DbType.Int32, realPropertiesId } };
            string query = $"SELECT id, pin, arp_no, assessed_value, previous_owner, effectivity_assessment, recording_person, date_recorded FROM {tableName} WHERE real_properties_id = @real_properties_id LIMIT 1";

            using (var reader = _genericCommands.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return dict;

                foreach (DataRow row in reader.Rows)
                {
                    dict.Add("id", row["id"].ToString());
                    dict.Add("pin", row["pin"].ToString());
                    dict.Add("arp_no", row["arp_no"].ToString());
                    dict.Add("assessed_value", row["assessed_value"].ToString());
                    dict.Add("previous_owner", row["previous_owner"].ToString());
                    dict.Add("effectivity_assessment", row["effectivity_assessment"].ToString());
                    dict.Add("recording_person", row["recording_person"].ToString());
                    dict.Add("date_recorded", row["date_recorded"].ToString());
                }
                return dict;
            }
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

        public bool Insert(PreviousAssessmentModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(PreviousAssessmentModel entity)
        {
            throw new NotImplementedException();
        }
    }
}