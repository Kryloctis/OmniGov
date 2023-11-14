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
        private AccGenericCommands _mySqlGenericCommands;

        public RptAssessmentPostsRepository(AccGenericCommands mySqlGenericCommands)
        {
            _mySqlGenericCommands = mySqlGenericCommands;
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
            var dict = new Dictionary<string, string>();
            var parameters = new object[][]
            {
                new object[] { @"id", DbType.Int32, Id},
            };

            string query = $"SELECT id, real_taxpayers_id, property_identifier, complete_arp_no, property_pin, taxpayer_tin, taxpayer_name, taxpayer_contact_info, taxpayer_address, street, barangay_name, municipality_name, province_name, property_kind, effectivity_quarterly, effectivity_year, other_improvements, assessed_value, area, lot_no, classification_code, classification_name, actual_use_code, actual_use_name, gr_year, is_taxable, is_cancelled, penalty_rate, penalty_frequency, basic_rate, sef_rate, year, posted_at, posted_by FROM {tableName} WHERE id = @id";

            using (var reader = _mySqlGenericCommands.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return dict;

                foreach (DataRow row in reader.Rows)
                {
                    dict.Add("id", row["id"].ToString());
                    dict.Add("real_taxpayers_id", row["real_taxpayers_id"].ToString());
                    dict.Add("property_identifier", row["property_identifier"].ToString());
                    dict.Add("complete_arp_no", row["complete_arp_no"].ToString());
                    dict.Add("property_pin", row["property_pin"].ToString());
                    dict.Add("taxpayer_tin", row["taxpayer_tin"].ToString());
                    dict.Add("taxpayer_name", row["taxpayer_name"].ToString());
                    dict.Add("taxpayer_contact_info", row["taxpayer_contact_info"].ToString());
                    dict.Add("taxpayer_address", row["taxpayer_address"].ToString());
                    dict.Add("street", row["street"].ToString());
                    dict.Add("barangay_name", row["barangay_name"].ToString());
                    dict.Add("municipality_name", row["municipality_name"].ToString());
                    dict.Add("province_name", row["province_name"].ToString());
                    dict.Add("property_kind", row["property_kind"].ToString());
                    dict.Add("effectivity_quarterly", row["effectivity_quarterly"].ToString());
                    dict.Add("effectivity_year", row["effectivity_year"].ToString());
                    dict.Add("other_improvements", row["other_improvements"].ToString());
                    dict.Add("assessed_value", row["assessed_value"].ToString());
                    dict.Add("area", row["area"].ToString());
                    dict.Add("lot_no", row["lot_no"].ToString());
                    dict.Add("classification_code", row["classification_code"].ToString());
                    dict.Add("classification_name", row["classification_name"].ToString());
                    dict.Add("actual_use_code", row["actual_use_code"].ToString());
                    dict.Add("actual_use_name", row["actual_use_name"].ToString());
                    dict.Add("gr_year", row["gr_year"].ToString());
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
                return dict;
            };
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
                    dict.Add("real_taxpayers_id", row["real_taxpayers_id"].ToString());
                    dict.Add("property_identifier", row["property_identifier"].ToString());
                    dict.Add("complete_arp_no", row["complete_arp_no"].ToString());
                    dict.Add("property_pin", row["property_pin"].ToString());
                    dict.Add("taxpayer_tin", row["taxpayer_tin"].ToString());
                    dict.Add("taxpayer_name", row["taxpayer_name"].ToString());
                    dict.Add("taxpayer_contact_info", row["taxpayer_contact_info"].ToString());
                    dict.Add("taxpayer_address", row["taxpayer_address"].ToString());
                    dict.Add("street", row["street"].ToString());
                    dict.Add("barangay_name", row["barangay_name"].ToString());
                    dict.Add("municipality_name", row["municipality_name"].ToString());
                    dict.Add("province_name", row["province_name"].ToString());
                    dict.Add("property_kind", row["property_kind"].ToString());
                    dict.Add("effectivity_quarterly", row["effectivity_quarterly"].ToString());
                    dict.Add("effectivity_year", row["effectivity_year"].ToString());
                    dict.Add("other_improvements", row["other_improvements"].ToString());
                    dict.Add("assessed_value", row["assessed_value"].ToString());
                    dict.Add("area", row["area"].ToString());
                    dict.Add("lot_no", row["lot_no"].ToString());
                    dict.Add("classification_code", row["classification_code"].ToString());
                    dict.Add("classification_name", row["classification_name"].ToString());
                    dict.Add("actual_use_code", row["actual_use_code"].ToString());
                    dict.Add("actual_use_name", row["actual_use_name"].ToString());
                    dict.Add("gr_year", row["gr_year"].ToString());
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
                new object[] { "@taxpayer_name", DbType.String, ownerName},
            };

            string isCancelledQuery = $"AND is_cancelled = 0";
            string query;

            if (isCancelled)
                query = $"SELECT * FROM {tableName} WHERE taxpayer_name = @taxpayer_name GROUP BY complete_arp_no ORDER BY complete_arp_no ASC";
            else
                query = $"SELECT * FROM {tableName} WHERE taxpayer_name = @taxpayer_name {isCancelledQuery} GROUP BY complete_arp_no ORDER BY complete_arp_no ASC";

            var dataTable = new DataTable();
            return _mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameters = new object[][]
            {
                new object [] { "@search_text", DbType.String, $"%{searchText}%"}
            };

            string query = $"SELECT * FROM {tableName} GROUP BY taxpayer_name";
            var dataTable = new DataTable();
            return _mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(RptAssessmentPostsModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@property_identifier", DbType.String, entity.PropertyIdentifier },
                new object[] { "@complete_arp_no", DbType.String, entity.CompleteArpNo },
                new object[] { "@property_pin", DbType.String, entity.PropertyPin },
                new object[] { "@taxpayer_tin", DbType.String, entity.TaxpayerTin },
                new object[] { "@real_taxpayers_id", DbType.Int32, entity.RealTaxPayerID },
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
                new object[] { "@year", DbType.Int32, entity.Year },
                new object[] { "@posted_at", DbType.DateTime, entity.PostedAt },
                new object[] { "@posted_by", DbType.Int32, entity.PostedBy },
            };

            string query = $"INSERT INTO {tableName} (property_identifier, real_taxpayers_id, complete_arp_no, property_pin, taxpayer_tin, taxpayer_name, taxpayer_contact_info, taxpayer_address, street, barangay_name, municipality_name, province_name, property_kind, effectivity_quarterly,  effectivity_year, other_improvements, assessed_value, area, lot_no, classification_code, classification_name, actual_use_code, actual_use_name, gr_year, is_taxable, is_cancelled, penalty_rate, penalty_frequency, basic_rate, sef_rate, year, posted_at, posted_by) VALUES(@property_identifier, @real_taxpayers_id,  @complete_arp_no, @property_pin, @taxpayer_tin, @taxpayer_name, @taxpayer_contact_info, @taxpayer_address, @street, @barangay_name, @municipality_name, @province_name, @property_kind, @effectivity_quarterly, @effectivity_year, @other_improvements, @assessed_value, @area, @lot_no, @classification_code, @classification_name, @actual_use_code, @actual_use_name, @gr_year, @is_taxable, @is_cancelled, @penalty_rate, @penalty_frequency, @basic_rate, @sef_rate, @year, @posted_at, @posted_by) ";

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
            return Convert.ToInt32(_mySqlGenericCommands.ExecuteScalar(query, parameters));
        }

        public DataTable Get_View_List_Of_Real_Property_Tax_Delinquences()
        {
            string query = $"SELECT * FROM {viewRptPropertyAssessments} WHERE (DATE(posted_at) <= DATE(NOW()) && MONTH(posted_at) > 3) ORDER BY complete_arp_no ASC";

            var dataTable = new DataTable();
            return _mySqlGenericCommands.Fill(query, dataTable);
        }

        public DataTable GetViewRptPropertyAssessmentsRecordsBy_OwnerName_Years(string ownerName, int yearFrom, int yearTo)
        {
            var parameters = new object[][]
            {
                new object[] { "@taxpayer_name", DbType.String, ownerName},
                new object[] { "@year_from", DbType.Int32, yearFrom},
                new object[] { "@year_to", DbType.Int32, yearTo}
            };

            string query = $"SELECT * FROM {viewRptPropertyAssessments} WHERE taxpayer_name = @taxpayer_name AND (year >= @year_to AND year <= @year_from) ORDER BY complete_arp_no ASC";

            var dataTable = new DataTable();
            return _mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }

        public DataTable Get_View_List_Of_Real_Property_Tax_Delinquences_By_Taxpayer_AsOfDate_TaxYear(string ownerName, DateTime asOfDate, int? taxYear)
        {
            string taxYearQuery;

            if (taxYear == null) taxYearQuery = string.Empty;
            else taxYearQuery = $"AND year = {taxYear}";

            var parameters = new object[][]
            {
                new object[] { "@taxpayer_name", DbType.String, ownerName},
                new object[] { "@posted_at", DbType.Date, asOfDate}
            };

            string query = $"SELECT * FROM {viewRptPropertyAssessments} WHERE taxpayer_name = @taxpayer_name AND (DATE(posted_at) <= @posted_at && MONTH(posted_at) > 3) {taxYearQuery}";
            var dataTable = new DataTable();
            return _mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }

        public DataTable Get_View_List_Of_Real_Property_Tax_Delinquences_By_BarangayName_AsOfDate_TaxYear(string barangayName, DateTime asOfDate, int? taxYear)
        {
            string taxYearQuery;

            if (taxYear == null) taxYearQuery = string.Empty;
            else taxYearQuery = $"AND year = {taxYear}";

            var parameters = new object[][]
            {
                new object[] { "@barangay_name", DbType.String, barangayName},
                new object[] { "@posted_at", DbType.Date, asOfDate.Date }
            };

            string query = $"SELECT * FROM {viewRptPropertyAssessments} WHERE barangay_name = @barangay_name AND (DATE(posted_at) <= @posted_at && MONTH(posted_at) > 3) {taxYearQuery}";
            var dataTable = new DataTable();
            return _mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }

        public DataTable Get_View_List_Of_Real_Property_Tax_Delinquences_By_Municipality_AsOfDate_TaxYear(string municipalityName, DateTime asOfDate, int? taxYear)
        {
            string taxYearQuery;

            if (taxYear == null) taxYearQuery = string.Empty;
            else taxYearQuery = $"AND year = {taxYear}";

            var parameters = new object[][]
            {
                new object[] { "@municipality_name", DbType.String, municipalityName},
                new object[] { "@posted_at", DbType.Date, asOfDate.Date }
            };

            string query = $"SELECT * FROM {viewRptPropertyAssessments} WHERE municipality_name = @municipality_name AND (DATE(posted_at) <= @posted_at && MONTH(posted_at) > 3) {taxYearQuery}";
            var dataTable = new DataTable();
            return _mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }

        public DataTable Get_Grouped_Barangay_Records()
        {
            string query = $"SELECT barangay_name FROM {tableName} GROUP BY barangay_name";
            var dataTable = new DataTable();
            return _mySqlGenericCommands.Fill(query, dataTable);
        }

        public DataTable Get_Grouped_Municipality_Records()
        {
            string query = $"SELECT municipality_name FROM {tableName} GROUP BY municipality_name";
            var dataTable = new DataTable();
            return _mySqlGenericCommands.Fill(query, dataTable);
        }

        public DataTable Get_View_CertListOfAllRptDelinquences_By_BarangayName_AsOfDate(string barangayName, DateTime asOfDate)
        {
            var parameters = new object[][]
            {
                new object[] { "@barangay_name", DbType.String, barangayName},
                new object[] { "@posted_at", DbType.Date, asOfDate.Date}
            };

            string query = $"SELECT * FROM {viewRptPropertyAssessments} WHERE barangay_name = @barangay_name AND (DATE(posted_at) <= @posted_at && MONTH(posted_at) > 3)";
            var dataTable = new DataTable();

            return _mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
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
            return _mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
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
            return _mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }

        public Dictionary<string, string> GetViewPreviousAssessmentPostRecord(string completeArpNo, int assessmentPostYear)
        {
            var dict = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@complete_arp_no", DbType.String, completeArpNo},
                new object[] { "@year", DbType.Int32, assessmentPostYear}
            };

            string query = $"SELECT rpt_assessment_posts_id, real_taxpayers_id, property_identifier, complete_arp_no, property_pin, taxpayer_tin, taxpayer_name, taxpayer_contact_info, taxpayer_address, street, barangay_name, municipality_name, province_name, property_kind, effectivity_quarterly, effectivity_year, other_improvements, assessed_value, area, lot_no, classification_code, classification_name, actual_use_code, actual_use_name, gr_year, is_taxable, is_cancelled, tax_dues_id, discount_rate, is_advance, penalty_rate, penalty_frequency, basic_rate, sef_rate, year, posted_at, posted_by, rpt_payments_id, rpt_payments_posted_at, rpt_payments_posted_by, payment_collections_id, payment_collections_collecting_officers_id, payment_collections_job_orders_id, payment_collections_funds_id, payment_collections_accountable_forms_id, payment_collections_payee, payment_collections_receipt_no, payment_collections_payment_date, payment_collections_amount, payment_collections_is_cancelled, payment_collections_created_at, payment_collections_created_by, payment_collections_updated_at, payment_collections_updated_by FROM {viewRptPropertyAssessments} WHERE complete_arp_no = @complete_arp_no AND year < @year ORDER BY year DESC";

            using (var reader = _mySqlGenericCommands.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return dict;

                //I choose indexing of row to get the nearest previous assessment to the applied assessment post year
                dict.Add("rpt_assessment_posts_id", reader.Rows[0]["rpt_assessment_posts_id"].ToString());
                dict.Add("real_taxpayers_id", reader.Rows[0]["real_taxpayers_id"].ToString());
                dict.Add("property_identifier", reader.Rows[0]["property_identifier"].ToString());
                dict.Add("complete_arp_no", reader.Rows[0]["complete_arp_no"].ToString());
                dict.Add("property_pin", reader.Rows[0]["property_pin"].ToString());
                dict.Add("taxpayer_tin", reader.Rows[0]["taxpayer_tin"].ToString());
                dict.Add("taxpayer_name", reader.Rows[0]["taxpayer_name"].ToString());
                dict.Add("taxpayer_contact_info", reader.Rows[0]["taxpayer_contact_info"].ToString());
                dict.Add("taxpayer_address", reader.Rows[0]["taxpayer_address"].ToString());
                dict.Add("street", reader.Rows[0]["street"].ToString());
                dict.Add("barangay_name", reader.Rows[0]["barangay_name"].ToString());
                dict.Add("municipality_name", reader.Rows[0]["municipality_name"].ToString());
                dict.Add("province_name", reader.Rows[0]["province_name"].ToString());
                dict.Add("property_kind", reader.Rows[0]["property_kind"].ToString());
                dict.Add("effectivity_quarterly", reader.Rows[0]["effectivity_quarterly"].ToString());
                dict.Add("effectivity_year", reader.Rows[0]["effectivity_year"].ToString());
                dict.Add("other_improvements", reader.Rows[0]["other_improvements"].ToString());
                dict.Add("assessed_value", reader.Rows[0]["assessed_value"].ToString());
                dict.Add("area", reader.Rows[0]["area"].ToString());
                dict.Add("lot_no", reader.Rows[0]["lot_no"].ToString());
                dict.Add("classification_code", reader.Rows[0]["classification_code"].ToString());
                dict.Add("classification_name", reader.Rows[0]["classification_name"].ToString());
                dict.Add("actual_use_code", reader.Rows[0]["actual_use_code"].ToString());
                dict.Add("actual_use_name", reader.Rows[0]["actual_use_name"].ToString());
                dict.Add("gr_year", reader.Rows[0]["gr_year"].ToString());
                dict.Add("is_taxable", reader.Rows[0]["is_taxable"].ToString());
                dict.Add("is_cancelled", reader.Rows[0]["is_cancelled"].ToString());
                dict.Add("tax_dues_id", reader.Rows[0]["tax_dues_id"].ToString());
                dict.Add("discount_rate", reader.Rows[0]["discount_rate"].ToString());
                dict.Add("is_advance", reader.Rows[0]["is_advance"].ToString());
                dict.Add("penalty_rate", reader.Rows[0]["penalty_rate"].ToString());
                dict.Add("penalty_frequency", reader.Rows[0]["penalty_frequency"].ToString());
                dict.Add("basic_rate", reader.Rows[0]["basic_rate"].ToString());
                dict.Add("sef_rate", reader.Rows[0]["sef_rate"].ToString());
                dict.Add("year", reader.Rows[0]["year"].ToString());
                dict.Add("posted_at", reader.Rows[0]["posted_at"].ToString());
                dict.Add("posted_by", reader.Rows[0]["posted_by"].ToString());
                dict.Add("rpt_payments_id", reader.Rows[0]["rpt_payments_id"].ToString());
                dict.Add("rpt_payments_posted_at", reader.Rows[0]["rpt_payments_posted_at"].ToString());
                dict.Add("rpt_payments_posted_by", reader.Rows[0]["rpt_payments_posted_by"].ToString());
                dict.Add("payment_collections_id", reader.Rows[0]["payment_collections_id"].ToString());
                dict.Add("payment_collections_collecting_officers_id", reader.Rows[0]["payment_collections_collecting_officers_id"].ToString());
                dict.Add("payment_collections_job_orders_id", reader.Rows[0]["payment_collections_job_orders_id"].ToString());
                dict.Add("payment_collections_funds_id", reader.Rows[0]["payment_collections_funds_id"].ToString());
                dict.Add("payment_collections_accountable_forms_id", reader.Rows[0]["payment_collections_accountable_forms_id"].ToString());
                dict.Add("payment_collections_payee", reader.Rows[0]["payment_collections_payee"].ToString());
                dict.Add("payment_collections_receipt_no", reader.Rows[0]["payment_collections_receipt_no"].ToString());
                dict.Add("payment_collections_payment_date", reader.Rows[0]["payment_collections_payment_date"].ToString());
                dict.Add("payment_collections_amount", reader.Rows[0]["payment_collections_amount"].ToString());
                dict.Add("payment_collections_is_cancelled", reader.Rows[0]["payment_collections_is_cancelled"].ToString());
                dict.Add("payment_collections_created_at", reader.Rows[0]["payment_collections_created_at"].ToString());
                dict.Add("payment_collections_created_by", reader.Rows[0]["payment_collections_created_by"].ToString());
                dict.Add("payment_collections_updated_at", reader.Rows[0]["payment_collections_updated_at"].ToString());
                dict.Add("payment_collections_updated_by", reader.Rows[0]["payment_collections_updated_by"].ToString());

                return dict;
            }
        }

        public DataTable Get_View_List_Of_Real_Property_Tax_Delinquences_By_ID(int realPropertyID)
        {
            var parameter = new object[][]
            {
                new object[] { "@real_property_id", DbType.Int32, realPropertyID }
            };

            string query = $"SELECT * FROM {viewRptPropertyAssessments} WHERE (DATE(posted_at) <= DATE(NOW()) && MONTH(posted_at) > 3) AND rpt_assessment_posts_id = @real_property_id ORDER BY complete_arp_no ASC";

            var dataTable = new DataTable();
            return _mySqlGenericCommands.FillBySearch(query, dataTable, parameter);
        }

        public DataTable Get_View_List_Of_Real_Property_Tax_Delinquences_By_TaxpayerID(int taxPayerID)
        {
            var parameter = new object[][]
            {
                new object[] { "@real_taxpayers_id", DbType.Int32, taxPayerID }
            };

            string query = $"SELECT * FROM {viewRptPropertyAssessments} WHERE (DATE(posted_at) <= DATE(NOW()) && MONTH(posted_at) > 3) AND real_taxpayers_id = @real_taxpayers_id  GROUP BY complete_arp_no ORDER BY complete_arp_no ASC";

            var dataTable = new DataTable();
            return _mySqlGenericCommands.FillBySearch(query, dataTable, parameter);
        }
    }
}