using ACC.Domain.Models;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IDocumentReferences : IAccRepository<DocumentReferencesModel>
    {
        DataTable GetViewRecords();

        DataTable GetViewRecordsByOffice(string office);
    }
}
