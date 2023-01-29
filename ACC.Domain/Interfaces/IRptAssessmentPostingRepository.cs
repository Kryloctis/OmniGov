using ACC.Domain.Interfaces;
using RPT.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace RPT.Domain.Interfaces
{
    public interface IRptAssessmentPostingRepository : IAccRepository<RptAssessmentPostsModel>
    {
        bool IsPropertyPosted(string arpNo);

        Dictionary<string, string> GetViewPreviousAssessmentPostRecord(string completeArpNo, int assessmentPostYear);

        int GetMinAssessmentPostYear(string completeArpNo);

        Dictionary<string, string> GetRecordBy_ArpNo_Year(string completeArpNo, int year);

        DataTable GetRecordsByOwnerName_IsCancelled(string ownerName, bool isCancelled);

        DataTable GetViewRptPropertyAssessmentsRecordsBy_OwnerName_Years(string ownerName, int yearFrom, int yearTo);

        DataTable GetRecordsByArpNo(string arpNo);

        bool BulkInsert(List<RptAssessmentPostsModel> assessmentPostingModels);

        DataTable Get_View_List_Of_Real_Property_Tax_Delinquences_By_Taxpayer_AsOfDate_TaxYear(string ownerName, DateTime asOfDate, int? taxYear);

        DataTable Get_View_List_Of_Real_Property_Tax_Delinquences_By_BarangayName_AsOfDate_TaxYear(string barangayName, DateTime asOfDate, int? taxYear);

        DataTable Get_View_List_Of_Real_Property_Tax_Delinquences_By_Municipality_AsOfDate_TaxYear(string municipalityName, DateTime asOfDate, int? taxYear);

        DataTable Get_View_CertListOfAllRptDelinquences_By_BarangayName_AsOfDate(string barangayName, DateTime asOfDate);

        DataTable Get_Grouped_Barangay_Records();

        DataTable Get_Grouped_Municipality_Records();

        DataTable GetViewRecords(int realTaxpayersId, string completeArpNo, bool showPaidAssessments);

        DataTable GetRecordsByRealTaxpayersId(int realTaxpayersId, bool showIsCancelled);
    }
}