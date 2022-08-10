using ACC.Data;
using RPT.Domain.Interfaces;
using RPT.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ACC.Data
{
    public class RptAssessmentPostingRepository : IRptAssessmentPostingRepository
    {
        private readonly string tableName = "rpt_assessment_posts";
        private readonly string rptTaxDues = "rpt_tax_dues";
        private MySqlGenericCommands _mySqlGenericCommands;

        public RptAssessmentPostingRepository(MySqlGenericCommands mySqlGenericCommands)
        {
            _mySqlGenericCommands = mySqlGenericCommands;
        }

        public bool BulkInsert(List<RptAssessmentPostingModel> assessmentPostingModels)
        {
            using (var scope = new TransactionScope())
            {
                foreach (RptAssessmentPostingModel assessmentPostingModel in assessmentPostingModels) 
                {
                    _ = Insert(assessmentPostingModel);
                }

                scope.Complete();
                return true;
            }           
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<RptAssessmentPostingModel> entityList)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> GetRecordBy_ArpNo_Year(string completeArpNo, int year)
        {
            var dict = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@complete_arp_no", DbType.String, completeArpNo},
                new object[] { "@year", DbType.Int32, year}
            };

            string query = $"SELECT * FROM {tableName} WHERE complete_arp_no = @complete_arp_no AND year = @year";
            using (var reader = _mySqlGenericCommands.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return dict;

                foreach (DataRow row in reader.Rows)
                {
                    dict.Add("id", row["id"].ToString());
                    dict.Add("property_identifier", row["property_identifier"].ToString());
                    dict.Add("complete_arp_no", row["complete_arp_no"].ToString());
                    dict.Add("property_pin", row["property_pin"].ToString());
                    dict.Add("owner_name", row["owner_name"].ToString());
                    dict.Add("owner_tin", row["owner_tin"].ToString());
                    dict.Add("owner_address", row["owner_address"].ToString());
                    dict.Add("owner_contact", row["owner_contact"].ToString());
                    dict.Add("barangay_name", row["barangay_name"].ToString());
                    dict.Add("municipality_name", row["municipality_name"].ToString());
                    dict.Add("province_name", row["province_name"].ToString());
                    dict.Add("property_kind", row["property_kind"].ToString());
                    dict.Add("effectivity_quarterly", row["effectivity_quarterly"].ToString());
                    dict.Add("effectivity_year", row["effectivity_year"].ToString());
                    dict.Add("assessed_value", row["assessed_value"].ToString());
                    dict.Add("is_taxable", row["is_taxable"].ToString());
                    dict.Add("is_cancelled", row["is_cancelled"].ToString());
                    dict.Add("penalty_rate", row["penalty_rate"].ToString());
                    dict.Add("penalty_frequency", row["penalty_frequency"].ToString());
                    dict.Add("basic_rate", row["basic_rate"].ToString());
                    dict.Add("sef_rate", row["sef_rate"].ToString());
                    dict.Add("year", row["year"].ToString());
                    dict.Add("posted_at", row["posted_at"].ToString());
                    dict.Add("posted_by", row["posted_by"].ToString());
                }
            }

            return dict;
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {tableName}";
            var dataTable = new DataTable();
            return _mySqlGenericCommands.Fill(query, dataTable);
        }

        public DataTable GetRecordsByArpNo(string arpNo)
        {
            var parameters = new object[][]
            {
                new object[] { "@complete_arp_no", DbType.String, arpNo}
            };

            string query = $"SELECT * FROM {tableName} WHERE NOT EXISTS(SELECT * FROM {rptTaxDues} WHERE {tableName}.id = {rptTaxDues}.rpt_assessment_posts_id) AND complete_arp_no = @complete_arp_no ORDER BY year DESC";
            var dataTable = new DataTable();
            return _mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }

        public DataTable GetRecordsByOwnerName_IsCancelled(string ownerName, bool isCancelled)
        {
            var parameters = new object[][]
            {
                new object[] { "@owner_name", DbType.String, ownerName},
            };

            string isCancelledQuery = $"AND is_cancelled = 0";
            string query;

            if (isCancelled)
                query = $"SELECT * FROM {tableName} WHERE owner_name = @owner_name GROUP BY complete_arp_no ORDER BY complete_arp_no ASC";
            else
               query = $"SELECT * FROM {tableName} WHERE owner_name = @owner_name {isCancelledQuery} GROUP BY complete_arp_no ORDER BY complete_arp_no ASC";

            var dataTable = new DataTable();
            return _mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameters = new object[][]
            {
                new object [] { "@search_text", DbType.String, $"%{searchText}%"}
            };

            string query = $"SELECT * FROM {tableName} WHERE complete_arp_no LIKE @search_text OR property_pin LIKE @search_text OR owner_name LIKE @search_text OR owner_tin LIKE @search_text OR owner_address LIKE @search_text OR owner_contact LIKE @search_text OR barangay_name LIKE @search_text OR municipality_name LIKE @search_text OR province_name LIKE @search_text GROUP BY owner_name";
            var dataTable = new DataTable();
            return _mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }

        public int PreviousAssessmentPostCount(string completeArpNo, int year)
        {
            var parameters = new object[][]
            {
                new object[] { "@complete_arp_no", DbType.String, completeArpNo},
                new object[] { "@year", DbType.Int32, year}
            };

            string query = $"SELECT COUNT(*) FROM {tableName} WHERE complete_arp_no = complete_arp_no AND year = (SELECT MAX(year) FROM {tableName} WHERE year < @year)";

            string result = _mySqlGenericCommands.ExecuteScalar(query, parameters);
            return Convert.ToInt32(result);
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(RptAssessmentPostingModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@property_identifier", DbType.String, entity.propertyIdentifier },
                new object[] { "@complete_arp_no", DbType.String, entity.CompleteArpNo },
                new object[] { "@property_pin", DbType.String, entity.PropertyPin },
                new object[] { "@owner_name", DbType.String, entity.OwnerName },
                new object[] { "@owner_tin", DbType.String, entity.OwnerTin },
                new object[] { "@owner_address", DbType.String, entity.OwnerAddress },
                new object[] { "@owner_contact", DbType.String, entity.OwnerContact },
                new object[] { "@barangay_name", DbType.String, entity.BarangayName },
                new object[] { "@municipality_name", DbType.String, entity.MunicipalityName },
                new object[] { "@province_name", DbType.String, entity.ProvinceName },
                new object[] { "@property_kind", DbType.String, entity.PropertyKind },
                new object[] { "@effectivity_quarterly", DbType.Int32, entity.EffectivityQuarter },
                new object[] { "@effectivity_year", DbType.Int32, entity.EffectivityYear },
                new object[] { "@assessed_value", DbType.Decimal, entity.AssessedValue },
                new object[] { "@is_taxable", DbType.Boolean, entity.IsTaxable },
                new object[] { "@is_cancelled", DbType.Boolean, entity.IsCancelled },
                new object[] { "@penalty_rate", DbType.Decimal, entity.PenaltyRate },
                new object[] { "@penalty_frequency", DbType.String, entity.PenaltyFrequency },
                new object[] { "@basic_rate", DbType.Decimal, entity.BasicRate },
                new object[] { "@sef_rate", DbType.Decimal, entity.SefRate },
                new object[] { "@year", DbType.Int32, entity.Year },
                new object[] { "@posted_at", DbType.DateTime, entity.PostedAt },
                new object[] { "@posted_by", DbType.Int32, entity.PostedBy },
            };

            string query = $"INSERT INTO {tableName} (property_identifier, complete_arp_no, property_pin, owner_name, owner_tin, owner_address, owner_contact, barangay_name, municipality_name, province_name, property_kind, effectivity_quarterly, effectivity_year, assessed_value, is_taxable, is_cancelled, penalty_rate, penalty_frequency, basic_rate, sef_rate, year, posted_at, posted_by) VALUES (@property_identifier, @complete_arp_no, @property_pin, @owner_name, @owner_tin, @owner_address, @owner_contact, @barangay_name, @municipality_name, @province_name, @property_kind, @effectivity_quarterly, @effectivity_year, @assessed_value, @is_taxable, @is_cancelled, @penalty_rate, @penalty_frequency, @basic_rate, @sef_rate, @year, @posted_at, @posted_by)";

            return _mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool IsPropertyPosted(string arpNo)
        {
            {
                var parameters = new object[][]
                {
                new object[] { "@complete_arp_no", DbType.String, arpNo },
                };

                string query = $"SELECT complete_arp_no FROM {tableName} WHERE complete_arp_no = @complete_arp_no";
                string queryResult = _mySqlGenericCommands.ExecuteScalar(query, parameters);

                if (!string.IsNullOrEmpty(queryResult))
                    return true;

                return false;
            }
        }

        public bool Update(RptAssessmentPostingModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
