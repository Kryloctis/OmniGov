using ACC.Domain.Models;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface ISignatoriesHasReferences : IRepository<SignatoriesHasReferencesModel>
    {
        DataTable GetRecordsBySignatoryId(int signatoryId);

        bool DeleteBySignatoryId(int signatoryId);

        bool ReferenceIdExist(int referenceId);
        bool IsReferencedBySignatory(int documentReferenceId, int signatories_id);
    }
}
