using ACC.Domain.Models;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IDocumentReferences : IRepository<DocumentReferencesModel>
    {
        DataTable GetViewRecords();
    }
}
