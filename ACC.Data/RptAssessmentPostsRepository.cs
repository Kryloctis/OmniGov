using RPT.Domain.Interfaces;
using RPT.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    public class RptAssessmentPostsRepository : IRptAssessmentPostingRepository
    {
        private readonly string tableName = "rpt_assessment_posts";
        private readonly string rptTaxDues = "rpt_tax_dues";
        private readonly string viewRptPropertyAssessments = "view_rpt_property_assessments";
        private AccGenericCommands mySqlGenericCommands;

        public RptAssessmentPostsRepository(AccGenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public bool BulkInsert(List<RptAssessmentPostsModel> assessmentPostingModels)
        {
            using (var scope = new TransactionScope())
            {
                foreach (RptAssessmentPostsModel assessmentPostingModel in assessmentPostingModels)
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

        public bool Delete(List<RptAssessmentPostsModel> entityList)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var recordDictionary = new Dictionary<string, string>();
            var parameters = new object[][]
            {
                new object[] { @"id", DbType.Int32, Id},
            };

            string query = $"SELECT * FROM {tableName} WHERE id = @id";

            DataTable dataTable = mySqlGenericCommands.ExecuteReader(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                foreach (DataColumn column in dataTable.Columns)
                    recordDictionary[column.ColumnName] = row[column].ToString();

                return recordDictionary;
            }
            return recordDictionary;
        }

        public Dictionary<string, string> GetRecordBy_ArpNo_Year(string completeArpNo, int year)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@complete_arp_no", DbType.String, completeArpNo},
                new object[] { "@year", DbType.Int32, year}
            };

            string query = $"SELECT * FROM {tableName} WHERE complete_arp_no = @complete_arp_no AND year = @year";
            DataTable dataTable = mySqlGenericCommands.ExecuteReader(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                foreach (DataColumn column in dataTable.Columns)
                    recordDictionary[column.ColumnName] = row[column].ToString();

                return recordDictionary;
            }
            return recordDictionary;
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {tableName}";
            var dataTable = new DataTable();
            return mySqlGenericCommands.Fill(query, dataTable);
        }

        public DataTable GetRecordsByArpNo(string arpNo)
        {
            var parameters = new object[][]
            {
                new object[] { "@complete_arp_no", DbType.String, arpNo}
            };

            string query = $"SELECT * FROM {tableName} WHERE NOT EXISTS(SELECT * FROM {rptTaxDues} WHERE {tableName}.id = {rptTaxDues}.rpt_assessment_posts_id) AND complete_arp_no = @complete_arp_no ORDER BY year DESC";
            var dataTable = new DataTable();
            return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }

        public DataTable GetRecordsByOwnerName_IsCancelled(string ownerName, bool isCancelled)
        {
            var parameters = new object[][]
            {
                new object[] { "@taxpayer_name", DbType.String, ownerName},
            };

            string isCancelledQuery = $"AND is_cancelled = 0";
            string query;

            if (isCancelled)
                query = $"SELECT * FROM {tableName} WHERE taxpayer_name = @taxpayer_name GROUP BY complete_arp_no ORDER BY complete_arp_no ASC";
            else
                query = $"SELECT * FROM {tableName} WHERE taxpayer_name = @taxpayer_name {isCancelledQuery} GROUP BY complete_arp_no ORDER BY complete_arp_no ASC";

            var dataTable = new DataTable();
            return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameters = new object[][]
            {
                new object [] { "@search_text", DbType.String, $"%{searchText}%"}
            };

            string query = $"SELECT * FROM {tableName} GROUP BY taxpayer_name";
            var dataTable = new DataTable();
            return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(RptAssessmentPostsModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@complete_arp_no", DbType.String, entity.CompleteArpNo },
                new object[] { "@property_pin", DbType.String, entity.PropertyPin },
                new object[] { "@taxpayer_tin", DbType.String, entity.TaxpayerTin },
                new object[] { "@real_taxpayers_id", DbType.Int32, entity.TaxpayerId },
                new object[] { "@taxpayer_name", DbType.String, entity.TaxpayerName },
                new object[] { "@taxpayer_contact_info", DbType.String, entity.TaxpayerContactInfo },
                new object[] { "@taxpayer_address", DbType.String, entity.TaxpayerAddress },
                new object[] { "@street", DbType.String, entity.Street},
                new object[] { "@barangay_name", DbType.String, entity.BarangayName },
                new object[] { "@municipality_name", DbType.String, entity.MunicipalityName },
                new object[] { "@province_name", DbType.String, entity.ProvinceName },
                new object[] { "@property_kind", DbType.String, entity.PropertyKind },
                new object[] { "@effectivity_quarterly", DbType.Int32, entity.EffectivityQuarter },
                new object[] { "@effectivity_year", DbType.Int32, entity.EffectivityYear },
                new object[] { "@other_improvements",DbType.Decimal, entity.OtherImprovements},
                new object[] { "@assessed_value", DbType.Decimal, entity.AssessedValue },
                new object[] { "@area", DbType.Decimal, entity.Area},
                new object[] { "@lot_no", DbType.String, entity.LotNo},
                new object[] { "@classification_code", DbType.String, entity.ClassificationCode},
                new object[] { "@classification_name", DbType.String, entity.ClassificationName},
                new object[] { "@actual_use_code", DbType.String, entity.ActualUseCode},
                new object[] { "@actual_use_name", DbType.String, entity.ActualUseName},
                new object[] { "@gr_year", DbType.Int32, entity.GrYear},
                new object[] { "@is_taxable", DbType.Boolean, entity.IsTaxable },
                new object[] { "@is_cancelled", DbType.Boolean, entity.IsCancelled },
                new object[] { "@penalty_rate", DbType.Decimal, entity.PenaltyRate },
                new object[] { "@penalty_frequency", DbType.String, entity.PenaltyFrequency },
                new object[] { "@basic_rate", DbType.Decimal, entity.BasicRate },
                new object[] { "@sef_rate", DbType.Decimal, entity.SefRate },
                new object[] { "@year", DbType.Int32, entity.DueYear },
                new object[] { "@posted_by", DbType.Int32, entity.PostedBy },
            };

            string query = $"INSERT INTO {tableName} (real_taxpayers_id, complete_arp_no, property_pin, taxpayer_tin, taxpayer_name, taxpayer_contact_info, taxpayer_address, street, barangay_name, municipality_name, province_name, property_kind, effectivity_quarterly, effectivity_year, other_improvements, assessed_value, area, lot_no, classification_code, classification_name, actual_use_code, actual_use_name, gr_year, is_taxable, is_cancelled, penalty_rate, penalty_frequency, basic_rate, sef_rate, year, posted_by) VALUES (@real_taxpayers_id, @complete_arp_no, @property_pin, @taxpayer_tin, @taxpayer_name, @taxpayer_contact_info, @taxpayer_address, @street, @barangay_name, @municipality_name, @province_name, @property_kind, @effectivity_quarterly, @effectivity_year, @other_improvements, @assessed_value, @area, @lot_no, @classification_code, @classification_name, @actual_use_code, @actual_use_name, @gr_year, @is_taxable, @is_cancelled, @penalty_rate, @penalty_frequency, @basic_rate, @sef_rate, @year, @posted_by)";

            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool IsPropertyPosted(string arpNo)
        {
            var parameters = new object[][]
            {
                new object[] { "@complete_arp_no", DbType.String, arpNo },
            };

            string query = $"SELECT complete_arp_no FROM {tableName} WHERE complete_arp_no = @complete_arp_no";
            string queryResult = mySqlGenericCommands.ExecuteScalar(query, parameters);

            if (!string.IsNullOrEmpty(queryResult))
                return true;

            return false;
        }

        public bool Update(RptAssessmentPostsModel entity)
        {
            throw new NotImplementedException();
        }

        public int GetMinAssessmentPostYear(string completeArpNo)
        {
            var parameters = new object[][]
            {
                new object[] { "@complete_arp_no", DbType.String, completeArpNo}
            };

            string query = $"SELECT COALESCE(MIN(year), 0) AS min_year FROM {tableName} WHERE complete_arp_no = @complete_arp_no";
            return Convert.ToInt32(mySqlGenericCommands.ExecuteScalar(query, parameters));
        }

        public DataTable GetViewRecordsByOwnerNamePeriod(string ownerName, DateTime periodFrom, DateTime periodTo)
        {
            var parameters = new object[][]
            {
                new object[] { "@taxpayer_name", DbType.String, ownerName},
                new object[] { "@periodFrom", DbType.DateTime, periodFrom},
                new object[] { "@periodTo", DbType.DateTime, periodTo},
            };

            string query = $"SELECT * FROM {viewRptPropertyAssessments} WHERE taxpayer_name = @taxpayer_name AND posted_at <= @periodTo AND posted_at >= @periodFrom ORDER BY complete_arp_no ASC";

            var dataTable = new DataTable();
            return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }

        public DataTable GetViewRecordsByBarangayNamePeriod(string barangayName, DateTime periodFrom, DateTime periodTo)
        {
            var parameters = new object[][]
            {
                new object[] { "@barangay_name", DbType.String, barangayName},
                new object[] { "@periodFrom", DbType.DateTime, periodFrom},
                new object[] { "@periodTo", DbType.DateTime, periodTo},
            };

            string query = $"SELECT * FROM {viewRptPropertyAssessments} WHERE barangay_name = @barangay_name AND posted_at <= @periodTo AND posted_at >= @periodFrom AND rpt_payments_id IS NULL";
            var dataTable = new DataTable();

            return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }

        public DataTable GetBarangayRecords()
        {
            string query = $"SELECT * FROM {tableName} GROUP BY barangay_name";
            var dataTable = new DataTable();
            return mySqlGenericCommands.Fill(query, dataTable);
        }

        public DataTable Get_Grouped_Municipality_Records()
        {
            string query = $"SELECT municipality_name FROM {tableName} GROUP BY municipality_name";
            var dataTable = new DataTable();
            return mySqlGenericCommands.Fill(query, dataTable);
        }

        public DataTable GetViewRecords(int realTaxpayersId, string completeArpNo, bool showPaidAssessments)
        {
            var parameters = new object[][]
            {
                new object[] { "@real_taxpayers_id", DbType.Int32, realTaxpayersId },
                new object[] { "@complete_arp_no", DbType.String, completeArpNo }
            };

            string subQuery = showPaidAssessments ? string.Empty : "(rpt_payments_id IS NULL OR rpt_payments_id = '') AND";

            string query = $"SELECT * FROM {viewRptPropertyAssessments} WHERE {subQuery} real_taxpayers_id = @real_taxpayers_id AND complete_arp_no = @complete_arp_no ORDER BY complete_arp_no ASC";

            var dataTable = new DataTable();
            return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }

        public DataTable GetRecordsByRealTaxpayersId(int realTaxpayersId, bool showIsCancelled)
        {
            var parameters = new object[][]
            {
                new object[] { "@real_taxpayers_id", DbType.Int32, realTaxpayersId}
            };

            string subQuery = showIsCancelled ? string.Empty : " AND is_cancelled = 0";
            string query = $"SELECT * FROM {tableName} WHERE real_taxpayers_id = @real_taxpayers_id AND is_taxable = 1{subQuery} GROUP BY complete_arp_no ORDER BY complete_arp_no ASC";
            var dataTable = new DataTable();
            return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }

        public Dictionary<string, string> GetViewRecentAssessmentRecord(string arpNo, int assessmentYear)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@complete_arp_no", DbType.String, arpNo},
                new object[] { "@year", DbType.Int32, assessmentYear}
            };

            string query = $"SELECT * FROM {viewRptPropertyAssessments} WHERE complete_arp_no = @complete_arp_no AND year < @year ORDER BY year DESC";

            DataTable dataTable = mySqlGenericCommands.ExecuteReader(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                foreach (DataColumn column in dataTable.Columns)
                    recordDictionary[column.ColumnName] = row[column].ToString();

                return recordDictionary;
            }
            return recordDictionary;
        }
    }
}