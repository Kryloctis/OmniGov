using OmniGov.Core.Entities;
using System.Data;

namespace OmniGov.Core.Interfaces
{
    public interface ISignatoriesHasReferences : IRepository<SignatoriesHasReferencesModel>
    {
        DataTable GetRecordsBySignatoryId(int signatoryId);

        DataTable GetDocumentRecordsBySignatoryId(int signatoryId);

        Dictionary<string, string> GetSigntryByRefDoc(string reference, string documentName);

        bool DeleteBySignatoryId(int signatoryId);

        bool ReferenceIdExist(int documentReferenceId);

        bool ReferenceIdExist(int documentReferenceId, int signatories_id);

        bool IsReferencedBySignatory(int documentReferenceId, int signatories_id);
    }
}