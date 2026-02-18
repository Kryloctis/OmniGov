using OmniGov.Core.Entities;
using System.Data;

namespace OmniGov.Core.Interfaces.Repositories
{
    public interface IDocumentReferences : IRepository<DocumentReferencesModel>
    {
        DataTable GetViewRecords();

        DataTable GetViewRecordsByOffice(string office);
    }
}
