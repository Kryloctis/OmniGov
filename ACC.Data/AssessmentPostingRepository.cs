using ACC.Data;
using RPT.Domain.Interfaces;
using RPT.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACC.Data
{
    public class AssessmentPostingRepository : IAssessmentPostingRepository
    {
        private readonly string tableName = "assessment_posts";

        private MySqlGenericCommands _mySqlGenericCommandsRPT;

        public AssessmentPostingRepository(MySqlGenericCommands mySqlGenericCommandsRPT)
        {
            _mySqlGenericCommandsRPT = mySqlGenericCommandsRPT;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<AssessmentPostingModel> entityList)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new NotImplementedException();
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

        public bool Insert(AssessmentPostingModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@complete_arp_no", DbType.String, entity.ArpNo },
                new object[] { "@property_pin", DbType.String, entity.PropertyKind },
                new object[] { "@owner_name", DbType.String, entity.Owner },
                new object[] { "@barangay_code", DbType.String, entity.BarangayCode },
                new object[] { "@barangay_name", DbType.String, entity.BarangayName },
                new object[] { "@municipality_code", DbType.String, entity.MunicipalityCode },
                new object[] { "@municipality_name", DbType.String, entity.MunicipalityName },
                new object[] { "@province_code", DbType.String, entity.ProvinceCode },
                new object[] { "@province_name", DbType.String, entity.ProvinceName },
                new object[] { "@property_kind", DbType.String, entity.PropertyKind },
                new object[] { "@effectivity_quarterly", DbType.Int32, entity.EffectivityQuarter },
                new object[] { "@effectivity_year", DbType.Int32, entity.EffectivityYear },
                new object[] { "@assessed_value", DbType.Decimal, entity.AssessedValue },
                new object[] { "@is_taxable", DbType.Boolean, entity.IsTaxable },
                new object[] { "@is_cancelled", DbType.Boolean, entity.IsCancelled},
                new object[] { "@posted_at", DbType.String, entity.PostedAt.ToString("yyyy-MM-dd hh:mm:ss") },
                new object[] { "@penalty_rate", DbType.Decimal, entity.PenaltyRate },
                new object[] { "@penalty_frequency", DbType.String, entity.PenaltyFrequency },
                new object[] { "@basic_rate", DbType.Decimal, entity.BasicRate },
                new object[] { "@sef_rate", DbType.Decimal, entity.SEFRate },
                new object[] { "@created_at", DbType.DateTime2, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") }
            };

            string query = $"INSERT INTO {tableName} (complete_arp_no, property_pin, owner_name, barangay_code, barangay_name, municipality_code, municipality_name, province_code, province_name, property_kind, effectivity_quarterly, effectivity_year, assessed_value, is_taxable, is_cancelled, posted_at, penalty_rate, penalty_frequency, basic_rate, sef_rate, created_at) VALUES (@complete_arp_no, @property_pin, @owner_name, @barangay_code, @barangay_name, @municipality_code, @municipality_name, @province_code, @province_name, @property_kind, @effectivity_quarterly, @effectivity_year, @assessed_value, @is_taxable, @is_cancelled, @posted_at, @penalty_rate, @penalty_frequency, @basic_rate, @sef_rate, @created_at)";

            return _mySqlGenericCommandsRPT.ExecuteNonQuery(query, parameters);
        }

        public bool IsPropertyPosted(string arpNo)
        {
            {
                var parameters = new object[][]
                {
                new object[] { "@complete_arp_no", DbType.String, arpNo },
                };

                string query = $"SELECT complete_arp_no FROM {tableName} WHERE complete_arp_no = @complete_arp_no";
                string queryResult = _mySqlGenericCommandsRPT.ExecuteScalar(query, parameters);

                if (!string.IsNullOrEmpty(queryResult))
                    return true;

                return false;
            }
        }

        public bool Update(AssessmentPostingModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
