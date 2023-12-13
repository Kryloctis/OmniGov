using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IRealPropertiesRepository : IAccRepository<RealPropertiesModel>
    {
        bool CompleteArpNoExist(string completeArpNo);

        bool CompleteArpNoExist(string completeArpNo, int Id);

        Dictionary<string, string> GetRecordByCompleteArpNo(string completeArpNo);

        DataTable GetRecordsBy_EffectivivtyYear_Barangay_Search(int effectivityYear, string barangay, string searchText);

        DataTable GetRecordsByCompleteARP(string completeARPNo);

        DataTable GetCancelledProperties();

        DataTable GetCancelledRecordsBySearch(string searchText);

        DataTable GetRecordsBySearch(string searchText, int rowFilter, bool showCancelled);

        int GetLastInsertedId();

        bool Synchronize(RealPropertiesModel realPropertiesModel);

        bool InsertWithPreviousAssessment(RealPropertiesModel realPropertiesModel, RptPreviousAssessmentModel rptPreviousAssessmentModel);
    }
}