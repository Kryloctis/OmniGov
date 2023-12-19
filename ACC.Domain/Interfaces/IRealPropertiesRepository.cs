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

        DataTable GetRecordsBy_EffectivivtyYear_Barangay_Search(int effectivityYear, string barangay, string searchText, int rowFilter);

        DataTable GetRecordNotExistedPreviousRpt(int rptId);

        DataTable GetRecordNotExistedPreviousRpt();

        DataTable GetRecordsBySearch(string searchText, int rowFilter, bool showCancelled);

        Dictionary<string, string> GetViewRecordById(int Id);

        int GetLastInsertedId(int userId);

        bool Synchronize(RealPropertiesModel realPropertiesModel);

        bool InsertWithPreviousAssessments(RealPropertiesModel realPropertiesModel);

        bool UpdateWithPreviousAssessements(RealPropertiesModel realPropertiesModel);
    }
}