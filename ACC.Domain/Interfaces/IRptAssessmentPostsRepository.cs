using ACC.Domain.Interfaces;
using RPT.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace RPT.Domain.Interfaces
{
    public interface IRptAssessmentPostsRepository : IAccRepository<RptAssessmentPostsModel>
    {
        bool IsPropertyPosted(string arpNo);

        Dictionary<string, string> GetViewRecentAssessmentRecord(string completeArpNo, int assessmentYear);

        int GetMinAssessmentPostYear(string completeArpNo);

        Dictionary<string, string> GetRecordBy_ArpNo_Year(string completeArpNo, int year);

        DataTable GetRecordsByOwnerName_IsCancelled(string ownerName, bool isCancelled);

        DataTable GetViewRecordsByOwnerNamePeriod(string ownerName, DateTime periodFrom, DateTime periodTo);

        DataTable GetViewRecordsByArpNoPeriod(string arpNo, DateTime periodFrom, DateTime periodTo);

        DataTable GetViewRecords(DateTime date);

        bool BulkInsert(List<RptAssessmentPostsModel> assessmentPostingModels);

        DataTable GetViewDelinquentRecordsByBarangayNamePeriod(string barangayName, DateTime periodFrom, DateTime periodTo);

        DataTable Get_View_List_Of_Real_Property_Tax_Delinquences_By_TaxpayerID(int taxpayerID);

        DataTable Get_View_List_Of_Real_Property_Tax_Delinquences_By_ID(int realPropertyID);

        DataTable GetViewDelinquentRecordsByOwnerNamePeriod(string ownerName, DateTime periodFrom, DateTime periodTo);

        DataTable GetBarangayRecords();

        DataTable GetViewRecordsByTaxpayerIdArpNoShowPaid(int realTaxpayersId, int calendarYear, string completeArpNo, bool showPaidAssessments);

        DataTable GetRecordsByRealTaxpayersId(int realTaxpayersId, bool showIsCancelled);

        DataTable GetViewRecordsByOwnerId(int taxpayerId);

        DataTable GetViewDeliquentRecords();

        DataTable GetViewDelinquentRecords(string completeArpNo, DateTime date);
    }
}