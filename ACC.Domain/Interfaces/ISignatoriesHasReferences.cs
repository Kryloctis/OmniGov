using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface ISignatoriesHasReferences : IRepository<SignatoriesHasReferencesModel>
    {
        DataTable GetRecordsBySignatoryId(int signatoryId);

        DataTable GetDocumentRecordsBySignatoryId(int signatoryId);

        DataTable GetRecordsByOffice(string office);

        Dictionary<string, string> GetSignatoryByReferenceAndDocumentName(string reference, string documentName);

        bool DeleteBySignatoryId(int signatoryId);

        bool ReferenceIdExist(int documentReferenceId);

        bool ReferenceIdExist(int documentReferenceId, int signatories_id);

        bool IsReferencedBySignatory(int documentReferenceId, int signatories_id);
    }
}
