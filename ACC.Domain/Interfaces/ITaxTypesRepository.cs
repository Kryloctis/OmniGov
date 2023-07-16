using ACC.Domain.Models;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface ITaxTypesRepository : IAccRepository<TaxTypesModel>
    {
        DataTable GetParentNodesTaxTypes();
        DataTable GetChildNodesTaxTypes(int parentID);
        DataTable GetTaxTypeCodes();
        string GetParentCodeByID(int parentID);
        bool DeleteTaxType(int taxTypeID);
        bool UnDeleteTaxType(int taxTypeID);
        int GetChildNodesIDs(int taxTypeID);
    }
}
