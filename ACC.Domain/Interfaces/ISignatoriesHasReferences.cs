using ACC.Domain.Models;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface ISignatoriesHasReferences : IRepository<SignatoriesHasReferencesModel>
    {
        DataTable GetRecordsBySignatoryId(int signatoryId);

        DataTable GetDocumentRecordsBySignatoryId(int signatoryId);

        bool DeleteBySignatoryId(int signatoryId);

        bool ReferenceIdExist(int documentReferenceId);

        bool ReferenceIdExist(int documentReferenceId, int signatories_id);

        bool IsReferencedBySignatory(int documentReferenceId, int signatories_id);
    }
}
