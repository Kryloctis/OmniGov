using System;
using System.Collections.Generic;
using System.Data;
using ACC.Domain.Interfaces;
using RPT.Domain.Models;

namespace RPT.Domain.Interfaces
{
    public interface IRptAssessmentPostingRepository : IRepository<RptAssessmentPostsModel>
    {
        bool IsPropertyPosted(string arpNo);

        int PreviousAssessmentPostCount(string completeArpNo, int year);

        int GetMinAssessmentPostYear(string completeArpNo);

        Dictionary<string, string> GetRecordBy_ArpNo_Year(string completeArpNo, int year);

        DataTable GetRecordsByOwnerName_IsCancelled(string ownerName, bool isCancelled);

        DataTable GetViewRptPropertyAssessmentsRecordsBy_OwnerName_Years(string ownerName, int yearFrom, int yearTo);

        DataTable GetRecordsByArpNo(string arpNo);

        bool BulkInsert(List<RptAssessmentPostsModel> assessmentPostingModels);

        DataTable Get_View_List_Of_Real_Property_Tax_Delinquences_By_Taxpayer_AsOfDate_TaxYear(string ownerName, DateTime asOfDate, int? taxYear);
        DataTable Get_View_List_Of_Real_Property_Tax_Delinquences_By_BarangayName_AsOfDate_TaxYear(string barangayName, DateTime asOfDate, int? taxYear);
        DataTable Get_View_List_Of_Real_Property_Tax_Delinquences_By_Municipality_AsOfDate_TaxYear(string municipalityName, DateTime asOfDate, int? taxYear);

        DataTable Get_Grouped_Barangay_Records();
        DataTable Get_Grouped_Municipality_Records();
    }
}
