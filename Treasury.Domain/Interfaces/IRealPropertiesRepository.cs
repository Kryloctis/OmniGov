using OmniGov.Core.Interfaces;
using System.Data;
using Treasury.Domain.Entities;

namespace Treasury.Domain.Interfaces
{
    public interface IRealPropertiesRepository : IRepository<RealPropertiesModel>
    {
        bool CompleteArpNoExist(string completeArpNo);

        bool CompleteArpNoExist(string completeArpNo, int Id);

        Dictionary<string, string> GetViewRecordByCompleteArpNo(string completeArpNo);

        DataTable GetRecordsBy_EffectivivtyYear_Barangay_Search(int effectivityYear, string barangay, string searchText, int rowFilter);

        DataTable GetRecordNotExistedPreviousRpt(int rptId);

        DataTable GetRecordNotExistedPreviousRpt();

        DataTable GetRecordsBySearch(string searchText, int rowFilter, bool showCancelled);

        DataTable GetViewRecords();

        DataTable GetViewRecordsByKind(char propertyType);

        Dictionary<string, string> GetViewRecordById(int Id);

        int GetLastInsertedId(int userId);

        bool Synchronize(RealPropertiesModel realPropertiesModel);

        bool InsertWithPreviousAssessments(RealPropertiesModel realPropertiesModel);

        bool UpdateWithPreviousAssessements(RealPropertiesModel realPropertiesModel);

        DataTable GetPropertiesByOwnerId(int taxPayerId);
    }
}