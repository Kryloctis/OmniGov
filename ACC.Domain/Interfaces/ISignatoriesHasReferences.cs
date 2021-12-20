using ACC.Domain.Models;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface ISignatoriesHasReferences : IRepository<SignatoriesHasReferencesModel>
    {
        DataTable GetRecordsBySignatoryId(int signatoyId);
    }
}
